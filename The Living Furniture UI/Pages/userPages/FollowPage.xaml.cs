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
using System.Reflection;
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;
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
                       basket.Add(new Db.Product(doc._id, doc.Category, doc.Name, doc.Price, doc.Raiting, doc.Width, doc.Height, doc.Color, doc.Structure, doc.Material, doc.Logo, doc.Photo, doc.SizeImage));
                    }
                }
            }
            PhotosListBox.ItemsSource = basket.ToList();

        }

        private void PhotosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Db.Product imageCollection = (Db.Product)PhotosListBox.SelectedItem;
            imgScreen.Source = new BitmapImage(new Uri(imageCollection.Photo, UriKind.Relative));
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
