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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControls.SeminarUC seminar = new UserControls.SeminarUC();

        public MainWindow()
        {

            PopulateModels.populate();
            InitializeComponent();
            
        }

        private void btnSeminars_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        private void btnAttendance_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 1;
        }

        private void btnFaculty_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 2;
        }

        private void btnSubjects_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 3;
        }

        private void btnFacultyLoads_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 4;
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 5;
        }
    }
}
