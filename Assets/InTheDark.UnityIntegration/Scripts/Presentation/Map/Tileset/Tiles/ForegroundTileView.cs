using InTheDark.Model.Map;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    [Serializable]
    public struct ForegroundTileView
    {
        [SerializeField] private ForegroundTileId _id;
        [SerializeField] private TileBase _view;

        public ForegroundTileId Id => _id;
        public TileBase View => _view;
    }
}
