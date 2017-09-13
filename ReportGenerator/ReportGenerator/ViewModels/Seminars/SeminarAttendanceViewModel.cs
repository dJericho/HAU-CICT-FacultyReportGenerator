using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarAttendanceViewModel
    {
        public static List<SeminarAttendance> seminarAttendance { get; set; }

        public static int getSeminar(int id)
        {
            return seminarAttendance.Find(x => x.Seminarid == id).Seminarid;
        }
        public static int getFaculty(int id)
        {
            return seminarAttendance.Find(x => x.Facultyid == id).Facultyid;
        }
    }
}
