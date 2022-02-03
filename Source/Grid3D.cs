using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using mview.ECL;
using System.Drawing;

namespace mview
{
    public class Grid3D
    {
        public float XC, YC, ZC; // Центр модели
        public float XMINCOORD;
        public float YMINCOORD;
        public float ZMINCOORD;
        public float XMAXCOORD;
        public float YMAXCOORD;
        public float ZMAXCOORD;
        public int NX;
        public int NY;
        public int NZ;
        public List<WELLDATA> WELLS; // Опасная копия данных с рестарт файла
        public List<WELLDATA> ACTIVE_WELLS; // Только те скважины, которые следует отображать

        Colorizer Colorizer = new Colorizer();
        public int ElementCount;
        public int QuadCount;

        public int welsID;
        public float Scale = 1;
        public float ScaleZ = 1;
        IntPtr VertexPointer;

        public int VBO, EBO, EBOQuads;

        readonly Cell[] Cells;

        public Grid3D(EclipseProject ecl)
        {
            System.Diagnostics.Debug.WriteLine("Grid3D.cs / void Grid3D()");

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();
            EBOQuads = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);

            Cells = new Cell[ecl.INIT.NACTIV];

            for (int Z = 0; Z < ecl.INIT.NZ; ++Z)
            {
                for (int Y = 0; Y < ecl.INIT.NY; ++Y)
                {
                    for (int X = 0; X < ecl.INIT.NX; ++X)
                    {
                        long cell_index = ecl.INIT.GetActive(X, Y, Z);

                        if (cell_index > 0)
                        {
                            Cells[cell_index - 1] = ecl.EGRID.GetCell(X, Y, Z);
                        }
                    }
                }
            }
        }

        public void Unload()
        {
            GL.DeleteBuffer(VBO);
            GL.DeleteBuffer(EBO);
            GL.DeleteBuffer(EBOQuads);

        }

        public void GenerateVertexAndColors(EclipseProject ecl, Func<long, float> GetValue)
        {
            System.Diagnostics.Debug.WriteLine("Grid3D.cs / void GenerateVertexAndColors");


            int ActiveCellCount = ecl.INIT.NACTIV;
            int index = 0;

            Colorizer.SetMinimum(0);
            Colorizer.SetMaximum(1);

            // Без обнуления буфферов, работает но очень медленно

            GL.BufferData(BufferTarget.ArrayBuffer, IntPtr.Zero, IntPtr.Zero, BufferUsageHint.StaticDraw);

            GL.BufferData(BufferTarget.ArrayBuffer,
                (IntPtr)(ActiveCellCount * sizeof(float) * 3 * 8 + ActiveCellCount * sizeof(byte) * 3 * 8), // Три координаты по float, 8 вершин и 8 цветов
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ActiveCellCount * sizeof(float) * 3 * 8);

            VertexPointer = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

            unsafe
            {
                float* vertex_mem = (float*)VertexPointer;
                byte* color_mem = (byte*)(VertexPointer + ActiveCellCount * sizeof(float) * 3 * 8);

                for (int Z = 0; Z < ecl.INIT.NZ; ++Z)
                {
                    for (int Y = 0; Y < ecl.INIT.NY; ++Y)
                    {
                        for (int X = 0; X < ecl.INIT.NX; ++X)
                        {
                            long cell_index = ecl.INIT.GetActive(X, Y, Z);

                            if (cell_index > 0)
                            {
                                var cell = Cells[cell_index - 1];
                                var value = GetValue(cell_index - 1);
                                var color = Colorizer.ColorByValue(value);
                                index = 8 * 3 * ((int)cell_index - 1);

                                vertex_mem[index + 0] = cell.TNW.X;
                                vertex_mem[index + 1] = cell.TNW.Y;
                                vertex_mem[index + 2] = cell.TNW.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.TSW.X;
                                vertex_mem[index + 1] = cell.TSW.Y;
                                vertex_mem[index + 2] = cell.TSW.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.TSE.X;
                                vertex_mem[index + 1] = cell.TSE.Y;
                                vertex_mem[index + 2] = cell.TSE.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.TNE.X;
                                vertex_mem[index + 1] = cell.TNE.Y;
                                vertex_mem[index + 2] = cell.TNE.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.BNW.X;
                                vertex_mem[index + 1] = cell.BNW.Y;
                                vertex_mem[index + 2] = cell.BNW.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.BSW.X;
                                vertex_mem[index + 1] = cell.BSW.Y;
                                vertex_mem[index + 2] = cell.BSW.Z;


                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.BSE.X;
                                vertex_mem[index + 1] = cell.BSE.Y;
                                vertex_mem[index + 2] = cell.BSE.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                                index = index + 3;

                                vertex_mem[index + 0] = cell.BNE.X;
                                vertex_mem[index + 1] = cell.BNE.Y;
                                vertex_mem[index + 2] = cell.BNE.Z;

                                color_mem[index + 0] = color.R;
                                color_mem[index + 1] = color.G;
                                color_mem[index + 2] = color.B;

                            }
                        }
                    }
                }
            }

            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
        }

