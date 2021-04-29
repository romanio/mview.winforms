using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class MainFormModel
    {
        private readonly ProjectManager pm = new ProjectManager();

        public event EventHandler<BinaryReaderArg> UpdateLoadingProgress;

        public void UpdateActiveProject()
        {
            pm.UpdateActiveProject();
        }

        public void OpenNewModel()
        {
            pm.UpdateLoadingProgress += PmOnUpdateLoadingProgress;
            pm.OpenECLProject();
            
        }

        private void PmOnUpdateLoadingProgress(object sender, BinaryReaderArg e)
        {
            UpdateLoadingProgress?.Invoke(sender, e);
        }

        public DateTime GetDateByStep(int step)
        {
            return pm.activeProject.SUMMARY.DATES[step];
        }

        public float GetParamAtIndex(int index, int step)
        {
            return pm.activeProject.SUMMARY.DATA[step][index];
        }

        public string[] GetKeywords(string name, NameOptions type)
        {
            var vector = pm.activeProject.VECTORS.FirstOrDefault(c => c.Name == name && c.Type == type);
            return vector.Data.Select(c => c.keyword).ToArray();
        }

        public Vector GetDataVector(string name)
        {
            return pm.activeProject.VECTORS.FirstOrDefault(c => c.Name == name);
        }

        public List<OxyPlot.DataPoint> GetDataTime(int projectIndex, string name, string keyword)
        {
            var vector = pm.projectList[projectIndex].ecl.VECTORS.FirstOrDefault(c => c.Name == name);

            List<OxyPlot.DataPoint> oxyData = new List<OxyPlot.DataPoint>();

            if (vector != null)
            {
                var data = vector.Data.FirstOrDefault(c => c.keyword == keyword);

                for (int it = 0; it < pm.projectList[projectIndex].ecl.SUMMARY.NTIME; ++it)
                {
                    double value = pm.projectList[projectIndex].ecl.SUMMARY.DATA[it][data.index];
                    oxyData.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(pm.projectList[projectIndex].ecl.SUMMARY.DATES[it]), value));
                }
            }
            else // if not found, return zero vector
            {
                for (int it = 0; it < pm.projectList[projectIndex].ecl.SUMMARY.NTIME; ++it)
                {
                    oxyData.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(pm.projectList[projectIndex].ecl.SUMMARY.DATES[it]), 0));
                }
            }
            return oxyData;
        }


        public List<string> GetProjectNames()
        {
            return
                (from item in pm.projectList
                 select item.name).ToList();
        }

        public List<int> GetSelectedProjectIndex()
        {
            var indices = new List<int>();

            for (int it = 0; it < pm.projectList.Count; ++it)
                if (pm.projectList[it].selected) indices.Add(it);

            return indices;
        }

        public void SetSelectedProjectIndex(List<int> selectedIndices)
        {
            // Снять выделение

            for (int it = 0; it < pm.projectList.Count; ++it)
                pm.projectList[it].selected = false;


            for (int it = 0; it < selectedIndices.Count; ++it)
                pm.projectList[selectedIndices[it]].selected = true;

            // Первый в списке назначается активным

            if (selectedIndices.Count > 0)
                pm.SetActiveProject(selectedIndices[0]);
        }

        public void DeleteSelectedProject()
        {
            pm.DeleteActiveProject();
        }

        public string GetActiveProjectName()
        {
            return pm.projectList[pm.activeProjectIndex].name;
        }

        public void ExportToExcel()
        {
            var excel = new ExcelWork();
            excel.ExportToExcel(pm.activeProject);
        }

        public string[] GetAllKeywords()
        {
            return pm.activeProject?.SUMMARY.KEYWORDS.Distinct().ToArray();
        }

        public string[] GetNamesByType(NameOptions type)
        {
            return
                (from item in pm.activeProject.VECTORS
                 where item.Type == type
                 select item.Name).ToArray();
        }

        public int GetStepCount()
        {
            return pm.activeProject.SUMMARY.NTIME;
        }

        public int GetStepCount(int projectIndex)
        {
            return pm.projectList[projectIndex].ecl.SUMMARY.NTIME;
        }
    }

}