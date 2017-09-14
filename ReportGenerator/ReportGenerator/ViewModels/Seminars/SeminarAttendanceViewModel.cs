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
        public static List<Seminar> seminars { get => SeminarViewModel.seminars; set=> seminars = value; }

        public static Seminar getSeminar(int id)
        {
            return seminarAttendance.Find(x => x.Seminarid == id).Seminar;
        }
        public static Faculty getFaculty(int id)
        {
            return seminarAttendance.Find(x => x.Facultyid == id).Faculty;
        }
        public static List<Faculty> getAttendance(int id)
        {
            return seminarAttendance.Where(x => x.Seminarid == id).Select(x => x.Faculty).ToList();
        }
    }
}
