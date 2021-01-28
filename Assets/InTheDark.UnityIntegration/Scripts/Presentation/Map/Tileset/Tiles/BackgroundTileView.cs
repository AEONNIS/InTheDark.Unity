using InTheDark.Model.Map;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    [Serializable]
    public struct BackgroundTileView
    {
        [SerializeField] private BackgroundTileId _id;
        [SerializeField] private TileBase _view;

        public BackgroundTileId Id => _id;
        public TileBase View => _view;
    }
}
