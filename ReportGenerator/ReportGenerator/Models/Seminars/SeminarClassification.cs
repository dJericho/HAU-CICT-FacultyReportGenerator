using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarClassification
    {
        private int _id;
        private string _classification;

        public int Id { get => _id; set => _id = value; }
        public string Classification { get => _classification; set => _classification = value; }
    }
}
