using System;

namespace SolarSystem.ObjectsInSpace
{
    public class Orbit
    {
        public double BigSemiaxis { get; }
        public double SmallSemiaxis { get; }

        //public Orbit(double bigSemiaxis, double smallSemiaxis)
        //{
        //    BigSemiaxis = bigSemiaxis;
        //    SmallSemiaxis = smallSemiaxis;
        //}

        public Orbit(double bigSemiaxis, double eccentricity)
        {
            BigSemiaxis = bigSemiaxis;
            SmallSemiaxis = bigSemiaxis * Math.Sqrt(1 - Math.Pow(eccentricity, 2));
        }
    }
}
