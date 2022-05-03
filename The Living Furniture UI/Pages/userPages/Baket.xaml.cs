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
            //listBasket.ItemsSource = Db.Basket.ShowProductsInCategory("Table");
            LoadData();
        }
        private async void LoadData()
        {

            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.User>("User");
            var filter = new BsonDocument();

            List<Db.ModifyProducts> basket = new List<Db.ModifyProducts>();

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;
                    foreach (Db.ModifyProducts doc in people)
                    {
                        basket.Add(new Db.ModifyProducts(doc._id, doc.Category, doc.Name, doc.Price, doc.Raiting, doc.Width, doc.Height, doc.Color, doc.Structure, doc.Material, doc.Logo, doc.Photo, doc.SizeImage));
                    }
                }
            }
            listlogin.ItemsSource = basket.ToList().Where(b => b.Category == CategoryLogged.Category);

        }

    }
}
