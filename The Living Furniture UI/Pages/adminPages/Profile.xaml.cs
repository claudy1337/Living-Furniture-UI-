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
        public static Db.Admin currentAdmin;
        public Profile()
        {
            InitializeComponent();
            admLogin.Text = "adm";
            admName.Text = "adm";
        }
        int count = 1;
    }   
}

