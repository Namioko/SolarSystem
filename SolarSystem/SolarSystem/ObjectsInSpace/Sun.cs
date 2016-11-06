using System;
using System.Drawing;

namespace SolarSystem.ObjectsInSpace
{
    public class Sun : ICelestialBody
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

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
