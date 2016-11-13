using System;
using System.Linq;
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
        private Timer timer = new Timer(Variables.MonthDurationInSecs);

        private SpaceObjectCollection system = new SpaceObjectCollection();

        private SolidColorBrush trajectoryBrush = new SolidColorBrush(Color.FromRgb(255,255,255));

        public MainWindow()
        {
            Variables.RadiusScale = 3;
            var canvasHalfHeight = 400;
            Variables.MonthDurationInSecs = 0.5;

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

            #region Earth
            var earth = new Planet("Earth", 59.8, sun.Radius / 4, new Orbit(1 * 100, 0.017, sun.Coordinates), 12, new StandardCalculator());
            var earthBrush = new SolidColorBrush { Color = Color.FromArgb(255, 0, 255, 255) };
            SettingPlanetOnCanvas(earth, earthBrush);
            #endregion

            #region Mercury
            var mercury = new Planet("Mercury", 3.3, sun.Radius / 4, new Orbit(0.3871 * 100, 0.205, sun.Coordinates), 2.9, new StandardCalculator());
            var mercuryBrush = new SolidColorBrush {Color = Color.FromArgb(255, 95, 54, 65)};
            SettingPlanetOnCanvas(mercury, mercuryBrush);
            #endregion

            #region Venus
            var venus = new Planet("Venus", 49, sun.Radius / 4, new Orbit(0.7233 * 100, 0.007, sun.Coordinates), 7.49, new StandardCalculator());
            var venusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 189, 164, 166) };
            SettingPlanetOnCanvas(venus, venusBrush);
            #endregion

            #region Mars
            var mars = new Planet("Mars", 6.44, sun.Radius / 4, new Orbit(1.5273 * 100, 0.094, sun.Coordinates), 22.9, new StandardCalculator());
            var marsBrush = new SolidColorBrush { Color = Color.FromArgb(255, 174, 15, 2) };
            SettingPlanetOnCanvas(mars, marsBrush);
            #endregion

            #region Jupiter
            var jupiter = new Planet("Jupiter", 19000, sun.Radius / 4, new Orbit(5.2028 * 100, 0.049, sun.Coordinates), 144.3, new StandardCalculator());
            var jupiterBrush = new SolidColorBrush { Color = Color.FromArgb(255, 95, 54, 44) };
            SettingPlanetOnCanvas(jupiter, jupiterBrush);
            #endregion

            #region Saturn
            var saturn = new Planet("Saturn", 5680, sun.Radius / 4, new Orbit(9.5388 * 100, 0.057, sun.Coordinates), 358.4, new StandardCalculator());
            var saturnBrush = new SolidColorBrush { Color = Color.FromArgb(255, 86, 75, 52) };
            SettingPlanetOnCanvas(saturn, saturnBrush);
            #endregion

            #region Uranus
            var uranus = new Planet("Uranus", 870, sun.Radius / 4, new Orbit(19.1914 * 100, 0.046, sun.Coordinates), 1022, new StandardCalculator());
            var uranusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 52, 131, 226) };
            SettingPlanetOnCanvas(uranus, uranusBrush);
            #endregion

            #region Neptune
            var neptune = new Planet("Neptune", 1030, sun.Radius / 4, new Orbit(30.0611 * 100, 0.011, sun.Coordinates), 2005, new StandardCalculator());
            var neptuneBrush = new SolidColorBrush { Color = Color.FromArgb(255, 36, 47, 251) };
            SettingPlanetOnCanvas(neptune, neptuneBrush);
            #endregion

            system.AddBody(mercury);
            system.AddBody(venus);
            system.AddBody(earth);
            system.AddBody(mars);
            system.AddBody(jupiter);
            system.AddBody(saturn);
            system.AddBody(uranus);
            system.AddBody(neptune);

            InitializeComponent();

            spaceCanvas.Children.Add(sunEllipse);
            //foreach (Planet o in system)
            //{
            //    spaceCanvas.Children.Add(o.PlanetEllipse);
            //}
        }

        private void SettingPlanetOnCanvas(Planet planet, SolidColorBrush brushForPlanet)
        {
            var planetEllipse = new Ellipse()
            {
                Width = planet.Radius * 2,
                Height = planet.Radius * 2
            };

            planetEllipse.Fill = brushForPlanet;
            planet.PlanetEllipse = planetEllipse;
            planet.PlanetBrush = brushForPlanet;

            planet.ChangePosition(0);
            Canvas.SetLeft(planetEllipse, planet.Coordinates.X - planet.Radius);
            Canvas.SetBottom(planetEllipse, planet.Coordinates.Y - planet.Radius);
        }

        private bool rendering = false;
        private bool firstRound = true;

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (!rendering)
            {
                CompositionTarget.Rendering += RenderFrame;
                rendering = true;
                for (int i = 0; i < system.Count(); i++)
                {
                    timer.AddObject(system[i]);
                }
                timer.CalculateTime();
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= RenderFrame;
            rendering = false;
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            foreach (var o in system)
            {
                Ellipse newEllipsePoint = new Ellipse();
                newEllipsePoint.Fill = ((Planet)o).PlanetBrush;
                newEllipsePoint.Width = ((Planet) o).PlanetEllipse.Width;
                newEllipsePoint.Height = ((Planet)o).PlanetEllipse.Height;

                Canvas.SetLeft(newEllipsePoint, o.Coordinates.X - newEllipsePoint.Width/2);
                Canvas.SetBottom(newEllipsePoint, o.Coordinates.Y - newEllipsePoint.Width/2);

                Ellipse newTrajectoryPoint = new Ellipse();
                newTrajectoryPoint.Fill = trajectoryBrush;
                newTrajectoryPoint.Width = newEllipsePoint.Width / 10;
                newTrajectoryPoint.Height = newEllipsePoint.Height / 10;

                Canvas.SetLeft(newTrajectoryPoint, o.Coordinates.X - newTrajectoryPoint.Width/2);
                Canvas.SetBottom(newTrajectoryPoint, o.Coordinates.Y - newTrajectoryPoint.Width/2);

                spaceCanvas.Children.Add(newTrajectoryPoint);
                spaceCanvas.Children.Add(newEllipsePoint);

                if (firstRound)
                    continue;
                spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - 17);
            }
            firstRound = false;
        }
    }
}
