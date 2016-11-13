using System;
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
        private SpaceObjectCollection system = new SpaceObjectCollection();
        private Timer timer = new Timer(Variables.MonthDurationInSecs);

        private Planet earth;
        private Ellipse earthEllipse;
        private SolidColorBrush earthBrush;
        private SolidColorBrush trajectoryBrush = new SolidColorBrush(Color.FromRgb(255,255,255));

        public MainWindow()
        {
            Variables.RadiusScale = 3;
            var canvasHalfHeight = 400;
            Variables.MonthDurationInSecs = 0.1;

            #region Sun
            var sun = new Sun(332940, new Point(canvasHalfHeight, canvasHalfHeight), 11 * Variables.RadiusScale);
            var sunEllipse = new Ellipse
            {
                Width = sun.Radius * 2,
                Height = sun.Radius * 2
            };

            var sunBrush = new SolidColorBrush { Color = Color.FromArgb(255, 255, 255, 0) };
            sunEllipse.Fill = sunBrush;

            Canvas.SetLeft(sunEllipse, sun.Coordinates.X - sun.Radius);
            Canvas.SetBottom(sunEllipse, sun.Coordinates.Y - sun.Radius);
            #endregion

            #region
            earth = new Planet("Earth", 1, sun.Radius / 4, new Orbit(1*100, 0.017, sun.Coordinates), 12, new StandardCalculator());
            earthEllipse = new Ellipse()
            {
                Width = earth.Radius * 2,
                Height = earth.Radius * 2
            };
            earthBrush = new SolidColorBrush { Color = Color.FromArgb(255, 0, 255, 255) };
            earthEllipse.Fill = earthBrush;

            earth.ChangePosition(0);
            Canvas.SetLeft(earthEllipse, earth.Coordinates.X - earth.Radius);
            Canvas.SetBottom(earthEllipse, earth.Coordinates.Y - earth.Radius);
            #endregion

            system.AddBody(earth);

            InitializeComponent();

            spaceCanvas.Children.Add(sunEllipse);
            spaceCanvas.Children.Add(earthEllipse);
        }

        private bool rendering = false;

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (!rendering)
            {
                CompositionTarget.Rendering += RenderFrame;
                rendering = true;
                timer.AddObject(earth);
                timer.CalculateTime();
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            //spaceCanvas.Children.RemoveRange(3, spaceCanvas.Children.Count - 3);
            CompositionTarget.Rendering -= RenderFrame;
            rendering = false;
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            foreach (var o in system)
            {
                Ellipse newEllipsePoint = new Ellipse();
                newEllipsePoint.Fill = earthBrush;
                newEllipsePoint.Width = earthEllipse.Width;
                newEllipsePoint.Height = earthEllipse.Height;

                Canvas.SetLeft(newEllipsePoint, o.Coordinates.X - newEllipsePoint.Width/2);
                Canvas.SetBottom(newEllipsePoint, o.Coordinates.Y - newEllipsePoint.Width/2);

                Ellipse newTrajectoryPoint = new Ellipse();
                newTrajectoryPoint.Fill = trajectoryBrush;
                newTrajectoryPoint.Width = earthEllipse.Width / 10;
                newTrajectoryPoint.Height = earthEllipse.Height / 10;

                Canvas.SetLeft(newTrajectoryPoint, o.Coordinates.X - newTrajectoryPoint.Width/2);
                Canvas.SetBottom(newTrajectoryPoint, o.Coordinates.Y - newTrajectoryPoint.Width/2);

                spaceCanvas.Children.Add(newTrajectoryPoint);
                spaceCanvas.Children.Add(newEllipsePoint);
                spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - 3);
            }
        }
    }
}
