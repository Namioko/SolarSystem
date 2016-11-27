using System.Windows;

namespace SolarSystem.ObjectsInSpace
{
    public class Sun
    {
        public Sun(double mass, Point coordinates, double radius)
        {
            Mass = mass;
            Coordinates = coordinates;
            Radius = radius;
        }

        public double Mass { get; set; }

        public Point Coordinates { get; set; }

        public double Radius { get; set; }
    }
}