using InTheDark.Model.Maps.Tiles;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    [CreateAssetMenu(fileName = "BgTilesetView", menuName = "InTheDark/BgTilesetView")]
    public class BgTilesetView : ScriptableObject
    {
        [SerializeField] private List<BgTileView> _bgTilesetView;

        public TileBase GetBgTileView(BgTileId id) => _bgTilesetView.Find(bgTileView => bgTileView.Id == id).TileView;
    }
}
