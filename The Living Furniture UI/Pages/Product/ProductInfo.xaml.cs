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
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Page
    {
        private static Db.Product currentProduct;
        public static Db.User currentUser;
        
        public ProductInfo(Db.Product product, Db.User user)
        {
            InitializeComponent();
            currentProduct = product;
            currentUser = user;
            
            ProdName.Text = currentProduct.Name;
            ProdPrice.Text = currentProduct.Price.ToString();
            ProdLogo.Source = new BitmapImage(new Uri(currentProduct.Photo, UriKind.RelativeOrAbsolute));
            imgProd.Source = new BitmapImage(new Uri(currentProduct.Logo, UriKind.RelativeOrAbsolute));
            CBmaterial.Text = currentProduct.Material;
            DataContext = this;
           
        }
        private void ProductRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {

        }

        int c=0;
        private void imgProd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            c++;
            if (c == 1)
                imgProd.Source = new BitmapImage(new Uri(currentProduct.SizeImage, UriKind.RelativeOrAbsolute));
            else
            {
                imgProd.Source = new BitmapImage(new Uri(currentProduct.Logo, UriKind.RelativeOrAbsolute));
                c = 0;
            }
        }
        private async void BtnBuy_Click(object sender, RoutedEventArgs e)
        {

            var std = new MongoClient("mongodb://localhost");
            var database = std.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Test>("Test");

            var filterCheck = Builders<Db.Test>.Filter.Empty;

            var update = Builders<Db.Test>.Update.PushEach(x => x.Trashes, new[]
            {
                        new Trash{name = "dda", add="fd"}
                    });

            await collection.UpdateOneAsync(filterCheck, update);
            //var usr = Db.Basket.BasketIsExists().FirstOrDefault(u => u.User.Login == currentUser.Login);
            //if (usr != null)
            //{
            //    //var client = new MongoClient("mongodb://localhost");
            //    //var database = client.GetDatabase("FurnitureBD");
            //    //var collection = database.GetCollection<Basket>("Basket");
            //    //MessageBox.Show("пользак есть");
            //    //List<Db.Product> cart = new List<Db.Product> { currentProduct };
            //    //List<Db.Product> carts = new List<Db.Product> { };
            //    //Db.Basket basket = new Basket(cart, currentUser);
            //    ////Db.Basket.BasketAddToDB(basket);
            //    //Db.Basket.EditBasket(carts, cart);

                    


            //}
            //else
            //{
            //    List<Db.Product> cart = new List<Db.Product> { currentProduct };
            //    List<Db.Product> carts = new List<Db.Product> {  };
            //    Db.Basket basket = new Basket(cart, currentUser);
            //    Db.Basket.BasketAddToDB(basket);
            //}
            //currentUser.Basket.Products.Add(currentProduct);
            //currentUser.AddProductToDB(currentUser.Basket.Products, currentUser);
        }
    }
}
