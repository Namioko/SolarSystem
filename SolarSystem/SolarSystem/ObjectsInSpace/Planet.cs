using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public class Planet : SpaceObject
    {
        public Planet(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator) : base(name, mass, radius, orbit, monthsPerOneTurn, calculator)
        {
        }
    }
}