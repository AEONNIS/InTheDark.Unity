using System;
using UnityEngine;

namespace InTheDark.Model.Maps
{
    [Serializable]
    public struct LayerTile
    {
        [SerializeField] public LayerTileId Id { get; }
        public readonly bool Passable { get; }
        public readonly bool Destructible { get; }
    }
}