using System;
using System.Threading;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarSystem.CoordinatesCalculation;
using SolarSystem.ObjectsInSpace;
using Timer = SolarSystem.CoordinatesCalculation.Timer;

namespace SolarSystemTests
{
    [TestClass()]
    public class TimerTests
    {
        [TestMethod()]
        public void AddObjectAndNotifyObjectTest()
        {
            var timer = new Timer(2);
            var spaceObject = new Planet(null, 0, 0, new Orbit(1, 1, new Point(0, 0)), 1, new StandardCalculator());
            var oldCoordinates = spaceObject.Coordinates;
            timer.AddObject(spaceObject);
            timer.NotifyObjects(new object(), new EventArgs());
            Assert.AreNotEqual(oldCoordinates, spaceObject.Coordinates);
        }

        [TestMethod()]
        public void RemoveObjectTest()
        {
            var timer = new Timer(2);
            var spaceObject = new Planet(null, 0, 0, new Orbit(1, 1, new Point(0, 0)), 1, new StandardCalculator());
            timer.AddObject(spaceObject);
            timer.NotifyObjects(new object(), new EventArgs());
            var oldCoordinates = spaceObject.Coordinates;
            timer.RemoveObject(spaceObject);
            timer.NotifyObjects(new object(), new EventArgs());
            Assert.AreEqual(oldCoordinates, spaceObject.Coordinates);
        }
    }
}