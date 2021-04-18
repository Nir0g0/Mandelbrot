using System.Windows.Input;
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


        private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }

        private void ZoomViewbox_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
        }
    }
}
