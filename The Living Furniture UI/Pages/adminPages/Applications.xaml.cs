using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

namespace The_Living_Furniture_UI.Pages.adminPages
{
    /// <summary>
    /// Логика взаимодействия для Applications.xaml
    /// </summary>
    public partial class Applications : Page
    {
        public Applications()
        {
            InitializeComponent();
            Refresh();
           
        }
        public void Refresh()
        {
            usrCounts.Text = null;
            prdCount.Text = null;
            usrCounts.Text = Db.User.GetAllUserList().Count.ToString();
            prdCount.Text = Db.Product.GetAllProductList().Count.ToString();
        }
        int value = 0;
        private void Btnupdate_Click(object sender, RoutedEventArgs e)
        {
           value++;
           Refresh();
           if (value==1)
           {
                for (int i = 0; i < 1000; i++)
                {
                    if (i==100)
                        prgUsr.Visibility = Visibility.Hidden;
                    else
                        prgUsr.Visibility = Visibility.Visible;
                }
               
           }
            else if (value==2)
            {
                prgUsr.IsIndeterminate = false;
                prgUsr.Visibility = Visibility.Hidden;
                value = 0;
            }
          
            
        }

        private void BtnUsrControl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserControl());
        }

        private void BtnProdControl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Product.CreateProduct());
        }

        private void ordControl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FullOrders());
        }

        private void prodUpdate_Click(object sender, RoutedEventArgs e)
        {
            value++;
            Refresh();
            if (value == 1)
            {
                prgProd.IsIndeterminate = true;
                prgProd.Visibility = Visibility.Visible;

            }
            else if (value == 2)
            {
                prgProd.IsIndeterminate = false;
                prgProd.Visibility = Visibility.Hidden;
                value = 0;
            }
        }
    }
}
