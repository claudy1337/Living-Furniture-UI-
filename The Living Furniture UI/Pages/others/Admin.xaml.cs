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
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/ConsultationControl.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdStatistic_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/userPages/FollowPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdUsrAccounts_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/Profile.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdAccount_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/UserControl.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdRequests_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/adminPages/Requests.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
