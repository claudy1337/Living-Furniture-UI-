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

namespace The_Living_Furniture_UI.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductOne_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Pages/Product/ProductInfo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ProductTwo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Pages/Product/ProductInfo.xaml", UriKind.RelativeOrAbsolute));

        }

        private void ProductThree_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Pages/Product/ProductInfo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ProductFour_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Pages/Product/ProductInfo.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
