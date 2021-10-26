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
    public class Engine3D
    {
        public Camera3D Camera = new Camera3D();
        public Grid3D grid = null;
        Vector3 m_start_vector = new Vector3();
        Vector3 m_end_vector = new Vector3();
        Vector3 m_delta_vector = new Vector3();

        //bool IsLeftDrag = false;

        bool IsMidDrag = false;
        bool IsRightDrag = false;
        TextRender txt_render;
        Font Serif = new Font("Segoe Pro Cond", 12, FontStyle.Regular);
        Matrix4 projection;
        Matrix4 modelview = new Matrix4();

        float _width;
        float _height;

        public bool IsLoaded = false;
        public void OnLoad()
        {
            System.Diagnostics.Debug.WriteLine("Engine3D.cs / void OnLoad() ");

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PolygonOffsetFill);

            GL.Enable(EnableCap.CullFace);
            //GL.FrontFace(FrontFaceDirection.Cw);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.White);

            grid.welsID = GL.GenLists(2);


            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
        }

        public void OnUnload()
        {
            grid.Unload();
            GL.DeleteLists(grid.welsID, 2);
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (!IsMidDrag) // begin panning
                {
                    m_start_vector = new Vector3(e.X, e.Y, 0f);
                    IsMidDrag = true;
                }
                else // ...continue panning
                {
                    m_end_vector = new Vector3(e.X, e.Y, 0f);
                    m_delta_vector = m_end_vector - m_start_vector;

                    Camera.Pan(m_delta_vector.X, m_delta_vector.Y);
                    UpdateModelView();

                    OnPaint();

                    m_start_vector = m_end_vector;
                }
            }
            else
            {
                if (IsMidDrag) // ...end panning
                {
                    IsMidDrag = false;
                    UpdateModelView();

                    OnPaint();
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (!IsRightDrag) // begin rotation
                {
                    m_start_vector = new Vector3(e.X, e.Y, 0f);
                    IsRightDrag = true;
                }
                else  // ...continue rotation
                {
                    m_end_vector = new Vector3(e.X, e.Y, 0f);
                    m_delta_vector = m_end_vector - m_start_vector;

                    Camera.Rotate(m_delta_vector.X, m_delta_vector.Y);
                    UpdateModelView();

                    OnPaint();
                    m_start_vector = m_end_vector;
                }
            }
            else
            {
                if (IsRightDrag)  //.. end rotation
                {
                    IsRightDrag = false;
                    UpdateModelView();

                    OnPaint();
                }
            }
        }

        public void OnMouseWheel(MouseEventArgs e)
        {
            Camera.Zoom(e.Delta);
            UpdateModelView();
        }

        public void OnPaint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PointSize(4);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Black);
            GL.Vertex3(Camera.Target);

            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.End();

            GL.PushMatrix();

            if (IsLoaded)
            {
                GL.Scale(Camera.Scale, Camera.Scale, Camera.Scale * 12);
                GL.Translate(-grid.XC, -grid.YC, -grid.ZC);
                Render();
            }
            else
            {
                GL.PolygonOffset(0, 0);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

                RenderEasyCube(true);

                // Отрисовка границ
                GL.PolygonOffset(1, 1);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                RenderEasyCube(false);
            }

            GL.PopMatrix();

            // Switch to 2D projection
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();

            GL.LoadIdentity();
            GL.Ortho(0, _width, _height, 0, -1, +1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.PointSize(4);

            //
            txt_render.Clear(Color.Transparent);


            if (grid.ACTIVE_WELLS != null)
            {
                foreach (ECL.WELLDATA well in grid.ACTIVE_WELLS)
                {
                    if (well.COMPLS.Count > 0)
                    {
                        var coord = ConvertWorldToScreen(new Vector3((well.XC - grid.XC) * Camera.Scale, (well.YC - grid.YC) * Camera.Scale, (well.ZC - grid.ZC) * Camera.Scale * 12));
                        txt_render.DrawString(well.WELLNAME, Serif, Brushes.Black, new PointF(coord.X, coord.Y));
                    }
                }
            }

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, txt_render.Texture);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Transparent);

            GL.TexCoord2(0, 0);
            GL.Vertex3(0, 0, 0);

            GL.TexCoord2(0, 1);
            GL.Vertex3(0, _height, 0);

            GL.TexCoord2(1, 1);
            GL.Vertex3(_width, _height, 0);


            GL.TexCoord2(1, 0);
            GL.Vertex3(_width, 0, 0);

            GL.End();
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
            //

            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Modelview);

            // Switch to 3D
        }

        public void DrawWells()
        {
            GL.CallList(grid.welsID);


        }
        public void RenderEasyCube(bool frame_mode)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(frame_mode ? Color.Black : Color.Green);
            GL.Vertex3(1.0, 1.0, -1.0);
            GL.Vertex3(-1.0, 1.0, -1.0);
            GL.Vertex3(-1.0, 1.0, 1.0);
            GL.Vertex3(1.0, 1.0, 1.0);

            if (!frame_mode)
            {
                GL.Color3(1.0, 0.5, 0.0);
            }

            GL.Vertex3(1.0, -1.0, 1.0);
            GL.Vertex3(-1.0, -1.0, 1.0);
            GL.Vertex3(-1.0, -1.0, -1.0);
            GL.Vertex3(1.0, -1.0, -1.0);

            if (!frame_mode)
            {
                GL.Color3(1.0, 0.0, 0.0);
            }


            GL.Vertex3(1.0, 1.0, 1.0);
            GL.Vertex3(-1.0, 1.0, 1.0);
            GL.Vertex3(-1.0, -1.0, 1.0);
            GL.Vertex3(1.0, -1.0, 1.0);

            if (!frame_mode)
            {
                GL.Color3(1.0, 1.0, 0.0);
            }

            GL.Vertex3(1.0, -1.0, -1.0);
            GL.Vertex3(-1.0, -1.0, -1.0);
            GL.Vertex3(-1.0, 1.0, -1.0);
            GL.Vertex3(1.0, 1.0, -1.0);

            if (!frame_mode)
            {
                GL.Color3(0.0, 0.0, 1.0);
            }

            GL.Vertex3(-1.0, 1.0, 1.0);
            GL.Vertex3(-1.0, 1.0, -1.0);
            GL.Vertex3(-1.0, -1.0, -1.0);
            GL.Vertex3(-1.0, -1.0, 1.0);

            if (!frame_mode)
            {
                GL.Color3(1.0, 0.0, 1.0);
            }

            GL.Vertex3(1.0, 1.0, -1.0);
            GL.Vertex3(1.0, 1.0, 1.0);
            GL.Vertex3(1.0, -1.0, 1.0);
            GL.Vertex3(1.0, -1.0, -1.0);

            GL.End();
        }
        public void Render()
        {

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, grid.EBO);

            // Отрисовка ячеек

            GL.PolygonOffset(+1, +1);

            GL.EnableClientState(ArrayCap.ColorArray);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.DrawElements(PrimitiveType.Triangles, grid.ElementCount, DrawElementsType.UnsignedInt, 0);


            // Отрисовка границ

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, grid.EBOQuads);

            GL.PolygonOffset(0, 0);
            GL.DisableClientState(ArrayCap.ColorArray);
            GL.Color3(Color.Black);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
            GL.DrawElements(PrimitiveType.Quads, grid.QuadCount, DrawElementsType.UnsignedInt, 0);


            //  GL.Disable(EnableCap.DepthTest);
            DrawWells();
            // GL.Enable(EnableCap.DepthTest);

        }

        /*
        public void SetGridModel(Grid3D grid)
        {
            m_grid = grid;
            camera.Scale = 0.004f;
            IsLoaded = true;
        }
        */

        Vector2 ConvertWorldToScreen(Vector3 point)
        {
            //point = Vector3.Transform(point, modelview);
            //point = Vector3.Transform(point, projection);
            point.X /= point.Z;
            point.Y /= point.Z;

            point.X = (point.X + 1) * _width / 2;
            point.Y = _height - (point.Y + 1) * _height / 2;

            return new Vector2(point.X, point.Y);
        }

        /*
        void WellRender()
        {
            if (IsLoaded == false) return;
            ECLStructure.Cell CELL;
            for (int iw = 0; iw < ecl_ref.RESTART.NWELLS; ++iw)
            {
                for (int ic = 0; ic < ecl_ref.RESTART.NCWMAX; ++ic)
                {
                    // Если перфорация активная
                    int cell_active = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 0];
                    int cell_X = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 1];
                    int cell_Y = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 2];
                    int cell_Z = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 3];
                    if (cell_active != 0)
                    {
                        CELL = ecl_ref.EGRID.GetCell(cell_X, cell_Y, cell_Z);
                        GL.LineWidth(3);
                        GL.Begin(PrimitiveType.Lines);
                        GL.Color3(Color.Red);
                        GL.Vertex3((CELL.TNE.X + CELL.BSW.X) * 0.5, (CELL.TNE.Y + CELL.BSW.Y) * 0.5, ecl_ref.EGRID.ZMAXCOORD);
                        GL.Vertex3((CELL.TNE.X + CELL.BSW.X) * 0.5, (CELL.TNE.Y + CELL.BSW.Y) * 0.5, (CELL.TNE.Z + CELL.BSW.Z) * 0.5);
                        GL.End();
                        continue;
                    }
                }
            }
            GL.LineWidth(1);
        }
        */
        /*
        public void GenerateGraphics(ECLStructure.ECL ecl)
        {
            IsLoaded = true;
            ecl_ref = ecl;
            ecl.ReadRestart(4);
            ecl.RESTART.ReadRestartGrid("PRESSURE");
            camera.Scale = 0.004f;
            grid.GenerateGraphics(ecl);
        }
        */

        public void OnResize(int width, int height)
        {
            float aspect = (float)width / (float)height;
            GL.Viewport(0, 0, width, height);
            _width = width;
            _height = height;

            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, aspect, 0.1f, 1000f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            UpdateModelView();

            //
            if (txt_render != null) txt_render.Dispose();
            txt_render = new TextRender((int)_width, (int)_height);
        }
        void UpdateModelView()
        {
            modelview = Matrix4.LookAt(Camera.Position, Camera.Target, Camera.UpDirection);
            GL.LoadMatrix(ref modelview);
        }

    }
}
