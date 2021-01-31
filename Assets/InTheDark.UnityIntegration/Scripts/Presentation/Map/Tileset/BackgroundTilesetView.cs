using InTheDark.Model.Map;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    [CreateAssetMenu(fileName = "BackgroundTilesetView", menuName = "InTheDark/Presentation/Map/BackgroundTilesetView")]
    public class BackgroundTilesetView : ScriptableObject
    {
        [SerializeField] private List<BackgroundTileView> _tilsetView;

        public TileBase GetViewFor(BackgroundTileId id) => _tilsetView.Find(tileView => tileView.Id == id).View;
    }
}
