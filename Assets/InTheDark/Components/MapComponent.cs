using Leopotam.Ecs.Types;
using System.Collections.Generic;

namespace InTheDark.Components
{
    public struct MapComponent
    {
        public Dictionary<Int2, Tile> Cells;
    }
}
