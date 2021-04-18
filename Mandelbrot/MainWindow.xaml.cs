using System;
using System.Windows.Input;
using System.Windows.Media;
using Mandelbrot.Model;

namespace Mandelbrot {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            DataContext = new BitmapDrawer();
        }

        private BitmapDrawer Model => DataContext as BitmapDrawer;


        private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }

        private void ZoomViewbox_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var zoom = Model.Zoom * ((e.Delta > 0) ? 2f : 0.8f);
            var pos = e.GetPosition(Image);
            var offsetx = Model.OffsetX + (int)(pos.X / Model.Zoom) - (int)((Model.Bitmap.Width / 2) / Model.Zoom);
            var offsety = Model.OffsetY + (int)(-pos.Y / Model.Zoom) + (int)((Model.Bitmap.Height / 2) / Model.Zoom);
            Model.DrawMendelbrot(zoom, offsetx, offsety);
        }
    }
}
