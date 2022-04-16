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
        public Baket()
        {
            InitializeComponent();
            LoadData();
            //listlogin.ItemsSource = 
        }

        private async void LoadData()
        {
            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Basket>("Basket");
            var filter = new BsonDocument();

            List<Db.Basket> students = new List<Db.Basket>();

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;
                    foreach (Db.Basket doc in people)
                    {
                        students.Add(new Db.Basket(doc.Name, doc.Size, doc.Material));
                    }
                }
            }
            listlogin.ItemsSource = students;

        }


    }
}
