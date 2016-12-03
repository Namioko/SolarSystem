using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Threading;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem.CoordinatesCalculation
{
    public class Timer
    {
        private readonly List<SpaceObject> _spaceObjects;
        public double TimePerMonth { get; set; }
        private readonly DispatcherTimer _timer;
        private readonly Stopwatch _watch;

        public Timer(double time)
        {
            TimePerMonth = time;
            _spaceObjects = new List<SpaceObject>();
            _timer = new DispatcherTimer();
            _watch = new Stopwatch();
        }

        public void AddObject(SpaceObject obj)
        {
            _spaceObjects.Add(obj);
        }

        public void RemoveObject(SpaceObject obj)
        {
            _spaceObjects.Remove(obj);
        }

        public void NotifyObjects(object sender, EventArgs e)
        {
            foreach (var obj in _spaceObjects)
            {
                obj.ChangePosition(_watch.Elapsed.TotalSeconds);
            }
        }

        public void CalculateTime()
        {
            _timer.Tick += NotifyObjects;
            _timer.Interval = TimeSpan.FromSeconds(TimePerMonth);
            _timer.Start();
            _watch.Start();
        }

        public void StopCalculating()
        {
            _timer.Tick -= NotifyObjects;
            _timer.Stop();
            _watch.Stop();
        }
    }
}