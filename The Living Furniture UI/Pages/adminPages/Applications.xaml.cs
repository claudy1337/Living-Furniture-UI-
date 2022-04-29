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
            usrCounts.Text = Db.User.GetAllUserList().Count.ToString();
            prdCount.Text = Db.Product.GetAllProductList().Count.ToString();
           
        }

        private void Btnupdate_Click(object sender, RoutedEventArgs e)
        {
            //TimerCallback tm = new TimerCallback(Prg());
           // Timer timer = new Timer(tm, 0, 0, 2000);
           // prg.IsIndeterminate = true;
            
        }

        private void BtnUsrControl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserControl());
        }
        
    }
}
