using InTheDark.Model.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    public class MapForegroundPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private ForegroundTilesetView _tilesetView;

        public void Present(in ForegroundTileComponent foregroundTile)
        {
            var tileView = _tilesetView.GetViewFor(foregroundTile.Id);
            var position = new Vector3Int(foregroundTile.Position.X, foregroundTile.Position.Y, 0);
            _tilemap.SetTile(position, tileView);
        }
    }
}
