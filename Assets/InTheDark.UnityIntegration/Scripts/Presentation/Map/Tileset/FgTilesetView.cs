using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    [CreateAssetMenu(fileName = "FgTilesetView", menuName = "InTheDark/FgTilesetView")]
    public class FgTilesetView : ScriptableObject
    {
        [SerializeField] private List<FgTileView> _fgTilesetView;

        public TileBase GetFgTileView(FgTileId id) => _fgTilesetView.Find(fgTileView => fgTileView.Id == id).TileView;
    }
}
