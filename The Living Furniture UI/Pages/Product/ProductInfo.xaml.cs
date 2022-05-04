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
            //var stds = new MongoClient("mongodb://localhost");
            //var datasbase = stds.GetDatabase("FurnitureBD");
            //var collecstion = datasbase.GetCollection<Db.User>("User");
            //var filterCheck = Builders<Db.User>.Filter.Where(u => u.Login == currentUser.Login );
            //var update = Builders<Db.User>.Update.PushEach(x => x.Basket.Product, new[]
            //{
            //            new ModifyProducts { _id = currentProduct._id,
            //                Name = currentProduct.Name,
            //                Price = currentProduct.Price,
            //                Raiting = currentProduct.Raiting,
            //                Width = currentProduct.Width,
            //                Height = currentProduct.Height,
            //                Color = currentProduct.Color,
            //                Category = currentProduct.Category,
            //                Structure = currentProduct.Structure,
            //                Material = currentProduct.Material,
            //                Photo = currentProduct.Photo,
            //                SizeImage = currentProduct.SizeImage,
            //                Logo = currentProduct.Logo,
            //            }

            //});

            //await collecstion.UpdateOneAsync(filterCheck, update);

            Db.Trash.AddToCliensCart(currentUser.Login, currentProduct.Name, "332");
        }
    }
}
