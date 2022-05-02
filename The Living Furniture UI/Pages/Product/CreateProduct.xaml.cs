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
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Page
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void BCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            string value = TBPrice.ToString();
            //Db.Product product = new Db.Product(,CBCategory.Text, TBName.Text, 1000, 0, 200, 300,CBColor.Text,false,CBMaterial.Text,TBLogo.Text, TBPhoto.Text, "");
            //Db.Product.ProductAddtoDb(product);
        }
    }
}
