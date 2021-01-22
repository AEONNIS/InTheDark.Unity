using System.Collections.Generic;
using UnityEngine;

namespace InTheDark.Presentation.Maps
{
    [CreateAssetMenu(fileName = "TilesetView", menuName = "InTheDark/Presentations/Maps/TilesetView")]
    public class TilesetView : ScriptableObject
    {
        [SerializeField] private List<LayerTileView> _tileViews;
    }
}
