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
            sun = new Sun(332940, new Point(canvasHalfHeight, canvasHalfHeight), 10.91);
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
            SettingPlanetOnCanvas(earth, earthBrush);
            #endregion

            #region Mercury
            var mercury = new Planet("Mercury", 3.3, 0.38 * Variables.RadiusScale, new Orbit(0.3871 * Variables.RadiusOrbitScale, 0.205, sun.Coordinates), 2.9, new StandardCalculator());
            var mercuryBrush = new SolidColorBrush {Color = Color.FromArgb(255, 95, 54, 65)};
            SettingPlanetOnCanvas(mercury, mercuryBrush);
            #endregion

            #region Venus
            var venus = new Planet("Venus", 49, 0.72 * Variables.RadiusScale, new Orbit(0.7233 * Variables.RadiusOrbitScale, 0.007, sun.Coordinates), 7.49, new StandardCalculator());
            var venusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 189, 164, 166) };
            SettingPlanetOnCanvas(venus, venusBrush);
            #endregion

            #region Mars
            var mars = new Planet("Mars", 6.44, 1.52 * Variables.RadiusScale, new Orbit(1.5273 * Variables.RadiusOrbitScale, 0.094, sun.Coordinates), 22.9, new StandardCalculator());
            var marsBrush = new SolidColorBrush { Color = Color.FromArgb(255, 174, 15, 2) };
            SettingPlanetOnCanvas(mars, marsBrush);
            #endregion

            #region Jupiter
            var jupiter = new Planet("Jupiter", 19000, 5.20 * Variables.RadiusScale, new Orbit(5.2028 * Variables.RadiusOrbitScale, 0.049, sun.Coordinates), 144.3, new StandardCalculator());
            var jupiterBrush = new SolidColorBrush { Color = Color.FromArgb(255, 95, 54, 44) };
            SettingPlanetOnCanvas(jupiter, jupiterBrush);
            #endregion

            #region Saturn
            var saturn = new Planet("Saturn", 5680, 9.54 * Variables.RadiusScale, new Orbit(9.5388 * Variables.RadiusOrbitScale, 0.057, sun.Coordinates), 358.4, new StandardCalculator());
            var saturnBrush = new SolidColorBrush { Color = Color.FromArgb(255, 86, 75, 52) };
            SettingPlanetOnCanvas(saturn, saturnBrush);
            #endregion

            #region Uranus
            var uranus = new Planet("Uranus", 870, 19.22 * Variables.RadiusScale, new Orbit(19.1914 * Variables.RadiusOrbitScale, 0.046, sun.Coordinates), 1022, new StandardCalculator());
            var uranusBrush = new SolidColorBrush { Color = Color.FromArgb(255, 52, 131, 226) };
            SettingPlanetOnCanvas(uranus, uranusBrush);
            #endregion

            #region Neptune
            var neptune = new Planet("Neptune", 1030, 30.06 * Variables.RadiusScale, new Orbit(30.0611 * Variables.RadiusOrbitScale, 0.011, sun.Coordinates), 2005, new StandardCalculator());
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

            var ticks = new DoubleCollection { 0.01, 5 };
            slider.Ticks = ticks;

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
                    DrawTrajectoryByEllipse(o);
                }

            foreach (var o in system)
            {
                Ellipse newEllipsePoint = new Ellipse();
                newEllipsePoint.Fill = ((Planet)o).PlanetBrush;
                newEllipsePoint.Width = ((Planet)o).PlanetEllipse.Width;
                newEllipsePoint.Height = ((Planet)o).PlanetEllipse.Height;
                newEllipsePoint.Name = ((Planet) o).Name;

                Canvas.SetLeft(newEllipsePoint, o.Coordinates.X - newEllipsePoint.Width/2);
                Canvas.SetBottom(newEllipsePoint, o.Coordinates.Y - newEllipsePoint.Width/2);

                if (isTrajectoryByPoints)
                    DrawTrajectoryByPoints(newEllipsePoint, o);
                else
                {
                    spaceCanvas.Children.Add(newEllipsePoint);
                    if (!firstRound)
                        spaceCanvas.Children.RemoveAt(spaceCanvas.Children.Count - 9);
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
            newTrajectory.Width = ((Planet) o)._orbit.BigSemiaxis*2;
            newTrajectory.Height = ((Planet) o)._orbit.SmallSemiaxis*2;

            Canvas.SetLeft(newTrajectory, sun.Coordinates.X - newTrajectory.Width/2);
            Canvas.SetBottom(newTrajectory, sun.Coordinates.Y - newTrajectory.Height/2);

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
