using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int classID { get; set; }
        public Classification classification { get => ClassificationVM.getClassification(classID); }
    }
}
