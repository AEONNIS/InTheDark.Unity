using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration
{
    [CreateAssetMenu(fileName = "LayerTilesetViews", menuName = "InTheDark/LayerTilesetViews")]
    public class LayerTilesetViews : ScriptableObject
    {
        [SerializeField] private List<LayerTileView> _layerTilesViews;

        public TileBase GetTileView(LayerTileId id) => _layerTilesViews.Find(LayerTileView => LayerTileView.Id == id).TileView;
    }
}
