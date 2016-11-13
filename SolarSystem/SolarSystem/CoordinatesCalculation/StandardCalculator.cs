using System;
using System.Windows;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem.CoordinatesCalculation
{
    public class StandardCalculator : ICalculator
    {
        public Point CalculateCoordinates(double time, double monthsPerOneTurn, Orbit orbit)
        {
            double angleFromTime = time * 2 * Math.PI / monthsPerOneTurn;
            return new Point((orbit.BigSemiaxis * Math.Cos(angleFromTime)) + orbit.CenterSpacePoint.X,
                (orbit.SmallSemiaxis * Math.Sin(angleFromTime)) + orbit.CenterSpacePoint.Y);
        }
    }
}
