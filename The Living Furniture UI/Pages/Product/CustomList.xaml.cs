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
        public static Db.User currentUser;
       
        public CustomList(Db.User user)
        {
            InitializeComponent();
            TBPrice.Text = CategoryLogged.Category;
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
           listlogin.ItemsSource = basket.ToList().Where(b=> b.Category== CategoryLogged.Category);

        }

        private void BtnShowProd_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = listlogin.SelectedItem as Db.Product;
            NavigationService.Navigate(new ProductInfo(selectedProduct, currentUser));
        }

        private void listlogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            CategoryLstw();
        }
        public async void CategoryLstw()
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
                        basket.Add(new Db.Product(doc.Category, doc.Name, doc.Price, doc.Raiting, doc.Width, doc.Height, doc.Color, doc.Structure, doc.Material, doc.Logo, doc.Photo, doc.SizeImage));
                    }
                }
            }
            listlogin.ItemsSource = basket.ToList().Where(b => b.Category == CBCategory.Text && b.Material == CBMaterial.Text );
            //cb.category="" 
        }
    }
}
