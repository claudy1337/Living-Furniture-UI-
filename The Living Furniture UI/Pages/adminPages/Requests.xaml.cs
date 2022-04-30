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
using System.Collections;
using System.Collections.ObjectModel;
using The_Living_Furniture_UI.Db;
using MongoDB.Bson;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Pages.adminPages
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class Requests : Page
    {
        
        public Requests()
        {
            InitializeComponent();
            Refresh();
        }

        private void lstw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void BisCheck_Click(object sender, RoutedEventArgs e)
        {
            Db.Requests.EditRequests(false, true);
            Refresh();
        }
        public void Refresh()
        {
            listRequest.ItemsSource = null;
            listRequest.ItemsSource = Db.Requests.GetRequestList();

            //requst list
            TBName.Text = null;
            TBMaterial.Text = null;
            TBSize.Text = null;
            TBType.Text = null;

            //usr list
            TBusrAddress.Text = null;
            TBusrName.Text = null;
            TBusrLogin.Text = null;
            TBusrCard.Text = null;

        }

        private void listRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                if (listRequest.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    TBName.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).Name;
                    TBMaterial.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).Material;
                    TBSize.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).Size;
                    TBType.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).Type;

                    TBusrCard.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).User.Card.ToString();
                    TBusrName.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).User.Name.ToString();
                    TBusrLogin.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).User.Login.ToString();
                    TBusrAddress.Text = Db.Requests.GetisRequest(listRequest.SelectedItem.ToString()).User.Address.ToString();
                    // TBconsIsCheck.Text = Consultation.GetisCheckCons(listLogin.SelectedItems.ToString()).isCheck.ToString(); bool convert in string 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error", ex.Message);
            }
        }
    }
}
