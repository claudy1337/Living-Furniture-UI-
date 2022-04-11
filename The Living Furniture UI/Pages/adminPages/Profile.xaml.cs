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
using System.IO;
namespace The_Living_Furniture_UI.Pages.adminPages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }
        int count = 1;
        private void imgCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            count++;
            switch (count)
            {
                case 1:
                    imgCard.Source = new BitmapImage(new Uri("/Assets/Images/Card/Furniture/f1.png", UriKind.Relative));
                    break;
                case 2:
                    imgCard.Source = new BitmapImage(new Uri("/Assets/Images/Card/Furniture/f2.png", UriKind.Relative));
                    break;
                case 3:
                    imgCard.Source = new BitmapImage(new Uri("/Assets/Images/Card/Furniture/f3.png", UriKind.Relative));
                    break;
                default:
                    count = 0;
                    break;
            }
        }
    }   
}

