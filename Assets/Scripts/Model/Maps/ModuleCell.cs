using UnityEngine;

namespace InTheDark.Model.Maps
{
    public readonly struct ModuleCell
    {
        public ModuleCell(Vector2Int worldPosition, ITile backgroundTile, ITile foregroundTile)
        {
            WorldPosition = worldPosition;
            BackgroundTile = backgroundTile;
            ForegroundTile = foregroundTile;
        }

        public readonly Vector2Int WorldPosition { get; }
        public readonly ITile BackgroundTile { get; }
        public readonly ITile ForegroundTile { get; }
    }
}
