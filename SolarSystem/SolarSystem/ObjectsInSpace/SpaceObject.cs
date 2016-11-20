using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public abstract class SpaceObject : ICelestialBody
    {
        public readonly Orbit Orbit;
        public Ellipse ObjectEllipse { get; set; }
        public SolidColorBrush ObjectBrush { get; set; }
        private readonly ICalculator _calculator;

        protected SpaceObject(string name, double mass, double speed, double acceleration, 
            double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator)
        {
            Name = name;
            Mass = mass;
            Speed = speed;
            Acceleration = acceleration;
            Radius = radius;
            Orbit = orbit;
            MonthsPerOneTurn = monthsPerOneTurn;
            _calculator = calculator;
        }

        protected SpaceObject(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            Orbit = orbit;
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
            Coordinates = _calculator.CalculateCoordinates((time / Variables.MonthDurationInSecs) % MonthsPerOneTurn, MonthsPerOneTurn, Orbit);
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}
