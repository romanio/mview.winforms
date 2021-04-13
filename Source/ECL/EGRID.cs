using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace mview.ECL
{
    public struct Cell
    {
        public Vector3 TNW;
        public Vector3 TNE;
        public Vector3 TSW;
        public Vector3 TSE;
        public Vector3 BNW;
        public Vector3 BNE;
        public Vector3 BSW;
        public Vector3 BSE;
    }

    public class BigArray<T>
    {
        internal const int BLOCK_SIZE = 524288;
        internal const int BLOCK_SIZE_LOG2 = 19;

        T[][] _elements;
        long _length;
  
        public BigArray(long size)
        {
            long numBlocks = (size / BLOCK_SIZE);
            if ((numBlocks * BLOCK_SIZE) < size)
                numBlocks++;

            _length = size;
            _elements = new T[numBlocks][];

            for (long iw = 0; iw < (numBlocks - 1); iw++)
                _elements[iw] = new T[BLOCK_SIZE];

            _elements[numBlocks - 1] = new T[size - (long)((numBlocks - 1) * BLOCK_SIZE)];
        }

        public long Length
        {
            get
            {
                return _length;
            }
        }
        public T this[long index]
        {
            get
            {
                long blockNum = (index >> BLOCK_SIZE_LOG2);
                long indexInBlock = (index & (BLOCK_SIZE - 1));
                return _elements[blockNum][indexInBlock];
            }
            set
            {
                long blockNum = (index >> BLOCK_SIZE_LOG2);
                long indexInBlock = (index & (BLOCK_SIZE - 1));
                _elements[blockNum][indexInBlock] = value;
            }
        }
    }

    public class EGRID
    {
        public int[] FILEHEAD = null;
        public int[] GRIDHEAD = null;
        public int GRIDTYPE;
        public int DUALPORO;
        public int FORMATDATA;
        public string MAPUNITS;
        public float XORIGIN;
        public float YORIGIN;
        public float XENDYAXIS;
        public float YENDYAXIS;
        public float XENDXAXIS;
        public float YENDXAXIS;
        public int NX;
        public int NY;
        public int NZ;
        public float[] COORD = null;
        public BigArray<float> ZCORN = null;

        public event EventHandler<BinaryReaderArg> UpdateData;
        
        public void ReadEGRID(string filename)
        {
            FileReader br = new FileReader();
            br.OpenBinaryFile(filename);
            br.UpdateData += OnBinaryReaderUpdateData;

            while (br.Position < br.Length - 24)
            {
                br.ReadHeader();
                if (br.header.keyword == "FILEHEAD")
                {
                    FILEHEAD = br.ReadIntList();
                    GRIDTYPE = FILEHEAD[4];
                    DUALPORO = FILEHEAD[5];
                    FORMATDATA = FILEHEAD[6];
                    continue;
                }

                if (br.header.keyword == "MAPUNITS")
                {
                    br.ReadBytes(4);
                    MAPUNITS = br.ReadString(8);
                    br.ReadBytes(4);
                    continue;
                }

                if (br.header.keyword == "MAPAXES")
                {
                    br.ReadBytes(4);
                    XENDYAXIS = br.ReadFloat();
                    YENDYAXIS = br.ReadFloat();
                    XORIGIN = br.ReadFloat();
                    YORIGIN = br.ReadFloat();
                    XENDXAXIS = br.ReadFloat();
                    YENDXAXIS = br.ReadFloat();
                    br.ReadBytes(4);
                    continue;
                }

                if (br.header.keyword == "GRIDHEAD")
                {
                    GRIDHEAD = br.ReadIntList();
                    NX = GRIDHEAD[1];
                    NY = GRIDHEAD[2];
                    NZ = GRIDHEAD[3];
                    continue;
                }

                if (br.header.keyword == "ENDGRID") // Завершение чтения данных основной сетки и переход к LGR
                {
                    break;
                }

                if (br.header.keyword == "COORD")
                {
                    COORD = br.ReadFloatList(6 * (NY + 1) * (NX + 1));
                    continue;
                }

                if (br.header.keyword == "ZCORN")
                {
                    ZCORN = br.ReadBigList((long)(8 * NX * NY * NZ));
                    continue;
                }

                /*
                Несмотря на то, что EGRID хранит в себе ACTNUM, иногда так происходит
                что EGRID подается на вход в модель и фактическое количество активных ячеек будет расчитано после
                начала расчёта. Настоящий массив ACTNUM поэтому, хранится в INIT и толку от его чтения здесь нет никакого.
                */

                br.SkipEclipseData();
            }
            br.CloseBinaryFile();
        }

        private void OnBinaryReaderUpdateData(object sender, BinaryReaderArg e)
        {
            UpdateData?.Invoke(sender, e);
        }


        public Cell GetCell(int X, int Y, int Z)
        {
            // Формат именования вершин в кубе.
            // На первом месте либо T (top, верхняя грань), либо B (bottom, нижняя грань)
            // далее N (north, северная, условный верх) либо S (south, южная, условный низ) грань 
            // и завершается  W( west, западная, условное лево) либо E (east, восточное, условное право).
            //Таким образом, трехбуквенным кодом обозначаются восемь вершин одной ячейки.
            // Это распространенный подход.

            Cell CELL = new Cell();

            // Отметки глубин

            CELL.TNW.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + 2 * X + 0)];
            CELL.TNE.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + 2 * X + 1)];
            CELL.TSW.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + 2 * X + NX * 2 + 0)];
            CELL.TSE.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + 2 * X + NX * 2 + 1)];

            CELL.BNW.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + NX * NY * 4 + 2 * X + 0)];
            CELL.BNE.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + NX * NY * 4 + 2 * X + 1)];
            CELL.BSW.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + NX * NY * 4 + 2 * X + NX * 2 + 0)];
            CELL.BSE.Z = ZCORN[(long)(Z * NX * NY * 8 + Y * NX * 4 + NX * NY * 4 + 2 * X + NX * 2 + 1)];

            // Направляющая линия от TNW до BNW

            Vector3 TOP = new Vector3();
            Vector3 BTM = new Vector3();

            TOP.X = COORD[(X + (NX + 1) * Y) * 6 + 0];
            TOP.Y = COORD[(X + (NX + 1) * Y) * 6 + 1];
            TOP.Z = COORD[(X + (NX + 1) * Y) * 6 + 2];

            BTM.X = COORD[(X + (NX + 1) * Y) * 6 + 3 + 0];
            BTM.Y = COORD[(X + (NX + 1) * Y) * 6 + 3 + 1];
            BTM.Z = COORD[(X + (NX + 1) * Y) * 6 + 3 + 2];

            float FRAC = 0;

            if (BTM.Z == TOP.Z) // нет наклона направляющей линии, значит координаты равны
            {
                CELL.TNW.X = TOP.X;
                CELL.TNW.Y = TOP.Y;
                CELL.BNW.X = BTM.X;
                CELL.BNW.Y = BTM.Y;
            }
            else
            {
                FRAC = (CELL.TNW.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.TNW.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.TNW.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);

                FRAC = (CELL.BNW.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.BNW.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.BNW.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);
            }

            // Направляющая линия от TNE до BNE

            TOP.X = COORD[((X + 1) + (NX + 1) * Y) * 6 + 0];
            TOP.Y = COORD[((X + 1) + (NX + 1) * Y) * 6 + 1];
            TOP.Z = COORD[((X + 1) + (NX + 1) * Y) * 6 + 2];

            BTM.X = COORD[((X + 1) + (NX + 1) * Y) * 6 + 3 + 0];
            BTM.Y = COORD[((X + 1) + (NX + 1) * Y) * 6 + 3 + 1];
            BTM.Z = COORD[((X + 1) + (NX + 1) * Y) * 6 + 3 + 2];

            if (BTM.Z == TOP.Z) // нет наклона направляющей линии, значит координаты равны
            {
                CELL.TNE.X = TOP.X;
                CELL.TNE.Y = TOP.Y;
                CELL.BNE.X = BTM.X;
                CELL.BNE.Y = BTM.Y;
            }
            else
            {
                FRAC = (CELL.TNE.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.TNE.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.TNE.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);

                FRAC = (CELL.BNE.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.BNE.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.BNE.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);
            }

            // Направляющая линия от TSE до BSE

            TOP.X = COORD[((X + 1) + (NX + 1) * (Y + 1)) * 6 + 0];
            TOP.Y = COORD[((X + 1) + (NX + 1) * (Y + 1)) * 6 + 1];
            TOP.Z = COORD[((X + 1) + (NX + 1) * (Y + 1)) * 6 + 2];

            BTM.X = COORD[((X + 1) + (NX + 1) * (Y + 1)) * 6 + 3 + 0];
            BTM.Y = COORD[((X + 1) + (NX + 1) * (Y + 1)) * 6 + 3 + 1];
            BTM.Z = COORD[((X + 1) + (NX + 1) * (Y + 1)) * 6 + 3 + 2];

            if (BTM.Z == TOP.Z) // нет наклона направляющей линии, значит координаты равны
            {
                CELL.TSE.X = TOP.X;
                CELL.TSE.Y = TOP.Y;
                CELL.BSE.X = BTM.X;
                CELL.BSE.Y = BTM.Y;
            }
            else
            {
                FRAC = (CELL.TSE.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.TSE.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.TSE.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);

                FRAC = (CELL.BSE.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.BSE.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.BSE.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);
            }

            // Направляющая линия от TSW до BSW

            TOP.X = COORD[(X + (NX + 1) * (Y + 1)) * 6 + 0];
            TOP.Y = COORD[(X + (NX + 1) * (Y + 1)) * 6 + 1];
            TOP.Z = COORD[(X + (NX + 1) * (Y + 1)) * 6 + 2];

            BTM.X = COORD[(X + (NX + 1) * (Y + 1)) * 6 + 3 + 0];
            BTM.Y = COORD[(X + (NX + 1) * (Y + 1)) * 6 + 3 + 1];
            BTM.Z = COORD[(X + (NX + 1) * (Y + 1)) * 6 + 3 + 2];

            if (BTM.Z == TOP.Z) // нет наклона направляющей линии, значит координаты равны
            {
                CELL.TSW.X = TOP.X;
                CELL.TSW.Y = TOP.Y;
                CELL.BSW.X = BTM.X;
                CELL.BSW.Y = BTM.Y;
            }
            else
            {
                FRAC = (CELL.TSW.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.TSW.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.TSW.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);

                FRAC = (CELL.BSW.Z - TOP.Z) / (BTM.Z - TOP.Z);
                CELL.BSW.X = TOP.X + FRAC * (BTM.X - TOP.X);
                CELL.BSW.Y = TOP.Y + FRAC * (BTM.Y - TOP.Y);
            }

            return CELL;
        }
    }

}
