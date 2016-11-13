﻿using System.Collections;
using System.Collections.Generic;

namespace SolarSystem.ObjectsInSpace
{
    public class SpaceObjectCollection : IEnumerable<SpaceObject>
    {
            private List<SpaceObject> _innerList = new List<SpaceObject>();

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
    }
}