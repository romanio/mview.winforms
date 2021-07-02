using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Windows.Forms;

namespace mview
{
    public class ViewPosition
    {
        public float scale = 0.01f;
        public Vector2 shift = new Vector2();
        public int XS, YS, ZS;
    }

    public enum ViewMode
    {
        X, Y, Z
    }

    public class Engine2D
    {
        public Camera2D camera = new Camera2D();
        public Grid2D grid;

        public ViewPosition viewPositionX = new ViewPosition();
        public ViewPosition viewPositionY = new ViewPosition();
        public ViewPosition viewPositionZ = new ViewPosition();

        public ViewMode currentViewMode = ViewMode.X;

        double XMIN, XMAX, YMIN, YMAX;
        public int width, height; // Параметры окна вывода
        private int XS, YS, ZS; // Координаты выбранной ячейки
        private float VS; // Значение выбранной ячейки

        MapStyle style = new MapStyle();
        BitmapRender render;

        public void SetPosition(ViewMode Position)
        {
            SavePosition();

            if (Position == ViewMode.X)
            {
                currentViewMode = ViewMode.X;
                grid.CurrentViewMode = ViewMode.X;

                RestorePosition();
            }

            if (Position == ViewMode.Y)
            {
                currentViewMode = ViewMode.Y;
                grid.CurrentViewMode = ViewMode.Y;

                RestorePosition();
            }

            if (Position == ViewMode.Z)
            {
                currentViewMode = ViewMode.Z;
                grid.CurrentViewMode = ViewMode.Z;

                RestorePosition();
            }

            grid.RefreshGrid();
        }

        public void SavePosition()
        {
            if (currentViewMode == ViewMode.X)
            {
                viewPositionX.scale = camera.Scale;
                viewPositionX.shift = camera.Shift;

                viewPositionX.XS = XS;
                viewPositionX.YS = YS;
                viewPositionX.ZS = ZS;
            }

            if (currentViewMode == ViewMode.Y)
            {
                viewPositionY.scale = camera.Scale;
                viewPositionY.shift = camera.Shift;

                viewPositionY.XS = XS;
                viewPositionY.YS = YS;
                viewPositionY.ZS = ZS;
            }

            if (currentViewMode == ViewMode.Z)
            {
                viewPositionZ.scale = camera.Scale;
                viewPositionZ.shift = camera.Shift;
 
                viewPositionZ.XS = XS;
                viewPositionZ.YS = YS;
                viewPositionZ.ZS = ZS;
            }
        }

        public void RestorePosition()
        {
            if (currentViewMode == ViewMode.X)
            {
                camera.Scale = viewPositionX.scale;
                camera.Shift = viewPositionX.shift;

                XS = viewPositionX.XS;
                YS = viewPositionX.YS;
                ZS = viewPositionX.ZS;

                XMIN = grid.YMINCOORD;
                XMAX = grid.YMAXCOORD;
                YMIN = grid.ZMINCOORD;
                YMAX = grid.ZMAXCOORD;
            }

            if (currentViewMode == ViewMode.Y)
            {
                camera.Scale = viewPositionY.scale;
                camera.Shift = viewPositionY.shift;

                XS = viewPositionY.XS;
                YS = viewPositionY.YS;
                ZS = viewPositionY.ZS;

                XMIN = grid.XMINCOORD;
                XMAX = grid.XMAXCOORD;
                YMIN = grid.ZMINCOORD;
                YMAX = grid.ZMAXCOORD;
            }

            if (currentViewMode == ViewMode.Z)
            {
                camera.Scale = viewPositionZ.scale;
                camera.Shift = viewPositionZ.shift;

                XS = viewPositionZ.XS;
                YS = viewPositionZ.YS;
                ZS = viewPositionZ.ZS;

                XMIN = grid.XMINCOORD;
                XMAX = grid.XMAXCOORD;
                YMIN = grid.YMINCOORD;
                YMAX = grid.YMAXCOORD;
            }
        }
        
        public void SetMapStyle(MapStyle style)
        {
            this.style = style;

            grid.colorizer.SetMinimum(style.minValue);
            grid.colorizer.SetMaximum(style.maxValue);
            grid.StretchFactor = style.stretchFactor;

            grid.RefreshGrid();

            camera.ZScale = style.zscale;
        }

