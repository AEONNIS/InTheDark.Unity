using InTheDark.Components;
using UnityEngine;

namespace InTheDark.UnityIntegration
{
    public class MapPresenter : MonoBehaviour, IMapChangePresenter
    {
        [SerializeField] private MapLayerPresenter _background;
        [SerializeField] private MapLayerPresenter _foreground;

        public void Present(in MapChangesComponent mapChanges)
        {
            Debug.Log($"{nameof(MapPresenter.Present)}: {mapChanges.ChangedCells}");

            _background.Present(mapChanges, true);
            _foreground.Present(mapChanges, false);
        }
    }
}
