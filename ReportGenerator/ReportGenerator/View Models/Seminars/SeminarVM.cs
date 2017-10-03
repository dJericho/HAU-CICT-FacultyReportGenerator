using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarVM
    {
        public static BindingList<Seminar> Seminars { get; set; }

        public static Seminar getSeminar(int id)
        {
            return Seminars.FirstOrDefault(e => e.id == id);
        }
        public static Seminar getSeminar(string name)
        {
            return Seminars.FirstOrDefault(e => e.seminarName == name);
        }
    }
}
