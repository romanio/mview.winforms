using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
    
    public class VisualFilter
    {
        public Pair<bool, int> ICfrom = new Pair<bool, int>();
        public Pair<bool, int> ICto = new Pair<bool, int>();
        public Pair<bool, int> JCfrom = new Pair<bool, int>();
        public Pair<bool, int> JCto = new Pair<bool, int>();
        public Pair<bool, int> KCfrom = new Pair<bool, int>();
        public Pair<bool, int> KCto = new Pair<bool, int>();
        public Pair<bool, float> min = new Pair<bool, float>();
        public Pair<bool, float> max = new Pair<bool, float>();
    }

    public class GraphicFilterData
    {
        public bool UseIndexFilter;

        public int IndexX = -1;
        public int IndexY = -1;
        public int IndexZ = -1;
    }

    class DDDModel
    {
        private readonly EclipseProject ecl = null;
        private Engine3D engine = new Engine3D();

        public DDDModel(EclipseProject ecl)
        {
            this.ecl = ecl;

        }

        //  GUI Logic

        private string uiStaticProperyName = null;
        private string uiDynamicPropertyName = "PORO";

        public void ReadGrid()
        {
            engine = new Engine3D();

            ecl.ReadEGRID();
            ecl.ReadINIT();

            engine.grid = new Grid3D(ecl);

            SetStaticProperty("PERMX");
            SetMinMaxAndScaleFactor();

            engine.grid.GenerateVertexAndColors(ecl, ecl.INIT.GetValue);
            engine.grid.GenerateGraphics(ecl, new GraphicFilterData { UseIndexFilter = false });

            engine.Camera.Scale = 0.004f;
            engine.IsLoaded = true;




        }


        public void ReadRestart(int step)
        {
            ecl.ReadRestart(step);
        }


        public void OnRestartSelected(int step)
        {
            ecl.ReadRestart(step);
            GenerateWellCoord();
        }

        public void OnStaticPropertySelected(string name)
        {
            uiStaticProperyName = name;
            uiDynamicPropertyName = null;

            SetStaticProperty(name);
            GenerateStaticGrid();
        }

        public void OnDynamicPropertySelected(string name)
        {
            uiDynamicPropertyName = name;
            uiStaticProperyName = null;

            SetDynamicProperty(name);
            GenerateDynamicGrid();
        }

        public void OnSetGraphicFilter(GraphicFilterData filter)
        {
            engine.grid.GenerateGraphics(ecl, filter);
        }


        // End GUI Logic

        public void OnLoad()
        {
            engine.OnLoad();

            
        }

        public void OnResize(int width, int height)
        {
            engine.OnResize(width, height);
        }

        public void OnUnload()
        {
            engine.OnUnload();
        }

        public void OnPaint()
        {
            engine.OnPaint();
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            engine.OnMouseMove(e);
        }

        public void OnMouseWheel(MouseEventArgs e)
        {
            engine.OnMouseWheel(e);
        }

        public void MouseClick(MouseEventArgs e)
        {
            //  Engine.OnMouseClick(e);
        }

        void SetMinMaxAndScaleFactor()// int width, int height)
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

            engine.grid.XMINCOORD = XCORD.Min();
            engine.grid.XMAXCOORD = XCORD.Max();

            // Координата Y четырех углов сетки

            List<float> YCORD = new List<float>()
            {
                 ecl.EGRID.COORD[1],
                 ecl.EGRID.COORD[6 *  ecl.EGRID.NX + 1],
                 ecl.EGRID.COORD[6 * (ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 1],
                 ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 1]
            };

            engine.grid.YMINCOORD = YCORD.Min();
            engine.grid.YMAXCOORD = YCORD.Max();

            engine.grid.ZMAXCOORD = ecl.INIT.GetArrayMax("DEPTH");
            engine.grid.ZMINCOORD = ecl.INIT.GetArrayMin("DEPTH");

            engine.grid.XC = (engine.grid.XMINCOORD + engine.grid.XMAXCOORD) * 0.5f;
            engine.grid.YC = (engine.grid.YMINCOORD + engine.grid.YMAXCOORD) * 0.5f;
            engine.grid.ZC = (engine.grid.ZMINCOORD + engine.grid.ZMAXCOORD) * 0.5f;

        }

        public List<string> GetStaticProperties()
        {
            var StaticProperties = new List<string>();

            for (int iw = 0; iw < ecl.INIT.NAME.Count; ++iw)
                for (int it = 0; it < ecl.INIT.NAME[iw].Length; ++it)
                    if (ecl.INIT.NUMBER[iw][it] == ecl.INIT.NACTIV)
                        StaticProperties.Add(ecl.INIT.NAME[iw][it]);

            return StaticProperties;
        }

        public List<string> GetDynamicProperties()
        {
            var DynamicProperties = new List<string>();

            for (int it = 0; it < ecl.RESTART.NAME.Count; ++it)
            {
                DynamicProperties.AddRange(GetDinamicProperties(it));
            }

            return DynamicProperties.Distinct().ToList();
        }
        public List<string> GetDinamicProperties(int step) // Вектора могут быть разными на разных рестар файлах
        {
            var DynamicProperties = new List<string>();

            for (int it = 0; it < ecl.RESTART.NAME[step].Length; ++it)
                if (ecl.RESTART.NUMBER[step][it] == ecl.INIT.NACTIV)
                    DynamicProperties.Add(ecl.RESTART.NAME[step][it]);

            return DynamicProperties;
        }

        public int GetNX()
        {
            return ecl.EGRID.NX;
        }

        public int GetNY()
        {
            return ecl.EGRID.NY;
        }

        public int GetNZ()
        {
            return ecl.EGRID.NZ;
        }

        public string[] GetRestartDates()
        {
            return
                (from item in ecl.RESTART.DATE
                 select item.ToString()).ToArray();
        }
        void GenerateWellCoord()
        {
            // Вспомогательный массив WCOORD содержит в себе
            // перфорации скважин. Если скважина вскрывает ячейку, то в массив WCOORD
            // записывается индекс скважины

            foreach (ECL.WELLDATA well in ecl.RESTART.WELLS)
            {
                if (well.LGR == 0)
                {
                    foreach (ECL.COMPLDATA compl in well.COMPLS)
                    {
                        //compl.Cell = ecl.EGRID.GetCell(compl.I, compl.J, compl.K);
                    }
                }
            }

            engine.grid.WELLS = ecl.RESTART.WELLS; // Опасное создание указателя на существующий набор данных
            engine.grid.Scale = engine.Camera.Scale;
            engine.grid.ScaleZ = engine.Camera.Scale * 12;

            engine.grid.GenerateWellDrawList(true);
        }

        public void SetStaticProperty(string name)
        {
            ecl.INIT.ReadGrid(name);

            GridUnit = ecl.INIT.GridUnit;
            PropertyMinValue = ecl.INIT.GetArrayMin(name);
            PropertyMaxValue = ecl.INIT.GetArrayMax(name);

            // Расчет распределения свойства по категориям

            PropertyStatistic = new long[20];

            // Уникальный случай, когда минимум равен максимуму

            if (PropertyMinValue == PropertyMaxValue)
            {
                PropertyStatistic[0] = 1;
            }
            else
            {
                for (int iw = 0; iw < ecl.INIT.DATA.Length; ++iw)
                    PropertyStatistic[
                        (int)((float)(ecl.INIT.DATA[iw] - PropertyMinValue) / (float)(PropertyMaxValue - PropertyMinValue) * 19)
                        ]++;
            }
        }

        string GridUnit = null;
        float PropertyMinValue = 0;
        float PropertyMaxValue = 1;
        long[] PropertyStatistic = null;

        public void GenerateStaticGrid()
        {
            engine.grid.Scale = engine.Camera.Scale;
            engine.grid.ScaleZ = engine.Camera.Scale * 12;

            engine.grid.GenerateVertexAndColors(ecl, ecl.INIT.GetValue);
            OnSetGraphicFilter(new GraphicFilterData { UseIndexFilter = false });
            engine.grid.GenerateWellDrawList(true);
        }


        public void GenerateDynamicGrid()
        {
            engine.grid.Scale = engine.Camera.Scale;
            engine.grid.ScaleZ = engine.Camera.Scale * 12;

            engine.grid.GenerateVertexAndColors(ecl, ecl.RESTART.GetValue);
            OnSetGraphicFilter(new GraphicFilterData { UseIndexFilter = false });
            engine.grid.GenerateWellDrawList(true);
        }

        public void SetDynamicProperty(string name)
        {
            System.Diagnostics.Debug.WriteLine("Form3DModel.cs / void SetDynamicProperty {0} ", name);

            if (Array.IndexOf(ecl.RESTART.NAME[ecl.RESTART.RESTART_STEP], name) != -1)
            {
                ecl.RESTART.ReadGrid(name);

                GridUnit = ecl.RESTART.GRIDUNIT;
                PropertyMinValue = ecl.RESTART.GetArrayMin(name);
                PropertyMaxValue = ecl.RESTART.GetArrayMax(name);

                PropertyStatistic = new long[20];

                // Уникальный случай, когда минимум равен максимуму

                if (PropertyMinValue == PropertyMaxValue)
                {
                    PropertyStatistic[0] = 1;
                }
                else
                {
                    for (int iw = 0; iw < ecl.RESTART.DATA.Length; ++iw)
                        PropertyStatistic[
                            (int)((float)(ecl.RESTART.DATA[iw] - PropertyMinValue) / (float)(PropertyMaxValue - PropertyMinValue) * 19)
                            ]++;
                }
            }
        }
    }
}
