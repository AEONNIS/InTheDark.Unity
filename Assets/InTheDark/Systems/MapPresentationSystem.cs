using InTheDark.Components;
using InTheDark.Components.Events;
using Leopotam.Ecs;

namespace InTheDark.Systems
{
    public class MapPresentationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BgTileComponent, ToPresentEvent> _bgTilePresent = null;
        private readonly EcsFilter<FgTileComponent, ToPresentEvent> _fgTilePresent = null;
        private readonly IMapPresenter _mapPresenter = null;

        public void Run()
        {
            PresentBackground();
            PresentForeground();
        }

        private void PresentBackground()
        {
            foreach (var i in _bgTilePresent)
            {
                ref var bgTile = ref _bgTilePresent.Get1(i);
                _mapPresenter.Present(bgTile);
            }
        }

        private void PresentForeground()
        {
            foreach (var i in _fgTilePresent)
            {
                ref var fgTile = ref _fgTilePresent.Get1(i);
                _mapPresenter.Present(fgTile);
            }
        }
    }
}
