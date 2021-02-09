using Leopotam.Ecs.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InTheDark.Model.Map
{
    internal class RoomsRegion
    {
        private readonly List<Room> _rooms;

        internal RoomsRegion(List<Room> rooms) => _rooms = rooms;

        internal ReadOnlyCollection<Room> Rooms => _rooms.AsReadOnly();

        internal static RoomsRegion CreateRandom(in Int2 size, int partitions, in Int2 offset)
        {
            var rooms = new List<Room>(partitions + 1);
            var room = new Room(new Int2() + offset, size + offset - new Int2(1, 1));


        }
    }
}
