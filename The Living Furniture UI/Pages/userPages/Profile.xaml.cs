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
using System.Collections.ObjectModel;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        ObservableCollection<string> imgCollection;
        public Profile()
        {
            InitializeComponent();
            imgCollection = new ObservableCollection<string> { "/Assets/Images/Card/Furniture/f1.png", "/Assets/Images/Card/Furniture/f2.png" };
            
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
