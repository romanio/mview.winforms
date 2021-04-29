using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public interface ITabObserver
    {
        void UpdateSelectedWells(TabSelectedWellsData data);
        void UpdateSelectedProjects();
    }

    public class TabSelectedWellsData
    {
        public List<string> selectedNames;
        public NameOptions type;
        public List<string> names;
    }
}
