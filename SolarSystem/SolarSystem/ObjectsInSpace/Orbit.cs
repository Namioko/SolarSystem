namespace SolarSystem.ObjectsInSpace
{
    public class Orbit
    {
        public double BigSemiaxis { get; }
        public double SmallSemiaxis { get; }

        protected Orbit(double bigSemiaxis, double smallSemiaxis)
        {
            BigSemiaxis = bigSemiaxis;
            SmallSemiaxis = smallSemiaxis;
        }
    }
}
