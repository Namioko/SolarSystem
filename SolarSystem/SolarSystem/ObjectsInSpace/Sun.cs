using System;
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

        public double Mass { get; }

        public Point Coordinates { get; }

        public double Radius { get; }
    }
}
