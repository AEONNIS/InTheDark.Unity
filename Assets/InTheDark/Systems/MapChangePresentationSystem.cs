using InTheDark.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace InTheDark.Systems
{
    public class MapChangePresentationSystem : IEcsRunSystem
    {
        private EcsFilter<MapComponent, MapChangesComponent> _filter = null;
        private IMapChangePresenter _mapPresenter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log($"{nameof(MapChangePresentationSystem.Run)}: {i}");

                ref var entity = ref _filter.GetEntity(i);
                ref var mapChanges = ref _filter.Get2(i);
                _mapPresenter.Present(mapChanges);
                entity.Del<MapChangesComponent>();
            }
        }
    }
}
