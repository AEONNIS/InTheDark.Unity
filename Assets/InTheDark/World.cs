using InTheDark.Components.Events;
using InTheDark.Systems;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace InTheDark
{
    public class World
    {
        private EcsWorld _ecsWorld = new EcsWorld();
        private EcsSystems _systems;

        public World()
        {
            _systems = new EcsSystems(_ecsWorld)
                .AddSystems()
                .AddOneFrameComponents();
        }

        public void Inject(object obj) => _systems.Inject(obj);

        public void Init()
        {
            _systems.Init();
            CreateMapPart();
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

        public void CreateMapPart()
        {
            var entity = _ecsWorld.NewEntity();
            ref var toCreateMapPart = ref entity.Get<ToCreateMapPartEvent>();
            toCreateMapPart = new ToCreateMapPartEvent { Size = new Int2(32, 32), OffsetOnMap = new Int2(0, 0) };
        }
    }

    public static class WorldExtension
    {
        public static EcsSystems AddSystems(this EcsSystems systems) => systems
            .Add(new MapPartGenerationSystem())
            .Add(new MapPresentationSystem());

        public static EcsSystems AddOneFrameComponents(this EcsSystems systems) => systems
            .OneFrame<ToCreateMapPartEvent>()
            .OneFrame<ToPresentEvent>();
    }
}
