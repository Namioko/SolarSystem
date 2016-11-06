using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem.CoordinatesCalculation
{
    public class Timer
    {
        private List<SpaceObject> _spaceObjects;
        public bool Stop { get; set; }
        public double TimePerMonth { get; set; }
        private double _time = 0;
        private Task _timeTask;

        public Timer()
        {
            Stop = false;
            _timeTask = new Task(CalculteTime);
        }

        public void AddObject(SpaceObject obj)
        {
            _spaceObjects.Add(obj);
        }

        public void RemoveObject(SpaceObject obj)
        {
            _spaceObjects.Remove(obj);
        }

        public void NotifyObjects()
        {
            foreach (var obj in _spaceObjects)
            {
                obj.ChangePosition(_time);
            }
        }

        public void CalculteTime()
        {
            while (!Stop)
            {
                NotifyObjects();
                _timeTask.Wait(TimeSpan.FromSeconds(TimePerMonth));
                _time++;
                if (_time == 12.0)
                    _time = 0.0;
            }
        }
    }
}
