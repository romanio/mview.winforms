using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace mview
{
    public class VirtualGroupItem
    {
        public string wellname;
        public string pad;
    }

    public class WellFilterSettings
    {
        readonly List<VirtualGroupItem> virtualGroups = new List<VirtualGroupItem>();

        public void LoadFromFile()
        {
            var fd = new OpenFileDialog() { Filter = "User group file|*.csv" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                virtualGroups.Clear();

                using (TextReader text = new StreamReader(fd.FileName, Encoding.GetEncoding("Windows-1251")))
                {
                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        string[] split = line.Split(new char[] { ';' });

                        if (split.Length == 2)
                        {
                            virtualGroups.Add(new VirtualGroupItem
                            {
                                wellname = split[0].Trim(),
                                pad = split[1].Trim()
                            });
                        }
                    }
                    text.Close();
                }
            }
        }

        public string[] GetVirtualGroups()
        {
            var pads = (from item in virtualGroups
                            select item.pad).Distinct().ToArray();
                return pads;
        }

        public string[] GetNamesFromVGroup(string selectedPad)
        {
            var wells = (from item in virtualGroups
                         where item.pad == selectedPad
                         select item.wellname).ToArray();

            return wells.ToArray();
        }

    }
}
