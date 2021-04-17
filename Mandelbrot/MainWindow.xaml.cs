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


    }
}
