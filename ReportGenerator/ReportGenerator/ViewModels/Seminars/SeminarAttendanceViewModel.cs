using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarAttendanceViewModel
    {
        public static BindingList<SeminarAttendance> seminarAttendance { get; set; }
        public static BindingList<Seminar> seminars { get => SeminarViewModel.seminars; set=> seminars = value; }

        public static Seminar getSeminar(int id)
        {
            return seminarAttendance.FirstOrDefault(x => x.Seminarid == id).Seminar;
        }
        public static Faculty getFaculty(int id)
        {
            return seminarAttendance.FirstOrDefault(x => x.Facultyid == id).Faculty;
        }
        public static List<Faculty> getAttendance(int id)
        {
            return seminarAttendance.Where(x => x.Seminarid == id).Select(x => x.Faculty).ToList();
        }
    }
}
