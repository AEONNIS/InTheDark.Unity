using InTheDark.Model.Components;
using InTheDark.Model.Map;
using UnityEngine;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    public class MapPresenter : MonoBehaviour, IMapPresenter
    {
        [SerializeField] private MapBackgroundPresenter _backgroundPresenter;
        [SerializeField] private MapForegroundPresenter _foregroundPresenter;

        public void Present(in BackgroundTileComponent backgroundTile) => _backgroundPresenter.Present(backgroundTile);

        public void Present(in ForegroundTileComponent foregroundTile) => _foregroundPresenter.Present(foregroundTile);
    }
}