        public void OnLoad()
        {
            GL.GetError();

            System.Diagnostics.Debug.WriteLine("OpenGL Version " + GL.GetString(StringName.Version));

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PolygonOffsetFill);
            GL.ClearColor(Color.White);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);
        }

        public void SetScaleFactors()
        {
            float MC, SC;
            SC = Math.Min(width, height);

            // Z Scale Default

            MC = Math.Max(grid.DX, grid.DY) * 1.1f;
            viewPositionZ.scale = SC / MC;

            // X Scale Default

            MC = Math.Max(grid.DY, grid.DZ * camera.ZScale) * 1.1f;

            viewPositionX.scale = SC / MC;

            // Y Scale Default

            MC = Math.Max(grid.DX, grid.DZ * camera.ZScale) * 1.1f;
            
            viewPositionY.scale = SC / MC;

            RestorePosition();
        }

        public void OnUnload()
        {
            
        }

        public void OnResize(int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("Engine.OnResize");

            this.width = width;
            this.height = height;

            // При изменении размера окна, необходимо определить новые координаты OpenGL
            // и задать новые размеры текстуры, для вывода текста

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Центр координат устанавливается в центре окна.

            GL.Ortho(-0.5 * width, +0.5 * width, +0.5 * height, -0.5 * height, -1, +1);
            GL.Viewport(0, 0, width, height);
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //
            if (render != null)
                render.Dispose(); // Удаляем старый рендер текста

            render = new BitmapRender(width, height); // И объявляем новый
        }

        public void LinkGrid(Grid2D grid)
        {
            this.grid = grid;
        }

        public void DrawWells()
        {
            GL.CallList(grid.wellsID);

            render.Clear(Color.Transparent);
            render.BeginDraw();

            foreach (ECL.WELLDATA well in grid.activeWells)
            {
                if (well.COMPLS.Count > 0)
                {
                    float XC = well.XC;
                    float YC = well.YC;
                    float X = 0;
                    float Y = 0;

                    // Calculate point

                    if (currentViewMode == ViewMode.X)
                    {
                        YC = grid.ZMINCOORD - 30;

                        X = (XC - grid.YMINCOORD - 0.5f * grid.DY + camera.Shift.X) * camera.Scale + 0.5f * width;
                        Y = (YC - grid.ZMINCOORD - 0.5f * grid.DZ + camera.Shift.Y / camera.ZScale) * (camera.Scale * camera.ZScale) + 0.5f * height;
                    };

                    if (currentViewMode == ViewMode.Y)
                    {
                        YC = grid.ZMINCOORD - 30;

                        X = (XC - grid.XMINCOORD - 0.5f * grid.DX + camera.Shift.X) * camera.Scale + 0.5f * width;
                        Y = (YC - grid.ZMINCOORD - 0.5f * grid.DZ + camera.Shift.Y / camera.ZScale) * (camera.Scale * camera.ZScale) + 0.5f * height;
                    };

                    if (currentViewMode == ViewMode.Z)
                    {
                        X = (XC - grid.XMINCOORD - 0.5f * grid.DX + camera.Shift.X) * camera.Scale + 0.5f * width;
                        Y = (YC - grid.YMINCOORD - 0.5f * grid.DY + camera.Shift.Y) * camera.Scale + 0.5f * height;
                    };

                    render.DrawWell(new Point((int)X, (int)Y), well, style);
                }
            }

            render.EndDraw();
        }

        public void DrawVectorField()
        {
            //GL.CallList(grid.vectorID);
        }

        public void OnPaint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (grid == null) return;

            // Масштабирование и перенос области отображения

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Scale(camera.Scale, camera.Scale, 1);

            if (currentViewMode != ViewMode.Z)
            {
                GL.Scale(1, camera.ZScale, 1);
            }

            if (currentViewMode == ViewMode.Z)
            {
                GL.Translate(-grid.XC, -grid.YC, 0);
                GL.Translate(camera.Shift.X, camera.Shift.Y, 0);
            }

            if (currentViewMode == ViewMode.X)
            {
                GL.Translate(-grid.YC, -grid.ZC, 0);
                GL.Translate(camera.Shift.X, camera.Shift.Y / (camera.ZScale), 0);
            }

            if (currentViewMode == ViewMode.Y)
            {
                GL.Translate(-grid.XC, -grid.ZC, 0);
                GL.Translate(camera.Shift.X, camera.Shift.Y / (camera.ZScale), 0);
            }

            if (grid.element_count > 0)
            {
                render.Clear(Color.Transparent);

                DrawWells();

                DrawVectorField();

                // Отрисовка ячеек

                if (style.showNoFillColor == false)
                {
                    GL.PolygonOffset(+1, +1);
                    GL.EnableClientState(ArrayCap.ColorArray);
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                    GL.DrawElements(PrimitiveType.Quads, grid.element_count, DrawElementsType.UnsignedInt, 0);
                }

                // Отрисовка границ ячеек

                if (style.showGridLines == true)
                {
                    GL.PolygonOffset(0, 0);
                    GL.DisableClientState(ArrayCap.ColorArray);
                    GL.Color3(Color.Black);
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                    GL.DrawElements(PrimitiveType.Quads, grid.element_count, DrawElementsType.UnsignedInt, 0);
                }
            }

            DrawSelectedCell();

            DrawFrame();

            if (grid.element_count > 0)
            {
                // Вывод текста текстурой

                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, render.Texture);

                GL.LoadIdentity();

                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha);

                GL.Begin(PrimitiveType.Quads);
                GL.Color4(Color.White);

                GL.TexCoord2(0, 1); GL.Vertex3(-0.5 * width, +0.5 * height, +0.3);
                GL.TexCoord2(1, 1); GL.Vertex3(+0.5 * width, +0.5 * height, +0.3);
                GL.TexCoord2(1, 0); GL.Vertex3(+0.5 * width, -0.5 * height, +0.3);
                GL.TexCoord2(0, 0); GL.Vertex3(-0.5 * width, -0.5 * height, +0.3);

                GL.End();

                GL.Disable(EnableCap.Blend);
                GL.Disable(EnableCap.Texture2D);
            }
        }

        public void DrawFrame() // Рамка вокруг модели
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Black);
            GL.Vertex3(XMIN, YMIN, 0);
            GL.Vertex3(XMIN, YMAX, 0);
            GL.Vertex3(XMIN, YMAX, 0);
            GL.Vertex3(XMAX, YMAX, 0);
            GL.Vertex3(XMAX, YMAX, 0);
            GL.Vertex3(XMAX, YMIN, 0);
            GL.Vertex3(XMAX, YMIN, 0);
            GL.Vertex3(XMIN, YMIN, 0);
            GL.End();
        }

        public void DrawSelectedCell()
        {
            // Отрисовка выбранной ячейки

            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(Color.Black);

            if (currentViewMode == ViewMode.X && (YS > -1))
            {
                foreach (Vector2 vec in grid.GetSelectedCell(ZS, YS))
                {
                    GL.Vertex3(vec.X, vec.Y, 0.3);
                }
            }

            if (currentViewMode == ViewMode.Y && (XS > -1))
            {
                foreach (Vector2 vec in grid.GetSelectedCell(ZS, XS))
                {
                    GL.Vertex3(vec.X, vec.Y, 0.3);
                }
            }

            if (currentViewMode == ViewMode.Z && (XS > -1))
            {
                foreach (Vector2 vec in grid.GetSelectedCell(XS, YS))
                {
                    GL.Vertex3(vec.X, vec.Y, 0.3);
                }
            }

            GL.End();
            GL.LineWidth(1);
        }

        public void SetStyle(MapStyle style)
        {
            this.style = style;

            OnPaint();
        }

        public void MouseWheel(MouseEventArgs e)
        {
            camera.MouseWheel(e);
        }

        public void MouseMove(MouseEventArgs e)
        {
            camera.MouseMove(e);
        }

        byte[] GetPixelRGBColor(int X, int Y)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetPName.Viewport, viewport);
            IntPtr p = new IntPtr();
            GL.ReadPixels(X, viewport[3] - Y, 1, 1, PixelFormat.Rgb, PixelType.UnsignedByte, ref p);
            return BitConverter.GetBytes(p.ToInt32());
        }

        public void MouseClick(MouseEventArgs e)
        {
            if (grid == null) return;

            if (e.Button == MouseButtons.Left)
            {
                byte[] pixel = GetPixelRGBColor(e.X, e.Y);

                float XT;
                float YT;

                
                //
                //;

                XT = (e.X - 0.5f * width) / camera.Scale;
                YT = (e.Y - 0.5f * height) / camera.Scale;

                if (currentViewMode == ViewMode.X)
                {
                    XT = XT + grid.YMINCOORD + 0.5f * grid.DY - camera.Shift.X;
                    YT = YT / camera.ZScale + grid.ZMINCOORD + 0.5f * grid.DZ - camera.Shift.Y / (camera.ZScale);

                    grid.GetCellUnderMouse(new Vector2(XT, YT), pixel);

                    XS = grid.XA;
                    ZS = grid.ZS;
                    YS = grid.YS;
                    VS = grid.VS;
                }

                if (currentViewMode == ViewMode.Y)
                {
                    XT = XT + grid.XMINCOORD + 0.5f * grid.DX - camera.Shift.X;
                    YT = YT / camera.ZScale + grid.ZMINCOORD + 0.5f * grid.DZ - camera.Shift.Y / (camera.ZScale);

                    grid.GetCellUnderMouse(new Vector2(XT, YT), pixel);

                    ZS = grid.ZS;
                    YS = grid.YA;
                    XS = grid.XS;
                    VS = grid.VS;
                }

                if (currentViewMode == ViewMode.Z)
                {
                    XT = XT + grid.XMINCOORD + 0.5f * grid.DX - camera.Shift.X;
                    YT = YT + grid.YMINCOORD + 0.5f * grid.DY - camera.Shift.Y;

                    grid.GetCellUnderMouse(new Vector2(XT, YT), pixel);

                    ZS = grid.ZA;
                    YS = grid.YS;
                    XS = grid.XS;
                    VS = grid.VS;
                }
            }
        }
    
        public Vector4 GetSelectedCellValue()
        {
            return new Vector4(XS, YS, ZS, VS);
        }
    }
}