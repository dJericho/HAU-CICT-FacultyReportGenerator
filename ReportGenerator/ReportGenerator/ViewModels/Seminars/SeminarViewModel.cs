using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarViewModel
    {
        public static BindingList<Seminar> seminars { get; set; }

        public static Seminar getSeminar(int id)
        {
            return seminars.FirstOrDefault(e => e.Id == id);
        }
    }
}
