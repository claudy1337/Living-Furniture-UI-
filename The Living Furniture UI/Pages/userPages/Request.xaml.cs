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
using The_Living_Furniture_UI.Db;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Page
    {
        private static Db.User currentUser;
        public Request(Db.User user)
        {
            InitializeComponent();
            currentUser = user;


        }

        private void BtnSendRequest_Click(object sender, RoutedEventArgs e)
        {
            
            
            List<Db.Product> products = new List<Db.Product>();
            Db.Order order = new Db.Order(products, false);
           // Db.Basket basket = new Db.Basket(new List<Db.Product>());
            Db.Requests request = new Db.Requests(usrName.Text, CBMaterialProduct.Text, CBTypeProduct.Text, CBSizeProduct.Text, currentUser, false);
            //Requests.SendToRequest(request);
            Db.Requests.requestAddToDB(request);
        }
    }
}
