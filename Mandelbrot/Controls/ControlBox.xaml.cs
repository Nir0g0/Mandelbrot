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
            Clear();
        }

        private void Clear()
        {
            var clearColorText = ClearColor.SelectionBoxItem as String;
            var convertedColor = ColorConverter.ConvertFromString(clearColorText);
            var color = (Color)(convertedColor ?? Colors.White);
            Model.Clear(color);
        }

        private void DrawCircleClick(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(centerx.Text, out var width))
            {
                MessageBox.Show("Ungültiges CenterX");
            }
            if (!Int32.TryParse(centery.Text, out var height)) {
                MessageBox.Show("Ungültiges CenterY");
            }
            if (!Int32.TryParse(this.radius.Text, out var radius)) {
                MessageBox.Show("Ungültiger Radius");
            }
            Model.DrawCircle(width, height, 400, 200, radius);
        }

        private void DrawRectangleClick(object sender, RoutedEventArgs e) {
            if (!Int32.TryParse(this.left.Text, out var left)) {
                MessageBox.Show("Ungültige Position links");
            }
            if (!Int32.TryParse(this.top.Text, out var top)) {
                MessageBox.Show("Ungültige Position oben");
            }
            if (!Int32.TryParse(Width.Text, out var width)) {
                MessageBox.Show("Ungültiger Radius");
            }
            if (!Int32.TryParse(this.height.Text, out var height)) {
                MessageBox.Show("Ungültiger Radius");
            }
            var fill = RectCheckboxFill.IsChecked ?? true;
            Model.DrawRectangle(left, top, width, height, fill);
        }

        private void DrawMendelbrotMenge(object sender, RoutedEventArgs e)
        {
            Model.DrawMendelbrot();
        }
    }
}
