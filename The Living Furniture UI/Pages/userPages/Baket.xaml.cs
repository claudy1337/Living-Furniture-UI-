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
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using The_Living_Furniture_UI.Db;
using MongoDB.Libmongocrypt;
using MongoDB.Driver.Linq;


namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Baket.xaml
    /// </summary>
    
    public partial class Baket : Page
    {
        private static Db.User currentUser;
        public Baket(Db.User user)
        {
            InitializeComponent();
            currentUser = user;
            
        }
        
    }
}
