using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Faculty
    {
        public int id { get; set; }
        public string name { get; set; }
        public string undergrad { get; set; }
        public int undergradYear { get; set; }
        public string postgrad { get; set; }
        public int postgradYear { get; set; }
        public string postgradExpectedYear { get; set; }
        public int roleID { get; set; }
        public Role role { get => RoleVM.getRole(roleID); }

    }
}
