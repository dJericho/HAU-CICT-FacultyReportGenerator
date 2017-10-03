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
using System.Windows.Shapes;

namespace ReportGenerator
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            PopulateModels.populate();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Connector db = new Connector();
            if (db.login(id.Text, password.Password))
            {
                AttendanceVM.setSpecificFaculty(CurrentUser.user.id);
                LoadsVM.setLoads(CurrentUser.user.id);
                CurrentUser.user = FacultyVM.getFaculty(CurrentUser.user.id);
                new MainWindow().Show();
                Close();
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            id.Text = "";
            password.Password = "";
        }
    }
}
