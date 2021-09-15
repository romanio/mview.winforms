using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class ChartModel
    {
        private EclipseProject ecl = null;

        public ChartModel(EclipseProject ecl)
        {
            UpdateECL(ecl);
        }

        public void UpdateECL(EclipseProject ecl)
        {
            this.ecl = ecl;
        }

        public List<AnnotationItem> GetAnnotation(string wellname)
        {
            return ecl.userAnnotations.GetAnnotation(wellname);
        }

        public DateTime GetDateByStep(int step)
        {
            return ecl.SUMMARY.DATES[step];
        }

        public float GetParamAtIndex(int index, int step)
        {
            return ecl.SUMMARY.DATA[step][index];
        }

        public string[] GetKeywords(string name, NameOptions type)
        {
            var vector = ecl.VECTORS.FirstOrDefault(c => c.Name == name && c.Type == type);
            return vector.Data.Select(c => c.keyword).ToArray();
        }

        public Vector GetDataVector(string name)
        {
            return ecl.VECTORS.FirstOrDefault(c => c.Name == name);
        }

        public List<OxyPlot.DataPoint> GetDataTime(string name, string keyword)
        {
            var vector = ecl.VECTORS.FirstOrDefault(c => c.Name == name);

            List<OxyPlot.DataPoint> oxyData = new List<OxyPlot.DataPoint>();

            if (vector != null)
            {
                var data = vector.Data.FirstOrDefault(c => c.keyword == keyword);

                for (int it = 0; it < ecl.SUMMARY.NTIME; ++it)
                {
                    double value = ecl.SUMMARY.DATA[it][data.index];
                    oxyData.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(ecl.SUMMARY.DATES[it]), value));
                }
            }
            else // if not found, return zero vector
            {
                for (int it = 0; it < ecl.SUMMARY.NTIME; ++it)
                {
                    oxyData.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(ecl.SUMMARY.DATES[it]), 0));
                }
            }

            return oxyData;
        }

        public string[] GetAllKeywords()
        {
            return ecl.SUMMARY.KEYWORDS.Distinct().ToArray();
        }

        public string[] GetNamesByType(NameOptions type)
        {
            return ecl.VECTORS.Where(c => c.Type == type).Select(c => c.Name).ToArray();
        }

        public int GetStepCount()
        {
            return ecl.SUMMARY.NTIME;
        }
    }
}