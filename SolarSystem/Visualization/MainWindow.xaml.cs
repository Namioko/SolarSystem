using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SolarSystem.CoordinatesCalculation;
using SolarSystem.ObjectsInSpace;

namespace Visualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Variables.RadiusScale = 10;
            var canvasHalfHeight = 400;

            #region Sun
            var sun = new Sun(332940, new System.Drawing.Point(canvasHalfHeight, canvasHalfHeight), 11 * Variables.RadiusScale);
            var sunEllipse = new Ellipse
            {
                Width = sun.Radius * 2,
                Height = sun.Radius * 2
            };

            var sunBrush = new SolidColorBrush {Color = Color.FromArgb(255, 255, 255, 0)};
            sunEllipse.Fill = sunBrush;

            Canvas.SetLeft(sunEllipse, sun.Coordinates.X - sun.Radius);
            Canvas.SetBottom(sunEllipse, sun.Coordinates.Y - sun.Radius);
            #endregion

            #region
            var earth = new Planet("Earth", 1, 1, new Orbit(1, 0.017), 12, new StandardCalculator());
            var earthEllipse = new Ellipse()
            {
                Width = earth.Radius * 2,
                Height = earth.Radius * 2
            };
            var earthBrush = new SolidColorBrush { Color = Color.FromArgb(255, 0, 255, 255) };
            earthEllipse.Fill = earthBrush;

            Canvas.SetLeft(earthEllipse, earth.Coordinates.X - earth.Radius);
            Canvas.SetBottom(earthEllipse, earth.Coordinates.Y - earth.Radius);
            #endregion

            InitializeComponent();

            spaceCanvas.Children.Add(sunEllipse);
            spaceCanvas.Children.Add(earthEllipse);
        }
    }
}
