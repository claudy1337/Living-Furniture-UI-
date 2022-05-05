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


namespace The_Living_Furniture_UI.Pages.userPages
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        
        public main()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void BSendConsultation_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBusrName.Text) && string.IsNullOrEmpty(TBusrNumber.Text))
                MessageBox.Show("null");
            else
            {
                Db.Consultation consultation = new Db.Consultation(TBusrName.Text, TBusrName.Text, false);
                Db.Consultation.SendToConsultation(consultation);
                prg.Visibility = Visibility.Visible;
                for (int i = 0; i < 100; i++)
                    prg.Value = i;
                MessageBox.Show("консультация отправлена");
                prg.Value = 0;
                prg.Visibility = Visibility.Hidden;
                TBusrNumber.Text = null;
                TBusrName.Text = null;
            }
            
        }
    }
}
