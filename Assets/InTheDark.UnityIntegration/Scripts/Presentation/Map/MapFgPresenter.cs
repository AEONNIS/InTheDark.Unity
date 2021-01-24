using InTheDark.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    public class MapFgPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private FgTilesetView _fgTilesetView;

        public void Present(in FgTileComponent tile)
        {
            var tileView = _fgTilesetView.GetFgTileView(tile.TileId);
            var position = new Vector3Int(tile.Position.X, tile.Position.Y, 0);
            _tilemap.SetTile(position, tileView);
        }
    }
}
