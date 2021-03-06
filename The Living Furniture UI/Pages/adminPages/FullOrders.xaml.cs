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
using MongoDB.Bson;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Pages.adminPages
{
    /// <summary>
    /// Логика взаимодействия для FullOrders.xaml
    /// </summary>
    public partial class FullOrders : Page
    {
        public FullOrders()
        {
            InitializeComponent();
            LoadData();
            ord.ItemsSource = Db.Order.GetAllOrderList();

        }
        private async void LoadData()
        {

            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Consultation>("Consultation");
            var filter = new BsonDocument();

            List<Db.Consultation> basket = new List<Db.Consultation>();

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;
                    foreach (Db.Consultation doc in people)
                    {
                        basket.Add(new Db.Consultation(doc.Name, doc.Number, doc.isCheck));
                    }
                }
            }
           // DGEmployee.ItemsSource = Db.Consultation.GetAllConsList();

        }

        private void BSearchUsr_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ord.SelectedIndex == -1)
            {
                return;
            }
            else
            {

            }
        }
    }
}
