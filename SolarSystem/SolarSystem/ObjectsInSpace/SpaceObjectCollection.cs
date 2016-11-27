using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.ObjectsInSpace
{
    public class SpaceObjectCollection : IEnumerable<SpaceObject>
    {
        private readonly List<SpaceObject> _innerList = new List<SpaceObject>();

        public void AddBody(SpaceObject o)
        {
            _innerList.Add(o);
        }

        public void Clear()
        {
            _innerList.Clear();
        }

        public IEnumerator<SpaceObject> GetEnumerator()
        {
            return ((IEnumerable<SpaceObject>)_innerList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<SpaceObject>)_innerList).GetEnumerator();
        }

        public SpaceObject this[int i]
        {
            get { return _innerList.ElementAt(i); }
            set { _innerList[i] = value; }
        }
    }
}