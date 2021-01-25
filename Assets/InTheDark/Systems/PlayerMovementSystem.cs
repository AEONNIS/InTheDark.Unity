using InTheDark.Components;
using InTheDark.Components.Events;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace InTheDark.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ToMoveEvent> _playerMove = null;
        private readonly EcsFilter<FgTileComponent> _fgTile = null;

        public void Run()
        {
            foreach (var i in _playerMove)
            {
                ref var entity = ref _playerMove.GetEntity(i);
                ref var player = ref _playerMove.Get1(i);
                ref var toMove = ref _playerMove.Get2(i);
                var endPosition = player.Position + toMove.Movement;

                if (MovementPossibility(endPosition))
                {
                    ref var toPresentMovement = ref entity.Get<ToPresentMovementEvent>();
                    toPresentMovement = new ToPresentMovementEvent { StartPosition = player.Position, EndPosition = endPosition };
                    player.Position = endPosition;
                }

                entity.Del<ToMoveEvent>();
            }
        }

        private bool MovementPossibility(in Int2 endPosition)
        {
            foreach (var i in _fgTile)
            {
                ref var tile = ref _fgTile.Get1(i);

                if (tile.Position == endPosition && TileIsNotPassable(tile))
                    return false;
            }

            return true;
        }

        private bool TileIsNotPassable(in FgTileComponent tile) => tile.TileId == FgTileId.Wall || tile.TileId == FgTileId.Door;
    }
}
