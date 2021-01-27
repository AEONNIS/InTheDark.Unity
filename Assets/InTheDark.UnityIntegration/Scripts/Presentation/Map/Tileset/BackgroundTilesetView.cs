using InTheDark.Model.Map;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace InTheDark.UnityIntegration.Presentation
{
    [CreateAssetMenu(fileName = "BackgroundTilesetView", menuName = "InTheDark/Presentation/BackgroundTilesetView")]
    public class BackgroundTilesetView : TilesetView<BackgroundTileId>
    {
        [SerializeField] private List<BackgroundTileView> _tilesetView;

        public TileBase GetViewFor(BackgroundTileId id) => _tilesetView.Find(tileView => tileView.Id == id).View;
    }

    public abstract class TilesetView<U, T> : ScriptableObject where U : TileView<T>
                                                               where T : struct
    {
        [SerializeField] private protected List<TileView<T>> _tilesetView;

        public TileBase GetViewFor(T id) => _tilesetView.Find(tileView => tileView.Id == id).View;
    }
}
