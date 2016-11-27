using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem
{
    class Rocket : SpaceObject, ISatellite
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
    }
}
