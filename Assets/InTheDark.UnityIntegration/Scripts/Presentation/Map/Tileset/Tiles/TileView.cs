using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    public abstract class TileView<T> where T : struct
    {
        [SerializeField] private protected T _id;
        [SerializeField] private protected TileBase _view;

        public T Id => _id;
        public TileBase View => _view;
    }
}
