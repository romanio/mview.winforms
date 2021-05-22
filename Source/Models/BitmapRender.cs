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
        Rectangle dirty_region;
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
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0,
                PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
        }

        public void Clear(Color color)
        {
            gfx.Clear(color);
            dirty_region = new Rectangle(0, 0, bmp.Width, bmp.Height);
            UploadBitmap();
        }

        Font InfoFont = new Font("Segoe Pro Cond", 09, FontStyle.Regular);

        // Text label format

        int min_bubble_size = 4;
        int pen_bubble_width = 1;
        float label_pos_x = -8;
        float label_pos_y = -32;
        float value_label_pos_x = -16;
        float value_label_pos_y = +16;



        public void DrawWell(ECL.WELLDATA well, Font font, Brush brush, CoordConverter cordconv, MapStyle style, bool MoveMode)
        {
            PointF point = cordconv.ConvertWorldToScreen(well.XC, well.YC);

            // 100 m3 = 10 pt

            float size = 0; // Размер круга
            float wcut = 1; // Обводненность
            double wlpr = 0;

            Rectangle bubble_rec = new Rectangle(0, 0, 0, 0);
            RectangleF value_label_rec = new RectangleF(0, 0, 0, 0);
            Rectangle point_rec = new Rectangle(0, 0, 0, 0);

            if (style.bubbleMode == BubbleMode.Simulation)
            {
                size = (int)(Math.Abs(well.WLPR) * style.scaleFactor * 0.01);
                if (size < min_bubble_size) size = min_bubble_size;

                wcut = well.WLPR == 0 ? 0 : (float)(well.WWPR / well.WLPR);
                wlpr = well.WLPR;
            }

            if (style.bubbleMode == BubbleMode.Historical)
            {
                if (well.WLPR < 0)
                {
                    size = (int)(Math.Abs(well.WWPRH) * style.scaleFactor * 0.01);
                    wlpr = Math.Abs(well.WWPRH);
                    wcut = 1;
                }
                else
                {
                    size = (int)(Math.Abs(well.WLPRH) * style.scaleFactor * 0.01);
                    wcut = well.WLPRH == 0 ? 0 : (float)(well.WWPRH / well.WLPRH);
                    wlpr = well.WLPRH;
                }

                if (size < min_bubble_size) size = min_bubble_size;
            }

            // Добывающие скважины

            if (well.WLPR >= 0)
            {
                if (style.showBubbles && !MoveMode)
                {
                    Point bubble_centr = new Point((int)(point.X - size / 2), (int)(point.Y - size / 2));
                    bubble_rec = new Rectangle(bubble_centr, new Size((int)size, (int)size));

                    gfx.DrawEllipse(new Pen(Color.Black, pen_bubble_width), bubble_rec);
                    gfx.FillPie(Brushes.BurlyWood, bubble_rec, 0, (float)Math.Round(360.0 * (1 - wcut)));
                    gfx.FillPie(Brushes.SteelBlue, bubble_rec, (float)Math.Round(360.0 * (1 - wcut)), 360 - (float)Math.Round(360.0 * (1 - wcut)));
                }


                Point value_label_point = new Point((int)(point.X + value_label_pos_x), (int)(point.Y + value_label_pos_y));
                string value_label_text = wlpr.ToString("N1") + " / " + (100 * wcut).ToString("N1");
                SizeF label_size_text = gfx.MeasureString(value_label_text, InfoFont);
                value_label_rec = new RectangleF(value_label_point, label_size_text);
                gfx.DrawString(value_label_text, InfoFont, brush, value_label_point);
            }

            // Нагнетательные скважины

            if (well.WLPR < 0) // Меньше нуля, это у нас закачка
            {
                if (style.showBubbles && !MoveMode)
                {
                    Point bubble_centr = new Point((int)(point.X - size / 2), (int)(point.Y - size / 2));
                    bubble_rec = new Rectangle(bubble_centr, new Size((int)size, (int)size));
                    gfx.DrawEllipse(new Pen(Color.Black, pen_bubble_width), bubble_rec);
                    gfx.FillPie(Brushes.LightBlue, bubble_rec, 0, 360);
                }

                wlpr = Math.Abs(wlpr);

                Point value_label_point = new Point((int)(point.X + value_label_pos_x), (int)(point.Y + value_label_pos_y));
                string value_label_text = wlpr.ToString("N1") + " / " + (100 * wcut).ToString("N1");
                SizeF label_size_text = gfx.MeasureString(value_label_text, InfoFont);
                value_label_rec = new RectangleF(value_label_point, label_size_text);
                gfx.DrawString(value_label_text, InfoFont, brush, value_label_point);
            }

            if (!MoveMode)
            {
                Point well_point = new Point((int)(point.X) - 4, (int)(point.Y) - 4);
                point_rec = new Rectangle(well_point, new Size(8, 8));
                gfx.FillEllipse(Brushes.White, point_rec);
                gfx.DrawEllipse(Pens.Black, point_rec);
            }

            SizeF size_wellname_text = gfx.MeasureString(well.WELLNAME, font);
            PointF well_name_point = new PointF(point.X + label_pos_x, point.Y + label_pos_y);
            gfx.DrawString(well.WELLNAME, font, brush, well_name_point);


            // Подготовка активного прямоугольника для обновления текстуры

            RectangleF rec = new RectangleF(well_name_point, size_wellname_text);

            if (value_label_rec.Width > 0 && value_label_rec.Height > 0)
            {
                rec = RectangleF.Union(rec, value_label_rec);
            }

            if (style.showBubbles && !MoveMode)
            {
                if (bubble_rec.Width > 0 && bubble_rec.Height > 0)
                {
                    rec = RectangleF.Union(rec, bubble_rec);
                }
            }

            if (!MoveMode)
            {
                if (point_rec.Width > 0 && point_rec.Height > 0)
                {
                    rec = RectangleF.Union(rec, point_rec);
                }
            }

            if (rec.X > 2)
            {
                rec.X += -2;
                rec.Width += 4;
            }

            if (rec.Y > 2)
            {
                rec.Y += -2;
                rec.Height += 4;
            }

            rec = RectangleF.Intersect(rec, new Rectangle(0, 0, bmp.Width, bmp.Height));

            dirty_region = Rectangle.Round(rec);

            //dirty_region = new Rectangle(0, 0, bmp.Width, bmp.Height);

            //dirty_region = Rectangle.Round(RectangleF.Union(dirty_region, new RectangleF(point, size_text)));
            //dirty_region = Rectangle.Intersect(dirty_region, new Rectangle(0, 0, bmp.Width, bmp.Height));


            //gfx.DrawRectangle(Pens.Black, Rectangle.Round(rec));

            if (dirty_region.Height > 0 && dirty_region.Width > 0)
            {
                UploadBitmap();
            }
        }

        public int Texture
        {
            get
            {
                //UploadBitmap();
                return texture;
            }
        }

        unsafe void UploadBitmap()
        {
            if (dirty_region != RectangleF.Empty)
            {
                System.Drawing.Imaging.BitmapData data = bmp.LockBits(dirty_region, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.BindTexture(TextureTarget.Texture2D, texture);

                GL.TexSubImage2D(TextureTarget.Texture2D, 0, dirty_region.X, dirty_region.Y, dirty_region.Width, dirty_region.Height, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                bmp.UnlockBits(data);
                dirty_region = Rectangle.Empty;
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
