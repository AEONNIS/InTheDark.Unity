using InTheDark.Components.Events;
using InTheDark.Systems;
using Leopotam.Ecs;

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

        public void Init() => _systems?.Init();

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
    }

    public static class WorldExtension
    {
        public static EcsSystems AddSystems(this EcsSystems systems) => systems
            .Add(new MapGenerationSystem())
            .Add(new MapPresentationSystem());

        public static EcsSystems AddOneFrameComponents(this EcsSystems systems) => systems
            .OneFrame<ToCreateMapPartEvent>()
            .OneFrame<ToPresentEvent>();
    }
}
