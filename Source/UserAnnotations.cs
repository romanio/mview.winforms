using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OxyPlot;
using System.Windows.Forms;

namespace mview
{
    public class AnnotationItem
    {
        public DateTime time;
        public string wellname;
        public string text;
    }

    public class UserAnnotations
    {
        List<AnnotationItem> annotationList = null;

        public string filename = "Path : None";

        public List<AnnotationItem> GetAnnotation(string wellname)
        {
            if (annotationList == null) return null;

            return
                 (from item in annotationList
                  where item.wellname == wellname && item.text != ""
                  select new AnnotationItem { time = item.time, text = item.text }).ToList();
        }


        public void LoadUserFunctions()
        {
            var fd = new OpenFileDialog() { Filter = "User file|*.csv" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                annotationList = new List<AnnotationItem>();
                filename = fd.FileName;

                using (TextReader text = new StreamReader(fd.FileName, Encoding.GetEncoding("Windows-1251")))
                {
                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        string[] split = line.Split(new char[] { ';' });

                        if (split.Length == 3)
                        {
                            annotationList.Add(new AnnotationItem
                            {
                                wellname = split[0].Trim(),
                                time = Convert.ToDateTime(split[1]),
                                text = split[2]
                            });
                        }
                    }

                    text.Close();
                }
            }
        }
    }
}
