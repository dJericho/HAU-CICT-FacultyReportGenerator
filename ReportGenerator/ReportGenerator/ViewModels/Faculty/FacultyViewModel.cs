using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FacultyViewModel
    {
        public static List<Faculty> faculty { get; set; }

        public static Faculty getFaculty(int id)
        {
            return faculty.Find(e => e.Id == id);
        }
    }
}
