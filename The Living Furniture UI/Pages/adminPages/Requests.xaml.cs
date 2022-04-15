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
            listLogin.ItemsSource  = Db.Requests.GetRequestList();
        }

        private void listLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLogin.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                TBusrName.Text = Db.Requests.GetRequest(listLogin.SelectedItem.ToString()).Name;
                TBusrNumber.Text = Db.Requests.GetRequest(listLogin.SelectedItem.ToString()).Number;
                TBchangeSize.Text = Db.Requests.GetRequest(listLogin.SelectedItem.ToString()).Size;
                TBchangeType.Text = Db.Requests.GetRequest(listLogin.SelectedItem.ToString()).Type;
            }
        }
    }
}
