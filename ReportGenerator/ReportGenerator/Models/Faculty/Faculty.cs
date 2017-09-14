using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Faculty
    {
        private int _id;
        private string _name;
        private string _undergrad;
        private string _postgrad;
        private int _roleId;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Undergrad { get => _undergrad; set => _undergrad = value; }
        public string Postgrad { get => _postgrad; set => _postgrad = value; }
        public String Role { get => RoleViewModel.getRole(RoleId);}
        public int RoleId { get => _roleId; set => _roleId = value; }
    }
}
