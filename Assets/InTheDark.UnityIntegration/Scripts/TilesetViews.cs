using System.Collections.Generic;
using UnityEngine;

namespace InTheDark.UnityIntegration
{
    [CreateAssetMenu(fileName = "TilesetView", menuName = "InTheDark/TilesetView")]
    internal class TilesetViews : ScriptableObject
    {
        [SerializeField] private List<TileView> _tilesViews;
    }
}
