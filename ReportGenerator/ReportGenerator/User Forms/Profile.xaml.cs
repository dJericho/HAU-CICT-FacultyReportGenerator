using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("");
            for (int i = 1970; i < DateTime.Now.Year; i++)
            {
                list.Add(i+"");
            }
            yearPost.ItemsSource = list;
            yearUnder.ItemsSource = list;
            List<string> list2 = new List<string>();
            list2.Add("");
            for (int i = DateTime.Now.Year; i < DateTime.Now.AddYears(5).Year; i++)
            {
                list2.Add(i + "");
            }
            yearExpected.ItemsSource = list2;
            setProfile();
        }
        private void setProfile()
        {
            name.Text = CurrentUser.user.name;
            role.Text = CurrentUser.user.role.roleName;
            id.Text = CurrentUser.user.id+"";
            undergrad.Text = CurrentUser.user.undergrad;
            yearUnder.Text = CurrentUser.user.undergradYear+"";
            postgrad.Text = CurrentUser.user.postgrad;
            yearPost.Text = CurrentUser.user.postgradYear + "";
            yearExpected.Text = CurrentUser.user.postgradExpectedYear + "";

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            createPrompt();
            Accept.Content = "ADD";
        }

        private void addData()
        {
            long lastid;
            string query;
            Connector db = new Connector();
            if (SubjectVM.getSubject(subjectTB.Text) == null)
            {
                query = String.Format("insert into subjects ( name, classificationID) values (" +
                    "'{0}', {1})", subjectTB.Text,
                    ClassificationVM.getClassification(typeCB.Text).id);
                lastid = db.addData(query);
                if (lastid != -1)
                {

                    SubjectVM.Subjects.Add(new Subject
                    {
                        id = (int)lastid,
                        name = subjectTB.Text,
                        classID = ClassificationVM.getClassification(typeCB.Text).id
                    });
                }
            }
            query = String.Format("insert into facultyloads (facultyId, subjectId) values (" +
                    "{0}, {1});", CurrentUser.user.id, SubjectVM.getSubject(subjectTB.Text).id);

            lastid = db.addData(query);
            if (lastid != -1)
            {
                //Console.WriteLine(query);
                LoadsVM.specificLoads.Add(new FacultyLoads
                {
                    id = (int)lastid,
                    facultyID = CurrentUser.user.id,
                    subjectID = SubjectVM.getSubject(subjectTB.Text).id
                });
            }
        }
        private void editData()
        {

            Connector db = new Connector();
            string query = String.Format("update subjects set " +
                "name = '{0}', classificationID = {1} where id = {2};", subjectTB.Text, ClassificationVM.getClassification(typeCB.Text).id, 
                ((FacultyLoads)dg.SelectedItem).subjectID);
            if (db.addData(query) != -1)
            {
                SubjectVM.getSubject(((FacultyLoads)dg.SelectedItem).subjectID).name = subjectTB.Text;
                SubjectVM.getSubject(((FacultyLoads)dg.SelectedItem).subjectID).classID = ClassificationVM.getClassification(typeCB.Text).id;
            }
            dg.Items.Refresh();
            typeCB.Items.Refresh();
            subjectTB.Items.Refresh();
        }
        private void subjectTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Accept.Content.ToString() == "ADD")
                {
                    typeCB.Text = (e.AddedItems[0] as Subject).classification.classification;
                    typeCB.IsEnabled = false;
                }
                else
                    typeCB.IsEnabled = true;
                //typeCB.Text = SubjectVM.getSubject(text).classification.classification;
            }
            catch(Exception ex)
            {
                typeCB.IsEnabled = true;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            createPrompt();
            if (dg.SelectedItem != null)
            {
                Accept.Content = "EDIT";
                typeCB.Text = ((FacultyLoads)dg.SelectedItem).subject.classification.classification;
                subjectTB.Text = ((FacultyLoads)dg.SelectedItem).subject.name;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePrompt();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string query = String.Format("update faculty set name = '{0}', undergrad = '{1}', " +
                "undergradYear = '{2}', postgrad = '{3}', postgradYear = '{4}', expectedDate = '{5}' " +
                "where id = {6};",
                name.Text, undergrad.Text, yearUnder.Text, postgrad.Text, yearPost.Text, yearExpected.Text,
                CurrentUser.user.id);
            Connector db = new Connector();
            if (db.addData(query) != -1)
            {
                FacultyVM.getFaculty(CurrentUser.user.id).name = name.Text;
                FacultyVM.getFaculty(CurrentUser.user.id).undergrad = undergrad.Text;
                FacultyVM.getFaculty(CurrentUser.user.id).undergradYear = yearUnder.Text;
                FacultyVM.getFaculty(CurrentUser.user.id).postgrad = postgrad.Text;
                FacultyVM.getFaculty(CurrentUser.user.id).postgradYear = yearPost.Text;
                FacultyVM.getFaculty(CurrentUser.user.id).postgradExpectedYear = yearExpected.Text;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            cancel = false;
            if (subjectTB.Text != "" && typeCB.Text != "")
            {
                if (Accept.Content.ToString() == "ADD")
                    addData();
                else if (Accept.Content.ToString() == "EDIT")
                    editData();
            }
            else if (Accept.Content.ToString() == "YES")
                deleteData();
            else if (!(subjectTB.Text != "" && typeCB.Text != ""))
                emptyPrompt();
        }


        private void emptyPrompt()
        {
            delete.Content = "Please fill out all fields";
            delete.Visibility = Visibility.Visible;
        }
        private void deletePrompt()
        {
            try
            {
                delete.Content = String.Format("Are you sure you want to delete {0}?", ((FacultyLoads)dg.SelectedItem).subject.name);
                Accept.Content = "YES";
            }
            catch(Exception e)
            {
                delete.Content = "No row selected.";
                Accept.Content = "OK";
            }
            typeCB.Visibility = Visibility.Collapsed;
            subjectTB.Visibility = Visibility.Collapsed;
            delete.Visibility = Visibility.Visible;
        }

        private void createPrompt()
        {
            typeCB.Visibility = Visibility.Visible;
            subjectTB.Visibility = Visibility.Visible;
            delete.Visibility = Visibility.Collapsed;
        }
        private void deleteData()
        {

            if (dg.SelectedItem != null)
            {
                Connector db = new Connector();
                string query = "delete from facultyloads where id = " + ((FacultyLoads)dg.SelectedItem).id;
                Console.WriteLine(query);
                db.deleteData(query);
                LoadsVM.specificLoads.Remove((FacultyLoads)dg.SelectedItem);
            }

        }

        private void DialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((!(subjectTB.Text != "" && typeCB.Text != "") && typeCB.Visibility == Visibility.Visible)  && !cancel)
                eventArgs.Cancel();
            else
            {
                subjectTB.Text = "";
                typeCB.Text = "";
                typeCB.IsEnabled = true;
            }
        }

        bool cancel = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancel = true;
        }
    }
}
