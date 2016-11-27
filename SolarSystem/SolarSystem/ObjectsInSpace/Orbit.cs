using System;
using System.Windows;

namespace SolarSystem.ObjectsInSpace
{
    public class Orbit
    {
        public double BigSemiaxis { get; set; }
        public double SmallSemiaxis { get; set; }
        public Point CenterSpacePoint { get; set; }
        public float Angle { get; set; }

        public Orbit(double bigSemiaxis, double eccentricity, Point centerSpacePoint)
        {
            BigSemiaxis = bigSemiaxis;
            SmallSemiaxis = bigSemiaxis * Math.Sqrt(1 - Math.Pow(eccentricity, 2));
            CenterSpacePoint = centerSpacePoint;
            Angle = 0;
        }

        public Orbit(double bigSemiaxis, double eccentricity, Point centerSpacePoint, float angle)
        {
            BigSemiaxis = bigSemiaxis;
            SmallSemiaxis = bigSemiaxis * Math.Sqrt(1 - Math.Pow(eccentricity, 2));
            CenterSpacePoint = centerSpacePoint;
            Angle = angle;
        }
    }
}