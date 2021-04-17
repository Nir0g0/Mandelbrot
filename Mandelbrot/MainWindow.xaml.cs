using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Mandelbrot {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            WriteableBitmap wb = new WriteableBitmap((int) 600, (int)400, 96, 96, PixelFormats.Bgra32, null);
            myImage.Source = wb;
        }

        public bool Fill = false;

        public void MakeScreenGreatAgain()
        {
            /*
            var wb = myImage.Source as WriteableBitmap;
            var white = new Int32Rect(0, 0, 800, 600);
            var stride = (white.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            var bufferSize = white.Height * stride;
            byte[] pix = new byte[bufferSize];
            for (int i = 0; i < 800 * 600; i++) {
                pix[4 * i + 0] = 0; // b
                pix[4 * i + 1] = 0; // g
                pix[4 * i + 2] = 255; // r
                pix[4 * i + 3] = 0; // a
            }
            wb.WritePixels(white, pix, stride, 0);
            */
            var wb = myImage.Source as WriteableBitmap;

            const int width = 600;
            const int height = 400;
            var rec = new Int32Rect(0, 0, width, height);
            var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            var bufferSize = rec.Height * stride;
            byte[] pix = new byte[bufferSize];
            for (int i = 0; i < width * height; i++) {
                pix[4 * i + 0] = 255; // b
                pix[4 * i + 1] = 255; // g
                pix[4 * i + 2] = 255; // r
                pix[4 * i + 3] = 255; // a
            }
            wb.WritePixels(rec, pix, stride, 0);
        }

        private void DrawRectangleClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    MakeScreenGreatAgain();
            //    int widdth = 0;
            //    int heigth = 0;
            //    int radius = 0;
            //    var wb = myImage.Source as WriteableBitmap;
            //    if (Int32.TryParse(widthh.Text, out int result)) {
            //        widdth = Convert.ToInt32(widthh.Text);
            //    } else {
            //        MessageBox.Show("Keine gültige Zahl");
            //    }
            //    if (Int32.TryParse(heigthh.Text, out int result2)) {
            //        heigth = Convert.ToInt32(heigthh.Text);
            //    } else {
            //        MessageBox.Show("Keine gültige Zahl");
            //    }
            //    if (Int32.TryParse(widthh.Text, out int result3)) {
            //        radius = Convert.ToInt32(Radius.Text);
            //    } else {
            //        MessageBox.Show("Keine gültige Zahl");
            //    }
            //    var rec = new Int32Rect(100, 100, widdth, heigth);
            //    var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            //    var bufferSize = rec.Height * stride;
            //    byte[] pix = new byte[bufferSize];
            //    for (int i = 0; i < widdth; i++) {
            //        for (int j = 0; j < heigth; j++)
            //        {
            //            var r = Math.Sqrt(Math.Pow(i - widdth / 2, 2) + Math.Pow(j - heigth / 2, 2));
            //            if (r <= radius)
            //            {
            //                pix[4 * (widdth * j + i) + 0] = 0; // b
            //                pix[4 * (widdth * j + i) + 1] = 0; // g
            //                pix[4 * (widdth * j + i) + 2] = 255; // r
            //                pix[4 * (widdth * j + i) + 3] = 255; // a
            //            }
            //            else
            //            {
            //                pix[4 * (widdth * j + i) + 0] = 255; // b
            //                pix[4 * (widdth * j + i) + 1] = 255; // g
            //                pix[4 * (widdth * j + i) + 2] = 255; // r
            //                pix[4 * (widdth * j + i) + 3] = 255; // a
            //            }
            //        }
            //    }
            //    wb.WritePixels(rec, pix, stride, 0);

            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.ToString());
            //}
        }

        private void DrawCircleClick(object sender, RoutedEventArgs e)
        {
            
            //var wb2 = myImage.Source as WriteableBitmap;

            //try {
            //    MakeScreenGreatAgain();
            //    int widdth = 0;
            //    int heigth = 0;
            //    var wb = myImage.Source as WriteableBitmap;
            //    if (Int32.TryParse(widthh.Text, out int result)) {
            //        widdth = Convert.ToInt32(widthh.Text);
            //    } else {
            //        MessageBox.Show("Keine gültige Zahl");
            //    }
            //    if (Int32.TryParse(heigthh.Text, out int result2)) {
            //        heigth = Convert.ToInt32(heigthh.Text);
            //    } else {
            //        MessageBox.Show("Keine gültige Zahl");
            //    }
            //    var rec = new Int32Rect(100, 100, widdth, heigth);
            //    var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            //    var bufferSize = rec.Height * stride;
            //    byte[] pix = new byte[bufferSize];
            //    for (int i = 0; i < widdth * heigth; i++) {
            //        pix[4 * i + 0] = 0; // b
            //        pix[4 * i + 1] = 0; // g
            //        pix[4 * i + 2] = 0; // r
            //        pix[4 * i + 3] = 255; // a
            //    }
            //    wb.WritePixels(rec, pix, stride, 0);
            //} catch (Exception exception) {
            //    MessageBox.Show(exception.ToString());
            //}

            //if (!Fill)
            //{
            //    try {
            //        int widdth = 0;
            //        int heigth = 0;
            //        var wb = myImage.Source as WriteableBitmap;
            //        if (Int32.TryParse(widthh.Text, out int result)) {
            //            widdth = Convert.ToInt32(widthh.Text) - 2;
            //        } else {
            //            MessageBox.Show("Keine gültige Zahl");
            //        }
            //        if (Int32.TryParse(heigthh.Text, out int result2)) {
            //            heigth = Convert.ToInt32(heigthh.Text) - 2;
            //        } else {
            //            MessageBox.Show("Keine gültige Zahl");
            //        }
            //        var rec = new Int32Rect(100 + 1, 100 + 1, widdth, heigth);
            //        var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            //        var bufferSize = rec.Height * stride;
            //        byte[] pix = new byte[bufferSize];
            //        for (int i = 0; i < widdth * heigth; i++) {
            //            pix[4 * i + 0] = 255; // b
            //            pix[4 * i + 1] = 255; // g
            //            pix[4 * i + 2] = 255; // r
            //            pix[4 * i + 3] = 255; // a
            //        }
            //        wb.WritePixels(rec, pix, stride, 0);
            //    } catch (Exception exception) {
            //        MessageBox.Show(exception.ToString());
            //    }
            //}
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            MakeScreenGreatAgain();
        }

        private void check(object sender, RoutedEventArgs e)
        {
            Fill = true;
        }

        private void uncheck(object sender, RoutedEventArgs e)
        {
            Fill = false;
        }
    }
}
