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
            foreach (var i in _bgTilePresent)
            {
                ref var entity = ref _bgTilePresent.GetEntity(i);
                ref var bgTile = ref _bgTilePresent.Get1(i);
                _mapPresenter.Present(bgTile);
            }

            foreach (var i in _fgTilePresent)
            {
                ref var entity = ref _fgTilePresent.GetEntity(i);
                ref var fgTile = ref _fgTilePresent.Get1(i);
                _mapPresenter.Present(fgTile);
            }
        }
    }
}
