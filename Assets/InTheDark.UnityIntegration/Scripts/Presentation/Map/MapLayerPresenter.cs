using InTheDark.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration
{
    public class MapLayerPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private LayerTilesetViews _tilesetViews;

        public void Present(in MapChangesComponent mapChanges, bool background)
        {
            foreach (var cell in mapChanges.ChangedCells)
            {
                var tileView = background ? _tilesetViews.GetTileView(cell.Tile.Background) : _tilesetViews.GetTileView(cell.Tile.Foreground);
                var position = new Vector3Int(cell.Position.X, cell.Position.Y, 0);
                _tilemap.SetTile(position, tileView);
            }
        }
    }
}
