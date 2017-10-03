using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class ClassificationVM
    {
        public static BindingList<Classification> Classifications { get; set; }

        public static Classification getClassification(int id)
        {
            return Classifications.FirstOrDefault(e => e.id == id);
        }
        public static Classification getClassification(string name)
        {
            return Classifications.FirstOrDefault(e => e.classification == name);
        }
    }
}
