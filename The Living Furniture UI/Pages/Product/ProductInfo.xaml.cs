﻿using System;
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
            CBcolor.Text = currentProduct.Color;
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
            
            if (CBmaterial.Text == null && CBcolor.Text == null && CBwidth == null && CBheight == null )
            {
                Db.Basket.AddProductToBasket(currentUser.Login, currentProduct._id, currentProduct.Category, currentProduct.Name, currentProduct.Price, currentProduct.Width, currentProduct.Height, currentProduct.Color, currentProduct.Structure, currentProduct.Material, currentProduct.Photo);
            }
            else
            {
                string color = CBcolor.SelectedIndex.ToString();
                int width = Convert.ToInt32(CBwidth.SelectedIndex);
                int height = Convert.ToInt32(CBheight.SelectedIndex);
                string material = CBmaterial.SelectedIndex.ToString();
                Db.Basket.AddProductToBasket(currentUser.Login, currentProduct._id, currentProduct.Category, currentProduct.Name, currentProduct.Price, width, height, color, currentProduct.Structure, material, currentProduct.Photo);
                
            }
            prg.Visibility = Visibility.Visible;
            for (int i = 0; i < 100; i++)
                prg.Value = i;
            MessageBox.Show("добавлен в корзину");
            prg.Visibility = Visibility.Hidden;
            prg.Value = 0;

        }
    }
}
