using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FacultyVM
    {
        public static BindingList<Faculty> faculty { get; set; }

        public static Faculty getFaculty(int id)
        {
            return faculty.FirstOrDefault(e => e.id==id);
        }
    }
}
