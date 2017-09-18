using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class RoleViewModel
    {
        public static BindingList<Role> roles { get; set; }
        
        public static string getRole(int id)
        {
            return roles.FirstOrDefault(c => c.Id == id).RoleName;
        }
    }
}
