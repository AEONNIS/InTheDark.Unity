using Leopotam.Ecs.Types;
using System.Collections.Generic;

namespace InTheDark.Model.Map
{
    internal class RoomGenerator
    {
        //To Config...
        private readonly Int2 _mapPartSize = new Int2(32, 32);
        private readonly int _partitions = 15;

        private readonly List<Room> _rooms = new List<Room>();
    }
}
