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
using The_Living_Furniture_UI.Pages.others;
using The_Living_Furniture_UI.Pages.userPages;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace The_Living_Furniture_UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Page
    {
        public auth()
        {
            InitializeComponent();
            
            
        }
        private void RegistrationPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

      

        private void TBforgotPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var usr = Db.User.UserIsExists(clientLogin.Text, clientPassword.Text).FirstOrDefault();
            if (usr != null)
            {
                MessageBox.Show("Welcome " + $"{clientLogin.Text}");
                others.User us = new others.User(usr);
                us.Show();
            }
            else if (usr == null)
            {
                var adm = Db.Admin.AdminIsExists(clientLogin.Text, clientPassword.Text);
                if (adm != null)
                {
                    MessageBox.Show("Welcome admin: " + $"{clientLogin.Text}");
                    others.Admin admin = new Admin();
                    admin.Show();
                }
                else
                    MessageBox.Show("dont search adm");
            }
            else
                MessageBox.Show("dont search user");
        }


        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
