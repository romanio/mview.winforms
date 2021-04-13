using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public class ProjectManagerItem
    {
        public EclipseProject ecl = new EclipseProject();
        public string name = null;
        public bool selected = false;
    }

    public class VirtualGroupItem
    {
        public string wellname;
        public string pad;
    }

    public class ProjectManager
    {
        public List<ProjectManagerItem> projectList = new List<ProjectManagerItem>();
        public List<VirtualGroupItem> virtualGroup = null;
        public int activeProjectIndex = -1;
        public EclipseProject activeProject;
        public event EventHandler<EclipseLoadingArg> UpdateLoadingProgress;

        public void OpenECLProject()
        {
            OpenFileDialog fd = new OpenFileDialog() {Filter = "Eclipse file|*.SMSPEC" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                var item = new ProjectManagerItem();
                item.ecl.UpdateLoadingProgress += EclOnUpdateLoadingProgress;
                item.ecl.OpenData(fd.FileName);
                item.name = item.ecl.ROOT;
                item.selected = true;

                projectList.Add(item);

                activeProject = projectList.Last().ecl;  // Set last project as active
                activeProjectIndex = projectList.Count - 1;
            }
        }

        private void EclOnUpdateLoadingProgress(object sender, EclipseLoadingArg e)
        {
            UpdateLoadingProgress?.Invoke(sender, e);
        }

        public void DeleteActiveProject()
        {
            projectList.RemoveAt(activeProjectIndex);

            if (projectList.Count > 0)
            {
                activeProject = projectList.Last().ecl;
                activeProjectIndex = projectList.Count - 1;
            }
            else // полное удаление
            {
                activeProjectIndex = -1;
                activeProject = null;
            }
        }


        public void SetActiveProject(int index)
        {
            activeProjectIndex = index;
            activeProject = projectList[index].ecl;
        }

        public void UpdateActiveProject()
        {
            activeProject.OpenData(activeProject.FILENAME);
        }

    }
}
