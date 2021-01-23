using InTheDark.Components;
using InTheDark.Systems;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;
using System.Collections.Generic;

namespace InTheDark
{
    public class World
    {
        private EcsWorld _ecsWorld = new EcsWorld();
        private EcsSystems _systems;

        public World()
        {
            _systems = new EcsSystems(_ecsWorld);
            AddSystems();
        }

        public void Inject(IMapChangePresenter mapChangePresenter) => _systems.Inject(mapChangePresenter);

        public void Init()
        {
            // Важен порядок: сначла инициализация, потом создание карты, иначе генерция карты не работает. Почему?
            _systems.Init();
            CreateMap();
        }

        public void Update() => _systems?.Run();

        public void Destroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _ecsWorld.Destroy();
                _systems = null;
                _ecsWorld = null;
            }
        }

        private void CreateMap()
        {
            var entity = _ecsWorld.NewEntity();
            ref var map = ref entity.Get<MapComponent>();
            map.Cells = new Dictionary<Int2, Tile>();

            // Testing
            ref var mapModuleCreation = ref entity.Get<MapModuleCreationComponent>();
            mapModuleCreation.OffsetOnMap = new Int2(0, 0);
            mapModuleCreation.ModuleSize = new Int2(16, 16);
        }

        private void AddSystems()
        {
            _systems.Add(new MapModuleGenerationSystem());
            _systems.Add(new MapChangePresentationSystem());
        }
    }
}
