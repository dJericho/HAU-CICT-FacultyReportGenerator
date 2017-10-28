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
    /// Interaction logic for Seminars.xaml
    /// </summary>
    public partial class Seminars : UserControl
    {
        public Seminars()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (classCB.Text != "" && seminarCB.Text != "" && typeCB.Text != "" &&
                dateTB.Text != "" && venueTB.Text != "")
            {
                if (Accept.Content.ToString() == "ADD")
                    addData();
                else if (Accept.Content.ToString() == "EDIT")
                    editData();
            }
            else if (Accept.Content.ToString() == "YES")
                deleteData();
            else
                MessageBox.Show("Empty Fields");
            classCB.Text = "";
            seminarCB.Text = "";
            typeCB.Text = "";
            dateTB.Text = "";
            venueTB.Text = "";
            classCB.IsEnabled = true;
            typeCB.IsEnabled = true;
            dateTB.IsEnabled = true;
            venueTB.IsEnabled = true;
        }

        private void addData()
        {
            string query;
            Connector db = new Connector();
            if(SeminarVM.getSeminar(seminarCB.Text) == null)
            {
                if(TypeVM.getType(typeCB.Text) == null)
                {
                    query = String.Format("insert into seminartypes (type) values (" +
                        "'{0}');", typeCB.Text);
                    if (db.addData(query))
                    {
                        TypeVM.Types.Add(new Type
                        {
                            id = TypeVM.Types.Max(x => x.id) + 1,
                            type = typeCB.Text
                        });
                    }
                }
                query = String.Format("insert into seminars (seminarName, seminarType, classificationID, venue, date) values (" +
                    "'{0}', {1}, {2}, '{3}', '{4}');", 
                    seminarCB.Text, 
                    TypeVM.getType(typeCB.Text).id, 
                    ClassificationVM.getClassification(classCB.Text).id,
                    venueTB.Text, dateTB.Text);
                if (db.addData(query))
                {
                    SeminarVM.Seminars.Add(new Seminar
                    {
                        id = SeminarVM.Seminars.Max(e => e.id)+1,
                        seminarName = seminarCB.Text,
                        typeid = TypeVM.getType(typeCB.Text).id,
                        classId = ClassificationVM.getClassification(classCB.Text).id,
                        venue = venueTB.Text,
                        date = dateTB.Text
                    });
                }
            }
            query = String.Format("insert into seminarsattendance (facultyID, seminarID) values (" +
                "{0}, {1});", CurrentUser.user.id, 
                SeminarVM.getSeminar(seminarCB.Text).id);
            if (db.addData(query))
            {
                AttendanceVM.specificAttendances.Add(new Attendance
                {
                    id = AttendanceVM.Attendances.Max(e => e.id) + 1,
                    facultyid = CurrentUser.user.id,
                    seminarid = SeminarVM.getSeminar(seminarCB.Text).id
                });
            }
        }
        private void editData()
        {
            Connector db = new Connector();
            string query = String.Format("update seminars set " +
                "seminarName = '{0}', seminarType = {1}, classificationId = {2}, " +
                "venue = '{3}', date = '{4}' where id = {5};",
                seminarCB.Text, TypeVM.getType(typeCB.Text).id,
                ClassificationVM.getClassification(classCB.Text).id, venueTB.Text, dateTB.Text,
                ((Attendance)dg.SelectedItem).seminarid);
            if (db.addData(query))
            {
                SeminarVM.getSeminar(((Attendance)dg.SelectedItem).seminarid).seminarName = seminarCB.Text;
                SeminarVM.getSeminar(((Attendance)dg.SelectedItem).seminarid).typeid = TypeVM.getType(typeCB.Text).id;
                SeminarVM.getSeminar(((Attendance)dg.SelectedItem).seminarid).classId = ClassificationVM.getClassification(classCB.Text).id;
                SeminarVM.getSeminar(((Attendance)dg.SelectedItem).seminarid).venue = venueTB.Text;
                SeminarVM.getSeminar(((Attendance)dg.SelectedItem).seminarid).date = dateTB.Text;
                dg.Items.Refresh();
                classCB.Items.Refresh();
                seminarCB.Items.Refresh();
                typeCB.Items.Refresh();
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            createPrompt();
            Accept.Content = "ADD";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            createPrompt();
            Accept.Content = "EDIT";
            if(dg.SelectedItem != null)
            {
                seminarCB.Text = ((Attendance)dg.SelectedItem).seminar.seminarName;
                classCB.Text = ((Attendance)dg.SelectedItem).seminar.classification.classification;
                typeCB.Text = ((Attendance)dg.SelectedItem).seminar.type.type;
                dateTB.Text = ((Attendance)dg.SelectedItem).seminar.date;
                venueTB.Text = ((Attendance)dg.SelectedItem).seminar.venue;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePrompt();
        }

        private void deleteData()
        {
            if (dg.SelectedItem != null)
            {
                Connector db = new Connector();
                string query = "delete from seminarsattendance where id = " + ((Attendance)dg.SelectedItem).id;
                db.deleteData(query);
                AttendanceVM.specificAttendances.Remove((Attendance)dg.SelectedItem);
            }
        }

        private void seminarCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                classCB.Text = (e.AddedItems[0] as Seminar).classification.classification;
                typeCB.Text = (e.AddedItems[0] as Seminar).type.type;
                dateTB.Text = (e.AddedItems[0] as Seminar).date;
                venueTB.Text = (e.AddedItems[0] as Seminar).venue;

                classCB.IsEnabled = false;
                typeCB.IsEnabled = false;
                dateTB.IsEnabled = false;
                venueTB.IsEnabled = false;
            }
            catch(Exception ex) {
                classCB.IsEnabled = true;
                typeCB.IsEnabled = true;
                dateTB.IsEnabled = true;
                venueTB.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            classCB.Text = "";
            seminarCB.Text = "";
            typeCB.Text = "";
            dateTB.Text = "";
            venueTB.Text = "";
            classCB.IsEnabled = true;
            typeCB.IsEnabled = true;
            dateTB.IsEnabled = true;
            venueTB.IsEnabled = true;
        }

        private void deletePrompt()
        {
            delete.Content = String.Format("Are you sure you want to delete {0}?", ((Attendance)dg.SelectedItem).seminar.seminarName);
            Accept.Content = "YES";

            classCB.Visibility = Visibility.Collapsed;
            seminarCB.Visibility = Visibility.Collapsed;
            typeCB.Visibility = Visibility.Collapsed;
            dateTB.Visibility = Visibility.Collapsed;
            venueTB.Visibility = Visibility.Collapsed;
            delete.Visibility = Visibility.Visible;
        }
        private void createPrompt()
        {
            classCB.Visibility = Visibility.Visible;
            seminarCB.Visibility = Visibility.Visible;
            typeCB.Visibility = Visibility.Visible;
            dateTB.Visibility = Visibility.Visible;
            venueTB.Visibility = Visibility.Visible;
            delete.Visibility = Visibility.Collapsed;
        }
    }
}
