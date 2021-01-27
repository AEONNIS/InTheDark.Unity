using InTheDark.Model.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    public class MapBgPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private BgTilesetView _bgTilesetView;

        public void Present(in BgTileComponent tile)
        {
            var tileView = _bgTilesetView.GetBgTileView(tile.TileId);
            var position = new Vector3Int(tile.Position.X, tile.Position.Y, 0);
            _tilemap.SetTile(position, tileView);
        }
    }
}
