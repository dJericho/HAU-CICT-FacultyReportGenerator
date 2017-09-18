using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SubjectViewModel
    {
        public static BindingList<Subject> subjects { get; set; }

        public static Subject getSubject(int id)
        {
            return subjects.FirstOrDefault(x => x.Id == id);
        }
    }
}
