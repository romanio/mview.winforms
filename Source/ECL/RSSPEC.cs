using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace mview.ECL
{
    public enum SIM_TYPE
    {
        ECL100 = 100,
        ECL300 = 300,
        ECL300T = 500,
        IX = 700,
        FrontSim = 800,
        OtherSim
    }

    public class COMPLDATA
    {
        public bool isShow;
        public int I;
        public int J;
        public int K;
        public int STATUS;
        public int LUMPNUM;
        public float WPIMULT = 1;

        public float Xw;
        public float Yw;
        public float TopAverage;
        public float BottomAverage;
        public float XC;
        public float YC;
        public float ZC;
        public float CF;
        public float Depth;
        public float D;
        public float kh;
        public float S;
        public float Complex; // ln(R/Rw)+S
        public float H; // DZ * NTG
        public float s38;

        public double Hw;
        public double OPR;
        public double WPR;
        public double GPR;
        public double OPT;
        public double WPT;
        public double GPT;
        public double PIO;
        public double PIW;
        public double PIG;
        public double PRESS;
        public double SOIL;

    }

    public class WELLDATA
    {
        public int WINDEX;
        public string WELLNAME;
        public int I;
        public int J;
        public int K;
        public int LGR;
        public int COMPLNUM;
        public int GROUPNUM;
        public int WELLTYPE;
        public int WELLSTATUS;
        public float WOPRH;
        public float WWPRH;
        public float WGPRH;
        public float WLPRH;
        public float REF_DEPTH;
        public float WEFA;
        public float WBHPH;
        public double WOPR;
        public double WWPR;
        public double WLPR;
        public double WBHP;
        public double WWCT;
        public double WOPT;
        public double WWPT;
        public double WWIT;
        public double WPI;
        public double WOPTH;
        public double WWPTH;
        public double WWITH;
        public float XC;
        public float YC;
        public float ZC;
        public int FIRSTCOMP = -1;
        public List<COMPLDATA> COMPLS = new List<COMPLDATA>();
    }

    public class RSSPEC
    {
        public List<double> TIME = new List<double>(); // Количество дней с начала расчёта
        public List<int> REPORT = new List<int>();
        public List<int> TYPE_RESTART = new List<int>();
        public List<DateTime> DATE = new List<DateTime>();
        public List<string[]> NAME = new List<string[]>(); // Имя массива
        public List<string[]> TYPE = new List<string[]>(); // Тип массива
        public List<int[]> NUMBER = new List<int[]>(); // Размер векторов
        public List<int[]> POINTER = new List<int[]>(); // Lower part of the address
        public List<int[]> POINTERB = new List<int[]>(); // Upper part of the address
        public List<float[]> ARRAYMAX = new List<float[]>(); // Maximum values
        public List<float[]> ARRAYMIN = new List<float[]>(); // Minimum values
        public List<string[]> UNITS = new List<string[]>(); // Единица измерения
        public string FILENAME = null;
        public string GRIDUNIT = null;


        public RSSPEC(string filename)
        {
            FileReader br = new FileReader();
            br.OpenBinaryFile(filename);

            if (br.Length > 0)
            {
                while (br.Position < br.Length - 24)
                {
                    br.ReadHeader();

                    if (br.header.keyword == "TIME")
                    {
                        br.ReadBytes(4);
                        TIME.Add(br.ReadDouble());
                        br.ReadBytes(4);
                        continue;
                    }

                    if (br.header.keyword == "ITIME")
                    {
                        // Eclipse должен содержать 11 элементов ITIME, 
                        // но tNavi игнорирует выгрузку этих элементов, параметры рестарт файла считываются из самих рестартов

                        int[] ITIME = br.ReadIntList();
                        if (ITIME.Length == 1)
                        {
                            REPORT.Add(ITIME[0]);
                        }
                        else
                        {
                            REPORT.Add(ITIME[0]);
                            TYPE_RESTART.Add(ITIME[5]);
                            if (ITIME.Length > 10)
                                DATE.Add(new DateTime(ITIME[3], ITIME[2], ITIME[1], ITIME[10], ITIME[11], (int)(ITIME[12] * 1e-6)));
                            else
                                DATE.Add(new DateTime(ITIME[3], ITIME[2], ITIME[1]));
                        }
                        continue;
                    }

                    if (br.header.keyword == "NAME")
                    {
                        NAME.Add(br.ReadStringList());
                        continue;
                    }

                    if (br.header.keyword == "TYPE")
                    {
                        TYPE.Add(br.ReadStringList());
                        continue;
                    }

                    if (br.header.keyword == "UNITS")
                    {
                        UNITS.Add(br.ReadStringList());
                        continue;
                    }

                    if (br.header.keyword == "NUMBER")
                    {
                        NUMBER.Add(br.ReadIntList());
                        continue;
                    }

                    if (br.header.keyword == "ARRAYMAX")
                    {
                        ARRAYMAX.Add(br.ReadFloatList(br.header.count));
                        continue;
                    }

                    if (br.header.keyword == "ARRAYMIN")
                    {
                        ARRAYMIN.Add(br.ReadFloatList(br.header.count));
                        continue;
                    }

                    if (br.header.keyword == "POINTER")
                    {
                        POINTER.Add(br.ReadIntList());
                        continue;
                    }

                    if (br.header.keyword == "POINTERB")
                    {
                        POINTERB.Add(br.ReadIntList());
                        continue;
                    }

                    br.SkipEclipseData();
                }
                br.CloseBinaryFile();
                
            }
        }


        public float GetArrayMin(string name)
        {
                for (int iw = 0; iw < NAME[RESTART_STEP].Length; ++iw)
                {
                    if (NAME[RESTART_STEP][iw] == name)
                    {
                        return ARRAYMIN[RESTART_STEP][iw];
                    }
                }
            return -9999;
        }

        public float GetArrayMax(string name)
        {
                for (int iw = 0; iw < NAME[RESTART_STEP].Length; ++iw)
                {
                    if (NAME[RESTART_STEP][iw] == name)
                    {
                        return ARRAYMAX[RESTART_STEP][iw];
                    }
                }
            return -9999;
        }

        public int NX, NY, NZ; // Размер по X, Y, Z
        public int NACTIV; // Количество активных ячеек
        public int IPHS; // Индикатор фазы
        public int NWELLS; // Количество скважин
        public int NCWMAX; // Максимальное количество перфораций на одну скважину
        public int NIWELZ; // Количество элементов данных в IWEL (int значения)
        public int NSWELZ; // Количество элементов данных в SWEL (float значения)
        public int NXWELZ; // Количество элементов данных в XWEL (double значения)
        public int NZWELZ; // Количество элементов данных в ZWEL (string значения)
        public int NICONZ; // Количество элементов данных в ICON (int значения)
        public int NSCONZ; // Количество элементов данных в SCON (float значения)
        public int NXCONZ; // Количество элементов данных в XCON (double значения)
        public SIM_TYPE SIMTYPE; // Тип симулятора

        // Разворачивание в человеческий вид содержимое рестарт файла

        public List<WELLDATA> WELLS = new List<WELLDATA>();
        public int RESTART_STEP;
        public float[] DATA = null;

        // Векторное поле

        public float[] FLOWI = null;
        public float[] FLOWJ = null;


        public void ReadRestart(string filename, int step)
       
        // для чтения показателей по перфорациям, я все таки вынес в отдельную процедуру
        // требуется редко, а читается постоянно 
        {
            FILENAME = filename;

            // Проверка на LGR
            bool LGR = REPORT.Count != NAME.Count;

            RESTART_STEP = LGR ? step * 2 : step;

            FileReader br = new FileReader();

            void SetPosition(string name)
            {
                int index = Array.IndexOf(NAME[RESTART_STEP], name);
                long pointer = POINTER[RESTART_STEP][index];
                long pointerb = POINTERB[RESTART_STEP][index];
                br.SetPosition(pointerb * 2147483648 + pointer);
            }

            WELLS = new List<WELLDATA>();

            br.OpenBinaryFile(filename);
            SetPosition("INTEHEAD");
            br.ReadHeader();
            int[] INTH = br.ReadIntList();
            NX = INTH[8];
            NY = INTH[9];
            NZ = INTH[10];
            NACTIV = INTH[11];
            IPHS = INTH[14];
            NWELLS = INTH[16];
            NCWMAX = INTH[17];
            NIWELZ = INTH[24];
            NSWELZ = INTH[25];
            NXWELZ = INTH[26];
            NZWELZ = INTH[27];
            NICONZ = INTH[32];
            NSCONZ = INTH[33];
            NXCONZ = INTH[34];

            if (INTH[94] < 0) SIMTYPE = SIM_TYPE.OtherSim;
            else
            {
                if (Enum.IsDefined(typeof(SIM_TYPE), INTH[94]))
                {
                    SIMTYPE = (SIM_TYPE)INTH[94];
                }
            }

            if (NWELLS != 0)
            {
                SetPosition("IWEL");
                br.ReadHeader();
                int[] IWEL = br.ReadIntList();

                for (int iw = 0; iw < NWELLS; ++iw)
                {
                    WELLS.Add(new WELLDATA
                    {
                        WINDEX = iw,
                        I = IWEL[iw * NIWELZ + 0],
                        J = IWEL[iw * NIWELZ + 1],
                        K = IWEL[iw * NIWELZ + 2],
                        COMPLNUM = IWEL[iw * NIWELZ + 4],
                        GROUPNUM = IWEL[iw * NIWELZ + 5],
                        WELLTYPE = IWEL[iw * NIWELZ + 6],
                        WELLSTATUS = IWEL[iw * NIWELZ + 10],
                        LGR = IWEL[iw * NIWELZ + 42]
                    });
                }

                if (SIMTYPE != SIM_TYPE.IX) // Интерсект не выгружает данные по скважинам  и перфорациям
                {
                    SetPosition("SWEL");
                    br.ReadHeader();

                    float[] SWEL = br.ReadFloatList(br.header.count);

                    for (int iw = 0; iw < NWELLS; ++iw)
                    {
                        WELLS[iw].WOPRH = SWEL[iw * NSWELZ + 0];
                        WELLS[iw].WWPRH = SWEL[iw * NSWELZ + 1];
                        WELLS[iw].WGPRH = SWEL[iw * NSWELZ + 2];
                        WELLS[iw].WLPRH = SWEL[iw * NSWELZ + 3];
                        WELLS[iw].REF_DEPTH = SWEL[iw * NSWELZ + 9];

                        if (NSWELZ > 10) // Навигатор NSWELS = 10
                        {
                            WELLS[iw].WEFA = SWEL[iw * NSWELZ + 24];
                            WELLS[iw].WBHPH = SWEL[iw * NSWELZ + 68];
                        }
                    }

                    SetPosition("XWEL");

                    br.ReadHeader();

                    double[] XWEL = br.ReadDoubleList();

                    for (int iw = 0; iw < NWELLS; ++iw)
                    {
                        WELLS[iw].WOPR = XWEL[iw * NXWELZ + 0];
                        WELLS[iw].WWPR = XWEL[iw * NXWELZ + 1];
                        WELLS[iw].WLPR = XWEL[iw * NXWELZ + 3];
                        WELLS[iw].WBHP = XWEL[iw * NXWELZ + 6];
                        WELLS[iw].WWCT = XWEL[iw * NXWELZ + 7];
                        WELLS[iw].WOPT = XWEL[iw * NXWELZ + 18];
                        WELLS[iw].WWPT = XWEL[iw * NXWELZ + 19];
                        WELLS[iw].WWIT = XWEL[iw * NXWELZ + 23];
                        WELLS[iw].WPI = XWEL[iw * NXWELZ + 55];
                        WELLS[iw].WOPTH = XWEL[iw * NXWELZ + 75];
                        WELLS[iw].WWPTH = XWEL[iw * NXWELZ + 76];
                        WELLS[iw].WWITH = XWEL[iw * NXWELZ + 81];
                    }
                }

                SetPosition("ZWEL");
                br.ReadHeader();

                string[] ZWEL = br.ReadStringList();

                for (int iw = 0; iw < NWELLS; ++iw)
                {
                    for (int ic = 0; ic < NZWELZ; ++ic)
                    {
                        WELLS[iw].WELLNAME = WELLS[iw].WELLNAME + ZWEL[iw * NZWELZ + ic];
                    }
                    WELLS[iw].WELLNAME.Trim();
                }

                SetPosition("ICON");
                br.ReadHeader();
                int[] ICON = br.ReadIntList();

                for (int IW = 0; IW < NWELLS; ++IW) // Для всех скважин и для всех перфораций
                    for (int IC = 0; IC < NCWMAX; ++IC)
                    {
                        if (ICON[IW * NICONZ * NCWMAX + IC * NICONZ + 0] != 0) // Если перфорация существует
                        {
                            WELLS[IW].COMPLS.Add(new COMPLDATA
                            {
                                I = ICON[IW * NICONZ * NCWMAX + IC * NICONZ + 1] - 1,
                                J = ICON[IW * NICONZ * NCWMAX + IC * NICONZ + 2] - 1,
                                K = ICON[IW * NICONZ * NCWMAX + IC * NICONZ + 3] - 1,
                                STATUS = ICON[IW * NICONZ * NCWMAX + IC * NICONZ + 5]
                            });
                        }
                    }
            }
     
            br.CloseBinaryFile();
        }

        public void ReadFullWellData()
        {
             FileReader br = new FileReader();

            void SetPosition(string name)
            {
                int index = Array.IndexOf(NAME[RESTART_STEP], name);
                long pointer = POINTER[RESTART_STEP][index];
                long pointerb = POINTERB[RESTART_STEP][index];
                br.SetPosition(pointerb * 2147483648 + pointer);
            }

            br.OpenBinaryFile(FILENAME);
            SetPosition("INTEHEAD");
            br.ReadHeader();
            int[] INTH = br.ReadIntList();
            NX = INTH[8];
            NY = INTH[9];
            NZ = INTH[10];
            NACTIV = INTH[11];
            IPHS = INTH[14];
            NWELLS = INTH[16];
            NCWMAX = INTH[17];
            NIWELZ = INTH[24];
            NSWELZ = INTH[25];
            NXWELZ = INTH[26];
            NZWELZ = INTH[27];
            NICONZ = INTH[32];
            NSCONZ = INTH[33];
            NXCONZ = INTH[34];

            if (INTH[94] < 0) SIMTYPE = SIM_TYPE.OtherSim;
            else
            {
                if (Enum.IsDefined(typeof(SIM_TYPE), INTH[94]))
                {
                    SIMTYPE = (SIM_TYPE)INTH[94];
                }
            }

            if (WELLS.Count != 0)
            {
                if (SIMTYPE != SIM_TYPE.IX) // Интерсект не выгружает данные по скважинам  и перфорациям
                {
                    SetPosition("ICON");
                    br.ReadHeader();
                    int[] ICON = br.ReadIntList();

                    SetPosition("SCON");
                    br.ReadHeader();
                    float[] SCON = br.ReadFloatList(br.header.count);

                    SetPosition("XCON");
                    br.ReadHeader();
                    double[] XCON = br.ReadDoubleList();

                    for (int IW = 0; IW < NWELLS; ++IW) // Для всех скважин и для всех перфораций
                        for (int IC = 0; IC < NCWMAX; ++IC)
                        {
                            if (ICON[IW * NICONZ * NCWMAX + IC * NICONZ + 0] != 0) // Если перфорация существует
                            {
                                WELLS[IW].COMPLS[IC].CF = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 0];
                                WELLS[IW].COMPLS[IC].Depth = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 1];
                                WELLS[IW].COMPLS[IC].D = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 2];
                                WELLS[IW].COMPLS[IC].kh = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 3];
                                WELLS[IW].COMPLS[IC].S = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 4];
                                WELLS[IW].COMPLS[IC].Complex = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 6];
                                WELLS[IW].COMPLS[IC].H = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 31];
                                WELLS[IW].COMPLS[IC].s38 = SCON[IW * NSCONZ * NCWMAX + IC * NSCONZ + 38];

                                WELLS[IW].COMPLS[IC].OPR = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 0];
                                WELLS[IW].COMPLS[IC].WPR = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 1];
                                WELLS[IW].COMPLS[IC].GPR = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 2];
                                WELLS[IW].COMPLS[IC].OPT = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 3];
                                WELLS[IW].COMPLS[IC].WPT = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 4];
                                WELLS[IW].COMPLS[IC].GPT = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 5];
                                WELLS[IW].COMPLS[IC].Hw = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 9];
                                WELLS[IW].COMPLS[IC].PIO = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 23];
                                WELLS[IW].COMPLS[IC].PIW = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 24];
                                WELLS[IW].COMPLS[IC].PIG = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 25];
                                WELLS[IW].COMPLS[IC].PRESS = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 34];
                                WELLS[IW].COMPLS[IC].SOIL = XCON[IW * NXCONZ * NCWMAX + IC * NXCONZ + 35];
                            }
                        }
                }
            }

            br.CloseBinaryFile();
        }

        public void ReadGrid(string property)
        {
            int index = Array.IndexOf(NAME[RESTART_STEP], property);

            if (index == -1) return;

            FileReader br = new FileReader();
            br.OpenBinaryFile(FILENAME);

            if (UNITS.Count != 0)
            {
                GRIDUNIT = UNITS[RESTART_STEP][index].ToString();
            }

            long pointer = POINTER[RESTART_STEP][index];
            long pointerb = POINTERB[RESTART_STEP][index];


            br.SetPosition(pointerb * 2147483648 + pointer);
            br.ReadHeader();

            // Если модель запущена с NOSIM
            // то файл расчетов создается, но внутри массивы пустые

            DATA = br.ReadFloatList(br.header.count);
            
            br.CloseBinaryFile();
        }

        public float GetValue(long index)
        {
            return DATA[index];
        }

        public void ReadVectorFile()
        {
            // Проверка наличия массивов

            if (Array.IndexOf(NAME[RESTART_STEP],"FLRWATI +") == -1)
            {
                System.Diagnostics.Debug.WriteLine("RSSPEC : Read Vector File Not Found");
                return;
            }

            FileReader br = new FileReader();

            Action<string> SetPosition = (name) =>
            {
                int index = Array.IndexOf(NAME[RESTART_STEP], name);

                if (UNITS.Count != 0)
                {
                    GRIDUNIT = UNITS[RESTART_STEP][index].ToString();
                }

                long pointer = POINTER[RESTART_STEP][index];
                long pointerb = POINTERB[RESTART_STEP][index];


                br.SetPosition(pointerb * 2147483648 + pointer);
            };

            br.OpenBinaryFile(FILENAME);
            SetPosition("FLRWATI+");
            br.ReadHeader();

            FLOWI = br.ReadFloatList(br.header.count);

            SetPosition("FLRWATJ+");
            br.ReadHeader();

            FLOWJ = br.ReadFloatList(br.header.count);

            br.CloseBinaryFile();
        }
    }


}
