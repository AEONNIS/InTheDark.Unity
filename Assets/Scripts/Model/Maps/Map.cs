using System.Collections.Generic;
using UnityEngine;

namespace InTheDark.Model.Maps
{
    public class Map
    {
        private readonly Dictionary<Vector2Int, ITile> _cells = new Dictionary<Vector2Int, ITile>();

        public void AddModule(Vector2Int offset, Dictionary<Vector2Int, ITile> cells)
        {
            foreach (var cell in cells)
                _cells.Add(cell.Key + offset, cell.Value);
        }
    }
}
