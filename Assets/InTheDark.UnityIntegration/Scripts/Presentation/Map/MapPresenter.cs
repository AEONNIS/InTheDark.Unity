using InTheDark.Model.Components;
using InTheDark.Model.Map;
using UnityEngine;

namespace InTheDark.UnityIntegration.Presentation
{
    public class MapPresenter : MonoBehaviour, IMapPresenter
    {
        [SerializeField] private MapBgPresenter _bgPresenter;
        [SerializeField] private MapFgPresenter _fgPresenter;

        public void Present(in BackgroundTileComponent bgTile) => _bgPresenter.Present(bgTile);

        public void Present(in ForegroundTileComponent fgTile) => _fgPresenter.Present(fgTile);
    }
}
