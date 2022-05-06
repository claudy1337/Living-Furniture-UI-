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
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using The_Living_Furniture_UI.Db;
using MongoDB.Libmongocrypt;
using MongoDB.Driver.Linq;
using System.CodeDom;



namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Baket.xaml
    /// </summary>
    public partial class Baket : Page
    {
       // List<Db.OrderedProduct> products = new List<Db.OrderedProduct>();
        private static Db.User currentUser;
        public Baket(Db.User user)
        {
            InitializeComponent();
            currentUser = user;
            listBasket.ItemsSource = currentUser.Basket.Product;
     
            int sum = 0;
            foreach (var item in user.Basket.Product)
            {
                sum += item.Price;
            }
            countProd.Text = user.Basket.Product.Count.ToString();
            priceProd.Text = sum.ToString();
            
            
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime currentDate = DateTime.Now.Date;
            Db.Order order = new Db.Order(currentUser, currentUser.Basket.Product.Where(x => true).ToList(), currentDate);
            Db.Order.ProductAddToOrder(order);
            
        }
        
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Object[] chel = null;
            Db.Basket.Edit(chel, currentUser.Login);
            listBasket.ItemsSource = null;

        }

        private void listBasket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(listBasket.SelectedItem.ToString());
        }
    }
}
