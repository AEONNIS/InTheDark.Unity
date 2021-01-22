using System.Collections.Generic;
using UnityEngine;

namespace InTheDark.Model.Maps
{
    public class MapModuleGenerator
    {
        private readonly Range<int> _partitioningRange;
        private readonly float _maxRatioLengthAndWidth;

        public MapModuleGenerator(Range<int> partitioningRange, float maxRatioLengthAndWidth)
        {
            _partitioningRange = partitioningRange;
            _maxRatioLengthAndWidth = maxRatioLengthAndWidth;
        }

        public Dictionary<Vector2Int, ITile> Generate(Vector2Int size, WorldSide sideWithoutWall)
        {
            var cells = BasisCreate(size);

            return cells;
        }

        private Dictionary<Vector2Int, ITile> BasisCreate(Vector2Int size)
        {
            var cells = new Dictionary<Vector2Int, ITile>(size.x * size.y);

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                    cells.Add(new Vector2Int(x, y), new Tile { Background = new LayerTile { } });
            }

            return cells;
        }
    }
}
