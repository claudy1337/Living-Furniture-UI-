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
using System.Collections.ObjectModel;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        ObservableCollection<string> imgCollection;
        private static Db.User currentUser;
        public Profile(Db.User user)
        {
            InitializeComponent();
            currentUser = user;
            TBusrName.Text = user.Name;
            TBusrLogin.Text = user.Login;
            TBusrAddress.Text = user.Address;
            Random rnd = new Random();
            int value = rnd.Next(1, 3);
            if (value == 1)
                ProductCart.Source = new BitmapImage(new Uri("/Assets/Images/Card/Furniture/f1.png", UriKind.RelativeOrAbsolute));
            else if (value == 2)
                ProductCart.Source = new BitmapImage(new Uri("/Assets/Images/Card/Furniture/f2.png", UriKind.RelativeOrAbsolute));
            else
                ProductCart.Source = new BitmapImage(new Uri("/Assets/Images/Card/Furniture/f3.png", UriKind.RelativeOrAbsolute));

        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void changeProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductCart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Category(currentUser));
        }
    }
}