        //

        // Формирует два буфера активных ячеек EBO с учетом примененного фильтра
        // Цвета и координаты вершин назначаются void GenerateVertexAndColors
        public void GenerateGraphics(EclipseProject ecl, GraphicFilterData filter)
        {
            // 
            System.Diagnostics.Debug.WriteLine("Grid3D.cs / void GenerateGraphics");

            int ActiveCellCount = ecl.INIT.NACTIV;

            int index = 0;
            int count = 0;
            int qcount = 0;
            long cell_index = 0;

            bool skip_right_face = false;
            bool skip_front_face = false;
            bool skip_bottom_face = false;
            bool skip_left_face = false;
            bool skip_top_face = false;
            bool skip_back_face = false;

            // Применить индексные фильтры

            List<int> XSet = new List<int>();
            List<int> YSet = new List<int>();
            List<int> ZSet = new List<int>();

            for (int X = 0; X < ecl.INIT.NX; ++X)
            {
                XSet.Add(X);
            }

            for (int Y = 0; Y < ecl.INIT.NY; ++Y)
            {
                YSet.Add(Y);
            }

            for (int Z = 0; Z < ecl.INIT.NZ; ++Z)
            {
                ZSet.Add(Z);
            }

            if (filter.UseIndexFilter)
            {
                if (filter.IndexX != -1) { XSet = new List<int>() { filter.IndexX }; };
                if (filter.IndexY != -1) { YSet = new List<int>() { filter.IndexY }; };
                if (filter.IndexZ != -1) { ZSet = new List<int>() { filter.IndexZ }; };
            }


            int[] Indices = new int[ActiveCellCount * 3 * 16];
            int[] Quades = new int[ActiveCellCount * 4 * 8];

            for (int zindex = 0; zindex < ZSet.Count; ++zindex)
            {
                for (int yindex = 0; yindex < YSet.Count; ++yindex)
                {
                    for (int xindex = 0; xindex < XSet.Count; ++xindex)
                    {
                        cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex]);

                        if (cell_index > 0)
                        {
                            var CELL = Cells[cell_index - 1];

                            index = 8 * ((int)cell_index - 1);

                            // Проверка соседей по X справа

                            skip_right_face = false;
                            skip_left_face = false;
                            skip_front_face = false;
                            skip_back_face = false;
                            skip_bottom_face = false;
                            skip_top_face = false;

                            if (filter == null)
                            {
                                // Проверка соседей по X справа

                                if (xindex < XSet.Count - 1) // Только не для последнего элемента
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex + 1], YSet[yindex], ZSet[zindex]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = Cells[cell_index - 1];

                                        skip_right_face =
                                            ((CELL.TNE == NCELL.TNW) &&
                                            (CELL.TSE == NCELL.TSW) &&
                                            (CELL.BNE == NCELL.BNW) &&
                                            (CELL.BSE == NCELL.BSW));
                                    }
                                }
                                // Проверка соседей по X слева

                                if (xindex > 0)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex - 1], YSet[yindex], ZSet[zindex]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = Cells[cell_index - 1];

