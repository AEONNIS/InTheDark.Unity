using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    [Serializable]
    public struct FgTileView
    {
        [SerializeField] private FgTileId _id;
        [SerializeField] private TileBase _tileView;

        public FgTileId Id => _id;
        public TileBase TileView => _tileView;
    }
}
