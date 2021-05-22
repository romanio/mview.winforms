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
        void UpdateSelectedProjects(EclipseProject ecl);
    }

    public class TabSelectedWellsData
    {
        public List<string> selectedNames;
        public List<string> names;
        public NameOptions type;
    }
}
