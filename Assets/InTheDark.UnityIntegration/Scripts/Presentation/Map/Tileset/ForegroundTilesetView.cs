using InTheDark.Model.Map;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    [CreateAssetMenu(fileName = "ForegroundTilesetView", menuName = "InTheDark/Presentation/ForegroundTilesetView")]
    public class ForegroundTilesetView : ScriptableObject
    {
        [SerializeField] private List<ForegroundTileView> _tilesetView;

        public TileBase GetViewFor(ForegroundTileId id) => _tilesetView.Find(tileView => tileView.Id == id).View;
    }
}
