using InTheDark.Model.Components;
using InTheDark.Model.Components.Events;
using InTheDark.Model.Maps.Tiles;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace InTheDark.Model.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ToMoveEvent> _playerToMoveFilter = null;
        private readonly EcsFilter<FgTileComponent> _fgTileFilter = null;

        public void Run()
        {
            foreach (var i in _playerToMoveFilter)
            {
                ref var entity = ref _playerToMoveFilter.GetEntity(i);
                ref var player = ref _playerToMoveFilter.Get1(i);
                ref var toMove = ref _playerToMoveFilter.Get2(i);
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
            foreach (var i in _fgTileFilter)
            {
                ref var tile = ref _fgTileFilter.Get1(i);

                if (tile.Position == endPosition && TileIsNotPassable(tile))
                    return false;
            }

            return true;
        }

        private bool TileIsNotPassable(in FgTileComponent tile) => tile.TileId == FgTileId.Wall || tile.TileId == FgTileId.Door;
    }
}
