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
        public MainWindow()
        {
            InitializeComponent();

            if(CurrentUser.user.roleID == 2)
            {
                Accounts.Visibility = Visibility.Collapsed;
                iconAccounts.Visibility = Visibility.Collapsed;
            }
        }
        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;

            MenuToggleButton.IsChecked = false;
        }

        private void DemoItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dockPanel.Children.Clear();
            if (profile.IsSelected)
            {
                dockPanel.Children.Add(new Profile());
                text_Navigation.Text = "My Profile & Subjects";
            }
            else if (seminar.IsSelected)
            {
                dockPanel.Children.Add(new Seminars());
                text_Navigation.Text = "Seminars";
            }
            else if (export.IsSelected)
            {
                text_Navigation.Text = "Export";
            }
            else if (logout.IsSelected)
            {
                new Login().Show();
                Close();
            }
            else if (Accounts.IsSelected)
            {
                dockPanel.Children.Add(new Accounts());
                text_Navigation.Text = "Accounts";
            }
        }
    }
}
