using System.Drawing;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem.CoordinatesCalculation
{
    public interface ICalculator
    {
        Point CalculateCoordinates(double time, double monthsPerOneTurn, Orbit orbit);
    }
}
