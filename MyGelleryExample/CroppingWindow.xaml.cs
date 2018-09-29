using System;
using System.IO;
using CroppingImageLibrary;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;


namespace MyGelleryExample
{
    /// <summary>
    /// Interaction logic for CroppingWindow.xaml
    /// </summary>
    public partial class CroppingWindow : Window
    {
        public CroppingAdorner CroppingAdorner;
        private string _photoAddres;
        public CroppingWindow(string photo)
        {
            _photoAddres = photo;
            InitializeComponent();
        }
        private void RootGrid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CroppingAdorner.CaptureMouse();
            CroppingAdorner.MouseLeftButtonDownEventHandler(sender, e);
 
        }


        private void CroppingWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(CanvasPanel);
            CroppingAdorner = new CroppingAdorner(CanvasPanel);
            adornerLayer.Add(CroppingAdorner);
        }





        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BitmapFrame croppedBitmapFrame = CroppingAdorner.GetCroppedBitmapFrame();
            //create PNG image
            BitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(croppedBitmapFrame));
            //save image to file

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "TestCropping"; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "Image png (.png)|*.png"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                using (FileStream imageFile =
                    new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(imageFile);
                    imageFile.Flush();
                    imageFile.Close();
                }
            }
        }
    }
}
