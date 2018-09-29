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
using Microsoft.Win32;

namespace MyGelleryExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CroppingWindow _croppingWindow;
        public PhotoCollection Photos;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnImagesDirChangeClick(object sender, RoutedEventArgs e)
        {
            this.Photos.Path = ImagesDir.Text;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ImagesDir.Text = Environment.CurrentDirectory + "\\images";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var photo = PhotosListBox.SelectedItem;
           
            if (photo != null)
            {
                //var x = op.FileName;
                   _croppingWindow = new CroppingWindow( photo.ToString());
                _croppingWindow.Closed += (a, b) => _croppingWindow = null;
               // _croppingWindow.Height = new BitmapImage(new Uri(photo.ToString())).Height;
                _croppingWindow.Height = 700;
               // _croppingWindow.Width = new BitmapImage(new Uri(photo.ToString())).Width;
                _croppingWindow.Width = 900;

                _croppingWindow.SourceImage.Source = new BitmapImage(new Uri(photo.ToString()));
               // _croppingWindow.SourceImage.Height = new BitmapImage(new Uri(photo.ToString())).Height;
                _croppingWindow.SourceImage.Height = 500;
               // _croppingWindow.SourceImage.Width = new BitmapImage(new Uri(photo.ToString())).Width;
                _croppingWindow.SourceImage.Width = 700;
               


                _croppingWindow.Show();
            }

        }
    }
}
