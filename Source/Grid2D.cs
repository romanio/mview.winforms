using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using mview.ECL ;

namespace mview
{
    public class Grid2D
    {
        public List<WELLDATA> activeWells = new List<WELLDATA>();
        public int wellsID;

        public ViewMode CurrentViewMode = ViewMode.X;
        public float StretchFactor = 0;
        public Colorizer colorizer = new Colorizer();

        EclipseProject ecl;
        Func<long, float> lastGetValue;

        public int element_count = 0;
        readonly int vboID;
        readonly int eboID;

        public float XMINCOORD;
        public float YMINCOORD;
        public float ZMINCOORD;
        public float XMAXCOORD;
        public float YMAXCOORD;
        public float ZMAXCOORD;

        public float XC, YC, ZC;
        public float DX, DY, DZ;

        public int NX;
        public int NY;
        public int NZ;

        // Выбранные для отображения координаты

        public int ZA = 0;
        public int XA = 0;
        public int YA = 0;

        // Координаты выбранной ячейки и значение

        public int ZS = -1;
        public int XS = -1;
        public int YS = -1;
        public float VS = -1;

        public int welsID;
        public int vectorID;

        public void Delete()
        {
            GL.DeleteBuffer(vboID);
            GL.DeleteBuffer(eboID);
            GL.DeleteLists(wellsID, 1);
        }

        public void GenerateVectorFiled()
        {
            System.Diagnostics.Debug.WriteLine("Grid2D [GenerateVectorField]");

            GL.NewList(vectorID, ListMode.Compile);

            GL.LineWidth(2);
            GL.Color3(Color.Black);

            GL.Begin(PrimitiveType.Lines);

            if (ecl.RESTART.FLOWI != null)
            {
                long cell_index = 0;
                double FLOWI;
                double FLOWJ;
                double len;
                double scale;

                ECL.Cell CELL;
                float XC, YC;

                for (int X = 0; X < ecl.EGRID.NX; ++X)
                    for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                    {
                        cell_index = ecl.INIT.GetActive(X, Y, ZA);

                        if (cell_index > 0)
                        {
                            CELL = ecl.EGRID.GetCell(X, Y, ZA);
                            XC = 0.5f * (CELL.TNW.X + CELL.TSE.X);
                            YC = 0.5f * (CELL.TNW.Y + CELL.TSE.Y);

                            GL.Vertex3(XC, YC, 0.2);

                            FLOWI = ecl.RESTART.FLOWI[cell_index - 1];
                            FLOWJ = ecl.RESTART.FLOWJ[cell_index - 1];

                            len = Math.Sqrt(FLOWI * FLOWI + FLOWJ * FLOWJ);

                            scale = len / 2;

                            if (scale > 1)
                            {
                                FLOWI = FLOWI / scale;
                                FLOWJ = FLOWJ / scale;
                            }

                            GL.Vertex3(XC + FLOWI, YC + FLOWJ, 0.3);
                        }
                    }
            }

            GL.End();
            GL.LineWidth(1);
            GL.EndList();

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());
        }

