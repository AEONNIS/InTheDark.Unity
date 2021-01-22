using InTheDark.Model.Maps;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.Presentation.Maps
{
    [Serializable]
    public struct LayerTileView
    {
        [SerializeField] private LayerTileId _tileId;
        [SerializeField] private TileBase _view;
    }
}
