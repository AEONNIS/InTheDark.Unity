using InTheDark.Model.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    public class MapBackgroundPresenter : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private BackgroundTilesetView _tilesetView;

        public void Present(in BackgroundTileComponent backgroundTile)
        {
            var tileView = _tilesetView.GetViewFor(backgroundTile.Id);
            var position = new Vector3Int(backgroundTile.Position.X, backgroundTile.Position.Y, 0);
            _tilemap.SetTile(position, tileView);
        }
    }
}
