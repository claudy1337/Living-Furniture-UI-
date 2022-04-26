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

      
        private async void LoadData()
        {

            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Product>("Product");
            var filter = new BsonDocument();

            List<Db.Product> basket = new List<Db.Product>();

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;
                    foreach (Db.Product doc in people)
                    {
                        basket.Add(new Db.Product(doc.Category,doc.Name, doc.Price,doc.Raiting,doc.Width, doc.Height,doc.Color,doc.Structure,doc.Material,doc.Logo,doc.Photo, doc.SizeImage));
                    }
                }
            }
           listlogin.ItemsSource = basket.ToList();

        }
    }
}
