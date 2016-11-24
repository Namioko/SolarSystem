using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarSystem.ObjectsInSpace;

namespace SolarSystem
{
    public class Moon : SpaceObject, ICelestialBody
    {
        private Planet primaryPlanet;

        public Moon(Planet primaryPlanet)
        {
            this.primaryPlanet = primaryPlanet;
        }

        public void CalculateCoordinates(int timeLapse)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
