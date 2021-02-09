using Leopotam.Ecs.Types;

namespace InTheDark.Model.Map
{
    internal class Room
    {
        internal Room(in Int2 northWest, in Int2 southEast)
        {
            var angles = new Angles(northWest, southEast);
            North = new HalfWallSegment(angles.NorthWest, angles.NorthEast);
            East = new HalfWallSegment(angles.NorthEast, angles.SouthEast);
            South = new HalfWallSegment(angles.SouthEast, angles.SouthWest);
            West = new HalfWallSegment(angles.SouthWest, angles.NorthWest);
            SetRoom();
        }

        internal HalfWallSegment North { get; private set; }
        internal HalfWallSegment East { get; private set; }
        internal HalfWallSegment South { get; private set; }
        internal HalfWallSegment West { get; private set; }
        internal int Area => North.Length * East.Length;

        internal Room WestEastPartition(float position)
        {
            var westRoom = new Room(North.Start, South.GetPointIn(1 - position));
            var eastRoom = new Room(North.GetPointIn(position), South.Start);
            westRoom.East.SetTwin(eastRoom.West);

            return new AdjacentWestEastRooms(westRoom, eastRoom);
        }

        internal AdjacentNorthSouthRooms NorthSouthPartition(float position)
        {
            var northRoom = new Room(North.Start, East.GetPointIn(position));
            var southRoom = new Room(West.GetPointIn(1 - position), South.Start);
            northRoom.South.SetTwin(southRoom.North);

            return new AdjacentNorthSouthRooms(northRoom, southRoom);
        }

        private void SetRoom()
        {
            North.SetRoom(this);
            East.SetRoom(this);
            South.SetRoom(this);
            West.SetRoom(this);
        }

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
