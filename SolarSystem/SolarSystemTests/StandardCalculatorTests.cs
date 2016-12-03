using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarSystem.CoordinatesCalculation;
using SolarSystem.ObjectsInSpace;

namespace SolarSystemTests
{
    [TestClass()]
    public class StandardCalculatorTests
    {
        [TestMethod()]
        public void CalculateCoordinatesReturnsZeroZeroTest()
        {
            var calculator = new StandardCalculator();
            Assert.AreEqual(new Point(0, 0), calculator.CalculateCoordinates(0, 1, new Orbit(0, 0, new Point(0, 0))));
        }

        [TestMethod()]
        public void CalculateCoordinatesReturnsOneZeroTest()
        {
            var calculator = new StandardCalculator();
            Assert.AreEqual(new Point(1, 0), calculator.CalculateCoordinates(1, 1, new Orbit(1, 1, new Point(0, 0))));
        }
    }
}