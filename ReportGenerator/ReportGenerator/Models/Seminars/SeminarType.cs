using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarType
    {
        private int _id;
        private string _type;

        public int Id { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
