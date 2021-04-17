using System;
using System.Windows;
using System.Windows.Media;
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
            var clearColorText = ClearColor.SelectionBoxItem as String;
            var convertedColor = ColorConverter.ConvertFromString(clearColorText);
            var color = (Color)(convertedColor ?? Colors.White);
            Model.Clear(color);
        }
    }
}
