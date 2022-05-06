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

namespace The_Living_Furniture_UI.Pages.others
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/Profile.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdStatistic_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/Applications.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdUsrAccounts_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/UserControl.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdRequests_Click(object sender, RoutedEventArgs e)
        {
           PagesNavigation.Navigate(new System.Uri("Pages/adminPages/Requests.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdExit_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to exit account?";
            string caption = "Exit Accout";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            
        }

        private void rdOrders_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/FullOrders.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdConsultation_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/ConsultationControl.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Product/CreateProduct.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
