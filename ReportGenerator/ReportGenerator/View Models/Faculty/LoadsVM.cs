using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class LoadsVM
    {
        public static BindingList<FacultyLoads> Loads { get; set; }
        public static BindingList<FacultyLoads> specificLoads { get; set; }
        public static BindingList<Classification> Classifications { get => ClassificationVM.Classifications; }
        public static BindingList<Subject> subjects { get => SubjectVM.Subjects; }

        public static Faculty getFaculty(int id)
        {
            return Loads.FirstOrDefault(e => e.facultyID == id).faculty;
        }
        public static Subject getSubject(int id)
        {
            return Loads.FirstOrDefault(e => e.subjectID == id).subject;
        }
        public static void setLoads(int facultyid)
        {
            specificLoads = new BindingList<FacultyLoads>(Loads.Where(e => e.facultyID==facultyid).ToList());
        }
    }
}
