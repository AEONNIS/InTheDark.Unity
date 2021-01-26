using InTheDark.Components;
using InTheDark.Components.Events;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace InTheDark.Systems
{
    public class InputPlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerMovementInputEvent> _inputPlayer = null;
        private readonly EcsFilter<PlayerComponent> _player = null;

        public void Run()
        {
            foreach (var ip in _inputPlayer)
            {
                foreach (var p in _player)
                {
                    ref var playerMovementInput = ref _inputPlayer.Get1(ip);
                    ref var entity = ref _player.GetEntity(p);
                    ref var toMove = ref entity.Get<ToMoveEvent>();
                    toMove = GetToMoveEvent(playerMovementInput);
                }
            }
        }

        private ToMoveEvent GetToMoveEvent(PlayerMovementInputEvent playerMovementInput)
            => playerMovementInput.Direction switch
            {
                WorldSide.North => new ToMoveEvent { Movement = new Int2(0, 1) },
                WorldSide.South => new ToMoveEvent { Movement = new Int2(0, -1) },
                WorldSide.West => new ToMoveEvent { Movement = new Int2(-1, 0) },
                _ => new ToMoveEvent { Movement = new Int2(1, 0) }
            };
    }
}
