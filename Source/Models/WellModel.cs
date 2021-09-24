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
        public double OPR;
        public double GPR;
    }

    public class LumpWell
    {
        public int LUMPNUM = 0;
        public int[] ZONE = null;
        public double[] CPI = null;
        public double[] LIQ = null;
        public double[] WATER = null;
        public double[] OIL = null;
        public double[] GAS = null;
        public double[] WCUT = null;
        public double[] GOR = null;

        public double[] M_CPI = null;
        public double[] M_LIQ = null;
        public double[] M_WATER = null;
        public double[] M_OIL = null;
        public double[] M_GAS = null;
        public double[] M_WCUT = null;
        public double[] M_GOR = null;
    }


    public class WellModel
    {
        private EclipseProject ecl;
        private ECL.WELLDATA well;
        private readonly ModiWell modi = new ModiWell();
        private LumpWell lump = new LumpWell();

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

        public LumpWell LUMP
        {
            get
            {
                return lump;
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

            System.Diagnostics.Debug.WriteLine(step);
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

        public void AdjustBHP()
        {
            /*
            Расчетное забойное давление это разница между потенциальным и расчетным дебитом
            деленное на продуктивность
            BHP = (QW_POT - WLPR) / PI;
             
            Потенциальный дебит, это сумма по перфорациям продуктивность измененная, умноженная на максимальную депрессию (bhp = 0)
            Q_POT[iw] = CPI[iw] * (COMPLS[iw].PRESS - COMPLS[iw].Hw);
            
            Так как множитель ищем постоянным для всех интервалов
            QW_POT = WPIMULT * SUMM(CPI[iw] * (COMPLS[iw].PRESS - COMPLS[iw].Hw))
            
            Продуктивность это тоже простая сумма продуктивностей
            PI = WPIMULT * SUMM(CPI[iw])
            
            Следовательно, формула для расчета забойного давления

            BHP = (WPIMULT * QW_POT - WLPR) / WPIMULT * PI
            BHP * WPIMULT * PI = WPIMULT * QW_POT - WLPR
            WPIMULT (QW_POT - BHP * PI) = WLPR
            WPIMULT = WLPR / (QW_POT - BHP * PI)
            */

            double QW_POT = 0;
            double PI = 0;

            for (int iw = 0; iw < well.COMPLNUM; ++iw)
            {
                if (well.COMPLS[iw].STATUS == 1)
                {
                    double CPI =
                        (well.COMPLS[iw].WPR + well.COMPLS[iw].OPR) /
                        (well.COMPLS[iw].PRESS - well.WBHP - well.COMPLS[iw].Hw);

                    if ((well.COMPLS[iw].WPR + well.COMPLS[iw].OPR) == 0)
                        CPI = 0;

                    PI = PI + CPI;

                    double Q_POT = CPI * (well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw);

                    QW_POT = QW_POT + Q_POT;
                }
            }

            double WPIMULT = well.WLPRH / (QW_POT - well.WBHPH * PI);

            for (int iw = 0; iw < well.COMPLNUM; ++iw)
            {
                if (well.COMPLS[iw].STATUS == 1)
                {
                    well.COMPLS[iw].WPIMULT = Convert.ToSingle(WPIMULT);
                }
            }

            UpdateWPIMULT();
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

                    if ((well.COMPLS[iw].WPR + well.COMPLS[iw].OPR) == 0)
                        CPI = 0;

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
                    modi.GAS[iw] = (well.COMPLS[iw].GPR / well.COMPLS[iw].OPR) * modi.OIL[iw];

                    modi.PDD[iw] = well.COMPLS[iw].PRESS - well.COMPLS[iw].Hw - modi.BHP;

                    modi.LPR = modi.LPR + modi.LIQ[iw];
                    modi.WPR = modi.WPR + modi.WATER[iw];
                    modi.GPR = modi.GPR + modi.GAS[iw];
                }
            }
            modi.OPR = modi.LPR - modi.WPR;
        }
    
        public void CalculateLump()
        {
            LUMP.ZONE = WELL.COMPLS.Select(c => c.LUMPNUM).Distinct().ToArray();

            LUMP.LUMPNUM = LUMP.ZONE.Length;
            
            LUMP.CPI = new double[LUMP.LUMPNUM];
            LUMP.LIQ = new double[LUMP.LUMPNUM]; 
            LUMP.WATER = new double[LUMP.LUMPNUM];
            LUMP.OIL = new double[LUMP.LUMPNUM]; 
            LUMP.GAS = new double[LUMP.LUMPNUM]; 
            LUMP.WCUT = new double[LUMP.LUMPNUM];
            LUMP.GOR = new double[LUMP.LUMPNUM];

            LUMP.M_CPI = new double[LUMP.LUMPNUM];
            LUMP.M_LIQ = new double[LUMP.LUMPNUM];
            LUMP.M_WATER = new double[LUMP.LUMPNUM];
            LUMP.M_OIL = new double[LUMP.LUMPNUM];
            LUMP.M_GAS = new double[LUMP.LUMPNUM];
            LUMP.M_WCUT = new double[LUMP.LUMPNUM];
            LUMP.M_GOR = new double[LUMP.LUMPNUM];

            for (int ic = 0; ic < WELL.COMPLNUM; ++ic)
            {
                for (int iw = 0; iw < LUMP.LUMPNUM; ++iw)
                {
                    if (WELL.COMPLS[ic].LUMPNUM == LUMP.ZONE[iw])
                    {
                        LUMP.CPI[iw] += MODI.CPI_INIT[ic];
                        LUMP.LIQ[iw] += (WELL.COMPLS[ic].OPR + WELL.COMPLS[ic].WPR);
                        LUMP.OIL[iw] += WELL.COMPLS[ic].OPR;
                        LUMP.WATER[iw] += WELL.COMPLS[ic].WPR;
                        LUMP.GAS[iw] += WELL.COMPLS[ic].GPR;

                        LUMP.M_CPI[iw] += MODI.CPI[ic];
                        LUMP.M_LIQ[iw] += MODI.LIQ[ic];
                        LUMP.M_OIL[iw] += MODI.OIL[ic];
                        LUMP.M_WATER[iw] += MODI.WATER[ic];
                        LUMP.M_GAS[iw] += MODI.GAS[ic];
                    }
                }
            }


            for (int iw = 0; iw < LUMP.LUMPNUM; ++iw)
            {
                LUMP.WCUT[iw] = LUMP.WATER[iw] / LUMP.LIQ[iw];
                LUMP.M_WCUT[iw] = LUMP.M_WATER[iw] / LUMP.M_LIQ[iw];

                LUMP.GOR[iw] = LUMP.GAS[iw] / LUMP.OIL[iw];
                LUMP.M_GOR[iw] = LUMP.M_GAS[iw] / LUMP.M_OIL[iw];
            }
        }
    }
}
