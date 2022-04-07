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
        public Category()
        {
            InitializeComponent();

        }

        private void CabinetCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Pages/Product/ProductList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