                                        skip_left_face =
                                            ((CELL.TNW == NCELL.TNE) &&
                                            (CELL.TSW == NCELL.TSE) &&
                                            (CELL.BNW == NCELL.BNE) &&
                                            (CELL.BSW == NCELL.BSE));
                                    }
                                }
                                // Проверка соседей по Y справа

                                if (yindex < YSet.Count - 1)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex + 1], ZSet[zindex]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = Cells[cell_index - 1];

                                        skip_front_face =
                                            ((CELL.TSW == NCELL.TNW) &&
                                             (CELL.TSE == NCELL.TNE) &&
                                             (CELL.BSW == NCELL.BNW) &&
                                             (CELL.BSE == NCELL.BNE));
                                    }
                                }

                                // Проверка соседей по Y слева

                                if (yindex > 0)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex - 1], ZSet[zindex]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = Cells[cell_index - 1];

                                        skip_back_face =
                                            ((CELL.TNW == NCELL.TSW) &&
                                            (CELL.TNE == NCELL.TSE) &&
                                            (CELL.BNW == NCELL.BSW) &&
                                            (CELL.BNE == NCELL.BSE));
                                    }
                                }

                                // Проверка соседей по Z снизу

                                if (zindex < ZSet.Count - 1)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex + 1]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = Cells[cell_index - 1];

                                        skip_bottom_face =
                                            ((CELL.BNW == NCELL.TNW) &&
                                            (CELL.BNE == NCELL.TNE) &&
                                            (CELL.BSW == NCELL.TSW) &&
                                            (CELL.BSE == NCELL.TSE));
                                    }
                                }

                                // Проверка соседей по Z сверху

                                if (zindex > 0)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex - 1]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = Cells[cell_index - 1];

                                        skip_top_face =
                                            ((CELL.TNW == NCELL.BNW) &&
                                            (CELL.TNE == NCELL.BNE) &&
                                            (CELL.TSW == NCELL.BSW) &&
                                            (CELL.TSE == NCELL.BSE));
                                    }
                                }
                            }

                            // Схема наименования вершин
                            //
                            // TSE----   TSW
                            // TNE----   TNW (передняя грань)
                            //
                            // BNE----   BNW (передняя грань)
                            //
                            // Порядок хранения вершин в буфере
                            //
                            // TNW(0) .. TSW(1) ..  TSE(2) .. TNE(3) 
                            // BNW(4) .. BSW(5) .. BSE(6) .. BNE(7)

                            if (skip_top_face == false) // Top face
                            {
                                Indices[count++] = index + 2; // TSE - TNE - TSW
                                Indices[count++] = index + 3;
                                Indices[count++] = index + 1;

                                Indices[count++] = index + 1; // TSW - TNE - TNW
                                Indices[count++] = index + 3;
                                Indices[count++] = index + 0;

                                Quades[qcount++] = index + 0; // TNW - TSW - TSE - TNE
                                Quades[qcount++] = index + 1;
                                Quades[qcount++] = index + 2;
                                Quades[qcount++] = index + 3;
                            }

                            if (skip_back_face == false) // Front face
                            {
                                Indices[count++] = index + 3; // TNE - BNE - TNW
                                Indices[count++] = index + 7;
                                Indices[count++] = index + 0;

                                Indices[count++] = index + 0; // TNW - BNE - BNW
                                Indices[count++] = index + 7;
                                Indices[count++] = index + 4;

                                Quades[qcount++] = index + 3; // TNE - BNE - BNW - TNW
                                Quades[qcount++] = index + 7;
                                Quades[qcount++] = index + 4;
                                Quades[qcount++] = index + 0;
                            }

                            if (skip_right_face == false) // Right  face
                            {
                                Indices[count++] = index + 2; // TSE - BSE - TNE
                                Indices[count++] = index + 6;
                                Indices[count++] = index + 3;

                                Indices[count++] = index + 3; // TNE - BSE - BNE
                                Indices[count++] = index + 6;
                                Indices[count++] = index + 7;

                                Quades[qcount++] = index + 2; // TSE - BSE - BNE - TNE
                                Quades[qcount++] = index + 6;
                                Quades[qcount++] = index + 7;
                                Quades[qcount++] = index + 3;
                            }

                            if (skip_left_face == false) // Left face
                            {
                                Indices[count++] = index + 0; // TNW - BNW - TSW
                                Indices[count++] = index + 4;
                                Indices[count++] = index + 1;

                                Indices[count++] = index + 1; // TSW - BNW - BSW
                                Indices[count++] = index + 4;
                                Indices[count++] = index + 5;

                                Quades[qcount++] = index + 0; // TNW - BNW - BSW - TSW
                                Quades[qcount++] = index + 4;
                                Quades[qcount++] = index + 5;
                                Quades[qcount++] = index + 1;
                            }

                            if (skip_front_face == false) // Back face
                            {
                                Indices[count++] = index + 2; // TSE - TSW - BSE
                                Indices[count++] = index + 1;
                                Indices[count++] = index + 6;

                                Indices[count++] = index + 6; // BSE - TSW - BSW
                                Indices[count++] = index + 1;
                                Indices[count++] = index + 5;

                                Quades[qcount++] = index + 2; // TSE - TSW - BSW - BSE
                                Quades[qcount++] = index + 1;
                                Quades[qcount++] = index + 5;
                                Quades[qcount++] = index + 6;
                            }

                            if (skip_bottom_face == false) // Bottom face
                            {
                                Indices[count++] = index + 7; // BNE - BSW - BSE
                                Indices[count++] = index + 6;
                                Indices[count++] = index + 5;

                                Indices[count++] = index + 5; // BSW - BNW - BNE
                                Indices[count++] = index + 4;
                                Indices[count++] = index + 7;

                                Quades[qcount++] = index + 4; // BNW - BNE - BSE - BSW
                                Quades[qcount++] = index + 7;
                                Quades[qcount++] = index + 6;
                                Quades[qcount++] = index + 5;
                            }

                            index += 8;
                        }
                    }
                }
            }

            ElementCount = count;
            QuadCount = qcount;

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);

            GL.BufferData(BufferTarget.ElementArrayBuffer, IntPtr.Zero, IntPtr.Zero, BufferUsageHint.StaticDraw);

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(ElementCount * sizeof(int)),
                Indices,
                BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOQuads);

            GL.BufferData(BufferTarget.ElementArrayBuffer, IntPtr.Zero, IntPtr.Zero, BufferUsageHint.StaticDraw);

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(qcount * sizeof(int)), // 16 треугольников
                Quades,
                BufferUsageHint.StaticDraw);

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());
        }


        public void GenerateWellDrawList(bool show_all)
        {
            System.Diagnostics.Debug.WriteLine("Grid3D.cs / void GenerateWellDrawList(bool show_all)");

            if (WELLS == null) return;

            ACTIVE_WELLS = new List<WELLDATA>();

            float X = 0;
            float Y = 0;
            float Z = 0;

            GL.NewList(welsID, ListMode.Compile);

            // Отрисовываем в первую очеред точки

            GL.PointSize(7);
            GL.Color3(Color.IndianRed);
            GL.Begin(PrimitiveType.Points);

            foreach (ECL.WELLDATA well in WELLS)
            {
                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    // Решение о визуализации скважины

                   // X = 0.5f * (compl.Cell.TNW.X + compl.Cell.BSE.X);
                   // Y = 0.5f * (compl.Cell.TNW.Y + compl.Cell.BSE.Y);
                   // Z = 0.5f * (compl.Cell.TNW.Z + compl.Cell.BSE.Z);

                  //  GL.Vertex3(X, Y, Z);
                }
            }

            GL.End();

            // Затем отрисовывем ствол скважины линиями

            GL.Color3(Color.Black);
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.Lines);

            foreach (ECL.WELLDATA well in WELLS)
            {
                bool is_first_name = true;
                float last_XC = 0;
                float last_YC = 0;
                float last_ZC = 0;

                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    // Решение о визуализации скважины

                    if (is_first_name) // Первая точка, начало траектории
                    {
                        //X = 0.5f * (compl.Cell.TNW.X + compl.Cell.BSE.X);
                        //Y = 0.5f * (compl.Cell.TNW.Y + compl.Cell.BSE.Y);
                        //Z = 0.5f * (compl.Cell.TNW.Z + compl.Cell.BSE.Z);

                        GL.Vertex3(X, Y, ZMINCOORD - 1.2 * (ZMAXCOORD - ZMINCOORD));
                        GL.Vertex3(X, Y, Z);

                        last_XC = X;
                        last_YC = Y;
                        last_ZC = Z;

                        well.XC = X;
                        well.YC = Y;
                        well.ZC = (float)(ZMINCOORD - 1.2 * (ZMAXCOORD - ZMINCOORD));

                        ACTIVE_WELLS.Add(well); // Сохранить в списке активных скважин

                        is_first_name = false;
                    }
                    else
                    {
                        GL.Vertex3(last_XC, last_YC, last_ZC);

                        //X = 0.5f * (compl.Cell.TNW.X + compl.Cell.BSE.X);
                        //Y = 0.5f * (compl.Cell.TNW.Y + compl.Cell.BSE.Y);
                        //Z = 0.5f * (compl.Cell.TNW.Z + compl.Cell.BSE.Z);

                        GL.Vertex3(X, Y, Z);

                        last_XC = X;
                        last_YC = Y;
                        last_ZC = Z;
                    }
                }
                is_first_name = true;
            }


            GL.End();
            GL.LineWidth(1);

            GL.EndList();
        }
    }
}
