using System.Collections.Generic;
using UnityEngine;

namespace InTheDark.Model.Maps
{
    public class Map
    {
        private readonly List<MapCell> _cells = new List<MapCell>();

        public void AddModule(Vector2Int positionLowerLeftModuleCell, MapModule module)
        {
            var mapCell = new MapCell(positionLowerLeftModuleCell, module);
            _cells.Add(mapCell);
        }
    }
}
