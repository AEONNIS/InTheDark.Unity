using InTheDark.Model.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    public class MapFgPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private ForegroundTilesetView _fgTilesetView;

        public void Present(in ForegroundTileComponent tile)
        {
            var tileView = _fgTilesetView.GetViewFor(tile.Id);
            var position = new Vector3Int(tile.Position.X, tile.Position.Y, 0);
            _tilemap.SetTile(position, tileView);
        }
    }
}
