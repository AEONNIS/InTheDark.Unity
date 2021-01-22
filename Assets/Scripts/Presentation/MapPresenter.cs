using System;
using UnityEngine;

namespace InTheDark.Presentation.Maps
{
    public class MapPresenter : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private MapLayerPresenter _background;
        [SerializeField] private MapLayerPresenter _foreground;

        public void Present()
        {
            _background.Present();
            _foreground.Present();
        }
    }
}
