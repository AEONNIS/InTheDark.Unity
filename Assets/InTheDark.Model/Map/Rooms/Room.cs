using Leopotam.Ecs.Types;

namespace InTheDark.Model.Map
{
    internal class Room
    {
        internal HalfWall South { get; set; }
        internal HalfWall East { get; set; }
        internal HalfWall North { get; set; }
        internal HalfWall West { get; set; }

        internal (Room West, Room East) VerticalPartition(float position)
        {

        }
    }

    internal class RoomBuilder
    {
        private HalfWall _south;
        private HalfWall _east;
        private HalfWall north;
        private HalfWall _west;

        internal Room Build(in Int2 northWest, in Int2 southEast)
        {
            var angles = BuildAngles(northWest, southEast);


        }

        private Angles BuildAngles(in Int2 northWest, in Int2 southEast)
            => new Angles
            (new Int2(northWest.X, southEast.Y),
             southEast,
             new Int2(southEast.X, northWest.Y),
             northWest);

        private Walls BuildWalls(Angles angles)
        {
            var walls = new Walls
            {
                South = new HalfWall { Origin = angles.SouthWest },
                East = new HalfWall { Origin = angles.SouthEast },
                North = new HalfWall { Origin = angles.NorthEast },
                West = new HalfWall { Origin = angles.NorthWest },
            };

            walls.South.Prev = walls.
        }
    }
}
