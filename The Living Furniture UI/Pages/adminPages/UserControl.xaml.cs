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
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UserControl : Page
    {
        public UserControl()
        {
            InitializeComponent();
            LoadData();
            usrList.ItemsSource = Db.User.GetAllUserList();
        }
        private async void LoadData()
        {

            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Consultation");
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
           // listlogin.ItemsSource = basket.ToList();

        }

        private void usrList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (usrList.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    var slectedRequest = usrList.SelectedItem.ToString();
                    TBusrName.Text = Db.User.GetUser(slectedRequest).Name;
                    TBusrLogin.Text = Db.User.GetUser(slectedRequest).Login;
                    TBusrdCard.Text = Db.User.GetUser(slectedRequest).Card.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
