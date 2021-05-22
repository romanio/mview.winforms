using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public class ProjectManager
    {
        private int selectedIndex = -1;

        private readonly List<EclipseProject> projects = new List<EclipseProject>();

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }

        public EclipseProject ECL
        {
            get
            {
                return projects[selectedIndex];
            }
        }

        public List<string> GetProjectNames()
        {
            return projects.Select(c => c.ROOT).ToList();
        }

        public void OpenECLProject(EventHandler<BinaryReaderArg> eventHandler)
        {
            OpenFileDialog fd = new OpenFileDialog() { Filter = "Eclipse file|*.SMSPEC" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                var item = new EclipseProject();

                item.UpdateLoadingProgress += eventHandler;
                item.OpenData(fd.FileName);

                projects.Add(item);
                selectedIndex = projects.Count - 1;
            }
        }

        public void UpdateSelectedProject()
        {
            string filename = projects[selectedIndex].FILENAME;
            projects[selectedIndex].OpenData(filename);
        }

        public void DeleteSelectedProject()
        {
            projects.RemoveAt(selectedIndex);
            selectedIndex = -1;

            if (projects.Count > 0)
            {
                selectedIndex = projects.Count - 1;
            }
        }

    }
}
