using System.Windows;
using Mandelbrot.Model;

namespace Mandelbrot.Controls
{
    /// <summary>
    /// Interaction logic for ControlBox.xaml
    /// </summary>
    public partial class ControlBox
    {
        private BitmapDrawer Model => DataContext as BitmapDrawer;

        public ControlBox()
        {
            InitializeComponent();
        }

        private void Clear_OnClick(object sender, RoutedEventArgs e)
        {
            Model.Clear();
        }
    }
}
