using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Seminar
    {
        public int id { get; set; }
        public string seminarName { get; set; }
        public int typeid { get; set; }
        public int classId { get; set; }
        public Type type { get => TypeVM.getType(typeid); }
        public Classification classification { get => ClassificationVM.getClassification(classId); }
        public string venue { get; set; }
        public string date { get; set; }
        public List<Faculty> Attendance { get => AttendanceVM.getFacultyAttendance(id); }//edit
    }
}
