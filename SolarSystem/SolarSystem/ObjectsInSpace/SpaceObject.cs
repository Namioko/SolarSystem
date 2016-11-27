using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public abstract class SpaceObject
    {
        public readonly Orbit Orbit;
        public Ellipse ObjectEllipse { get; set; }
        public SolidColorBrush ObjectBrush { get; set; }
        private readonly ICalculator _calculator;

        protected SpaceObject() { }

        protected SpaceObject(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            Orbit = orbit;
            MonthsPerOneTurn = monthsPerOneTurn;
            _calculator = calculator;
        }

        public string Name { get; private set; }

        public double Mass { get; set; }

        public Point Coordinates { get; private set; }

        public double Radius { get; private set; }

        public double MonthsPerOneTurn { get; set; }

        public virtual void ChangePosition(double time)
        {
            Coordinates = _calculator.CalculateCoordinates((time / Variables.MonthDurationInSecs) % MonthsPerOneTurn, MonthsPerOneTurn, Orbit);
        }
    }
}