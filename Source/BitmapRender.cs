using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Drawing;
using mview.ECL;

namespace mview
{
    // Отрисовка текста и прочей графики в текстуру.
    // Используется для вывода текста в режиме OpenGL
    // Код взят с сайта opentk.com на одном из форумов

    class BitmapRender : IDisposable
    {
        Bitmap bmp;
        Graphics gfx;
        int texture;
        Rectangle dirtyRegion;
        bool disposed;

        public BitmapRender(int width, int height)
        {
            if (width == 0) return;
            if (height == 0) return;

            if (GraphicsContext.CurrentContext == null)
                throw new InvalidOperationException("No GraphicsContext is current on the calling thread.");

            bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            gfx = Graphics.FromImage(bmp);

            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            texture = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexImage2D(
                TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0,
                PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
        }

        public void Clear(Color color)
        {
            gfx.Clear(color);
            dirtyRegion = new Rectangle(0, 0, bmp.Width, bmp.Height);
            UploadBitmap();
        }

        // Settings

        readonly Font infoFont = new Font("Segoe Pro Cond", 09, FontStyle.Regular);
        readonly Font wellsFont = new Font("Segoe Pro Cond", 11, FontStyle.Bold);
      
        // Text label format

        readonly int minBubbleSize = 6;
        readonly int maxBubbleSize = 120;
        readonly int penBubbleWidth = 1;
        readonly int wellPointSize = 8;
        readonly float scaleRate = 0.01f;
        readonly float scaleTotal = 0.01f * 0.001f;

        readonly PointF labelPos = new PointF(-8, -32);
        readonly PointF valueLabelPos = new PointF(-16, +16);
        readonly List<Rectangle> drawList = new List<Rectangle>();

        public void DrawWell(Point point, WELLDATA well, MapStyle style)
        {
            // 100 m3 = 10 pt

            float size = 0; // Размер круга
            float wcut = 1; // Обводненность
            double wlpr = 0;


            if (style.bubbleMode == BubbleMode.Simulation)
            {
                size = (int)(Math.Abs(well.WLPR) * style.scaleFactor * scaleRate);

                wcut = well.WLPR == 0 ? 0 : (float)(well.WWPR / well.WLPR);
                wlpr = well.WLPR;
            }

            if (style.bubbleMode == BubbleMode.Historical)
            {
                if (well.WLPR < 0)
                {
                    size = (int)(Math.Abs(well.WWPRH) * style.scaleFactor * scaleRate);
                    wlpr = -well.WWPRH;
                    wcut = 1;
                }
                else
                {
                    size = (int)(Math.Abs(well.WLPRH) * style.scaleFactor * scaleRate);
                    wcut = well.WLPRH == 0 ? 0 : (float)(well.WWPRH / well.WLPRH);
                    wlpr = well.WLPRH;
                }
            }

            if (style.bubbleMode == BubbleMode.DiffOPR)
            {
                if (well.WLPR > 0)
                {
                    wlpr = well.WOPR - well.WOPRH;
                    size = (int)(Math.Abs(wlpr) * style.scaleFactor * scaleRate);
                    
                    if (wlpr > 0)
                    {
                        wcut = 0;
                    }

                    if (wlpr < 0)
                    {
                        wcut = 1;
                        wlpr = -wlpr;
                    }
                }
            }

            if (style.bubbleMode == BubbleMode.DiffLPR)
            {
                if (well.WLPR > 0)
                {
                    wlpr = well.WLPR - well.WLPRH;
                    size = (int)(Math.Abs(wlpr) * style.scaleFactor * scaleRate);
                    
                    if (wlpr > 0)
                    {
                        wcut = 0;
                    }

                    if (wlpr < 0)
                    {
                        wcut = 1;
                        wlpr = -wlpr;
                    }
                }
            }

            if (style.bubbleMode == BubbleMode.DiffWCUT)
            {
                if (well.WLPR > 0)
                {
                    wlpr = (float)(well.WWPR / well.WLPR) - (float)(well.WWPRH / well.WLPRH);
                    size = (int)(Math.Abs(wlpr) * 100 * style.scaleFactor * scaleRate);

                    if (wlpr > 0)
                    {
                        wcut = 0;
                    }

                    if (wlpr < 0)
                    {
                        wcut = 1;
                        wlpr = -wlpr;
                    }
                }
            }

            if (style.bubbleMode == BubbleMode.DiffBHP)
            {
                if (well.WBHPH > 0)
                {
                    wlpr = well.WBHP - well.WBHPH;
                    size = (int)(Math.Abs(wlpr) * style.scaleFactor * scaleRate);

                    if (wlpr > 0)
                    {
                        wcut = 0;
                    }

                    if (wlpr < 0)
                    {
                        wcut = 1;
                        wlpr = -wlpr;
                    }
                }
            }
            if (size < minBubbleSize) size = minBubbleSize;
            if (size > maxBubbleSize) size = maxBubbleSize;


            // Добывающие скважины

            if (wlpr > 0)
            {

                drawList.Add(DrawComplicatedBubble(point, size, wcut));
                string text = wlpr.ToString("N1") + " / " + (100 * wcut).ToString("N1") + " %";
                drawList.Add(DrawLabel(point, text));
            }

            // Нагнетательные скважины

            if (wlpr < 0) // Меньше нуля, это у нас закачка
            {
                drawList.Add(DrawSingleBubble(point, size));
                wlpr = Math.Abs(wlpr);
                string text = wlpr.ToString("N1");
                drawList.Add(DrawLabel(point, text));
            }

            drawList.Add(DrawWellPoint(point));
            drawList.Add(DrawWellName(point, well.WELLNAME));
        }

        public void BeginDraw()
        {
            drawList.Clear();
        }

        public void EndDraw()
        {
            Rectangle final = new Rectangle(0, 0, 0, 0);

            foreach (Rectangle item in drawList)
            {
                final = Rectangle.Union(final, item);
            }

            if (final.X > 2)
            {
                final.X += -8;
                final.Width += 12;
            }

            if (final.Y > 2)
            {
                final.Y += -8;
                final.Height += 12;
            }

            final = Rectangle.Intersect(final, new Rectangle(0, 0, bmp.Width, bmp.Height));

            dirtyRegion = Rectangle.Round(final);

            if (dirtyRegion.Height > 0 && dirtyRegion.Width > 0)
            {
                UploadBitmap();
            }
        }


        Rectangle DrawWellPoint(Point point)
        {
            Point startPoint = new Point((int)(point.X) - wellPointSize / 2, (int)(point.Y) - wellPointSize / 2);
            Rectangle rectangle = new Rectangle(startPoint, new Size(wellPointSize, wellPointSize));
            gfx.FillEllipse(Brushes.White, rectangle);
            gfx.DrawEllipse(Pens.Black, rectangle);

            return rectangle;
        }
        
        Rectangle DrawWellName(Point point, string text)
        {
            SizeF size = gfx.MeasureString(text, wellsFont);
            Point p = new Point((int)(point.X + labelPos.X), (int)(point.Y + labelPos.Y));
            gfx.DrawString(text, wellsFont, Brushes.Black, p);
            return new Rectangle(p, size.ToSize());
        }

        Rectangle DrawSingleBubble(Point point, float size)
        {
            Point p = new Point((int)(point.X - size / 2), (int)(point.Y - size / 2));
            Rectangle rectangle = new Rectangle(p, new Size((int)size, (int)size));

            gfx.DrawEllipse(new Pen(Color.Black, penBubbleWidth), rectangle);
            gfx.FillPie(Brushes.LightBlue, rectangle, 0, 360);

            return rectangle;
        }

        Rectangle DrawComplicatedBubble(Point point, float size, float fraction)
        {
            Point p = new Point((int)(point.X - size / 2), (int)(point.Y - size / 2));
            Rectangle rectangle = new Rectangle(p, new Size((int)size, (int)size));

            gfx.DrawEllipse(new Pen(Color.Black, penBubbleWidth), rectangle);
            gfx.FillPie(Brushes.BurlyWood, rectangle, 0, (float)Math.Round(360.0 * (1 - fraction)));
            gfx.FillPie(Brushes.SteelBlue, rectangle, (float)Math.Round(360.0 * (1 - fraction)), 360 - (float)Math.Round(360.0 * (1 - fraction)));

            return rectangle;
        }

        Rectangle DrawLabel(Point point, string text)
        {
            Point p = new Point((int)(point.X + valueLabelPos.X), (int)(point.Y + valueLabelPos.Y));
            SizeF size = gfx.MeasureString(text, infoFont);
            Rectangle rectangle = new Rectangle(p, size.ToSize());
            gfx.DrawString(text, infoFont, Brushes.Black, p);
            
            return rectangle;
        }

        public int Texture
        {
            get
            {
                return texture;
            }
        }

        unsafe void UploadBitmap()
        {
            if (dirtyRegion != RectangleF.Empty)
            {
                System.Drawing.Imaging.BitmapData data = bmp.LockBits(dirtyRegion, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.BindTexture(TextureTarget.Texture2D, texture);

                GL.TexSubImage2D(TextureTarget.Texture2D, 0, dirtyRegion.X, dirtyRegion.Y, dirtyRegion.Width, dirtyRegion.Height, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                bmp.UnlockBits(data);
                dirtyRegion = Rectangle.Empty;
            }
        }

        void Dispose(bool manual)
        {
            if (!disposed)
            {
                if (manual)
                {
                    if (bmp != null)
                        bmp.Dispose();

                    if (gfx != null)
                        gfx.Dispose();

                    if (GraphicsContext.CurrentContext != null)
                        GL.DeleteTexture(texture);
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BitmapRender()
        {
            Console.WriteLine("[Warning] Resource leaked: {0}.", typeof(TextRenderer));
        }
    }


}
