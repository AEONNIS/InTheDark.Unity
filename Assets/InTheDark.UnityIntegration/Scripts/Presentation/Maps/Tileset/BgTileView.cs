using InTheDark.Model.Maps.Tiles;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    [Serializable]
    public struct BgTileView
    {
        [SerializeField] private BgTileId _id;
        [SerializeField] private TileBase _tileView;

        public BgTileId Id => _id;
        public TileBase TileView => _tileView;
    }
}
