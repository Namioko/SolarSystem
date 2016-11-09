using System;
using System.Drawing;
using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public abstract class SpaceObject : ICelestialBody
    {
        private readonly Orbit _orbit;
        private readonly ICalculator _calculator;

        protected SpaceObject(string name, double mass, double speed, double acceleration, 
            double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator)
        {
            Name = name;
            Mass = mass;
            Speed = speed;
            Acceleration = acceleration;
            Radius = radius;
            _orbit = orbit;
            MonthsPerOneTurn = monthsPerOneTurn;
            _calculator = calculator;
        }

        protected SpaceObject(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            _orbit = orbit;
            MonthsPerOneTurn = monthsPerOneTurn;
            _calculator = calculator;
        }

        public string Name { get; }

        public double Mass { get; }

        public double Speed { get; }

        public double Acceleration { get; }

        public Point Coordinates { get; private set; }

        public double Radius { get; }

        public double MonthsPerOneTurn { get; }

        public virtual void ChangePosition(double time)
        {
            Coordinates = _calculator.CalculateCoordinates(time, MonthsPerOneTurn, _orbit);
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}
