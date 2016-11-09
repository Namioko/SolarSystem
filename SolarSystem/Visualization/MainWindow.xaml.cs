using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SolarSystem.ObjectsInSpace;

namespace Visualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Sun sun = new Sun(332940, new System.Drawing.Point(400, 400), 10);
            Ellipse sunEllipse = new Ellipse
            {
                Name = "sunEllipse",
                Width = sun.Radius,
                Height = sun.Radius
            };
            // Create a SolidColorBrush with a red color to fill the 
            // Ellipse with.
            SolidColorBrush sunBrush = new SolidColorBrush();

            // Describes the brush's color using RGB values. 
            // Each value has a range of 0-255.
            sunBrush.Color = Color.FromArgb(255, 255, 255, 0);
            sunEllipse.Fill = sunBrush;
            sunEllipse.StrokeThickness = 2;
            sunEllipse.Stroke = Brushes.Black;

            Canvas.SetLeft(sunEllipse, sun.Coordinates.X);
            Canvas.SetBottom(sunEllipse, sun.Coordinates.Y);
            
            InitializeComponent();

            spaceCanvas.Children.Add(sunEllipse);
        }
    }
}