        public void GenerateWellDrawList(bool show_all)
        {
            /*
            System.Diagnostics.Debug.WriteLine("Grid2D [GenerateWellDrawList]");

            ACTIVE_WELLS = new List<ECL.WELLDATA>();

            float DX = (XMAXCOORD - XMINCOORD) / ecl.EGRID.NX;
            float DY = (YMAXCOORD - YMINCOORD) / ecl.EGRID.NY;
            float DZ = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

            float X = 0;
            float Y = 0;

            GL.NewList(welsID, ListMode.Compile);

            // Отрисовываем в первую очеред точки

            GL.PointSize(7);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);

            foreach (ECL.WELLDATA well in WELLS)
            {
                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    // Решение о визуализации скважины

                    compl.is_show = false;

                    switch (CurrentViewMode)
                    {
                        case ViewMode.X:
                            if (compl.I == XA)
                            {
                                X = 0.5f * (compl.Cell.TSE.Y + compl.Cell.BNE.Y) * (1 - StretchFactor) + (YMINCOORD + DY * compl.J + 0.5f * DY) * StretchFactor;
                                Y = 0.5f * (compl.Cell.TSE.Z + compl.Cell.BNE.Z) * (1 - StretchFactor) + (ZMINCOORD + DZ * compl.K + 0.5f * DZ) * StretchFactor;
                                compl.is_show = true;
                            }
                            break;
                        case ViewMode.Y:
                            if (compl.J == YA)
                            {
                                X = 0.5f * (compl.Cell.TSW.X + compl.Cell.BSE.X) * (1 - StretchFactor) + (XMINCOORD + DX * compl.I + 0.5f * DX) * StretchFactor;
                                Y = 0.5f * (compl.Cell.TSW.Z + compl.Cell.BSE.Z) * (1 - StretchFactor) + (ZMINCOORD + DZ * compl.K + 0.5f * DZ) * StretchFactor;
                                compl.is_show = true;
                            }
                            break;
                        case ViewMode.Z:
                            if (compl.K == ZA || show_all)
                            {
                                X = 0.5f * (compl.Cell.TNW.X + compl.Cell.TSE.X);
                                Y = 0.5f * (compl.Cell.TNW.Y + compl.Cell.TSE.Y);
                                compl.is_show = true;
                            }
                            break;
                    }

                    if (compl.is_show)
                    {
                        GL.Vertex3(X, Y, 0.2);
                    }
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

                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    // Решение о визуализации скважины

                    switch (CurrentViewMode)
                    {
                        case ViewMode.X:
                            if (compl.I == XA)
                            {
                                if (is_first_name) // Первая точка, начало траектории
                                {
                                    X = 0.5f * (compl.Cell.TSE.Y + compl.Cell.BNE.Y) * (1 - StretchFactor) + (YMINCOORD + DY * compl.J + 0.5f * DY) * StretchFactor;
                                    Y = 0.5f * (compl.Cell.TSE.Z + compl.Cell.BNE.Z) * (1 - StretchFactor) + (ZMINCOORD + DZ * compl.K + 0.5f * DZ) * StretchFactor;

                                    GL.Vertex3(X, ZMINCOORD - (30 / (Scale * ScaleZ)), 0.2);
                                    GL.Vertex3(X, Y, 0.2);

                                    last_XC = X;
                                    last_YC = Y;

                                    well.XC = X;
                                    well.YC = Y;

                                    ACTIVE_WELLS.Add(well); // Сохранить в списке активных скважин

                                    is_first_name = false;
                                }
                                else
                                {
                                    GL.Vertex3(last_XC, last_YC, 0.2);

                                    X = 0.5f * (compl.Cell.TSE.Y + compl.Cell.BNE.Y) * (1 - StretchFactor) + (YMINCOORD + DY * compl.J + 0.5f * DY) * StretchFactor;
                                    Y = 0.5f * (compl.Cell.TSE.Z + compl.Cell.BNE.Z) * (1 - StretchFactor) + (ZMINCOORD + DZ * compl.K + 0.5f * DZ) * StretchFactor;

                                    GL.Vertex3(X, Y, 0.2);

                                    last_XC = X;
                                    last_YC = Y;
                                }
                            }
                            break;

                        case ViewMode.Y:
                            if (compl.J == YA)
                            {
                                if (is_first_name) // Первая точка, начало траектории
                                {
                                    X = 0.5f * (compl.Cell.TSW.X + compl.Cell.BSE.X) * (1 - StretchFactor) + (XMINCOORD + DX * compl.I + 0.5f * DX) * StretchFactor;
                                    Y = 0.5f * (compl.Cell.TSW.Z + compl.Cell.BSE.Z) * (1 - StretchFactor) + (ZMINCOORD + DZ * compl.K + 0.5f * DZ) * StretchFactor;

                                    GL.Vertex3(X, ZMINCOORD - (30 / (Scale * ScaleZ)), 0.2);
                                    GL.Vertex3(X, Y, 0.2);

                                    last_XC = X;
                                    last_YC = Y;

                                    well.XC = X;
                                    well.YC = Y;

                                    ACTIVE_WELLS.Add(well); // Сохранить в списке активных скважин

                                    is_first_name = false;
                                }
                                else
                                {
                                    GL.Vertex3(last_XC, last_YC, 0.2);

                                    X = 0.5f * (compl.Cell.TSW.X + compl.Cell.BSE.X) * (1 - StretchFactor) + (XMINCOORD + DX * compl.I + 0.5f * DX) * StretchFactor;
                                    Y = 0.5f * (compl.Cell.TSW.Z + compl.Cell.BSE.Z) * (1 - StretchFactor) + (ZMINCOORD + DZ * compl.K + 0.5f * DZ) * StretchFactor;

                                    GL.Vertex3(X, Y, 0.2);

                                    last_XC = X;
                                    last_YC = Y;
                                }
                            }
                            break;
                        case ViewMode.Z:
                            if (compl.K == ZA || show_all)
                            {
                                if (is_first_name) // Первая точка, начало траектории
                                {
                                    X = 0.5f * (compl.Cell.TNW.X + compl.Cell.TSE.X);
                                    Y = 0.5f * (compl.Cell.TNW.Y + compl.Cell.TSE.Y);

                                    last_XC = X;
                                    last_YC = Y;

                                    well.XC = X;
                                    well.YC = Y;

                                    ACTIVE_WELLS.Add(well); // Сохранить в списке активных скважин

                                    is_first_name = false;
                                }
                                else
                                {
                                    GL.Vertex3(last_XC, last_YC, 0.2);

                                    X = 0.5f * (compl.Cell.TNW.X + compl.Cell.TSE.X);
                                    Y = 0.5f * (compl.Cell.TNW.Y + compl.Cell.TSE.Y);

                                    GL.Vertex3(X, Y, 0.2);

                                    last_XC = X;
                                    last_YC = Y;
                                }
                            }
                            break;
                    }

                }
                is_first_name = true;
            }


            GL.End();
            GL.LineWidth(1);

            GL.EndList();

            //  System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());
            */
        }

