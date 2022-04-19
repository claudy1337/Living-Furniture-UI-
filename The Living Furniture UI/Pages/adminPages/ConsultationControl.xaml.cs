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
            listLogin.ItemsSource = Db.Consultation.GetConsList();
            
        }

        private void BFullList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BisCheckConsultation_Click(object sender, RoutedEventArgs e)
        {
            var selectedCons = listLogin.SelectedItem as Db.Consultation;
            Db.Consultation.EditCons(selectedCons.isCheck, true);
            MessageBox.Show("Заявка обработана");
        }

        private void listLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLogin.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                TBusrName.Text = Consultation.GetCons(listLogin.SelectedItem.ToString()).Name;
                TBusrNumber.Text = Consultation.GetCons(listLogin.SelectedItem.ToString()).Number;
            }
        }
    }
}
