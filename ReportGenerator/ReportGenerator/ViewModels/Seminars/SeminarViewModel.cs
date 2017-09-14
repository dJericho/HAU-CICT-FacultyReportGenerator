using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarViewModel
    {
        public static List<Seminar> seminars { get; set; }

        public static Seminar getSeminar(int id)
        {
            return seminars.Find(e => e.Id == id);
        }
    }
}
