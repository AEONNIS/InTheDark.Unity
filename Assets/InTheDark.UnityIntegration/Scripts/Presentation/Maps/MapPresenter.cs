using InTheDark.Model.Components;
using InTheDark.Model.Maps;
using UnityEngine;

namespace InTheDark.UnityIntegration.Presentation
{
    public class MapPresenter : MonoBehaviour, IMapPresenter
    {
        [SerializeField] private MapBgPresenter _bgPresenter;
        [SerializeField] private MapFgPresenter _fgPresenter;

        public void Present(in BgTileComponent bgTile) => _bgPresenter.Present(bgTile);

        public void Present(in FgTileComponent fgTile) => _fgPresenter.Present(fgTile);
    }
}
