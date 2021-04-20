using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using System.IO;

namespace mview
{
    public class SeriesStyle
    {
        public string name;
        public OxyColor lineColor;
        public OxyColor markerColor;
        public OxyColor markerFillColor;
        public int markerSize;
        public int lineWidth;
        public bool lineSmooth;
        public MarkerType markerType;
        public LineStyle lineStyle;
    }

    public class StyleSettings
    {
        readonly List<SeriesStyle> listSeriesStyle = new List<SeriesStyle>();

        public LineStyle axisXStyle = LineStyle.None;
        public LineStyle axisYStyle = LineStyle.None;
        
        public int axisXWidth = 1;
        public int axisYWidth = 1;

        public OxyColor axisXColor;
        public OxyColor axisYColor;

        public OxyPlot.Legends.LegendPosition LegendPosition = OxyPlot.Legends.LegendPosition.TopRight;

        public string axisX = "Time";
        public string axisY = "Normal";

        public void UpdateStyle(SeriesStyle style)
        {
            int index = GetIndex(style.name);

            if (index == -1)
            {
                listSeriesStyle.Add(style);
            }
            else
            {
                listSeriesStyle[index] = style;
            }
        }

        public int GetIndex(string name)
        {
            for (int iw = 0; iw < listSeriesStyle.Count; ++iw)
            {
                if (listSeriesStyle[iw].name == name)
                    return iw;
            }
            return -1;
        }

        public void SaveSettings()
        {
            using (TextWriter text = new StreamWriter(System.Windows.Forms.Application.StartupPath + "/mview.ini", false))
            {
                // Сохраним настройки графика

                text.WriteLine(axisXStyle);
                text.WriteLine(axisXWidth);
                text.WriteLine(axisXColor.ToUint());

                text.WriteLine(axisYStyle);
                text.WriteLine(axisYWidth);
                text.WriteLine(axisYColor.ToUint());

                text.WriteLine(LegendPosition);

                // Сохраним настройки линий графика

                text.WriteLine(listSeriesStyle.Count);

                for (int iw = 0; iw < listSeriesStyle.Count; ++iw)
                {
                    text.WriteLine(listSeriesStyle[iw].name);

                    text.WriteLine(listSeriesStyle[iw].lineColor.ToUint());
                    text.WriteLine(listSeriesStyle[iw].markerColor.ToUint());
                    text.WriteLine(listSeriesStyle[iw].markerFillColor.ToUint());

                    text.WriteLine(listSeriesStyle[iw].markerSize);
                    text.WriteLine(listSeriesStyle[iw].lineWidth);
                    text.WriteLine(listSeriesStyle[iw].lineSmooth);

                    text.WriteLine(listSeriesStyle[iw].markerType);
                    text.WriteLine(listSeriesStyle[iw].lineStyle);
                }

                text.Close();
            }
        }

        public void LoadSettings()
        {
            string filename = System.Windows.Forms.Application.StartupPath + "/mview.ini";

            if (System.IO.File.Exists(filename))
            {
                using (TextReader text = new StreamReader(filename))
                {
                    axisXStyle = (LineStyle)Enum.Parse(typeof(LineStyle), text.ReadLine(), true);
                    axisXWidth = Int32.Parse(text.ReadLine());
                    axisXColor = OxyColor.FromUInt32(UInt32.Parse(text.ReadLine()));

                    axisYStyle = (LineStyle)Enum.Parse(typeof(LineStyle), text.ReadLine(), true);
                    axisYWidth = Int32.Parse(text.ReadLine());
                    axisYColor = OxyColor.FromUInt32(UInt32.Parse(text.ReadLine()));

                    LegendPosition = (OxyPlot.Legends.LegendPosition)Enum.Parse(typeof(OxyPlot.Legends.LegendPosition), text.ReadLine(), true);

                    int count = Int32.Parse(text.ReadLine());

                    for (int iw = 0; iw < count; ++iw)
                    {
                        var tmpStyle = new SeriesStyle();

                        tmpStyle.name = text.ReadLine();
                        tmpStyle.lineColor = OxyColor.FromUInt32(UInt32.Parse(text.ReadLine()));
                        tmpStyle.markerColor = OxyColor.FromUInt32(UInt32.Parse(text.ReadLine()));
                        tmpStyle.markerFillColor = OxyColor.FromUInt32(UInt32.Parse(text.ReadLine()));
                        tmpStyle.markerSize = Int32.Parse(text.ReadLine());
                        tmpStyle.lineWidth = Int32.Parse(text.ReadLine());
                        tmpStyle.lineSmooth = Boolean.Parse(text.ReadLine());
                        tmpStyle.markerType = (MarkerType)Enum.Parse(typeof(MarkerType), text.ReadLine(), true);
                        tmpStyle.lineStyle = (LineStyle)Enum.Parse(typeof(LineStyle), text.ReadLine(), true);
                        listSeriesStyle.Add(tmpStyle);
                    }

                    text.Close();
                }
            }
        }

        public SeriesStyle GetStyle(string name)
        {
            int index = GetIndex(name);

            if (index != -1) return GetStyle(index);
            
            return null;
        }

        public SeriesStyle GetStyle(int index)
        {
            return listSeriesStyle[index];
        }
          
    }
}
