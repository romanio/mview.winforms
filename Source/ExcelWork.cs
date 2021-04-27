using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;


namespace mview
{
    public class ExcelWork
    {
        public void ExportToExcel(EclipseProject ecl)
        {
            var XL = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = false,
                Interactive = false,
                ScreenUpdating = false,
                SheetsInNewWorkbook = 1
            };

            Workbook wb = XL.Workbooks.Add();
            Worksheet ws = XL.Worksheets[1];
            ws.Name = "DATA";

            var range = ws.get_Range(
                ((Range)ws.Cells[2, 1]).Address,
                ((Range)ws.Cells[2 + ecl.SUMMARY.KEYWORDS.Length - 1, 4]).Address);

            object[,] keys = new object[ecl.SUMMARY.KEYWORDS.Length, 4];

            for (int iw = 0; iw < ecl.SUMMARY.KEYWORDS.Length; ++iw)
            {
                keys[iw, 0] = ecl.SUMMARY.KEYWORDS[iw];
                keys[iw, 1] = ecl.SUMMARY.WGUNITS[iw];
                keys[iw, 2] = ecl.SUMMARY.WGNAMES[iw];
                keys[iw, 3] = ecl.SUMMARY.NUMS[iw];
            }
            range.Value = keys;

            range = ws.get_Range(
                ((Range)ws.Cells[2, 5]).Address,
                ((Range)ws.Cells[2 + ecl.SUMMARY.KEYWORDS.Length - 1, 5 + ecl.SUMMARY.NTIME - 1]).Address);

            object[,] data = new object[ecl.SUMMARY.KEYWORDS.Length, ecl.SUMMARY.NTIME];

            for (int it = 0; it < ecl.SUMMARY.NTIME; ++it)
            {
                for (int iw = 0; iw < ecl.SUMMARY.KEYWORDS.Length; ++iw)
                {
                    data[iw, it] = ecl.SUMMARY.DATA[it][iw];
                }
            }

            range.Value = data;
            XL.Visible = true;
            XL.Interactive = true;
            XL.ScreenUpdating = true;
        }
    }
}
