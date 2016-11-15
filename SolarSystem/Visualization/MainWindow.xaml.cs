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

        private Sun sun;
        //private Ellipse sunEllipse;

        private SolidColorBrush trajectoryBrush = new SolidColorBrush(Color.FromRgb(255,255,255));

        public MainWindow()
        {
            Variables.RadiusScale = 10;
            Variables.RadiusOrbitScale = 100;
            var canvasHalfHeight = 3100;
            Variables.MonthDurationInSecs = 1;

            #region Sun
            sun = new Sun(332940, new Point(canvasHalfHeight, canvasHalfHeight), 20);
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
            var earth = new Planet("Earth", 59.8, Variables.RadiusScale, new Orbit(1 * Variables.RadiusOrbitScale, 0.017, sun.Coordinates), 12, new StandardCalculator());
            var earthBrush = new SolidColorBrush { Color = Color.FromArgb(255, 0, 255, 255) };
            SettingObjectsOnCanvas(earth, earthBrush);
            #endregion

            #region Mercury
            var mercury = new Planet("Mercury", 3.3, 0.38 * Variables.RadiusScale, new Orbit(0.3871 * Variables.RadiusOrbitScale, 0.205, sun.Coordinates), 2.9, new StandardCalculator());
            var mercuryBrush = new SolidColorBrush {Color = Color.FromArgb(255, 95, 54, 65)};
            SettingObjectsOnCanvas(mercury, mercuryBrush);
            #endregion

            #region Venus
            var venus = new Planet("Venus", 49, 0.95 * Variables.RadiusScale, new Orbit(0.7233 * Variables.RadiusOrbitScale, 0.007, sun.Coordinates), 7.49, new StandardCalculator());
            var venusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 189, 164, 166) };
            SettingObjectsOnCanvas(venus, venusBrush);
            #endregion

            #region Mars
            var mars = new Planet("Mars", 6.44, 0.53 * Variables.RadiusScale, new Orbit(1.5273 * Variables.RadiusOrbitScale, 0.094, sun.Coordinates), 22.9, new StandardCalculator());
            var marsBrush = new SolidColorBrush { Color = Color.FromArgb(255, 174, 15, 2) };
            SettingObjectsOnCanvas(mars, marsBrush);
            #endregion

            #region Jupiter
            var jupiter = new Planet("Jupiter", 19000, 11.2 * Variables.RadiusScale, new Orbit(5.2028 * Variables.RadiusOrbitScale, 0.049, sun.Coordinates), 144.3, new StandardCalculator());
            var jupiterBrush = new SolidColorBrush { Color = Color.FromArgb(255, 95, 54, 44) };
            SettingObjectsOnCanvas(jupiter, jupiterBrush);
            #endregion

            #region Saturn
            var saturn = new Planet("Saturn", 5680, 9.45 * Variables.RadiusScale, new Orbit(9.5388 * Variables.RadiusOrbitScale, 0.057, sun.Coordinates), 358.4, new StandardCalculator());
            var saturnBrush = new SolidColorBrush { Color = Color.FromArgb(255, 86, 75, 52) };
            SettingObjectsOnCanvas(saturn, saturnBrush);
            #endregion

            #region Uranus
            var uranus = new Planet("Uranus", 870, 4.3 * Variables.RadiusScale, new Orbit(19.1914 * Variables.RadiusOrbitScale, 0.046, sun.Coordinates), 1022, new StandardCalculator());
            var uranusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 52, 131, 226) };
            SettingObjectsOnCanvas(uranus, uranusBrush);
            #endregion

            #region Neptune
            var neptune = new Planet("Neptune", 1030, 3.88 * Variables.RadiusScale, new Orbit(30.0611 * Variables.RadiusOrbitScale, 0.011, sun.Coordinates), 2005, new StandardCalculator());
            var neptuneBrush = new SolidColorBrush { Color = Color.FromArgb(255, 36, 47, 251) };
            SettingObjectsOnCanvas(neptune, neptuneBrush);
            #endregion

            #region Moon
            var moon = new Moon("Moon", 0.735, 1.16138017 * 0.1 * Variables.RadiusScale, new Orbit(0.00257 * Variables.RadiusOrbitScale + Variables.RadiusScale, 0.0549, earth.Coordinates), 0.91, new StandardCalculator(), earth);
            var moonBrush = new SolidColorBrush { Color = Color.FromArgb(255, 255, 255, 150) };
            SettingObjectsOnCanvas(moon, moonBrush);
            #endregion

            #region Phobos
            var phobos = new Moon("Phobos", 1.072 * 0.0000001, 1.72 * 0.1 * Variables.RadiusScale, new Orbit(6.27 * 0.01 * Variables.RadiusOrbitScale + Variables.RadiusScale, 0.0167, mars.Coordinates), 0.009, new StandardCalculator(), mars);
            var phobosBrush = new SolidColorBrush { Color = Color.FromArgb(255, 255, 255, 150) };
            SettingObjectsOnCanvas(phobos, phobosBrush);
            #endregion

            #region Deimos
            var deimos = new Moon("Deimos", 1.48 * 0.00000001, 1.72 * 0.1 * Variables.RadiusScale, new Orbit(7.23 * 0.01 * Variables.RadiusOrbitScale + Variables.RadiusScale, 0.0002, mars.Coordinates), 0.01, new StandardCalculator(), mars);
            var deimosBrush = new SolidColorBrush { Color = Color.FromArgb(255, 255, 240, 120) };
            SettingObjectsOnCanvas(deimos, deimosBrush);
            #endregion

            system.AddBody(mercury);
            system.AddBody(venus);
            system.AddBody(earth);
            system.AddBody(mars);
            system.AddBody(jupiter);
            system.AddBody(saturn);
            system.AddBody(uranus);
            system.AddBody(neptune);
            system.AddBody(moon);
            system.AddBody(phobos);
            system.AddBody(deimos);

            InitializeComponent();

            var ticks = new DoubleCollection { 0.01, 5 };
            slider.Ticks = ticks;

            spaceCanvas.Children.Add(sunEllipse);
            //foreach (Planet o in system)
            //{
            //    spaceCanvas.Children.Add(o.PlanetEllipse);
            //}
        }
        
        private void SettingObjectsOnCanvas(SpaceObject spaceObject, SolidColorBrush brushForPlanet)
        {
            var planetEllipse = new Ellipse()
            {
                Width = spaceObject.Radius * 2,
                Height = spaceObject.Radius * 2
            };

            planetEllipse.Fill = brushForPlanet;
            spaceObject.ObjectEllipse = planetEllipse;
            spaceObject.ObjecttBrush = brushForPlanet;

            spaceObject.ChangePosition(0);
            Canvas.SetLeft(planetEllipse, spaceObject.Coordinates.X - spaceObject.Radius);
            Canvas.SetBottom(planetEllipse, spaceObject.Coordinates.Y - spaceObject.Radius);
        }

        private bool rendering = false;
        private bool firstRound = true;
        private bool isTrajectoryByPoints = false;
        private bool isTrajectoryOn = true;

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (!rendering)
            {
                //trajectoryCheckBox.IsEnabled = false;
                showTrajectoryCheckBox.Visibility = Visibility.Hidden;
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
            //spaceCanvas.Children.Clear();
            //spaceCanvas.Children.Add(sunEllipse);
            //firstRound = true;
            CompositionTarget.Rendering -= RenderFrame;
            rendering = false;
            timer.StopCalculating();
            timer = new Timer(Variables.MonthDurationInSecs);
            //trajectoryCheckBox.IsEnabled = true;
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            if(!isTrajectoryByPoints && firstRound && isTrajectoryOn)
                foreach (var o in system)
                {
                    if(o is Planet)
                        DrawTrajectoryByEllipse(o);
                }

            foreach (var o in system)
            {
                Ellipse newEllipsePoint = new Ellipse();
                newEllipsePoint.Fill = o.ObjecttBrush;
                newEllipsePoint.Width = o.ObjectEllipse.Width;
                newEllipsePoint.Height = o.ObjectEllipse.Height;

                Canvas.SetLeft(newEllipsePoint, o.Coordinates.X - newEllipsePoint.Width/2);
                Canvas.SetBottom(newEllipsePoint, o.Coordinates.Y - newEllipsePoint.Width/2);

                if (isTrajectoryByPoints)
                    DrawTrajectoryByPoints(newEllipsePoint, o);
                else
                {
                    spaceCanvas.Children.Add(newEllipsePoint);
                    if (!firstRound)
                    {
                        var countOfObjectsWithoutSun = 8 + 3; //Planets + their moons
                        if (o is Moon)
                            o.Orbit.CenterSpacePoint = ((Moon) o).CentralObject.Coordinates;
                        spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - countOfObjectsWithoutSun - 1);
                    }
                }
            }

            firstRound = false;
        }

        private void DrawTrajectoryByPoints(Ellipse newEllipsePoint, SpaceObject o)
        {
            Ellipse newTrajectoryPoint = new Ellipse();
            newTrajectoryPoint.Fill = trajectoryBrush;
            newTrajectoryPoint.Width = newEllipsePoint.Width/10;
            newTrajectoryPoint.Height = newEllipsePoint.Height/10;

            Canvas.SetLeft(newTrajectoryPoint, o.Coordinates.X - newTrajectoryPoint.Width/2);
            Canvas.SetBottom(newTrajectoryPoint, o.Coordinates.Y - newTrajectoryPoint.Width/2);

            spaceCanvas.Children.Add(newTrajectoryPoint);
            spaceCanvas.Children.Add(newEllipsePoint);

            if (firstRound)
                return;
            spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - 17);
        }

        private void DrawTrajectoryByEllipse(SpaceObject o)
        {
            Ellipse newTrajectory = new Ellipse();
            newTrajectory.Stroke = trajectoryBrush;
            newTrajectory.Width = o.Orbit.BigSemiaxis * 2;
            newTrajectory.Height = o.Orbit.SmallSemiaxis * 2;

            Canvas.SetLeft(newTrajectory, o.Orbit.CenterSpacePoint.X - newTrajectory.Width/2);
            Canvas.SetBottom(newTrajectory, o.Orbit.CenterSpacePoint.Y - newTrajectory.Height/2);

            spaceCanvas.Children.Add(newTrajectory);
        }
        
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= RenderFrame;
            rendering = false;
            timer.StopCalculating();
        }

        private void trajectoryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isTrajectoryByPoints = true;
        }

        private void trajectoryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isTrajectoryByPoints = false;
        }

        const double ScaleRate = 5;
        private bool isZoomed = true;
        private void zoomButton_Clicked(object sender, RoutedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            spaceCanvas.RenderTransform = st;
            if (isZoomed)
            {
                mainWindow.Height /= ScaleRate;
                mainWindow.Width /= ScaleRate;
                st.ScaleX /= ScaleRate;
                st.ScaleY /= ScaleRate;
                isZoomed = false;
            }
            else
            {
                mainWindow.Height *= ScaleRate;
                mainWindow.Width *= ScaleRate;
                spaceCanvas.RenderTransform = null;
                isZoomed = true;
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Variables.MonthDurationInSecs = e.NewValue;
        }

        private void showTrajectoryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isTrajectoryOn = true;
        }

        private void showTrajectoryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isTrajectoryOn = false;
        }
    }
}
