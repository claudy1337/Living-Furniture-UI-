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
        public Order()
        {
            InitializeComponent();
            //listlogin.ItemsSource = Basket.GetLoginList();
            //TBNames.Text = Basket.GetUser(listlogin.SelectedItem.ToString()).Name;
            
            //TBPrice.Text = Basket.GetUser(listlogin.SelectedItem.ToString()).Size;
        }

        private void listlogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
