using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class TypeVM
    {
        public static BindingList<Type> Types { get; set; }

        public static Type getType(int id)
        {
            return Types.FirstOrDefault(e => e.id == id);
        }
        public static Type getType(string type)
        {
            return Types.FirstOrDefault(e => e.type == type);
        }
    }
}
