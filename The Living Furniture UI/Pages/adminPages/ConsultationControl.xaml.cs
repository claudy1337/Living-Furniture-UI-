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
           
            lstv.ItemsSource = Consultation.GetConsList();
        }
    }
}
