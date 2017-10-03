using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ReportGenerator
{
    class GenerateReport
    {
        public static bool GenerateExcel()
        {
            Application xl = new Application();
            if (xl == null)
                return false;
            var wb = xl.Workbooks.Add();
            var ws = (Worksheet)wb.Worksheets[1];
            ws.Name = "Seminars";
            if (ws == null)
                return false;

            ws.Cells[3, 2] = "Name";
            ws.Cells[4, 2] = "Post-Grad";
            ws.Cells[5, 2] = "Under-grad";
            ws.Cells[3, 3] = CurrentUser.user.name;
            ws.Cells[4, 3] = CurrentUser.user.postgrad;
            ws.Cells[5, 3] = CurrentUser.user.undergrad;
            ws.Cells[4, 5] = "Year";
            ws.Cells[5, 5] = "Year";
            ws.Cells[4, 6] = CurrentUser.user.postgradYear;
            ws.Cells[5, 6] = CurrentUser.user.undergradYear;
            ws.Cells[4, 8] = CurrentUser.user.postgradExpectedYear;

            ws.Range[ws.Cells[7, 2], ws.Cells[7, 4]].Merge();
            ws.Cells[7, 2] = "SEMINARS ATTENDED";
            ws.Range[ws.Cells[7, 5], ws.Cells[7, 10]].Merge();
            ws.Cells[7, 5] = "COURSES ALIGNED";
            ws.Cells[8, 2] = "DATE";
            ws.Cells[8, 3] = "TITLE";
            ws.Cells[8, 4] = "VENUE";

            int i = 0;
            foreach (Classification x in ClassificationVM.Classifications)
            {
                ws.Cells[8, i + 5] = x.classification;
                i++;
            }
            i = 0;
            int cs=0, an=0, wd=0, nw=0, al=0;
            foreach(Attendance x in AttendanceVM.specificAttendances)
            {
                ws.Cells[i + 9, 2] = x.seminar.date;
                ws.Cells[i + 9, 3] = x.seminar.seminarName;
                ws.Cells[i + 9, 4] = x.seminar.venue;
                //√
                if (x.seminar.classId == 3)
                {
                    ws.Cells[i + 9, 5] = "√";
                    cs++;
                }
                if (x.seminar.classId == 4)
                {
                    ws.Cells[i + 9, 6] = "√";
                    an++;
                }
                if (x.seminar.classId == 5)
                {
                    ws.Cells[i + 9, 7] = "√";
                    wd++;
                }
                if (x.seminar.classId == 6)
                {
                    ws.Cells[i + 9, 8] = "√";
                    nw++;
                }
                if (x.seminar.classId == 7)
                {
                    ws.Cells[i + 9, 9] = "√";
                    al++;
                }
                i++;
            }
            ws.Cells[i + 9, 4] = "TOTAL: ";
            ws.Cells[i + 9, 5] = cs;
            ws.Cells[i + 9, 6] = an;
            ws.Cells[i + 9, 7] = wd;
            ws.Cells[i + 9, 8] = nw;
            ws.Cells[i + 9, 9] = al;

            ws.Columns.AutoFit();

            ws = (Worksheet)wb.Worksheets[2];
            ws.Name = "Subjects";

            ws.Cells[3, 2] = "Name";
            ws.Cells[4, 2] = "Post-Grad";
            ws.Cells[5, 2] = "Under-grad";
            ws.Cells[3, 3] = CurrentUser.user.name;
            ws.Cells[4, 3] = CurrentUser.user.postgrad;
            ws.Cells[5, 3] = CurrentUser.user.undergrad;
            ws.Cells[4, 5] = "Year";
            ws.Cells[5, 5] = "Year";
            ws.Cells[4, 6] = CurrentUser.user.postgradYear;
            ws.Cells[5, 6] = CurrentUser.user.undergradYear;
            ws.Cells[4, 8] = CurrentUser.user.postgradExpectedYear;

            ws.Range[ws.Cells[7, 3], ws.Cells[7, 7]].Merge();
            ws.Cells[7, 3] = "COURSE";
            ws.Cells[8, 2] = "Subject";
            i = 0;
            foreach (Classification x in ClassificationVM.Classifications)
            {
                ws.Cells[8, i + 5] = x.classification;
                i++;
            }
            i = 0; cs = 0; nw = 0; wd = 0; an = 0; al = 0;
            foreach (FacultyLoads x in LoadsVM.specificLoads)
            {
                ws.Cells[i + 9, 3] = x.subject.name;

                if (x.subject.classID == 3)
                {
                    ws.Cells[i + 9, 5] = "√";
                    cs++;
                }
                if (x.subject.classID == 4)
                {
                    ws.Cells[i + 9, 6] = "√";
                    an++;
                }
                if (x.subject.classID == 5)
                {
                    ws.Cells[i + 9, 7] = "√";
                    wd++;
                }
                if (x.subject.classID == 6)
                {
                    ws.Cells[i + 9, 8] = "√";
                    nw++;
                }
                if (x.subject.classID == 7)
                {
                    ws.Cells[i + 9, 9] = "√";
                    al++;
                }
                i++;
            }
            ws.Cells[i + 9, 4] = "TOTAL: ";
            ws.Cells[i + 9, 5] = cs;
            ws.Cells[i + 9, 6] = an;
            ws.Cells[i + 9, 7] = wd;
            ws.Cells[i + 9, 8] = nw;
            ws.Cells[i + 9, 9] = al;

            ws.Columns.AutoFit();

            wb.SaveAs(@"F:\School Folder\OOPL\Excel.xlsx");
            wb.Close();
            xl.Quit();
            Marshal.ReleaseComObject(xl);
            return true;
        }
    }
}
