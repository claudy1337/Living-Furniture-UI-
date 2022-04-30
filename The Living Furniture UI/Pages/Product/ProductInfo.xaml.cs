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

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            var usr = Db.Basket.BasketIsExists().FirstOrDefault(u => u.User.Login == currentUser.Login);
            if (usr != null)
            {
                MessageBox.Show("пользак есть");
            }
            else
            {
                List<Db.Product> cart = new List<Db.Product>() { currentProduct };
                Db.Basket basket = new Basket(cart, currentUser);
                Db.Basket.BasketAddToDB(basket);
            }
           
            //currentUser.Basket.Products.Add(currentProduct);
            //currentUser.AddProductToDB(currentUser.Basket.Products, currentUser);
        }
    }
}
