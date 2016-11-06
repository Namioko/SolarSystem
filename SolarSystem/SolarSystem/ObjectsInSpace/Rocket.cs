using System.Collections.Generic;

namespace SolarSystem.ObjectsInSpace
{
    class Rocket 
    {
        private List<ICelestialBody> observers;
        public void AddObserver(ICelestialBody c)
        {
            observers.Add(c);
        }

        public void NotifyObservers()
        {
            foreach (ICelestialBody c in observers)
            {
                c.Update();
            }
        }

        public void RemoveObserver(ICelestialBody c)
        {
            observers.Remove(c);
        }

        public Rocket(string name, double mass, double speed, double acceleration, double radius) : base(name, mass, speed, acceleration, radius)
        {
        }
    }
}
