using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Attendance
    {
        public int id { get; set; }
        public int facultyid { get; set; }
        public int seminarid { get; set; }
        public Seminar seminar { get => SeminarVM.getSeminar(seminarid); } //edit
        public Faculty faculty { get => FacultyVM.getFaculty(facultyid); } //edit
    }
}
