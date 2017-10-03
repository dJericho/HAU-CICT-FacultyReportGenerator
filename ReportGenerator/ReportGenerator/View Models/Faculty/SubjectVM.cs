using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SubjectVM
    {
        public static BindingList<Subject> Subjects { get; set; }

        public static Subject getSubject(int id)
        {
            return Subjects.FirstOrDefault(e => e.id == id);
        }
        public static Subject getSubject(string subject)
        {
            return Subjects.FirstOrDefault(e => e.name == subject);
        }
    }
}
