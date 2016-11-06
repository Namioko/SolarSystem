using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public class Moon : SpaceObject
    {
        public Moon(string name, double mass, double speed, double acceleration, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator) : base(name, mass, speed, acceleration, radius, orbit, monthsPerOneTurn, calculator)
        {
        }
    }
}
