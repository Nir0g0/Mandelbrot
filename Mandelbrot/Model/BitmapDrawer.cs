using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mandelbrot.Model
{
    class BitmapDrawer
    {
        public float Zoom { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public WriteableBitmap Bitmap { get; } = new WriteableBitmap(600, 400, 96, 96, PixelFormats.Bgra32, null);

        public BitmapDrawer()
        {
        }

        private Rectangle selection = new Rectangle() 
            {Stroke = Brushes.Black,
             StrokeThickness = 1,
             Visibility = Visibility.Collapsed
        };
        private bool mousedown = false;
        private Point mousedownpos;

        public void Clear(Color backgroundColor)
        {
            const int width = 600;
            const int height = 400;
            var rec = new Int32Rect(0, 0, width, height);
            var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            var bufferSize = rec.Height * stride;
            byte[] pix = new byte[bufferSize];
            for (int i = 0; i < width * height; i++)
            {
                pix[4 * i + 0] = backgroundColor.B; 
                pix[4 * i + 1] = backgroundColor.G;
                pix[4 * i + 2] = backgroundColor.R;
                pix[4 * i + 3] = backgroundColor.A;
            }
            Bitmap.WritePixels(rec, pix, stride, 0);
        }

        public void DrawCircle(int x, int y, int width, int height, int radius)
        {
            try
            {
                int widdth = width;
                int heigth = height;

                if (radius > 100)
                {
                    MessageBox.Show("Bitte gebe einen kleinen Radius an");
                    return;
                }

                var rec = new Int32Rect(x, y, widdth, heigth);
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

        public void DrawRectangle(int x, int y, int width, int height, bool fill)
        {
            try
            {
                int widdth = width;
                int heigth = height;
                
                var rec = new Int32Rect(x, y, widdth, heigth);
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
                    int widdth = width - 2;
                    int heigth = height - 2;
                    
                    var rec = new Int32Rect(x + 1, y + 1, widdth, heigth);
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

        public void DrawMendelbrot(float zoom = 1, int offset_x = 0, int offset_y = 0)
        {
            Zoom = zoom;
            OffsetX = offset_x;
            OffsetY = offset_y;

            MandelbrotSetForm.GenerateBitmap(Bitmap, zoom, offset_x, offset_y);
        }

    }
}
