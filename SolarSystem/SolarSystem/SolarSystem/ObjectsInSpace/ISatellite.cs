using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.ObjectsInSpace
{
    interface ISatellite
    {
        void AddObserver(ICelestialBody c);
        void NotifyObservers();
        void RemoveObserver(ICelestialBody c);
    }
}
