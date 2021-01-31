using Leopotam.Ecs.Types;

namespace InTheDark.Model.Map
{
    internal class Angles
    {
        internal Angles(in Int2 southWest, in Int2 southEast, in Int2 northEast, in Int2 northWest)
        {
            SouthWest = new Angle(southWest);
            SouthEast = new Angle(southEast);
            NorthEast = new Angle(northEast);
            NorthWest = new Angle(northWest);
        }

        internal Angle SouthWest { get; }
        internal Angle SouthEast { get; }
        internal Angle NorthEast { get; }
        internal Angle NorthWest { get; }
    }
}
