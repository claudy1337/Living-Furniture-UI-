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
using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;
using MaterialDesignThemes.Wpf;

namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для FollowPage.xaml
    /// </summary>
    public partial class FollowPage : Page
    {
        public FollowPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void OnPhotoMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
           
        }
        private async void LoadData()
        {
            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.ImageCollection>("ImageCollection");
            var filter = new BsonDocument();
            List<Db.ImageCollection> basket = new List<Db.ImageCollection>();
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;
                    foreach (Db.ImageCollection doc in people)
                    {
                        basket.Add(new Db.ImageCollection(doc.Paths, doc.Category));
                    }
                }
            }
            PhotosListBox.ItemsSource = basket.ToList();

        }

        private void PhotosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.Show("dads");
        }
    }
}
