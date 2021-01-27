using InTheDark.Model.Components;
using InTheDark.Model.Components.Events;
using Leopotam.Ecs;

namespace InTheDark.Model.Systems
{
    public class InputProcessingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerMoveInputEvent> _playerMoveInputFilter = null;
        private readonly EcsFilter<PlayerComponent> _playerFilter = null;

        public void Run()
        {
            foreach (var pmi in _playerMoveInputFilter)
            {
                foreach (var p in _playerFilter)
                {
                    ref var playerMoveInput = ref _playerMoveInputFilter.Get1(pmi);
                    ref var entity = ref _playerFilter.GetEntity(p);
                    ref var toMove = ref entity.Get<ToMoveEvent>();
                    toMove = new ToMoveEvent { Movement = playerMoveInput.Direction };
                }
            }
        }
    }
}
