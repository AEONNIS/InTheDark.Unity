using InTheDark.Model.Components.Events;
using InTheDark.Model.Systems;
using Leopotam.Ecs;

namespace InTheDark.Model
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

        public void Send<T>(in T eventComponent) where T : struct
        {
            var entity = _ecsWorld.NewEntity();
            ref var newEventComponent = ref entity.Get<T>();
            newEventComponent = eventComponent;
        }

        public void Inject<T>(T instance) => _systems.Inject(instance);

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

    // Частный случай расширения, никакой универсальности. Надо переделать или убрать.
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
