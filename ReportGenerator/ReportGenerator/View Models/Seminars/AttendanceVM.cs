using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class AttendanceVM
    {
        public static BindingList<Attendance> Attendances { get; set; }
        public static BindingList<Attendance> specificAttendances { get; set; }
        public static BindingList<Seminar> Seminars { get => SeminarVM.Seminars; }
        public static BindingList<Type> types { get => TypeVM.Types; }
        public static BindingList<Classification> classifications { get => ClassificationVM.Classifications; }

        public static Attendance getAttendance(int id)
        {
            return Attendances.FirstOrDefault(e => e.id == id);
        }
        public static List<Faculty> getFacultyAttendance(int id)
        {
            return Attendances.Where(x => x.seminarid == id).Select(x => x.faculty).ToList();
        }
        public static void setSpecificFaculty(int id)
        {
            specificAttendances = new BindingList<Attendance>(Attendances.Where(e => e.facultyid==id).ToList());
        }
    }
}
