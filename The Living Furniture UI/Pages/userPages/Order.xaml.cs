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
using The_Living_Furniture_UI.Db;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private static Db.User currentUser;
        public Order(Db.User user)
        {
            currentUser = user;
            InitializeComponent();
            listOrder.ItemsSource = Db.Order.GetOrderList(currentUser.Login);
             
            //listlogin.ItemsSource = Basket.GetLoginList();
            //TBNames.Text = Basket.GetUser(listlogin.SelectedItem.ToString()).Name;
            
            //TBPrice.Text = Basket.GetUser(listlogin.SelectedItem.ToString()).Size;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
