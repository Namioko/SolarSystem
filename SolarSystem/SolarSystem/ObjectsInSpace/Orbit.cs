using System;
using System.Windows;

namespace SolarSystem.ObjectsInSpace
{
    public class Orbit
    {
        public double BigSemiaxis { get; }
        public double SmallSemiaxis { get; }
        public Point CenterSpacePoint { get; set; }

        public Orbit(double bigSemiaxis, double eccentricity, Point centerSpacePoint)
        {
            BigSemiaxis = bigSemiaxis;
            SmallSemiaxis = bigSemiaxis * Math.Sqrt(1 - Math.Pow(eccentricity, 2));
            CenterSpacePoint = centerSpacePoint;
        }

        public Orbit(double bigSemiaxis, double smallSemiaxis)
        {
            BigSemiaxis = bigSemiaxis;
            SmallSemiaxis = smallSemiaxis;
        }
    }
}
