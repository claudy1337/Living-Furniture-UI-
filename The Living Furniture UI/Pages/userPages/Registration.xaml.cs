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
using The_Living_Furniture_UI.Pages;
using The_Living_Furniture_UI.Pages.others;
using The_Living_Furniture_UI.Db;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        
        public Registration()
        {
            InitializeComponent();
        }

        private void SignInPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new auth());
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (isCheсkAgree.IsChecked == true)
            {
                List<Db.Product> product = new List<Db.Product>();
                List<ModifyProducts> modifyProducts = new List<ModifyProducts>();
                Random rnd = new Random();
                Basket basket = new Basket();
                int cardNumber = rnd.Next(10000, 99999);
                var login = Db.User.GetUser(usrLogin.Text);
                if (login == null)
                {
                    Db.User usr = new Db.User(usrLogin.Text, usrPassword.Text, usrName.Text, cardNumber, "","", basket);
                    Db.User.usrAddToDB(usr);
                    MessageBox.Show("Welcome: " + $"{usrLogin.Text} " + $"{usrName.Text}");
                    others.User user = new others.User(usr);
                    user.Show();
                }
                else
                    MessageBox.Show("loff");
                
            }
            else
            {
                MessageBox.Show("none");
            }           
        }
        private void isCheсkAgree_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
