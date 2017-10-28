using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportGenerator
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : UserControl
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                Connector db = new Connector();
                string query = "delete from faculty where id = " + ((Faculty)dg.SelectedItem).id;
                Console.WriteLine(query);
                db.deleteData(query);
                FacultyVM.faculty.Remove((Faculty)dg.SelectedItem);
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            string query = String.Format("insert into faculty (name, roleid, password) values (" +
                "'{0}', {1}, '{2}');", name.Text,
                RoleVM.getRole(role.Text).id, password.Password);
            Connector db = new Connector();
            long lastid = db.addData(query);
            if (lastid != -1)
            {
                FacultyVM.faculty.Add(new Faculty
                {
                    id = (int)lastid,
                    name = name.Text,
                    roleID = RoleVM.getRole(role.Text).id
                });
            }
            dg.Items.Refresh();
        }
    }
}
