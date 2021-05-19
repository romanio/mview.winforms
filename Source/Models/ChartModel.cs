using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class ChartModel
    {
        private readonly ProjectManager pm = new ProjectManager();
        private readonly UserAnnotations userAnnotations = new UserAnnotations();

        public event EventHandler<BinaryReaderArg> UpdateLoadingProgress;

        public void UpdateActiveProject()
        {
            pm.UpdateSelectedProject();
        }

        public void OpenNewModel()
        {
            pm.UpdateLoadingProgress += PmOnUpdateLoadingProgress;
            pm.OpenECLProject();
        }

        public void OpenUserAnnotation()
        {
            userAnnotations.LoadUserFunctions();
        }

        public List<AnnotationItem> GetAnnotation(string wellname)
        {
            return userAnnotations.GetAnnotation(wellname);
        }

        private void PmOnUpdateLoadingProgress(object sender, BinaryReaderArg e)
        {
            UpdateLoadingProgress?.Invoke(sender, e);
        }

        public DateTime GetDateByStep(int step)
        {
            return pm.ECL.SUMMARY.DATES[step];
        }

        public float GetParamAtIndex(int index, int step)
        {
            return pm.ECL.SUMMARY.DATA[step][index];
        }

        public string[] GetKeywords(string name, NameOptions type)
        {
            var vector = pm.ECL.VECTORS.FirstOrDefault(c => c.Name == name && c.Type == type);
            return vector.Data.Select(c => c.keyword).ToArray();
        }

        public Vector GetDataVector(string name)
        {
            return pm.ECL.VECTORS.FirstOrDefault(c => c.Name == name);
        }

        public List<OxyPlot.DataPoint> GetDataTime(string name, string keyword)
        {
            var vector = pm.ECL.VECTORS.FirstOrDefault(c => c.Name == name);

            List<OxyPlot.DataPoint> oxyData = new List<OxyPlot.DataPoint>();

            if (vector != null)
            {
                var data = vector.Data.FirstOrDefault(c => c.keyword == keyword);

                for (int it = 0; it < pm.ECL.SUMMARY.NTIME; ++it)
                {
                    double value = pm.ECL.SUMMARY.DATA[it][data.index];
                    oxyData.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(pm.ECL.SUMMARY.DATES[it]), value));
                }
            }
            else // if not found, return zero vector
            {
                for (int it = 0; it < pm.ECL.SUMMARY.NTIME; ++it)
                {
                    oxyData.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(pm.ECL.SUMMARY.DATES[it]), 0));
                }
            }

            return oxyData;
        }


        public List<string> GetProjectNames()
        {
            return pm.GetProjectNames();
        }

        public int GetSelectedProjectIndex()
        {
            return pm.GetSelectedIndex();
        }

        public void SetSelectedProject(int index)
        {
            pm.SelectProject(index);
        }

        public void DeleteSelectedProject()
        {
            pm.DeleteSelectedProject();
        }

        /*
        public string GetActiveProjectName()
        {
            return pm.projectList[pm.activeProjectIndex].name;
        }
        */

        public void ExportToExcel()
        {
            var excel = new ExcelWork();
            excel.ExportToExcel(pm.ECL);
        }

        public string[] GetAllKeywords()
        {
            return pm.ECL.SUMMARY.KEYWORDS.Distinct().ToArray();
        }

        public string[] GetNamesByType(NameOptions type)
        {
            return pm.ECL.VECTORS.Where(c => c.Type == type).Select(c => c.Name).ToArray();
        }

        public int GetStepCount()
        {
            return pm.ECL.SUMMARY.NTIME;
        }

    }

}