using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration
{
    [Serializable]
    public struct LayerTileView
    {
        [SerializeField] private LayerTileId _id;
        [SerializeField] private TileBase _tileView;

        public LayerTileId Id => _id;
        public TileBase TileView => _tileView;
    }
}
