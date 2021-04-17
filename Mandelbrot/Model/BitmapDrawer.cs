using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mandelbrot.Model
{
    class BitmapDrawer
    {
        public WriteableBitmap Bitmap { get; } = new WriteableBitmap(600, 400, 96, 96, PixelFormats.Bgra32, null);

        public BitmapDrawer()
        {
            // ToDo remove this
            DrawRectangle(100, 100, true);
            DrawCircle(50, 50, 25);
        }

        public void Clear()
        {
            const int width = 600;
            const int height = 400;
            var rec = new Int32Rect(0, 0, width, height);
            var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            var bufferSize = rec.Height * stride;
            byte[] pix = new byte[bufferSize];
            for (int i = 0; i < width * height; i++)
            {
                pix[4 * i + 0] = 255; // b
                pix[4 * i + 1] = 255; // g
                pix[4 * i + 2] = 255; // r
                pix[4 * i + 3] = 255; // a
            }
            Bitmap.WritePixels(rec, pix, stride, 0);
        }

        private void DrawCircle(int width, int height, int radius)
        {
            try
            {
                int widdth = width;
                int heigth = height;
                
                var rec = new Int32Rect(100, 100, widdth, heigth);
                var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
                var bufferSize = rec.Height * stride;
                byte[] pix = new byte[bufferSize];
                for (int i = 0; i < widdth; i++)
                {
                    for (int j = 0; j < heigth; j++)
                    {
                        var r = Math.Sqrt(Math.Pow(i - widdth / 2, 2) + Math.Pow(j - heigth / 2, 2));
                        if (r <= radius)
                        {
                            pix[4 * (widdth * j + i) + 0] = 0; // b
                            pix[4 * (widdth * j + i) + 1] = 0; // g
                            pix[4 * (widdth * j + i) + 2] = 255; // r
                            pix[4 * (widdth * j + i) + 3] = 255; // a
                        }
                        else
                        {
                            pix[4 * (widdth * j + i) + 0] = 255; // b
                            pix[4 * (widdth * j + i) + 1] = 255; // g
                            pix[4 * (widdth * j + i) + 2] = 255; // r
                            pix[4 * (widdth * j + i) + 3] = 255; // a
                        }
                    }
                }
                Bitmap.WritePixels(rec, pix, stride, 0);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void DrawRectangle(int width, int height, bool fill)
        {
            try
            {
                int widdth = width;
                int heigth = height;
                
                var rec = new Int32Rect(100, 100, widdth, heigth);
                var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
                var bufferSize = rec.Height * stride;
                byte[] pix = new byte[bufferSize];
                for (int i = 0; i < widdth * heigth; i++)
                {
                    pix[4 * i + 0] = 0; // b
                    pix[4 * i + 1] = 0; // g
                    pix[4 * i + 2] = 0; // r
                    pix[4 * i + 3] = 255; // a
                }
                Bitmap.WritePixels(rec, pix, stride, 0);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            if (!fill)
            {
                try
                {
                    int widdth = width;
                    int heigth = height;
                    
                    var rec = new Int32Rect(100 + 1, 100 + 1, widdth, heigth);
                    var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
                    var bufferSize = rec.Height * stride;
                    byte[] pix = new byte[bufferSize];
                    for (int i = 0; i < widdth * heigth; i++)
                    {
                        pix[4 * i + 0] = 255; // b
                        pix[4 * i + 1] = 255; // g
                        pix[4 * i + 2] = 255; // r
                        pix[4 * i + 3] = 255; // a
                    }
                    Bitmap.WritePixels(rec, pix, stride, 0);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }

    }
}