        public void RefreshGrid()
        {
            GenerateGrid(lastGetValue);
            GenerateWellTracks(true);
        }

        public List<Vector2> GetSelectedCell(int Xw, int Yw)
        {
            ICellStrategy cell = SelectCellStrategy();
            
            cell.SetEclipse(ecl);

            if (cell.Extract(Xw, Yw))
            {
                return cell.Points;
            }

            return new List<Vector2>();
        }

        public Grid2D(EclipseProject ecl)
        {
            vboID = GL.GenBuffer();
            eboID = GL.GenBuffer();
            wellsID = GL.GenLists(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, eboID);

            SetEclipseProject(ecl);
        }

        public void SetEclipseProject(EclipseProject ecl)
        {
            this.ecl = ecl;

            CalculateGridAttributes();
        }

        void CalculateGridAttributes()
        {
            // Определение максимальной и минимальной координаты Х и Y кажется простым,
            // для этого рассмотрим координаты четырех углов модели.
            // Более полный алгоритм должен рассматривать все 8 углов модели

            // Координата X четырех углов сетки

            List<float> XCORD = new List<float>()
            {
                ecl.EGRID.COORD[0],
                ecl.EGRID. COORD[6 *  ecl.EGRID.NX + 0],
                ecl.EGRID.COORD[6 * ( ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 0],
                ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 0]
            };

            XMINCOORD = XCORD.Min();
            XMAXCOORD = XCORD.Max();

            // Координата Y четырех углов сетки

            List<float> YCORD = new List<float>()
            {
                 ecl.EGRID.COORD[1],
                 ecl.EGRID.COORD[6 *  ecl.EGRID.NX + 1],
                 ecl.EGRID.COORD[6 * (ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 1],
                 ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 1]
            };

            YMINCOORD = YCORD.Min();
            YMAXCOORD = YCORD.Max();

            ZMAXCOORD = ecl.INIT.GetArrayMax("DEPTH");
            ZMINCOORD = ecl.INIT.GetArrayMin("DEPTH");

            XC = (XMINCOORD + XMAXCOORD) * 0.5f;
            YC = (YMINCOORD + YMAXCOORD) * 0.5f;
            ZC = (ZMINCOORD + ZMAXCOORD) * 0.5f;

            DX = XMAXCOORD - XMINCOORD;
            DY = YMAXCOORD - YMINCOORD;
            DZ = ZMAXCOORD - ZMINCOORD;
        }

