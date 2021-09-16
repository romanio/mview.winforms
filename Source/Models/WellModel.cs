using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class ModiWell
    {
        public double[] CPI = null;
        public double[] CPI_INIT = null;
        public double[] LIQ = null;
        public double[] WATER = null;
        public double[] OIL = null;
        public double[] GAS = null;
        public double[] WCUT = null;
        public double[] PDD = null;
        public double[] Q_POT = null;

        public double PI = 0;
        public double QW_POT = 0;
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

            ecl.ReadEGRID();
            ecl.ReadINIT();
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

            if (well == null)
            {
                return;
            };

            
            GenerateTopAndBottomCoordinate();    
            UpdateWPIMULT();
        }

        public void GenerateTopAndBottomCoordinate()
        {
            if (well.LGR == 0)
            {
                foreach (ECL.COMPLDATA comp in well.COMPLS)
                {
                    var index = ecl.INIT.GetActive(comp.I, comp.J, comp.K);

                    if (index > 0)
                    {
                        var cell = ecl.EGRID.GetCell(comp.I, comp.J, comp.K);

                        comp.TopAverage = (cell.TSE.Z + cell.TSW.Z + cell.TNE.Z + cell.TNW.Z) / 4;
                        comp.BottomAverage = (cell.BSE.Z + cell.BSW.Z + cell.BNE.Z + cell.BNW.Z) / 4;

                    }
                }
            }
        }
        
        public void UpdateLumping(string lumpname)
        {
            ecl.INIT.ReadGrid(lumpname);


            for (int IW = 0; IW < ecl.RESTART.WELLS.Count; ++IW) // Для всех скважин и для всех перфораций
                for (int IC = 0; IC < ecl.RESTART.WELLS[IW].COMPLS.Count; ++IC)
                {
                    long index = ecl.INIT.GetActive(
                        ecl.RESTART.WELLS[IW].COMPLS[IC].I,
                        ecl.RESTART.WELLS[IW].COMPLS[IC].J,
                        ecl.RESTART.WELLS[IW].COMPLS[IC].K) - 1;

                    ecl.RESTART.WELLS[IW].COMPLS[IC].LUMPNUM = (int)ecl.INIT.GetValue(index);
                }
        }

        public void UpdateWPIMULT()
        {
            modi.CPI = new double[well.COMPLNUM];
            modi.LIQ = new double[well.COMPLNUM];
            modi.WATER = new double[well.COMPLNUM];
            modi.OIL = new double[well.COMPLNUM];
            modi.GAS = new double[well.COMPLNUM];
            modi.WCUT = new double[well.COMPLNUM];
            modi.PDD = new double[well.COMPLNUM];
            modi.CPI_INIT = new double[well.COMPLNUM];
            modi.Q_POT = new double[well.COMPLNUM];

            modi.PI = 0;
            modi.QW_POT = 0;

            for (int iw = 0; iw < well.COMPLNUM; ++iw)
            {
                if (well.COMPLS[iw].STATUS == 1)
                {
                    double CPI =
                        (well.COMPLS[iw].WPR + well.COMPLS[iw].OPR) /
                        (well.COMPLS[iw].PRESS - well.WBHP - well.COMPLS[iw].Hw);

                    modi.CPI_INIT[iw] = CPI;

                    modi.CPI[iw] = CPI * well.COMPLS[iw].WPIMULT;

                    modi.PI = modi.PI + modi.CPI[iw];
                    modi.Q_POT[iw] = modi.CPI[iw] * (well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw);
                    modi.QW_POT = modi.QW_POT + modi.Q_POT[iw];
                }
            }

            modi.BHP = (modi.QW_POT - well.WLPR) / modi.PI;
            modi.LPR = 0;
            modi.WPR = 0;

            for (int iw = 0; iw < well.COMPLNUM; ++iw)
            {
                if (well.COMPLS[iw].STATUS == 1)
                {
                    modi.LIQ[iw] = modi.CPI[iw] * (well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw - modi.BHP);
                    modi.WCUT[iw] = well.COMPLS[iw].WPR / (well.COMPLS[iw].WPR + well.COMPLS[iw].OPR);
                    modi.WATER[iw] = modi.LIQ[iw] * modi.WCUT[iw];
                    
                    modi.OIL[iw] = modi.LIQ[iw] - modi.WATER[iw];

                    modi.PDD[iw] = well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw - modi.BHP;

                    modi.LPR = modi.LPR + modi.LIQ[iw];
                    modi.WPR = modi.WPR + modi.WATER[iw];
                }
            }
        }
    }
}
