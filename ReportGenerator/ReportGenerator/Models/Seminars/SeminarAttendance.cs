using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarAttendance
    {
        private int _id;
        private int _facultyid;
        private int _seminarid;

        public int Id { get => _id; set => _id = value; }
        public int Facultyid { get => _facultyid; set => _facultyid = value; }
        public int Seminarid { get => _seminarid; set => _seminarid = value; }
    }
}
