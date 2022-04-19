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
    /// Логика взаимодействия для FollowPage.xaml
    /// </summary>
    public partial class FollowPage : Page
    {
        public FollowPage()
        {
            InitializeComponent();
        }
        private void OnPhotoMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
           
        }

        private void PhotosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhotosListBox.SelectedItem = ViewedPhoto;
        }
    }
}
