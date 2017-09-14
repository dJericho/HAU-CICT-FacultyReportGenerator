using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Role
    {
        private int _id;
        private string _roleName;

        public int Id { get => _id; set => _id = value; }
        public string RoleName { get => _roleName; set => _roleName = value; }
    }
}