        ICellStrategy SelectCellStrategy()
        {
            ICellStrategy cell = null;

            if (CurrentViewMode == ViewMode.X)
            {
                cell = new CellViewModeXStrategy()
                {
                    StretchFactor = StretchFactor,
                    Slice = XA,
                    DxDy = new Vector2(DY / NY, DZ / NZ),
                    MinPoint = new Vector2(YMINCOORD, ZMINCOORD)
                };
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                cell = new CellViewModeYStrategy()
                {
                    StretchFactor = StretchFactor,
                    Slice = YA,
                    DxDy = new Vector2(DX / NX, DZ / NZ),
                    MinPoint = new Vector2(XMINCOORD, ZMINCOORD)
                };
            }

            if (CurrentViewMode == ViewMode.Z)
            {
                cell = new CellViewModeZStrategy()
                {
                    StretchFactor = StretchFactor,
                    Slice = ZA
                };
            }

            return cell;
        }

        public void GetCellUnderMouse(Vector2 point, byte[] RGB)
        {
            XS = -1;
            YS = -1;
            ZS = -1;

            ICellStrategy cell = SelectCellStrategy();

            cell.SetEclipse(ecl);

            for (int X = 0; X < cell.NX; ++X)
                for (int Y = 0; Y < cell.NY; ++Y)
                {
                    if (cell.Extract(X, Y))
                    {
                        var color = colorizer.ColorByValue(lastGetValue(cell.Index - 1));
                        if (color.R == RGB[0] && color.G == RGB[1] && color.B == RGB[2])
                        {
                            float xmin = cell.Points.Min(c => c.X);
                            float xmax = cell.Points.Max(c => c.X);

                            if (point.X >= xmin && point.X <= xmax)
                            {
                                float ymin = cell.Points.Min(c => c.Y);
                                float ymax = cell.Points.Max(c => c.Y);

                                if (point.Y >= ymin && point.Y <= ymax)
                                {
                                    VS = lastGetValue(cell.Index - 1);

                                    if (CurrentViewMode == ViewMode.X)
                                    {
                                        XS = -1;
                                        YS = Y;
                                        ZS = X;
                                    }

                                    if (CurrentViewMode == ViewMode.Y)
                                    {
                                        XS = Y;
                                        YS = -1;
                                        ZS = X;
                                    }

                                    if (CurrentViewMode == ViewMode.Z)
                                    {
                                        XS = X;
                                        YS = Y;
                                        ZS = -1;
                                    }
                                }
                            }
                        }
                    }
                }
        }

