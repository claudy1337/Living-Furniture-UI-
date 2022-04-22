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

namespace The_Living_Furniture_UI.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для CustomList.xaml
    /// </summary>
    public partial class CustomList : Page
    {
        private static Db.User currentUser;
        public CustomList(Db.User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void LoadData()
        {

            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Basket>("Basket");
            var filter = new BsonDocument();

            List<Db.Basket> basket = new List<Db.Basket>();

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;
                    foreach (Db.Basket doc in people)
                    {
                        basket.Add(new Db.Basket(doc.Name, doc.Size, doc.Material, doc.Image));
                    }
                }
            }
           listlogin.ItemsSource = basket.Where(b => b._id == currentUser.Basket._id).ToList();

        }
    }
}
