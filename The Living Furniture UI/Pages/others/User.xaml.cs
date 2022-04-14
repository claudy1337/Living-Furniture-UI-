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
using System.Windows.Controls.Primitives;
using The_Living_Furniture_UI.Pages.userPages;
using The_Living_Furniture_UI.Pages.Product;
using The_Living_Furniture_UI.Pages.others;
using The_Living_Furniture_UI.Db;

namespace The_Living_Furniture_UI.Pages.others
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        private static Db.User currentUser;
        public User(Db.User user)
        {
            InitializeComponent();
            txtq.Text = user.Name;
            currentUser = user;
        }

        private void rdRequest_Click(object sender, RoutedEventArgs e)
        {
           // PagesNavigation.Navigate(new System.Uri("Pages/userPages/Request.xaml", UriKind.RelativeOrAbsolute));
            PagesNavigation.Navigate(new Request(currentUser));


        }
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/userPages/main.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdAccount_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/userPages/Profile.xaml", UriKind.RelativeOrAbsolute));
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void rdBasket_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rdCategory_Checked(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/userPages/Category.xaml", UriKind.RelativeOrAbsolute));
        }

        private void PagesNavigation_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void rdCategory_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/userPages/Category.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void rdOrder_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdBasket_Checked(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/userPages/Baket.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
