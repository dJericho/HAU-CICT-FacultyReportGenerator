using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class RoleVM
    {
        public static BindingList<Role> Roles { get; set; }

        public static Role getRole(int id)
        {
            return Roles.FirstOrDefault(e => e.id == id);
        }
        public static Role getRole(string role)
        {
            return Roles.FirstOrDefault(e => e.roleName == role);
        }
    }
}
