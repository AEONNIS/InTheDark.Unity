using Leopotam.Ecs.Types;

namespace InTheDark.Model.Map
{
    internal class Room
    {
        internal Room(in Int2 northWest, in Int2 southEast)
        {
            var angles = new Angles(northWest, southEast);
            North = new Wall(angles.NorthWest, angles.NorthEast, this);
            East = new Wall(angles.NorthEast, angles.SouthEast, this);
            South = new Wall(angles.SouthEast, angles.SouthWest, this);
            West = new Wall(angles.SouthWest, angles.NorthWest, this);
        }

        internal Wall North { get; private set; }
        internal Wall East { get; private set; }
        internal Wall South { get; private set; }
        internal Wall West { get; private set; }

        private readonly struct Angles
        {
            internal Angles(in Int2 northWest, in Int2 southEast)
            {
                NorthWest = northWest;
                NorthEast = new Int2(southEast.X, northWest.Y);
                SouthEast = southEast;
                SouthWest = new Int2(northWest.X, southEast.Y);
            }

            internal Int2 NorthWest { get; }
            internal Int2 NorthEast { get; }
            internal Int2 SouthEast { get; }
            internal Int2 SouthWest { get; }
        }
    }
}
