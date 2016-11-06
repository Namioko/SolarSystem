namespace SolarSystem.ObjectsInSpace
{
    interface ISatellite
    {
        void AddObserver(ICelestialBody c);
        void NotifyObservers();
        void RemoveObserver(ICelestialBody c);
    }
}
