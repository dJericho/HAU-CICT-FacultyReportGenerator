using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FacultyLoadsViewModel
    {
        public static BindingList<FacultyLoads> facultyloads { get; set; }

        public static Faculty getFaculty(int id)
        {
            return facultyloads.FirstOrDefault(e => e.Id == id).faculty;
        }
        public static Subject getSubject(int id)
        {
            return facultyloads.FirstOrDefault(e => e.Id == id).subject;
        }
    }
}
