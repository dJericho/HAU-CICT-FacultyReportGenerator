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

namespace ReportGenerator.UserControls
{
    /// <summary>
    /// Interaction logic for AttendanceUC.xaml
    /// </summary>
    public partial class AttendanceUC : UserControl
    {
        public AttendanceUC()
        {
            InitializeComponent();
        }
        private void Context_Delete(object sender, RoutedEventArgs e)
        {
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toDeleteFromBindedList = (Faculty)item.SelectedCells[0].Item;

            var tab = (Seminar)tabAttendance.SelectedItem;
            //Remove the toDeleteFromBindedList object from your ObservableCollection
            SeminarAttendanceViewModel.seminarAttendance.Remove(
                SeminarAttendanceViewModel.seminarAttendance.FirstOrDefault(a =>
                    a.Seminar == tab && a.Faculty == toDeleteFromBindedList)
                );
            Console.WriteLine(SeminarAttendanceViewModel.seminarAttendance.Count);
        }
    }
}
