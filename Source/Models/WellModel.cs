using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class ModiWell
    {
        public double[] CPI_LIST = null;
        public double[] CPI_INIT_LIST = null;
        public double[] LIQ_LIST = null;
        public double[] WATER_LIST = null;
        public double[] OIL_LIST = null;
        public double[] WCUT_LIST = null;
        public double[] PDD_LIST = null;
        public double[] Q_POT_LIST = null;

        public int LUMPNUM = 0;
        public int[] LUMPED_ZONE = null;
        public double[] LUMP_M_LIQ_LIST = null;
        public double[] LUMP_M_WATER_LIST = null;
        public double[] LUMP_M_OIL_LIST = null;
        public double[] LUMP_M_WCUT_LIST = null;

        public double[] LUMP_LIQ_LIST = null;
        public double[] LUMP_WATER_LIST = null;
        public double[] LUMP_OIL_LIST = null;
        public double[] LUMP_WCUT_LIST = null;

        public double PI = 0;
        public double Q_POT = 0;
        public double BHP;
        public double LPR;
        public double WPR;
    }

    public class WellModel
    {
        private EclipseProject ecl;
        private ECL.WELLDATA well;
        private ModiWell modi = new ModiWell();

        public ECL.WELLDATA WELL
        {
            get
            {
                return well;
            }
        }

        public ModiWell MODI
        {
            get
            {
                return modi;
            }
        }

        public WellModel(EclipseProject ecl)
        {
            UpdateECL(ecl);
        }

        public void UpdateECL(EclipseProject ecl)
        {
            this.ecl = ecl;
        }

        public void ReadRestart(int step)
        {
            ecl.ReadRestart(step);
        }

        public string[] GetRestartDates()
        {
            return
                (from item in ecl.RESTART.DATE
                 select item.ToString()).ToArray();
        }

        public void ReadWellData()
        {
            ecl.RESTART.ReadFullWellData();
        }

        public void GetWellData(string wellname)
        {
            well = ecl.RESTART.WELLS.FirstOrDefault(c => c.WELLNAME == wellname);
            
            UpdateWPIMULT();
        }

        public void UpdateWPIMULT()
        {
            modi.CPI_LIST = new double[well.COMPLNUM];
            modi.LIQ_LIST = new double[well.COMPLNUM];
            modi.WATER_LIST = new double[well.COMPLNUM];
            modi.OIL_LIST = new double[well.COMPLNUM];
            modi.WCUT_LIST = new double[well.COMPLNUM];
            modi.PDD_LIST = new double[well.COMPLNUM];
            modi.CPI_INIT_LIST = new double[well.COMPLNUM];
            modi.Q_POT_LIST = new double[well.COMPLNUM];

            modi.PI = 0;
            modi.Q_POT = 0;

            for (int iw = 0; iw < well.COMPLNUM; ++iw)
            {
                if (well.COMPLS[iw].STATUS == 1)
                {
                    double CPI =
                        (well.COMPLS[iw].WPR + well.COMPLS[iw].OPR) /
                        (well.COMPLS[iw].PRESS - well.WBHP - well.COMPLS[iw].Hw);

                    modi.CPI_INIT_LIST[iw] = CPI;

                    modi.CPI_LIST[iw] = CPI * well.COMPLS[iw].WPIMULT;

                    modi.PI = modi.PI + modi.CPI_LIST[iw];
                    modi.Q_POT_LIST[iw] = modi.CPI_LIST[iw] * (well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw);
                    modi.Q_POT = modi.Q_POT + modi.Q_POT_LIST[iw];
                }
            }

            modi.BHP = (modi.Q_POT - well.WLPR) / modi.PI;
            modi.LPR = 0;
            modi.WPR = 0;

            for (int iw = 0; iw < well.COMPLNUM; ++iw)
            {
                if (well.COMPLS[iw].STATUS == 1)
                {
                    modi.LIQ_LIST[iw] = modi.CPI_LIST[iw] * (well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw - modi.BHP);
                    modi.WCUT_LIST[iw] = well.COMPLS[iw].WPR / (well.COMPLS[iw].WPR + well.COMPLS[iw].OPR);
                    modi.WATER_LIST[iw] = modi.LIQ_LIST[iw] * modi.WCUT_LIST[iw];
                    modi.OIL_LIST[iw] = modi.LIQ_LIST[iw] - modi.WATER_LIST[iw];

                    modi.PDD_LIST[iw] = well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw - modi.BHP;

                    modi.LPR = modi.LPR + modi.LIQ_LIST[iw];
                    modi.WPR = modi.WPR + modi.WATER_LIST[iw];
                }
            }
        }
    }
}
