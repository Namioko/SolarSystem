using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public class Comet : SpaceObject
    {
        public Comet(string name, double mass, double speed, double acceleration, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator) : base(name, mass, speed, acceleration, radius, orbit, monthsPerOneTurn, calculator)
        {
        }

        public Comet(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator) : base(name, mass, radius, orbit, monthsPerOneTurn, calculator)
        {
        }

        public Comet() { }
    }
}
