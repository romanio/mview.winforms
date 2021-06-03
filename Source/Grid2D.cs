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
        //public List<ECL.WELLDATA> WELLS; // Опасная копия данных с рестарт файла
        //public List<ECL.WELLDATA> ACTIVE_WELLS; // Только те скважины, которые следует отображать

        public ViewMode CurrentViewMode = ViewMode.X;
        public float StretchFactor = 0;
        public float Scale = 1;
        public float ScaleZ = 1;
        public Colorizer colorizer = new Colorizer();

        EclipseProject ecl;
        Func<long, float> lastGetValue;

        public int element_count = 0;
        
        int vboID;
        int eboID;

        public float XMINCOORD;
        public float YMINCOORD;
        public float ZMINCOORD;
        public float XMAXCOORD;
        public float YMAXCOORD;
        public float ZMAXCOORD;
        public float XC;
        public float YC;
        public float ZC;
        public int NX;
        public int NY;
        public int NZ;

        // Выбранные для отображения координаты

        public int ZA = 0;
        public int XA = 0;
        public int YA = 0;

        public int welsID;
        public int vectorID;

        public void Delete()
        {
            GL.DeleteBuffer(vboID);
            GL.DeleteBuffer(eboID);
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
        }

        public ECL.Cell GetCell(int X, int Y, int Z)
        {
            var cell_index = ecl.INIT.GetActive(X, Y, Z);

            if (cell_index > 0)
            {
                return ecl.EGRID.GetCell(X, Y, Z);
            }

            return new ECL.Cell();
        }

        public Tuple<int, int, float> GetCellUnderMouseX(float eX, float eY, byte[] pixel)
        {
            long cell_index = 0;
            float value;
            Color color;
            ECL.Cell CELL;

            float DY = (YMAXCOORD - YMINCOORD) / ecl.EGRID.NY;
            float DZ = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

            for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                for (int Z = 0; Z < ecl.EGRID.NZ; ++Z)
                {
                    cell_index = ecl.INIT.GetActive(XA, Y, Z);

                    if (cell_index > 0)
                    {
                        value = lastGetValue(cell_index - 1);
                        color = colorizer.ColorByValue(value);

                        if (color.R == pixel[0])
                            if (color.G == pixel[1])
                                if (color.B == pixel[2])
                                {
                                    CELL = ecl.EGRID.GetCell(XA, Y, Z);

                                    float[] xcoords = new float[4] {
                                        CELL.TSE.Y * (1 - StretchFactor) + (YMINCOORD + DY * Y + DY) * StretchFactor,
                                        CELL.BSE.Y * (1 - StretchFactor) + (YMINCOORD + DY * Y + DY) * StretchFactor,
                                        CELL.BNE.Y * (1 - StretchFactor) + (YMINCOORD + DY * Y) * StretchFactor,
                                        CELL.TNE.Y * (1 - StretchFactor) + (YMINCOORD + DY * Y) * StretchFactor };

                                    float xmin = xcoords.Min();
                                    float xmax = xcoords.Max();

                                    if (eX >= xmin && eX <= xmax)
                                    {
                                        float[] ycoords = new float[4] {

                                            CELL.TSE.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z) * StretchFactor,
                                            CELL.BSE.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z + DZ) * StretchFactor,
                                            CELL.BNE.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z + DZ) * StretchFactor,
                                            CELL.TNE.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z) * StretchFactor };

                                        float ymin = ycoords.Min();
                                        float ymax = ycoords.Max();
                                        if (eY >= ymin && eY <= ymax)
                                        {
                                            return new Tuple<int, int, float>(Y, Z, value);
                                        }
                                    }
                                }
                    }
                }

            return new Tuple<int, int, float>(-1, -1, -1);
        }

        public Tuple<int, int, float> GetCellUnderMouseY(float eX, float eY, byte[] pixel)
        {
            long cell_index = 0;
            float value;
            Color color;
            ECL.Cell CELL;

            float DX = (XMAXCOORD - XMINCOORD) / ecl.EGRID.NX;
            float DZ = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

            for (int X = 0; X < ecl.EGRID.NX; ++X)
                for (int Z = 0; Z < ecl.EGRID.NZ; ++Z)
                {
                    cell_index = ecl.INIT.GetActive(X, YA, Z);

                    if (cell_index > 0)
                    {
                        value = lastGetValue(cell_index - 1);
                        color = colorizer.ColorByValue(value);

                        if (color.R == pixel[0])
                            if (color.G == pixel[1])
                                if (color.B == pixel[2])
                                {
                                    CELL = ecl.EGRID.GetCell(X, YA, Z);

                                    float[] xcoords = new float[4] {
                                        CELL.TSW.X * (1 - StretchFactor) + (XMINCOORD + DX * X) * StretchFactor,
                                        CELL.TSE.X * (1 - StretchFactor) + (XMINCOORD + DX * X + DX) * StretchFactor,
                                        CELL.BSE.X * (1 - StretchFactor) + (XMINCOORD + DX * X + DX) * StretchFactor,
                                        CELL.BSW.X * (1 - StretchFactor) + (XMINCOORD + DX * X) * StretchFactor };

                                    float xmin = xcoords.Min();
                                    float xmax = xcoords.Max();

                                    if (eX >= xmin && eX <= xmax)
                                    {
                                        float[] ycoords = new float[4] {
                                            CELL.TSW.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z) * StretchFactor,
                                            CELL.TSE.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z) * StretchFactor,
                                            CELL.BSE.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z + DZ) * StretchFactor,
                                            CELL.BSW.Z * (1 - StretchFactor) + (ZMINCOORD + DZ * Z + DZ) * StretchFactor };

                                        float ymin = ycoords.Min();
                                        float ymax = ycoords.Max();
                                        if (eY >= ymin && eY <= ymax)
                                        {
                                            return new Tuple<int, int, float>(X, Z, value);
                                        }
                                    }
                                }
                    }
                }

            return new Tuple<int, int, float>(-1, -1, -1);
        }

        public Tuple<int, int, float> GetCellUnderMouseZ(float eX, float eY, byte[] pixel)
        {
            long cell_index = 0;
            float value;
            Color color;
            ECL.Cell CELL;

            for (int X = 0; X < ecl.EGRID.NX; ++X)
                for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                {
                    cell_index = ecl.INIT.GetActive(X, Y, ZA);

                    if (cell_index > 0)
                    {
                        value = lastGetValue(cell_index - 1);
                        color = colorizer.ColorByValue(value);

                        if (color.R == pixel[0])
                            if (color.G == pixel[1])
                                if (color.B == pixel[2])
                                {
                                    CELL = ecl.EGRID.GetCell(X, Y, ZA);

                                    float[] xcoords = new float[4] { CELL.TNE.X, CELL.TNW.X, CELL.TSE.X, CELL.TSW.X };
                                    float xmin = xcoords.Min();
                                    float xmax = xcoords.Max();

                                    if (eX >= xmin && eX <= xmax)
                                    {
                                        float[] ycoords = new float[4] { CELL.TNE.Y, CELL.TNW.Y, CELL.TSE.Y, CELL.TSW.Y };
                                        float ymin = ycoords.Min();
                                        float ymax = ycoords.Max();
                                        if (eY >= ymin && eY <= ymax)
                                        {
                                            return new Tuple<int, int, float>(X, Y, value);
                                        }
                                    }
                                }
                    }
                }

            return new Tuple<int, int, float>(-1, -1, -1);
        }




        public Grid2D(EclipseProject ecl)
        {
            vboID = GL.GenBuffer();
            eboID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, eboID);

            SetEclipseProject(ecl);
        }

        public void SetEclipseProject(EclipseProject ecl)
        {
            this.ecl = ecl;

            UpdateMinMax();
            GenerateGrid(ecl.INIT.GetValue);
        }

        void UpdateMinMax()
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
        }

        public interface ICellStrategy
        {
            int XCOUNT { get; }
            int YCOUNT { get; }
            Vector3 NE { get; }
            Vector3 NW { get; }
            Vector3 SE { get; }
            Vector3 SW { get; }

            void SetEclipse(EclipseProject ecl);
            void SetActiveSlice(int slice);
            long CellIndex(int X, int Y);
        }

        public class CellViewModeZSrategy : ICellStrategy
        {
            private EclipseProject ecl;
            private int slice;
            private long index;
            private Cell cell;

            public int XCOUNT => ecl.EGRID.NX;

            public int YCOUNT => ecl.EGRID.NY;

            public Vector3 NE => throw new NotImplementedException();

            public Vector3 NW => throw new NotImplementedException();

            public Vector3 SE => throw new NotImplementedException();

            public Vector3 SW => throw new NotImplementedException();

            public long CellIndex(int X, int Y)
            {
                index = ecl.INIT.GetActive(X, Y, slice);

                if (index > 0)
                {
                    cell = ecl.EGRID.GetCell(X, Y, slice);
                }

                return index;
            }

            public void SetEclipse(EclipseProject ecl)
            {
                this.ecl = ecl;
            }
        }

        public class CellViewModeXStrategy : ICellStrategy
        {
            private EclipseProject ecl;

            public int XCOUNT => throw new NotImplementedException();

            public int YCOUNT => throw new NotImplementedException();

            public long CELLINDEX => throw new NotImplementedException();

            public Vector3 NE => throw new NotImplementedException();

            public Vector3 NW => throw new NotImplementedException();

            public Vector3 SE => throw new NotImplementedException();

            public Vector3 SW => throw new NotImplementedException();
            
            public void SetEclipse(EclipseProject ecl)
            {
                this.ecl = ecl;
            }
        }

        public class CellViewModeYStrategy : ICellStrategy
        {
            private EclipseProject ecl;

            public int XCOUNT => throw new NotImplementedException();

            public int YCOUNT => throw new NotImplementedException();

            public long CELLINDEX => throw new NotImplementedException();

            public Vector3 NE => throw new NotImplementedException();

            public Vector3 NW => throw new NotImplementedException();

            public Vector3 SE => throw new NotImplementedException();

            public Vector3 SW => throw new NotImplementedException();

            public void SetEclipse(EclipseProject ecl)
            {
                this.ecl = ecl;
            }
        }

        public void GenerateGrid(Func<long, float> GetValue)
        {
            this.lastGetValue = GetValue;

            IntPtr vertex_ptr;
            IntPtr element_ptr;

            long cellIndex = 0;

            Color color;
            float value;
            Cell cell;
            int index = 0;

            float DX = 0;
            float DY = 0;

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


            if (CurrentViewMode == ViewMode.Z)
            {
                GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NY * sizeof(float) * 3 * 4 + ecl.EGRID.NX * ecl.EGRID.NY * sizeof(byte) * 4 * 3),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

                GL.BufferData(
                    BufferTarget.ElementArrayBuffer,
                    (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NY * sizeof(int) * 4),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

                GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
                GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.EGRID.NX * ecl.EGRID.NY * sizeof(float) * 3 * 4);

                unsafe
                {
                    float* vertex_mem = (float*)vertex_ptr;
                    int* index_mem = (int*)element_ptr;
                    byte* color_mem = (byte*)(vertex_ptr + ecl.EGRID.NX * ecl.EGRID.NY * sizeof(float) * 3 * 4);

                    for (int X = 0; X < ecl.EGRID.NX; ++X)
                        for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                        {
                            cellIndex = ecl.INIT.GetActive(X, Y, ZA);

                            if (cellIndex > 0)
                            {
                                cell = ecl.EGRID.GetCell(X, Y, ZA);

                                value = GetValue(cellIndex - 1);

                                color = colorizer.ColorByValue(value);

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TNW.X;
                                vertex_mem[index * 3 + 1] = cell.TNW.Y;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TNE.X;
                                vertex_mem[index * 3 + 1] = cell.TNE.Y;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TSE.X;
                                vertex_mem[index * 3 + 1] = cell.TSE.Y;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TSW.X;
                                vertex_mem[index * 3 + 1] = cell.TSW.Y;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                            }
                        }
                }
            } // End for CurrentViewMode Z

            if (CurrentViewMode == ViewMode.X)
            {
                GL.BufferData(
                      BufferTarget.ArrayBuffer,
                      (IntPtr)(ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(float) * 3 * 4 + ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(byte) * 4 * 3),
                      IntPtr.Zero,
                      BufferUsageHint.StaticDraw);

                System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());


                vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

                GL.BufferData(
                    BufferTarget.ElementArrayBuffer,
                    (IntPtr)(ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(int) * 4),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());

                element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

                GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
                GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());

                DX = (YMAXCOORD - YMINCOORD) / ecl.EGRID.NY;
                DY = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

                unsafe
                {
                    float* vertex_mem = (float*)vertex_ptr;
                    int* index_mem = (int*)element_ptr;
                    byte* color_mem = (byte*)(vertex_ptr + ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                    for (int Z = 0; Z < ecl.EGRID.NZ; ++Z)
                        for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                        {
                            cellIndex = ecl.INIT.GetActive(XA, Y, Z);

                            if (cellIndex > 0)
                            {
                                cell = ecl.EGRID.GetCell(XA, Y, Z);

                                value = GetValue(cellIndex - 1);

                                color = colorizer.ColorByValue(value);

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TSE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.TSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.BSE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.BSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.BNE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.BNE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TNE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.TNE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                            }
                        }
                }
            } // End for CurrentViewMode X


            if (CurrentViewMode == ViewMode.Y)
            {
                GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(float) * 3 * 4 + ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(byte) * 4 * 3),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

                GL.BufferData(
                    BufferTarget.ElementArrayBuffer,
                    (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(int) * 4),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

                GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
                GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                DX = (XMAXCOORD - XMINCOORD) / ecl.EGRID.NX;
                DY = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

                unsafe
                {
                    float* vertex_mem = (float*)vertex_ptr;
                    int* index_mem = (int*)element_ptr;
                    byte* color_mem = (byte*)(vertex_ptr + ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                    for (int Z = 0; Z < ecl.EGRID.NZ; ++Z)
                        for (int X = 0; X < ecl.EGRID.NX; ++X)
                        {
                            cellIndex = ecl.INIT.GetActive(X, YA, Z);

                            if (cellIndex > 0)
                            {
                                cell = ecl.EGRID.GetCell(X, YA, Z);

                                value = GetValue(cellIndex - 1);

                                color = colorizer.ColorByValue(value);

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TSW.X * (1 - StretchFactor) + (XMINCOORD + DX * X) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.TSW.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.TSE.X * (1 - StretchFactor) + (XMINCOORD + DX * X + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.TSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.BSE.X * (1 - StretchFactor) + (XMINCOORD + DX * X + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.BSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = cell.BSW.X * (1 - StretchFactor) + (XMINCOORD + DX * X) * StretchFactor;
                                vertex_mem[index * 3 + 1] = cell.BSW.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                            }
                        }
                }
            } // End for CurrentViewMode Y

            element_count = index;
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        }
    }
}
