using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace mview
{
    public enum BubbleMode
    {
        None,
        Simulation,
        Historical,
        DiffLPT,
        DiffOPT,
        DiffGPT,
        DiffWIT,
        DiffOPR,
        DiffLPR,
        DiffGPR,
        DiffWCUT,
        DiffBHP
    }

public class MapModel
    {
        private readonly EclipseProject ecl;
        private readonly Engine2D engine = new Engine2D();
        private Grid2D grid;

        private string gridUnit;
        private float maxValue = 1;
        private float minValue = 0;

        public MapModel(EclipseProject ecl)
        {
            this.ecl = ecl;
        }

        public void ReadGrid()
        {
            ecl.ReadEGRID();
            ecl.ReadINIT();

            grid = new Grid2D(ecl);
            SetStaticProperty("PERMX");

            engine.LinkGrid(grid);
            engine.SetScaleFactors();
        }

        public void OnLoad()
        {
            System.Diagnostics.Debug.WriteLine("OnLoad()");
            engine.OnLoad();

        }

        public void OnResize(int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("OnResize()");
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

        public string GetGridUnit()
        {
            return gridUnit;
        }

        public float GetMinValue()
        {
            return minValue;
        }

        public float GetMaxValue()
        {
            return maxValue;
        }

        public void SetPosition(ViewMode position)
        {
            engine.SetPosition(position);
        }

        public void SetXA(int X)
        {
            grid.XA = X;
            grid.RefreshGrid();
        }

        public void SetYA(int Y)
        {
            grid.YA = Y;
            grid.RefreshGrid();
        }

        public void SetZA(int Z)
        {
            grid.ZA = Z;
            grid.RefreshGrid();
        }

        public void SetStaticProperty(string name)
        {
            ecl.INIT.ReadGrid(name);

            gridUnit = ecl.INIT.GridUnit;
            minValue = ecl.INIT.DATA.Min();
            maxValue = ecl.INIT.DATA.Max();

            grid.colorizer.SetMaximum(maxValue);
            grid.colorizer.SetMinimum(minValue);

            grid.GenerateGrid(ecl.INIT.GetValue);
        }

        public void ReadRestart(int step)
        {
            ecl.ReadRestart(step);
        }

        public void SetDynamicProperty(string name)
        {
            ecl.RESTART.ReadGrid(name);

            gridUnit = ecl.RESTART.GRIDUNIT;
            minValue = ecl.RESTART.DATA.Min();
            maxValue = ecl.RESTART.DATA.Max();

            grid.colorizer.SetMaximum(maxValue);
            grid.colorizer.SetMinimum(minValue);

            grid.GenerateGrid(ecl.RESTART.GetValue);
        }

        public void SetMapStyle(MapStyle style)
        {
            engine.SetMapStyle(style);
        }

        public void SetCameraFocusOn(string name)
        {
            engine.SetCameraFocusOn(name);
        }

        public Vector4 GetSelectedCellValue()
        {
            return engine.GetSelectedCellValue();
        }

        public Vector3 GetSlice()
        {
            return engine.GetSlice();
        }
    }
}
