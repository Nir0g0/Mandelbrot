using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Mandelbrot
{
    /// <summary>
    /// Generates bitmap of Mandelbrot Set and display it on the form.
    /// </summary>
    public class MandelbrotSetForm
    {
         const double MaxValueExtentStart = 2.0;
         static double MaxValueExtent;

        static double CalcMandelbrotSetColor(ComplexNumber c)
        {
            // from http://en.wikipedia.org/w/index.php?title=Mandelbrot_set
            const int MaxIterations = 500;
            const double MaxNorm = MaxValueExtentStart * MaxValueExtentStart;

            int iteration = 0;
            ComplexNumber z = new ComplexNumber();
            do
            {
                z = z * z + c;
                iteration++;
            } while (z.Norm() < MaxNorm && iteration < MaxIterations);

            if (iteration < MaxIterations)
                return (double) iteration / MaxIterations;
            else
                return 0; // black
        }

        public static void GenerateBitmap(WriteableBitmap bitmap, float zoom = 1, int offset_x = 0, int offset_y = 0)
        {
            MaxValueExtent = MaxValueExtentStart / zoom; 
            var rec = new Int32Rect(0, 0, (int) bitmap.Width, (int) bitmap.Height);
            var stride = (rec.Width * PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
            var bufferSize = rec.Height * stride;
            byte[] pix = new byte[bufferSize];

            double scale = 2 * MaxValueExtent / Math.Min(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Height; i++)
            {
                double y = (bitmap.Height / 2 - i + offset_y) * scale;
                for (int j = 0; j < bitmap.Width; j++)
                {
                    double x = (j - bitmap.Width / 2 + offset_x) * scale;
                    double value= CalcMandelbrotSetColor(new ComplexNumber(x, y));
                    var color = GetColor(value);
        
                    pix[4 * ((int)bitmap.Width * i + j) + 0] = color.B; // b
                    pix[4 * ((int)bitmap.Width * i + j) + 1] = color.G; // g
                    pix[4 * ((int)bitmap.Width * i + j) + 2] = color.R; // r
                    pix[4 * ((int)bitmap.Width * i + j) + 3] = color.A; // a
                }
            }

            bitmap.WritePixels(rec, pix, stride, 0);
        }

        static Color GetColor(double value)
        {
            const double MaxColor = 256;
            const double ContrastValue = 0.2;
            return Color.FromArgb(255,0, 0,
                (byte) (MaxColor * Math.Pow(value, ContrastValue)));
        }
        
    }

    struct ComplexNumber
    {
        public double Re;
        public double Im;

        public ComplexNumber(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }

        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re + y.Re, x.Im + y.Im);
        }

        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re * y.Re - x.Im * y.Im,
                x.Re * y.Im + x.Im * y.Re);
        }

        public double Norm()
        {
            return Re * Re + Im * Im;
        }
    }
}