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
using MongoDB.Bson.IO;

namespace The_Living_Furniture_UI.Pages.adminPages
{
    /// <summary>
    /// Логика взаимодействия для ConsultationControl.xaml
    /// </summary>
    public partial class ConsultationControl : Page
    {
        public ConsultationControl()
        {
            InitializeComponent();
            Refresh();  

        }

        private void BFullList_Click(object sender, RoutedEventArgs e)
        {
            listLogin.ItemsSource = Db.Consultation.GetAllConsList();
        }
        private void BDontCheck_Click(object sender, RoutedEventArgs e)
        {
            listLogin.ItemsSource = Db.Consultation.GetConsList();
        }
        private async void BisCheckConsultation_Click(object sender, RoutedEventArgs e)
        {
            Db.Consultation.UpdateCons(Consultation.GetisCheckCons(listLogin.SelectedItem.ToString()).Number, true);
            MessageBox.Show("Заявка обработана");
            Refresh();

        }

        private void listLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listLogin.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    var slectedRequest = listLogin.SelectedItem.ToString();
                    TBusrName.Text = Consultation.GetisCheckCons(slectedRequest).Name;
                    TBusrNumber.Text = Consultation.GetisCheckCons(slectedRequest).Number;
                    if (Consultation.GetisCheckCons(slectedRequest).isCheck == true)
                        TBconsIsCheck.Text = "DONE";
                    else
                        TBconsIsCheck.Text = "NOT DONE";
                  
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.ToString()); 
            }
            
        }

        public void Refresh()
        {
            TBusrName.Text = null;
            TBusrNumber.Text = null;
            listLogin.ItemsSource = null;
            listLogin.ItemsSource = Db.Consultation.GetConsList();   
        }
       
    }
}
