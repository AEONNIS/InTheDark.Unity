using UnityEngine;

namespace InTheDark.UnityIntegration
{
    internal class MapPresenter : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private MapLayerPresenter _background;
        [SerializeField] private MapLayerPresenter _foreground;
    }
}
