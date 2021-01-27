using InTheDark.Model.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    public class MapBgPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private BackgroundTilesetView _bgTilesetView;

        public void Present(in BackgroundTileComponent tile)
        {
            var tileView = _bgTilesetView.GetViewFor(tile.Id);
            var position = new Vector3Int(tile.Position.X, tile.Position.Y, 0);
            _tilemap.SetTile(position, tileView);
        }
    }
}
