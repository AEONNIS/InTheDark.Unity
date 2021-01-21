using UnityEngine;

namespace InTheDark.Model.Maps
{
    public readonly struct MapCell
    {
        public MapCell(Vector2Int positionLowerLeftModuleCell, MapModule module)
        {
            PositionLowerLeftModuleCell = positionLowerLeftModuleCell;
            Module = module;
        }

        public readonly Vector2Int PositionLowerLeftModuleCell { get; }
        public readonly MapModule Module { get; }
    }
}
