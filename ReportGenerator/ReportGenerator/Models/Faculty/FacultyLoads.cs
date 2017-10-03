using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FacultyLoads
    {
        public int id { get; set; }
        public int facultyID { get; set; }
        public int subjectID { get; set; }
        public Faculty faculty { get => FacultyVM.getFaculty(facultyID); } //edit
        public Subject subject { get => SubjectVM.getSubject(subjectID); } //edit
    }
}
