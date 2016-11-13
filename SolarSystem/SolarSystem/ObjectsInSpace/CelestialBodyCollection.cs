using System.Collections;
using System.Collections.Generic;

namespace SolarSystem.ObjectsInSpace
{
    public class CelestialBodyCollection : IEnumerable<ICelestialBody>
    {
        private List<ICelestialBody> _innerList = new List<ICelestialBody>();

        public void AddBody(ICelestialBody o)
        {
            _innerList.Add(o);
        }

        public IEnumerator<ICelestialBody> GetEnumerator()
        {
            return ((IEnumerable<ICelestialBody>)_innerList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ICelestialBody>)_innerList).GetEnumerator();
        }
    }
}
