using System;
using System.Drawing;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem.CoordinatesCalculation
{
    public class StandardCalculator : ICalculator
    {
        public Point CalculateCoordinates(double time, double monthsPerOneTurn, Orbit orbit)
        {
            double angleFromTime = time * 2 * Math.PI / monthsPerOneTurn;
            return new Point(int.Parse((orbit.BigSemiaxis * Math.Cos(angleFromTime)).ToString()),
                int.Parse((orbit.SmallSemiaxis * Math.Sin(angleFromTime)).ToString()));
        }
    }
}
