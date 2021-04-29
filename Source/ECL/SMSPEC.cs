using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview.ECL
{
    public class SMSPEC
    {
        public DateTime STARTDATE; // Начальная дата расчёта
        public int NLIST; // Количество векторов, которое записано на каждый временный шаг
        public int NDIVX; // Количество ячеек по X
        public int NDIVY; // Количество ячеек по Y
        public int NDIVZ; // Количество ячеек по Z
        public int ISTAR; // Номер шага рестарта, с которого произведен запуск
        public string RESTART; // Имя рестарта
        public int[] NUMS = null; // Дополнительная информация о векторах, например номер региона, аквифера итд
        public string[] KEYWORDS = null; // Список ключевых слов
        public string[] WGNAMES = null; // Имена скважин или групп
        public string[] WGUNITS = null; // Размерность ключевого слова
        public string[] MEASRMNT = null;
        public List<float[]> DATA = null; // Расчётные показатели
        public int TINDEX; // Индекс вектора TIME
        public int NTIME; // Количество временных шагов
        public DateTime[] DATES = null;

        public event EventHandler<BinaryReaderArg> UpdateLoadingData;

        public void InitSMSPEC(string filename)
        {
            FileReader br = new FileReader();

            UpdateLoadingData?.Invoke(null, new BinaryReaderArg { filename = filename });

            //br.UpdateData += OnBinaryReaderUpdateData;

            br.OpenBinaryFile(filename);

            while (br.Position < br.Length - 24)
            {
                br.ReadHeader();

                if (br.header.keyword == "RESTART")
                {
                    var tmp = br.ReadStringList();
                    StringBuilder str = new StringBuilder();
                    foreach (string item in tmp)
                        str.Append(item);

                    RESTART = str.ToString();
                    continue;
                }

                if (br.header.keyword == "MEASRMNT")
                {
                    if (br.header.count == 0) continue;

                    var tmp = br.ReadStringList();
                    int lenght = br.header.count / NLIST;
                    MEASRMNT = new string[NLIST];
                    StringBuilder str = new StringBuilder();
                    for (int iw = 0; iw < NLIST; ++iw)
                    {
                        str.Clear();
                        for (int ik = 0; ik < lenght; ++ik)
                            str.Append(tmp[iw * lenght + ik]);
                        MEASRMNT[iw] = str.ToString();
                    }
                    continue;
                }

                if (br.header.keyword == "DIMENS")
                {
                    br.ReadBytes(4);
                    NLIST = br.ReadInt32();
                    NDIVX = br.ReadInt32();
                    NDIVY = br.ReadInt32();
                    NDIVZ = br.ReadInt32();
                    br.ReadBytes(4);
                    ISTAR = br.ReadInt32();
                    br.ReadBytes(4);
                    continue;
                }
                if (br.header.keyword == "KEYWORDS")
                {
                    KEYWORDS = br.ReadStringList();
                    continue;
                }

                if (br.header.keyword == "WGNAMES")
                {
                    WGNAMES = br.ReadStringList();
                    continue;
                }

                if (br.header.keyword == "NAMES")
                {
                    WGNAMES = br.ReadC0StringList();
                    continue;
                }

                if (br.header.keyword == "NUMS")
                {
                    NUMS = br.ReadIntList();
                    continue;
                }

                if (br.header.keyword == "UNITS")
                {
                    WGUNITS = br.ReadStringList();
                    continue;
                }

                if (br.header.keyword == "STARTDAT")
                {
                    br.ReadBytes(4);
                    int SDAY = br.ReadInt32();
                    int SMONTH = br.ReadInt32();
                    int SYEAR = br.ReadInt32();

                    STARTDATE = new DateTime(SYEAR, SMONTH, SDAY);

                    if (br.header.count > 3)
                    {
                        int SHOUR = br.ReadInt32();
                        int SMINUTE = br.ReadInt32();
                        int SSECOND = (int)(br.ReadInt32() * 1e6);
                        STARTDATE = new DateTime(SYEAR, SMONTH, SDAY, SHOUR, SMINUTE, SSECOND);
                     }
                    br.ReadBytes(4);
                    continue;
                }
                br.SkipEclipseData();
            }
            br.CloseBinaryFile();
        }

        private void OnBinaryReaderUpdateData(object sender, BinaryReaderArg e)
        {
            UpdateLoadingData?.Invoke(sender, e);
        }

        public void ReadUNSMRY(string filename)
        {
            FileReader br = new FileReader();

            UpdateLoadingData?.Invoke(null, new BinaryReaderArg { filename = filename });

            br.OpenBinaryFile(filename);
            if (br.Length > 0)
            {
                DATA = new List<float[]>();

                while (br.Position < br.Length - 24)
                {
                    br.ReadHeader();
                    if (br.header.keyword == "PARAMS" && br.header.count == NLIST)
                    {
                        DATA.Add(br.ReadFloatList(NLIST));
                        continue;
                    }
                    br.SkipEclipseData();
                }
            }
            br.CloseBinaryFile();

            AfterSMRYRead();
        }

        void AfterSMRYRead()
        {
            NTIME = DATA.Count;
            TINDEX = Array.IndexOf(KEYWORDS, "TIME");

            DATES = new DateTime[NTIME];

            for (int it = 0; it < NTIME; ++it)
            {
                DATES[it] = STARTDATE.AddDays(DATA[it][TINDEX]);
            }
        }


        public void ReadSNNN(string[] filenames)
        {
            DATA = new List<float[]>();

            for (int iw = 0; iw < filenames.Length; ++iw)
            {
                FileReader br = new FileReader();

                UpdateLoadingData?.Invoke(null, new BinaryReaderArg { filename = filenames[iw] });

                br.OpenBinaryFile(filenames[iw]);

                if (br.Length == 0) break;

                while (br.Position < br.Length - 24)
                {
                    br.ReadHeader();
                    if (br.header.keyword == "PARAMS" && br.header.count == NLIST)
                    {
                        DATA.Add(br.ReadFloatList(NLIST));
                        continue;
                    }
                    br.SkipEclipseData();
                }

                br.CloseBinaryFile();
            }

            AfterSMRYRead();
        }
    }
}
