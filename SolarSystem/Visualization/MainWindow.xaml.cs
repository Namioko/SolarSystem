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
    public partial class MainWindow
    {
        private readonly Timer _timer = new Timer(Variables.MonthDurationInSecs);

        private readonly SpaceObjectCollection _system = new SpaceObjectCollection();

        private readonly SolidColorBrush _trajectoryBrush = new SolidColorBrush(Color.FromRgb(255,255,255));

        public MainWindow()
        {
            InitializeComponent();
            Variables.EarthRadius = 10;
            Variables.RadiusOrbitScale = 100;
            Variables.MonthDurationInSecs = 1;
            
            #region Sun
            var sun = new Sun(332940, new Point(spaceCanvas.Width / 2 + 500, spaceCanvas.Height / 2 - 700), 14 * Variables.EarthRadius);
            var sunEllipse = new Ellipse
            {
                Width = sun.Radius * 2,
                Height = sun.Radius * 2
            };

            var sunBrush = new SolidColorBrush { Color = Color.FromArgb(255, 255, 255, 0) };
            sunEllipse.Fill = sunBrush;
            sunEllipse.Name = "Sun";

            Canvas.SetLeft(sunEllipse, sun.Coordinates.X - sun.Radius);
            Canvas.SetBottom(sunEllipse, sun.Coordinates.Y - sun.Radius);
            #endregion

            #region Earth
            var earth = new Planet("Earth", 59.8, Variables.EarthRadius, new Orbit(5 * Variables.RadiusOrbitScale, 0.017, sun.Coordinates), 12, new StandardCalculator());
            var earthBrush = new SolidColorBrush { Color = Color.FromArgb(255, 0, 255, 255) };
            SettingObjectsOnCanvas(earth, earthBrush);
            #endregion

            #region Mercury
            var mercury = new Planet("Mercury", 3.3, 0.38 * Variables.EarthRadius, new Orbit(0.3871 * earth.Orbit.BigSemiaxis, 0.205, sun.Coordinates), 2.9, new StandardCalculator());
            var mercuryBrush = new SolidColorBrush {Color = Color.FromArgb(255, 95, 54, 65)};
            SettingObjectsOnCanvas(mercury, mercuryBrush);
            #endregion

            #region Venus
            var venus = new Planet("Venus", 49, 0.95 * Variables.EarthRadius, new Orbit(0.7233 * earth.Orbit.BigSemiaxis, 0.007, sun.Coordinates), 7.49, new StandardCalculator());
            var venusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 189, 164, 166) };
            SettingObjectsOnCanvas(venus, venusBrush);
            #endregion

            #region Mars
            var mars = new Planet("Mars", 6.44, 0.53 * Variables.EarthRadius, new Orbit(1.5273 * earth.Orbit.BigSemiaxis, 0.094, sun.Coordinates), 22.9, new StandardCalculator());
            var marsBrush = new SolidColorBrush { Color = Color.FromArgb(255, 174, 15, 2) };
            SettingObjectsOnCanvas(mars, marsBrush);
            #endregion

            #region Jupiter
            var jupiter = new Planet("Jupiter", 19000, 11.2 * Variables.EarthRadius, new Orbit(5.2028 * earth.Orbit.BigSemiaxis, 0.049, sun.Coordinates), 144.3, new StandardCalculator());
            var jupiterBrush = new SolidColorBrush { Color = Color.FromArgb(255, 95, 54, 44) };
            SettingObjectsOnCanvas(jupiter, jupiterBrush);
            #endregion

            #region Saturn
            var saturn = new Planet("Saturn", 5680, 9.45 * Variables.EarthRadius, new Orbit(9.5388 * earth.Orbit.BigSemiaxis, 0.057, sun.Coordinates), 358.4, new StandardCalculator());
            var saturnBrush = new SolidColorBrush { Color = Color.FromArgb(255, 86, 75, 52) };
            SettingObjectsOnCanvas(saturn, saturnBrush);
            #endregion

            #region Uranus
            var uranus = new Planet("Uranus", 870, 4.3 * Variables.EarthRadius, new Orbit(19.1914 * earth.Orbit.BigSemiaxis, 0.046, sun.Coordinates), 1022, new StandardCalculator());
            var uranusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 52, 131, 226) };
            SettingObjectsOnCanvas(uranus, uranusBrush);
            #endregion

            #region Neptune
            var neptune = new Planet("Neptune", 1030, 3.88 * Variables.EarthRadius, new Orbit(30.0611 * earth.Orbit.BigSemiaxis, 0.011, sun.Coordinates), 2005, new StandardCalculator());
            var neptuneBrush = new SolidColorBrush { Color = Color.FromArgb(255, 36, 47, 251) };
            SettingObjectsOnCanvas(neptune, neptuneBrush);
            #endregion

            #region Moon
            var moon = new Moon("Moon", 0.735, 1.16138017 * 0.1 * Variables.EarthRadius, new Orbit(0.00257 * earth.Orbit.BigSemiaxis + Variables.EarthRadius, 0.0549, earth.Coordinates), 0.91, new StandardCalculator(), earth);
            var moonBrush = new SolidColorBrush { Color = Color.FromArgb(255, 133, 133, 133) };
            SettingObjectsOnCanvas(moon, moonBrush);
            #endregion

            #region Phobos
            var phobos = new Moon("Phobos", 1.072 * 0.0000001, 1.72 * 0.1 * Variables.EarthRadius, new Orbit(6.27 * 0.01 * earth.Orbit.BigSemiaxis + Variables.EarthRadius, 0.0167, mars.Coordinates), 0.009, new StandardCalculator(), mars);
            var phobosBrush = new SolidColorBrush { Color = Color.FromArgb(255, 133, 133, 133) };
            SettingObjectsOnCanvas(phobos, phobosBrush);
            #endregion

            #region Deimos
            var deimos = new Moon("Deimos", 1.48 * 0.00000001, 1.72 * 0.1 * Variables.EarthRadius, new Orbit(7.23 * 0.01 * earth.Orbit.BigSemiaxis + Variables.EarthRadius, 0.0002, mars.Coordinates), 0.01, new StandardCalculator(), mars);
            var deimosBrush = new SolidColorBrush { Color = Color.FromArgb(255, 133, 133, 133) };
            SettingObjectsOnCanvas(deimos, deimosBrush);
            #endregion

            _system.AddBody(mercury);
            _system.AddBody(venus);
            _system.AddBody(earth);
            _system.AddBody(mars);
            _system.AddBody(jupiter);
            _system.AddBody(saturn);
            _system.AddBody(uranus);
            _system.AddBody(neptune);
            _system.AddBody(moon);
            _system.AddBody(phobos);
            _system.AddBody(deimos);
            
            var ticks = new DoubleCollection { 0.01, 5 };
            slider.Ticks = ticks;

            spaceCanvas.Children.Add(sunEllipse);
        }
        
        private static void SettingObjectsOnCanvas(SpaceObject spaceObject, SolidColorBrush brushForPlanet)
        {
            var planetEllipse = new Ellipse
            {
                Width = spaceObject.Radius*2,
                Height = spaceObject.Radius*2,
                Fill = brushForPlanet
            };

            spaceObject.ObjectEllipse = planetEllipse;
            spaceObject.ObjecttBrush = brushForPlanet;

            spaceObject.ChangePosition(0);
            Canvas.SetLeft(planetEllipse, spaceObject.Coordinates.X - spaceObject.Radius);
            Canvas.SetBottom(planetEllipse, spaceObject.Coordinates.Y - spaceObject.Radius);
        }

        private bool _rendering;
        private bool _firstRound = true;
        private bool _isTrajectoryOn = true;

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rendering) return;
            showTrajectoryCheckBox.Visibility = Visibility.Hidden;
            CompositionTarget.Rendering += RenderFrame;
            _rendering = true;
            for (var i = 0; i < _system.Count(); i++)
            {
                _timer.AddObject(_system[i]);
            }
            _timer.CalculateTime();
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            if(_firstRound && _isTrajectoryOn)
                foreach (var o in _system.OfType<Planet>())
                {
                    DrawTrajectoryByEllipse(o);
                }

            foreach (var o in _system)
            {
                var newEllipsePoint = new Ellipse
                {
                    Fill = o.ObjecttBrush,
                    Width = o.ObjectEllipse.Width,
                    Height = o.ObjectEllipse.Height
                };

                Canvas.SetLeft(newEllipsePoint, o.Coordinates.X - newEllipsePoint.Width/2);
                Canvas.SetBottom(newEllipsePoint, o.Coordinates.Y - newEllipsePoint.Width/2);
                
                spaceCanvas.Children.Add(newEllipsePoint);
                if (_firstRound) continue;
                const int countOfObjectsWithoutSun = 8 + 3; //Planets + their moons
                var moon = o as Moon;
                if (moon != null)
                    moon.Orbit.CenterSpacePoint = moon.CentralObject.Coordinates;
                spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - countOfObjectsWithoutSun - 1);
            }

            _firstRound = false;
        }

        private void DrawTrajectoryByEllipse(SpaceObject o)
        {
            var newTrajectory = new Ellipse
            {
                Stroke = _trajectoryBrush,
                Width = o.Orbit.BigSemiaxis*2,
                Height = o.Orbit.SmallSemiaxis*2
            };

            Canvas.SetLeft(newTrajectory, o.Orbit.CenterSpacePoint.X - newTrajectory.Width/2);
            Canvas.SetBottom(newTrajectory, o.Orbit.CenterSpacePoint.Y - newTrajectory.Height/2);

            spaceCanvas.Children.Add(newTrajectory);
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= RenderFrame;
            _rendering = false;
            _timer.StopCalculating();
        }

        const double ScaleRate = 5;
        private bool _isZoomed = true;
        private void zoomButton_Clicked(object sender, RoutedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            spaceCanvas.RenderTransform = st;
            if (_isZoomed)
            {
                st.ScaleX /= ScaleRate;
                st.ScaleY /= ScaleRate;
                _isZoomed = false;
                zoomButton.Content = "Zoom in";
                spaceCanvas.Margin = new Thickness(spaceCanvas.Width / 2, spaceCanvas.Height / 2, 0, 0);
            }
            else
            {
                //st.ScaleX *= ScaleRate;
                //st.ScaleY *= ScaleRate;
                _isZoomed = true;
                zoomButton.Content = "Zoom out";
                spaceCanvas.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Variables.MonthDurationInSecs = e.NewValue;
        }

        private void showTrajectoryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _isTrajectoryOn = true;
        }

        private void showTrajectoryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _isTrajectoryOn = false;
        }
    }
}
