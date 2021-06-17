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
        public float shiftX = 0.0f;
        public float shiftY = 0.0f;
        public int XS, YS, ZS;
    }

    public enum ViewMode
    {
        X, Y, Z
    }

    public class CoordConverter
    {
        private readonly Engine2D engine = null;

        public ViewMode currentViewMode = ViewMode.X;

        public CoordConverter(Engine2D engine)
        {
            this.engine = engine;
        }

     
        public PointF ConvertWorldToScreen(float XC, float YC)
        {
            float X = 0;
            float Y = 0;

            /*
            if (currentViewMode == ViewMode.X)
            {
                X = (XC - engine.grid.YMINCOORD - 0.5f * (engine.grid.YMAXCOORD - engine.grid.YMINCOORD) + engine.camera.shift_x + engine.camera.shift_end_x - engine.camera.shift_start_x) * engine.camera.scale + 0.5f * engine.width;
                Y = (-30 / (engine.camera.scale_z * engine.camera.scale) - 0.5f * (engine.grid.ZMAXCOORD - engine.grid.ZMINCOORD) - engine.camera.shift_y + engine.camera.shift_end_y - engine.camera.shift_start_y) * engine.camera.scale * engine.camera.scale_z + 0.5f * engine.height;
            };

            if (currentViewMode == ViewMode.Y)
            {
                X = (XC - engine.grid.XMINCOORD - 0.5f * (engine.grid.XMAXCOORD - engine.grid.XMINCOORD) + engine.camera.shift_x + engine.camera.shift_end_x - engine.camera.shift_start_x) * engine.camera.scale + 0.5f * engine.width;
                Y = (-30 / (engine.camera.scale_z * engine.camera.scale) - 0.5f * (engine.grid.ZMAXCOORD - engine.grid.ZMINCOORD) - engine.camera.shift_y + engine.camera.shift_end_y - engine.camera.shift_start_y) * engine.camera.scale * engine.camera.scale_z + 0.5f * engine.height;
            };

            if (currentViewMode == ViewMode.Z)
            {
                X = (XC - engine.grid.XMINCOORD - 0.5f * (engine.grid.XMAXCOORD - engine.grid.XMINCOORD) + engine.camera.shift_x + engine.camera.shift_end_x - engine.camera.shift_start_x) * engine.camera.scale + 0.5f * engine.width;
                Y = (YC - engine.grid.YMINCOORD - 0.5f * (engine.grid.YMAXCOORD - engine.grid.YMINCOORD) - engine.camera.shift_y + engine.camera.shift_end_y - engine.camera.shift_start_y) * engine.camera.scale + 0.5f * engine.height;
            };

            */

            return new PointF(X, Y);
        }
    }

    public class Engine2D
    {
        private readonly Camera2D camera = new Camera2D();
        private Grid2D grid;

        public ViewPosition ViewPositionX = new ViewPosition();
        public ViewPosition ViewPositionY = new ViewPosition();
        public ViewPosition ViewPositionZ = new ViewPosition();

        double XMIN, XMAX, YMIN, YMAX;

        public ViewMode CurrentViewMode = ViewMode.X;

        MapStyle style = new MapStyle();

        BitmapRender render;

        public void SetPosition(ViewMode Position)
        {
            SavePosition();

            if (Position == ViewMode.X)
            {
                CurrentViewMode = ViewMode.X;
                camera.CurrentViewMode = ViewMode.X;
                grid.CurrentViewMode = ViewMode.X;

                RestorePosition();
            }

            if (Position == ViewMode.Y)
            {
                CurrentViewMode = ViewMode.Y;
                camera.CurrentViewMode = ViewMode.Y;
                grid.CurrentViewMode = ViewMode.Y;

                RestorePosition();
            }

            if (Position == ViewMode.Z)
            {
                CurrentViewMode = ViewMode.Z;
                camera.CurrentViewMode = ViewMode.Z;
                grid.CurrentViewMode = ViewMode.Z;

                RestorePosition();
            }

            grid.RefreshGrid();
        }

        public void SavePosition()
        {
            if (CurrentViewMode == ViewMode.X)
            {
                ViewPositionX.scale = camera.scale;
                ViewPositionX.shiftX = camera.shift_x;
                ViewPositionX.shiftY = camera.shift_y;

                ViewPositionX.XS = XS;
                ViewPositionX.YS = YS;
                ViewPositionX.ZS = ZS;
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                ViewPositionY.scale = camera.scale;
                ViewPositionY.shiftX = camera.shift_x;
                ViewPositionY.shiftY = camera.shift_y;

                ViewPositionY.XS = XS;
                ViewPositionY.YS = YS;
                ViewPositionY.ZS = ZS;
            }

            if (CurrentViewMode == ViewMode.Z)
            {
                ViewPositionZ.scale = camera.scale;
                ViewPositionZ.shiftX = camera.shift_x;
                ViewPositionZ.shiftY = camera.shift_y;

                ViewPositionZ.XS = XS;
                ViewPositionZ.YS = YS;
                ViewPositionZ.ZS = ZS;
            }
        }

        public void RestorePosition()
        {
            if (CurrentViewMode == ViewMode.X)
            {
                camera.scale = ViewPositionX.scale;
                camera.shift_x = ViewPositionX.shiftX;
                camera.shift_y = ViewPositionX.shiftY;

                XS = ViewPositionX.XS;
                YS = ViewPositionX.YS;
                ZS = ViewPositionX.ZS;

                XMIN = grid.YMINCOORD;
                XMAX = grid.YMAXCOORD;
                YMIN = grid.ZMINCOORD;
                YMAX = grid.ZMAXCOORD;
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                camera.scale = ViewPositionY.scale;
                camera.shift_x = ViewPositionY.shiftX;
                camera.shift_y = ViewPositionY.shiftY;

                XS = ViewPositionY.XS;
                YS = ViewPositionY.YS;
                ZS = ViewPositionY.ZS;

                XMIN = grid.XMINCOORD;
                XMAX = grid.XMAXCOORD;
                YMIN = grid.ZMINCOORD;
                YMAX = grid.ZMAXCOORD;
            }

            if (CurrentViewMode == ViewMode.Z)
            {
                camera.scale = ViewPositionZ.scale;
                camera.shift_x = ViewPositionZ.shiftX;
                camera.shift_y = ViewPositionZ.shiftY;

                XS = ViewPositionZ.XS;
                YS = ViewPositionZ.YS;
                ZS = ViewPositionZ.ZS;

                XMIN = grid.XMINCOORD;
                XMAX = grid.XMAXCOORD;
                YMIN = grid.YMINCOORD;
                YMAX = grid.YMAXCOORD;
            }
        }

        
        public void SetMapStyle(MapStyle style)
        {
            camera.scalez = style.zscale;
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
            /*

            grid.welsID = GL.GenLists(2);
            grid.vectorID = grid.welsID + 1;




            grid.Scale = camera.scale;
            grid.ScaleZ = camera.scale_z;
            */
        }

        public void SetScaleFactors()
        {
            float MC, SC;
            SC = Math.Min(width, height);

            // Z Scale Default

            MC = Math.Max(grid.DX, grid.DY) * 1.1f;
            ViewPositionZ.scale = SC / MC;

            // X Scale Default

            MC = Math.Max(grid.DY, grid.DZ * camera.scalez) * 1.1f;

            ViewPositionX.scale = SC / MC;

            // Y Scale Default

            MC = Math.Max(grid.DX, grid.DZ * camera.scalez) * 1.1f;
            
            ViewPositionY.scale = SC / MC;

            RestorePosition();
        }

        
        public void OnUnload()
        {
            
        }

        private int width, height; // Параметры окна вывода

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

        readonly Font WellsFont = new Font("Segoe Pro Cond", 11, FontStyle.Bold);

        public void LinkGrid(Grid2D grid)
        {
            this.grid = grid;
        }

        public void DrawWells()
        {
            System.Diagnostics.Debug.WriteLine("Engine [DrawWells]");

            /*
            GL.CallList(grid.welsID);

            CoordConverter cordconv = new CoordConverter(this);
            cordconv.currentViewMode = CurrentViewMode;

            render.Clear(Color.Transparent);

            foreach (ECL.WELLDATA well in grid.ACTIVE_WELLS)
            {
                if (well.COMPLS.Count > 0)
                {
                    render.DrawWell(well, WellsFont, Brushes.Black, cordconv, style, camera.is_mouse_shift);
                }
            }
            */
        }

        public void DrawVectorField()
        {
            //GL.CallList(grid.vectorID);
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

        public void OnPaint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (grid == null) return;

            // Масштабирование и перенос области отображения

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Scale(camera.scale, camera.scale, 1);

            if (CurrentViewMode != ViewMode.Z)
            {
                GL.Scale(1, camera.scalez, 1);
            }

            // Центрирование

            GL.Translate(camera.shift_x + (camera.shift_end_x - camera.shift_start_x), -camera.shift_y + camera.shift_end_y - camera.shift_start_y, 0); // Сдвиг за счет мышки

            if (CurrentViewMode == ViewMode.Z)
            {
                GL.Translate(-grid.XC, -grid.YC, 0);
            }

            if (CurrentViewMode == ViewMode.X)
            {
                GL.Translate(-grid.YC, -grid.ZC, 0);
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                GL.Translate(-grid.XC, -grid.ZC, 0);
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

            // Отрисовка выбранной ячейки

            if (CurrentViewMode == ViewMode.X && (YS > -1))
            {
                var CELL = grid.GetCell(XS, YS, ZS);

                if ((CELL.TNE.X + CELL.TNW.X + CELL.TSE.X) != 0)
                {
                    float DY = (grid.YMAXCOORD - grid.YMINCOORD) / grid.NY;
                    float DZ = (grid.ZMAXCOORD - grid.ZMINCOORD) / grid.NZ;

                    GL.LineWidth(3);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Black);

                    GL.Vertex3(CELL.TSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.BNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.BNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.TNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.TNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.TNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);


                    GL.End();

                    GL.LineWidth(1);
                }
            }

            if (CurrentViewMode == ViewMode.Y && (XS > -1))
            {
                var CELL = grid.GetCell(XS, YS, ZS);

                if ((CELL.TNE.X + CELL.TNW.X + CELL.TSE.X) != 0)
                {
                    float DX = (grid.XMAXCOORD - grid.XMINCOORD) / grid.NX;
                    float DZ = (grid.ZMAXCOORD - grid.ZMINCOORD) / grid.NZ;

                    GL.LineWidth(3);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Black);

                    GL.Vertex3(CELL.TSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.TSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.TSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.BSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.BSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.TSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);


                    GL.End();

                    GL.LineWidth(1);
                }
            }

            if (CurrentViewMode == ViewMode.Z && (XS > -1))
            {
                var CELL = grid.GetCell(XS, YS, ZS);

                if ((CELL.TNE.X + CELL.TNW.X + CELL.TSE.X) != 0)
                {
                    GL.LineWidth(3);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Black);

                    GL.Vertex3(CELL.TNW.X, CELL.TNW.Y, 0.3);
                    GL.Vertex3(CELL.TNE.X, CELL.TNE.Y, 0.3);

                    GL.Vertex3(CELL.TNE.X, CELL.TNE.Y, 0.3);
                    GL.Vertex3(CELL.TSE.X, CELL.TSE.Y, 0.3);

                    GL.Vertex3(CELL.TSE.X, CELL.TSE.Y, 0.3);
                    GL.Vertex3(CELL.TSW.X, CELL.TSW.Y, 0.3);

                    GL.Vertex3(CELL.TSW.X, CELL.TSW.Y, 0.3);
                    GL.Vertex3(CELL.TNW.X, CELL.TNW.Y, 0.3);

                    GL.End();

                    GL.LineWidth(1);
                }
            }

                     

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

        public void SetStyle(MapStyle style)
        {
            this.style = style;

            OnPaint();
        }

        public void MouseWheel(MouseEventArgs e)
        {
            camera.MouseWheel(e);

            // Изменение Scale приводит к изменению масштаба по оси Z.
            // Приходится перерисовывать стволы

           //grid.Scale = camera.scale;
           //grid.ScaleZ = camera.scalez;
        }

        public void MouseMove(MouseEventArgs e)
        {
            camera.MouseMove(e);
        }

        public int XS, YS, ZS; // Координаты выбранной ячейки
        public float VS; // Значение выбранной ячейки

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
            if (grid.element_count == 0) return;

            if (e.Button == MouseButtons.Left)
            {
                byte[] pixel = GetPixelRGBColor(e.X, e.Y);

                float XT;
                float YT;

                XS = grid.XA;
                YS = grid.YA;
                ZS = grid.ZA;

                if (CurrentViewMode == ViewMode.X)
                {
                    XT = (e.X - 0.5f * width) / camera.scale + grid.YMINCOORD + 0.5f * grid.DY - camera.shift_x - camera.shift_end_x + camera.shift_start_x;
                    YT = (e.Y - 0.5f * height) / (camera.scale * camera.scalez) + grid.ZMINCOORD + 0.5f * grid.DZ + camera.shift_y - camera.shift_end_y + camera.shift_start_y;

                    grid.GetCellUnderMouse(new Vector2(XT, YT), pixel);

                    ZS = grid.ZS;
                    YS = grid.YS;
                    VS = grid.VS;
                }

                if (CurrentViewMode == ViewMode.Y)
                {
                    XT = (e.X - 0.5f * width) / camera.scale + grid.XMINCOORD + 0.5f * grid.DX - camera.shift_x - camera.shift_end_x + camera.shift_start_x;
                    YT = (e.Y - 0.5f * height) / (camera.scale * camera.scalez) + grid.ZMINCOORD + 0.5f * grid.DZ + camera.shift_y - camera.shift_end_y + camera.shift_start_y;

                    grid.GetCellUnderMouse(new Vector2(XT, YT), pixel);

                    ZS = grid.ZS;
                    XS = grid.XS;
                    VS = grid.VS;
                }

                if (CurrentViewMode == ViewMode.Z)
                {
                    XT = (e.X - 0.5f * width) / camera.scale + grid.XMINCOORD + 0.5f * grid.DX - camera.shift_x - camera.shift_end_x + camera.shift_start_x;
                    YT = (e.Y - 0.5f * height) / camera.scale + grid.YMINCOORD + 0.5f * grid.DY + camera.shift_y - camera.shift_end_y + camera.shift_start_y;

                    grid.GetCellUnderMouse(new Vector2(XT, YT), pixel);

                    YS = grid.YS;
                    XS = grid.XS;
                    VS = grid.VS;
                }
            }
        }
    }
}