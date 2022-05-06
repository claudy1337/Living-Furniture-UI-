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
using The_Living_Furniture_UI.Pages.userPages;
using The_Living_Furniture_UI.Pages.Product;
using The_Living_Furniture_UI.Pages.others;
using System.Diagnostics;

using MaterialDesignThemes.Wpf;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        private static Db.User currentUser;
        public Category(Db.User user)
        {
            InitializeComponent();
            currentUser = user;

        }

        private void CabinetCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CategoryLogged.Category = "Cabinet";
            NavigationService.Navigate(new CustomList(currentUser));
        }

        private void ChairCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CategoryLogged.Category = "Chair";
            NavigationService.Navigate(new CustomList(currentUser));           
        }

        private void LampCrd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CategoryLogged.Category = "Lamp";
            NavigationService.Navigate(new CustomList(currentUser));
        }

        private void TableCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CategoryLogged.Category = "Table";
            NavigationService.Navigate(new CustomList(currentUser));
        }

        private void BtnFollow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FollowPage());
        }
    }
}
