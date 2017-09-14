using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class RoleViewModel
    {
        public static List<Role> roles { get; set; }
        
        public static string getRole(int id)
        {
            return roles.Find(c => c.Id == id).RoleName;
        }
    }
}
