using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public class Moon : SpaceObject
    {
        public SpaceObject CentralObject { get; set; }

        public Moon(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator, SpaceObject centralObject) : base(name, mass, radius, orbit, monthsPerOneTurn, calculator)
        {
            CentralObject = centralObject;
        }
    }
}