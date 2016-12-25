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

        private readonly Comet _cometHalley = new Comet();

        private bool _rendering;
        private bool _firstRound = true;
        private bool _isTrajectoryOn = true;

        const double ScaleRate = 5;
        private bool _isZoomed = true;

        public MainWindow()
        {
            InitializeComponent();
            legendGroupBox.Visibility = Visibility.Hidden;
            closeLegendButton.Visibility = Visibility.Hidden;
            showTrajectoryCheckBox.IsEnabled = true;
            Variables.EarthRadius = 10;
            Variables.RadiusOrbitScale = 100;
            Variables.EarthBigSemiaxis = 5*Variables.RadiusOrbitScale;
            zoomButton_Clicked(new object(), null);

            var ticks = new DoubleCollection { 0.01, 5 };
            secondsSlider.Ticks = ticks;

            #region Sun
            var sun = new Sun(332940, new Point(spaceCanvas.Width / 2 + spaceCanvas.Width / 8, spaceCanvas.Height / 2 - spaceCanvas.Height / 8), 14 * Variables.EarthRadius);
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

            spaceCanvas.Children.Add(sunEllipse);
            #endregion
            
            #region Mercury
            var mercury = new Planet("Mercury", 3.3, 0.38 * Variables.EarthRadius, new Orbit(0.3871 * Variables.EarthBigSemiaxis, 0.205, sun.Coordinates), 2.9, new StandardCalculator());
            var mercuryBrush = new SolidColorBrush {Color = Color.FromArgb(255, 95, 54, 65)};
            SettingObjectsOnCanvas(mercury, mercuryBrush);
            _system.AddBody(mercury);
            #endregion

            #region Venus
            var venus = new Planet("Venus", 49, 0.95 * Variables.EarthRadius, new Orbit(0.7233 * Variables.EarthBigSemiaxis, 0.007, sun.Coordinates), 7.49, new StandardCalculator());
            var venusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 189, 164, 166) };
            SettingObjectsOnCanvas(venus, venusBrush);
            _system.AddBody(venus);
            #endregion

            #region Earth
            var earth = new Planet("Earth", 59.8, Variables.EarthRadius, new Orbit(Variables.EarthBigSemiaxis, 0.017, sun.Coordinates), 12, new StandardCalculator());
            var earthBrush = new SolidColorBrush { Color = Color.FromArgb(255, 0, 255, 255) };
            SettingObjectsOnCanvas(earth, earthBrush);
            _system.AddBody(earth);
            #endregion

            #region Mars
            var mars = new Planet("Mars", 6.44, 0.53 * Variables.EarthRadius, new Orbit(1.5273 * Variables.EarthBigSemiaxis, 0.094, sun.Coordinates), 22.9, new StandardCalculator());
            var marsBrush = new SolidColorBrush { Color = Color.FromArgb(255, 174, 15, 2) };
            SettingObjectsOnCanvas(mars, marsBrush);
            _system.AddBody(mars);
            #endregion

            #region Jupiter
            var jupiter = new Planet("Jupiter", 19000, 11.2 * Variables.EarthRadius, new Orbit(5.2028 * Variables.EarthBigSemiaxis, 0.049, sun.Coordinates), 144.3, new StandardCalculator());
            var jupiterBrush = new SolidColorBrush { Color = Color.FromArgb(255, 95, 54, 44) };
            SettingObjectsOnCanvas(jupiter, jupiterBrush);
            _system.AddBody(jupiter);
            #endregion

            #region Saturn
            var saturn = new Planet("Saturn", 5680, 9.45 * Variables.EarthRadius, new Orbit(9.5388 * Variables.EarthBigSemiaxis, 0.057, sun.Coordinates), 358.4, new StandardCalculator());
            var saturnBrush = new SolidColorBrush { Color = Color.FromArgb(255, 86, 75, 52) };
            SettingObjectsOnCanvas(saturn, saturnBrush);
            _system.AddBody(saturn);
            #endregion

            #region Uranus
            var uranus = new Planet("Uranus", 870, 4.3 * Variables.EarthRadius, new Orbit(19.1914 * Variables.EarthBigSemiaxis, 0.046, sun.Coordinates), 1022, new StandardCalculator());
            var uranusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 52, 131, 226) };
            SettingObjectsOnCanvas(uranus, uranusBrush);
            _system.AddBody(uranus);
            #endregion

            #region Neptune
            var neptune = new Planet("Neptune", 1030, 3.88 * Variables.EarthRadius, new Orbit(30.0611 * Variables.EarthBigSemiaxis, 0.011, sun.Coordinates), 2005, new StandardCalculator());
            var neptuneBrush = new SolidColorBrush { Color = Color.FromArgb(255, 36, 47, 251) };
            SettingObjectsOnCanvas(neptune, neptuneBrush);
            _system.AddBody(neptune);
            #endregion

            #region Moon
            var moon = new Moon("Moon", 0.735, 0.273 * Variables.EarthRadius, new Orbit(0.00257 * Variables.EarthBigSemiaxis + Variables.EarthRadius, 0.0549, earth.Coordinates), 0.91, new StandardCalculator(), earth);
            var moonBrush = new SolidColorBrush { Color = Color.FromArgb(255, 133, 133, 133) };
            SettingObjectsOnCanvas(moon, moonBrush);
            _system.AddBody(moon);
            #endregion

            #region Phobos
            var phobos = new Moon("Phobos", 1.072 * Math.Pow(10, -7), 0.006 * moon.Radius * 100, new Orbit(6.27 * 0.01 * Variables.EarthBigSemiaxis + mars.Radius, 0.0167, mars.Coordinates), 0.009, new StandardCalculator(), mars);
            var phobosBrush = new SolidColorBrush { Color = Color.FromArgb(255, 184, 184, 100) };
            SettingObjectsOnCanvas(phobos, phobosBrush);
            _system.AddBody(phobos);
            #endregion

            #region Deimos
            var deimos = new Moon("Deimos", 1.48 * Math.Pow(10, -8), 0.004 * moon.Radius * 100, new Orbit(7.23 * 0.01 * Variables.EarthBigSemiaxis + mars.Radius, 0.0002, mars.Coordinates), 0.01, new StandardCalculator(), mars);
            var deimosBrush = new SolidColorBrush { Color = Color.FromArgb(255, 200, 133, 100) };
            SettingObjectsOnCanvas(deimos, deimosBrush);
            _system.AddBody(deimos);
            #endregion

            #region Titan
            var titan = new Moon("Titan", 1.3452, 1.48 * moon.Radius, new Orbit(0.008 * Variables.EarthBigSemiaxis + saturn.Radius, 0.0288, saturn.Coordinates), 0.514, new StandardCalculator(), saturn);
            var titanBrush = new SolidColorBrush { Color = Color.FromArgb(255, 150, 180, 150) };
            SettingObjectsOnCanvas(titan, titanBrush);
            _system.AddBody(titan);
            #endregion

            #region Ganymede
            var ganymede = new Moon("Ganymede", 1.4819, 0.413 * earth.Radius, new Orbit(0.0071 * Variables.EarthBigSemiaxis + jupiter.Radius, 0.0013, jupiter.Coordinates), 0.23, new StandardCalculator(), jupiter);
            var ganymedeBrush = new SolidColorBrush { Color = Color.FromArgb(255, 175, 170, 180) };
            SettingObjectsOnCanvas(ganymede, ganymedeBrush);
            _system.AddBody(ganymede);
            #endregion

            #region Comet Halley
            _cometHalley = new Comet("Comet Halley", 2.2 * Math.Pow(10, -9), 7.353 * Variables.EarthRadius * 0.1 * _cometHalley.Mass * Math.Pow(10, 9), new Orbit(17.83414 * Variables.EarthBigSemiaxis, 0.9671429, new Point(sun.Coordinates.X - /*16.45*/ 17.248 * earth.Orbit.BigSemiaxis , sun.Coordinates.Y /*- 5.187* earth.Orbit.BigSemiaxis*/)), 903.6, new StandardCalculator());
            var cometHalleyBrush = new SolidColorBrush { Color = Color.FromArgb(255, 255, 236, 139) };
            SettingObjectsOnCanvas(_cometHalley, cometHalleyBrush);
            _system.AddBody(_cometHalley);
            #endregion

            FillLegend();
        }

        private void FillLegend()
        {
            int i = -750;
            foreach (var obj in _system)
            {
                var tempEllipse = new Ellipse
                {
                    Margin = new Thickness(-145, i, 0, 0),
                    Height = 47
                };
                tempEllipse.Width = tempEllipse.Height;
                tempEllipse.Fill = obj.ObjectBrush;
                var tempLabel = new Label
                {
                    Content = obj.Name,
                    Margin = new Thickness(70, i, 0, 0),
                    Height = 50,
                    Width = 150,
                    FontSize = 20,
                    Foreground = new SolidColorBrush { Color = Color.FromArgb(255, 255, 255, 255) }
                };
                legendGrid.Children.Add(tempEllipse);
                legendGrid.Children.Add(tempLabel);
                i += 20 + (int)tempEllipse.Height * 2;
            }
        }

        private void SettingObjectsOnCanvas(SpaceObject spaceObject, SolidColorBrush brushForPlanet)
        {
            var spaceObjectEllipse = new Ellipse
            {
                Width = spaceObject.Radius*2,
                Height = spaceObject.Radius*2,
                Fill = brushForPlanet
            };

            spaceObject.ObjectEllipse = spaceObjectEllipse;
            spaceObject.ObjectBrush = brushForPlanet;

            spaceObject.ChangePosition(0);
            Canvas.SetLeft(spaceObjectEllipse, spaceObject.Coordinates.X - spaceObject.Radius);
            Canvas.SetBottom(spaceObjectEllipse, spaceObject.Coordinates.Y - spaceObject.Radius);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rendering) return;
            showTrajectoryCheckBox.IsEnabled = false;
            massSlider.IsEnabled = false;
            speedSlider.IsEnabled = false;
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
            if(_firstRound)
                DrawTrajectories();

            foreach (var o in _system)
            {
                var newEllipsePoint = new Ellipse
                {
                    Fill = o.ObjectBrush,
                    Width = o.ObjectEllipse.Width,
                    Height = o.ObjectEllipse.Height
                };

                Canvas.SetLeft(newEllipsePoint, o.Coordinates.X - newEllipsePoint.Width/2);
                Canvas.SetBottom(newEllipsePoint, o.Coordinates.Y - newEllipsePoint.Width/2);

                if (o is Moon)
                {
                    var moon = o as Moon;
                    moon.Orbit.CenterSpacePoint = moon.CentralObject.Coordinates;
                }

                spaceCanvas.Children.Add(newEllipsePoint);

                if (_firstRound) continue;
                const int countOfObjectsWithoutSun = 8 + 5 + 1; //Planets + their moons + comet Halley
                spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - countOfObjectsWithoutSun - 1);
            }

            _firstRound = false;
        }

        private void DrawTrajectories()
        {
            if (!_isTrajectoryOn) return;
            DrawPlanetTrajectories();
            DrawCometTrajectories();
        }

        private void DrawCometTrajectories()
        {
            foreach (var o in _system.OfType<Comet>())
            {
                DrawTrajectoryByEllipse(o);
            }
        }

        private void DrawPlanetTrajectories()
        {
            foreach (var o in _system.OfType<Planet>())
            {
                DrawTrajectoryByEllipse(o);
            }
        }

        private void DrawTrajectoryByEllipse(SpaceObject o)
        {
            var newTrajectory = new Ellipse
            {
                Stroke = _trajectoryBrush,
                Width = o.Orbit.BigSemiaxis*2,
                Height = o.Orbit.SmallSemiaxis*2
            };

            if(o is Comet)
                newTrajectory.StrokeDashArray = new DoubleCollection(new double[] {16, 4});

            var rotateTransform = new RotateTransform(o.Orbit.Angle);
            newTrajectory.RenderTransform = rotateTransform;

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

        private void zoomButton_Clicked(object sender, RoutedEventArgs e)
        {
            var st = new ScaleTransform();
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

        private void openLegendButton_Click(object sender, RoutedEventArgs e)
        {
            legendGroupBox.Visibility = Visibility.Visible;
            closeLegendButton.Visibility = Visibility.Visible;
            openLegendButton.Visibility = Visibility.Hidden;
        }

        private void closeLegendButton_Click(object sender, RoutedEventArgs e)
        {
            legendGroupBox.Visibility = Visibility.Hidden;
            closeLegendButton.Visibility = Visibility.Hidden;
            openLegendButton.Visibility = Visibility.Visible;
        }

        private void massSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _cometHalley.Mass = e.NewValue * Math.Pow(10, -9);
        }

        private void SpeedSlider_OnValueChangedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _cometHalley.MonthsPerOneTurn = e.NewValue * 12;
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }
    }
}