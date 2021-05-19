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

    public class ProjectManager
    {
        public event EventHandler<BinaryReaderArg> UpdateLoadingProgress;

        private int selectedIndex= -1;
        private readonly List<ProjectManagerItem> projects = new List<ProjectManagerItem>();

        public EclipseProject ECL
        {
            get
            {
                return projects[selectedIndex].ecl;
            }
        }

        public void OpenECLProject()
        {
            OpenFileDialog fd = new OpenFileDialog() { Filter = "Eclipse file|*.SMSPEC" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                var item = new ProjectManagerItem();

                item.ecl.UpdateLoadingProgress += EclOnUpdateLoadingProgress;
                item.ecl.OpenData(fd.FileName);
                item.name = item.ecl.ROOT;
                item.selected = true;

                ResetSelection();
                projects.Add(item);
                selectedIndex = projects.Count - 1;
            }
        }

        private void ResetSelection()
        {
            foreach (ProjectManagerItem item in projects)
            {
                item.selected = false;
            }
        }

        public List<string> GetProjectNames()
        {
            return projects.Select(c => c.name).ToList();
        }

        public int GetSelectedIndex()
        {
            return selectedIndex;
        }
        public void DeleteSelectedProject()
        {
            projects.RemoveAt(selectedIndex);
            selectedIndex = -1;

            if (projects.Count > 0)
            {
                projects.Last().selected = true;
                selectedIndex = projects.Count - 1;
            }
        }

        public void SelectProject(int index)
        {
            ResetSelection();

            selectedIndex = index;
            projects[index].selected = true;
        }

        public void UpdateSelectedProject()
        {
            string filename = projects[selectedIndex].ecl.FILENAME;
            projects[selectedIndex].ecl.OpenData(filename);
        }
        
        private void EclOnUpdateLoadingProgress(object sender, BinaryReaderArg e)
        {
            UpdateLoadingProgress?.Invoke(sender, e);
        }
    }
}
