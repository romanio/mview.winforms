using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public enum BubbleMode
    {
        Simulation,
        Historical,
        SimVSHist
    }

    public class MapStyle
    {
        public bool showGridLines = true;
        public bool showAllWelltrack = true;
        public bool showBubbles = true;
        public bool showNoFillColor = false;
        public bool showVectorField = false;

        public BubbleMode bubbleMode = BubbleMode.Simulation;
        public double minValue = 0;
        public double maxValue = 1;
        public double scaleFactor = 30;
        public double zscale = 12;
        public double stretchFactor = 0;
    }

    public class MapModel
    {
        private readonly EclipseProject ecl;
        private readonly Engine2D engine = new Engine2D();
        private Grid2D grid;

        public MapModel(EclipseProject ecl)
        {
            this.ecl = ecl;
        }

        public void ReadGrid()
        {
            ecl.ReadEGRID();
            ecl.ReadINIT();

            ecl.INIT.ReadGrid("PERMX");

            grid = new Grid2D(ecl);
            
            engine.LinkGrid(grid);
            engine.SetScaleFactors();
        }

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
            grid.Delete();

            engine.OnUnload();
        }

        public void OnPaint()
        {
            engine.OnPaint();
        }

        public void MouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            engine.MouseMove(e);
        }

        public void MouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            engine.MouseWheel(e);
            //engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
            //engine.grid.GenerateVectorFiled();
        }

        public void MouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            engine.MouseClick(e);
        }

        public List<string> GetDynamicProperties()
        {
            var properties = new List<string>();

            for (int iw = 0; iw < ecl.RESTART.NAME.Count; ++iw)
            {
                for (int it = 0; it < ecl.RESTART.NAME[iw].Length; ++it)
                {
                    if (ecl.RESTART.NUMBER[iw][it] == ecl.INIT.NACTIV)
                    {
                        properties.Add(ecl.RESTART.NAME[iw][it]);
                    }
                }
            }

            return properties.Distinct().ToList();
        }

        public List<string> GetStaticProperties()
        {
            var properties = new List<string>();

            for (int iw = 0; iw < ecl.INIT.NAME.Count; ++iw)
            {
                for (int it = 0; it < ecl.INIT.NAME[iw].Length; ++it)
                {
                    if (ecl.INIT.NUMBER[iw][it] == ecl.INIT.NACTIV)
                    {
                        properties.Add(ecl.INIT.NAME[iw][it]);
                    }
                }
            }

            return properties;
        }

        public string[] GetRestartDates()
        {
            return
                (from item in ecl.RESTART.DATE
                 select item.ToString()).ToArray();
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

        public void SetPosition(ViewMode position)
        {
            engine.SetPosition(position);
        }

    }
}
