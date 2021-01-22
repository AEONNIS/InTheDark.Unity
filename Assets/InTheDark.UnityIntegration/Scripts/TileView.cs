using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration
{
    [Serializable]
    internal struct TileView
    {
        [SerializeField] private LayerTileId _id;
        [SerializeField] private TileBase _tile;
    }
}
