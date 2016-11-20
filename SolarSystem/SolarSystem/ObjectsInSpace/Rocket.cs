using System.Collections.Generic;

namespace SolarSystem.ObjectsInSpace
{
    public class Rocket 
    {
        private readonly List<ICelestialBody> _observers;

        public Rocket(List<ICelestialBody> observers)
        {
            _observers = observers;
        }

        public void AddObserver(ICelestialBody c)
        {
            _observers.Add(c);
        }

        public void NotifyObservers()
        {
            foreach (var c in _observers)
            {
                c.Update();
            }
        }

        public void RemoveObserver(ICelestialBody c)
        {
            _observers.Remove(c);
        }
    }
}
