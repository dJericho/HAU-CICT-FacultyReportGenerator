using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ReportGenerator
{
    class GenerateReport
    {
        public static bool GenerateExcel()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel Files|*.xlsx";
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                Application xl = new Application();
                if (xl == null)
                    return false;
                var wb = xl.Workbooks.Add();
                var ws = (Worksheet)wb.Worksheets[1];
                ws.Name = "Seminars";
                if (ws == null)
                    return false;



                ws.Cells[3, 1] = "Name";

                ws.Cells[4, 1] = "Post-Grad";
                ws.Cells[5, 1] = "Under-grad";
                ws.Cells[3, 2] = CurrentUser.user.name;
                ws.Cells[4, 2] = CurrentUser.user.postgrad;
                ws.Cells[5, 2] = CurrentUser.user.undergrad;

                ws.Cells[4, 4] = "Year";
                ws.Cells[5, 4] = "Year";
                ws.Cells[4, 5] = CurrentUser.user.postgradYear;
                ws.Cells[5, 5] = CurrentUser.user.undergradYear;
                ws.Cells[4, 6] = "Expected Date";
                ws.Cells[4, 7] = CurrentUser.user.postgradExpectedYear == String.Empty ? "N/A" : CurrentUser.user.postgradExpectedYear;

                ws.Range[ws.Cells[7, 1], ws.Cells[7, 3]].Merge();
                ws.Cells[7, 1] = "SEMINARS ATTENDED";
                ws.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Range[ws.Cells[7, 4], ws.Cells[7, 8]].Merge();
                ws.Cells[7, 4] = "COURSES ALIGNED";
                ws.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Cells[8, 1] = "DATE";
                ws.Cells[8, 2] = "TITLE";
                ws.Cells[8, 3] = "VENUE";

                int i = 0;
                foreach (Classification x in ClassificationVM.Classifications)
                {
                    ws.Cells[8, i + 4] = x.classification;
                    ws.Cells[8, i + 4].Orientation = 45;
                    i++;
                }
                i = 0;
                int cs = 0, an = 0, wd = 0, nw = 0, al = 0;
                foreach (Attendance x in AttendanceVM.specificAttendances)
                {
                    ws.Cells[i + 9, 1] = x.seminar.date;
                    ws.Cells[i + 9, 2] = x.seminar.seminarName;
                    ws.Cells[i + 9, 3] = x.seminar.venue;
                    //√
                    if (x.seminar.classId == 3)
                    {
                        ws.Cells[i + 9, 4] = "√";
                        cs++;
                    }
                    if (x.seminar.classId == 4)
                    {
                        ws.Cells[i + 9, 5] = "√";
                        an++;
                    }
                    if (x.seminar.classId == 5)
                    {
                        ws.Cells[i + 9, 6] = "√";
                        wd++;
                    }
                    if (x.seminar.classId == 6)
                    {
                        ws.Cells[i + 9, 7] = "√";
                        nw++;
                    }
                    if (x.seminar.classId == 7)
                    {
                        ws.Cells[i + 9, 8] = "√";
                        al++;
                    }
                    i++;
                }
                ws.Cells[i + 9, 3] = "TOTAL: ";
                ws.Cells[i + 9, 4] = cs;
                ws.Cells[i + 9, 5] = an;
                ws.Cells[i + 9, 6] = wd;
                ws.Cells[i + 9, 7] = nw;
                ws.Cells[i + 9, 8] = al;



                //UNDERLINES
                Range range = ws.Cells[3, 2];
                underline(range);
                range = ws.Cells[4, 2];
                underline(range);
                range = ws.Cells[5, 2];
                underline(range);
                range = ws.Cells[4, 5];
                underline(range);
                range = ws.Cells[5, 5];
                underline(range);
                range = ws.Cells[4, 7];
                underline(range);
                //FULL BORDERS
                range = ws.Range[ws.Cells[7, 1], ws.Cells[i + 8, 8]];
                fullBorders(range);
                range = ws.Range[ws.Cells[i + 9, 3], ws.Cells[i + 9, 8]];
                fullBorders(range);

                ws.Columns.AutoFit();

                //NEW WORKSHEET
                ws = wb.Worksheets.Add();
                //var ws2 = (Worksheet)wb.Worksheets[2];
                ws.Name = "Subjects";

                ws.Cells[3, 1] = "Name";
                ws.Cells[4, 1] = "Post-Grad";
                ws.Cells[5, 1] = "Under-grad";
                ws.Cells[3, 2] = CurrentUser.user.name;
                ws.Cells[4, 2] = CurrentUser.user.postgrad;
                ws.Cells[5, 2] = CurrentUser.user.undergrad;
                ws.Cells[4, 4] = "Year";
                ws.Cells[5, 4] = "Year";
                ws.Cells[4, 5] = CurrentUser.user.postgradYear;
                ws.Cells[5, 5] = CurrentUser.user.undergradYear;
                ws.Cells[4, 6] = "Expected Date";
                ws.Cells[4, 7] = CurrentUser.user.postgradExpectedYear == String.Empty ? "N/A" : CurrentUser.user.postgradExpectedYear;

                ws.Range[ws.Cells[7, 4], ws.Cells[7, 8]].Merge();
                ws.Cells[7, 4] = "COURSE";
                ws.Cells[7, 4].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Cells[8, 1] = "Subject";
                ws.Cells[8, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Range[ws.Cells[8, 1], ws.Cells[8, 3]].Merge();
                i = 0;
                foreach (Classification x in ClassificationVM.Classifications)
                {
                    ws.Cells[8, i + 4] = x.classification;
                    ws.Cells[8, i + 4].Orientation = 45;
                    i++;
                }
                i = 0; cs = 0; nw = 0; wd = 0; an = 0; al = 0;
                foreach (FacultyLoads x in LoadsVM.specificLoads)
                {
                    ws.Cells[i + 9, 1] = x.subject.name;
                    ws.Range[ws.Cells[i + 9, 1], ws.Cells[i + 9, 3]].Merge();

                    if (x.subject.classID == 3)
                    {
                        ws.Cells[i + 9, 4] = "√";
                        cs++;
                    }
                    if (x.subject.classID == 4)
                    {
                        ws.Cells[i + 9, 5] = "√";
                        an++;
                    }
                    if (x.subject.classID == 5)
                    {
                        ws.Cells[i + 9, 6] = "√";
                        wd++;
                    }
                    if (x.subject.classID == 6)
                    {
                        ws.Cells[i + 9, 7] = "√";
                        nw++;
                    }
                    if (x.subject.classID == 7)
                    {
                        ws.Cells[i + 9, 8] = "√";
                        al++;
                    }
                    i++;
                }
                ws.Cells[i + 9, 3] = "TOTAL: ";
                ws.Cells[i + 9, 4] = cs;
                ws.Cells[i + 9, 5] = an;
                ws.Cells[i + 9, 6] = wd;
                ws.Cells[i + 9, 7] = nw;
                ws.Cells[i + 9, 8] = al;


                //UNDERLINES
                range = ws.Cells[3, 2];
                underline(range);
                range = ws.Cells[4, 2];
                underline(range);
                range = ws.Cells[5, 2];
                underline(range);
                range = ws.Cells[4, 5];
                underline(range);
                range = ws.Cells[5, 5];
                underline(range);
                range = ws.Cells[4, 7];
                underline(range);
                //FULL BORDERS
                range = ws.Range[ws.Cells[8, 1], ws.Cells[i + 8, 8]];
                fullBorders(range);
                range = ws.Range[ws.Cells[i + 9, 3], ws.Cells[i + 9, 8]];
                fullBorders(range);
                range = ws.Range[ws.Cells[7, 4], ws.Cells[7, 8]];
                fullBorders(range);

                ws.Columns.AutoFit();



                wb.SaveAs(dlg.FileName);
                wb.Close();
                xl.Quit();
                Marshal.ReleaseComObject(xl);
            }
            return true;
        }
        private static void fullBorders(Range range)
        {
            Range cell = range.Cells;
            Borders border = cell.Borders;

            border.LineStyle = XlLineStyle.xlContinuous;
            border.Weight = 2d;
        }
        private static void underline(Range range)
        {
            Range cell = range.Cells;
            cell.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            cell.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
        }
    }
}
