using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace SolarSystem
{
    public class SpaceObject
    {
        public double Mass { get; }

        public double Speed { get; }

        public double Acceleration { get; }

        public Point Coordinates { get; set; }

        public double Radius { get; }
    }
}