        public void GenerateGrid(Func<long, float> GetValue)
        {
            GenerateWellTracks(true);

            this.lastGetValue = GetValue;

            IntPtr vertex_ptr;
            IntPtr element_ptr;
            Color color;

            NX = ecl.EGRID.NX;
            NY = ecl.EGRID.NY;
            NZ = ecl.EGRID.NZ;

            GL.BufferData(
                BufferTarget.ArrayBuffer,
                IntPtr.Zero, // Три координаты по float, 8 вершин и 8 цветов
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                IntPtr.Zero, // 16 треугольников
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            ICellStrategy cell = SelectCellStrategy();

            cell.SetEclipse(ecl);

            GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    (IntPtr)(cell.NX * cell.NY * sizeof(float) * 3 * 4 + cell.NX * cell.NY * sizeof(byte) * 4 * 3),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

            vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

            GL.BufferData(
                    BufferTarget.ElementArrayBuffer,
                    (IntPtr)(cell.NX * cell.NY * sizeof(int) * 4),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

            element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, cell.NX * cell.NY * sizeof(float) * 3 * 4);

            element_count = 0;

            unsafe
            {
                float* vertex_mem = (float*)vertex_ptr;
                int* index_mem = (int*)element_ptr;
                byte* color_mem = (byte*)(vertex_ptr + cell.NX * cell.NY * sizeof(float) * 3 * 4);

                for (int X = 0; X < cell.NX; ++X)
                    for (int Y = 0; Y < cell.NY; ++Y)
                    {
                        if (cell.Extract(X, Y))
                        {
                            color = colorizer.ColorByValue(GetValue(cell.Index - 1));

                            foreach(Vector2 vec in cell.Points)
                            {
                                index_mem[element_count] = element_count;
                                vertex_mem[element_count * 3 + 0] = vec.X;
                                vertex_mem[element_count * 3 + 1] = vec.Y;
                                vertex_mem[element_count * 3 + 2] = 0.1f;

                                color_mem[element_count * 3 + 0] = color.R;
                                color_mem[element_count * 3 + 1] = color.G;
                                color_mem[element_count * 3 + 2] = color.B;

                                element_count++;
                            }
                        }
                    }
            }
                        
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        }        
    
        public void GenerateWellTracks(bool isShowAll)
        { 
            activeWells.Clear();

            GL.NewList(wellsID, ListMode.Compile);

            ICellStrategy cell = SelectCellStrategy();

            cell.SetEclipse(ecl);

            GL.PointSize(5);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);

            // Перфорации
            
            foreach (WELLDATA well in ecl.RESTART.WELLS)
            {
                if (well.LGR == 0)
                {
                    foreach (COMPLDATA comp in well.COMPLS)
                    {
                        comp.isShow = false;
                       
                        if (CurrentViewMode == ViewMode.X && comp.I == XA)
                        {
                            cell.Extract(comp.K, comp.J);
                            comp.Xw = cell.Points.Average(c => c.X);
                            comp.Yw = cell.Points.Average(c => c.Y);
                            comp.isShow = true;
                        }

                        if (CurrentViewMode == ViewMode.Y && comp.J == YA)
                        {
                            cell.Extract(comp.K, comp.I);
                            comp.Xw = cell.Points.Average(c => c.X);
                            comp.Yw = cell.Points.Average(c => c.Y);
                            comp.isShow = true;
                        }

                        if (CurrentViewMode == ViewMode.Z && comp.K == ZA)
                        {
                            cell.Extract(comp.I, comp.J);
                            comp.Xw = cell.Points.Average(c => c.X);
                            comp.Yw = cell.Points.Average(c => c.Y);
                            comp.isShow = true;
                        }

                        if (comp.isShow)
                        {
                            GL.Vertex3(comp.Xw, comp.Yw, 0.2);
                        }
                    }
                }
            }

            // Ствол скважины
            
            GL.End();

            GL.Color3(Color.Black);
            GL.LineWidth(2);
            GL.Begin(PrimitiveType.Lines);


            foreach (WELLDATA well in ecl.RESTART.WELLS)
            {
                bool isFirstName = true;

                float lastXw = 0;
                float lastYw = 0;

                if (well.LGR == 0)
                {
                    foreach (COMPLDATA comp in well.COMPLS)
                    {
                        if (comp.isShow)
                        {
                            if (isFirstName)
                            {
                                if (CurrentViewMode != ViewMode.Z)
                                {
                                    GL.Vertex3(comp.Xw, ZMINCOORD - 30, 0.2);
                                    GL.Vertex3(comp.Xw, comp.Yw, 0.2);
                                }

                                lastXw = comp.Xw;
                                lastYw = comp.Yw;
                                isFirstName = false;
                                well.XC = comp.Xw;
                                well.YC = comp.Yw;
                                activeWells.Add(well);
                            }
                            else
                            {
                                GL.Vertex3(lastXw, lastYw, 0.2);
                                GL.Vertex3(comp.Xw, comp.Yw, 0.2);
                                lastXw = comp.Xw;
                                lastYw = comp.Yw;

                            }
                        }
                    }
                }
            }
            GL.End();
            GL.LineWidth(1);

            GL.EndList();
        }
    }
}
