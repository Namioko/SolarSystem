﻿using System.Windows.Media;
using System.Windows.Shapes;
using SolarSystem.CoordinatesCalculation;

namespace SolarSystem.ObjectsInSpace
{
    public class Planet : SpaceObject
    {
        public Planet(string name, double mass, double speed, double acceleration, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator, Ellipse planetEllipse, SolidColorBrush planetBrush) : base(name, mass, speed, acceleration, radius, orbit, monthsPerOneTurn, calculator)
        {
        }

        public Planet(string name, double mass, double radius, Orbit orbit, double monthsPerOneTurn, ICalculator calculator) : base(name, mass, radius, orbit, monthsPerOneTurn, calculator)
        {
        }
    }
}
