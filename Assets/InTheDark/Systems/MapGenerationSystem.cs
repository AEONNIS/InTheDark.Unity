using InTheDark.Components;
using InTheDark.Components.Events;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace InTheDark.Systems
{
    public class MapGenerationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ToCreateMapPartEvent> _filter = null;

        // Вынести в конфиг, когда разберусь, как его правильно реализовать.
        private readonly Int2 _mapPartSize = new Int2(32, 32);
        private readonly Int2 _initOffsetOnMap = new Int2(0, 0);

        public void Init()
        {
            var toCreateInitMapPart = new ToCreateMapPartEvent { Size = _mapPartSize, OffsetOnMap = _initOffsetOnMap };
            CreateInitMapPart(toCreateInitMapPart);
        }

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var toCreateMapPart = ref _filter.Get1(i);
                CreateFloor(toCreateMapPart);
                CreateExternalWalls(toCreateMapPart);
            }
        }

        public void CreateInitMapPart(in ToCreateMapPartEvent toCreateInitMapPart)
        {
            var entity = _world.NewEntity();
            ref var toCreateMapPart = ref entity.Get<ToCreateMapPartEvent>();
            toCreateMapPart = toCreateInitMapPart;
        }

        private void CreateFloor(in ToCreateMapPartEvent toCreateMapPart)
        {
            for (int x = 0; x < toCreateMapPart.Size.X; x++)
            {
                for (int y = 0; y < toCreateMapPart.Size.Y; y++)
                {
                    var position = new Int2(x, y) + toCreateMapPart.OffsetOnMap;
                    CreateFloorTile(position);
                }
            }
        }

        private void CreateFloorTile(in Int2 position)
        {
            var entity = _world.NewEntity();
            ref var backgroundTile = ref entity.Get<BgTileComponent>();
            backgroundTile = new BgTileComponent { Position = position, TileId = BgTileId.Floor };
            entity.Get<ToPresentEvent>();
        }

        private void CreateExternalWalls(in ToCreateMapPartEvent toCreateMapPart)
        {
            CreateSouthAndNorthWalls(toCreateMapPart);
            CreateWestAndEastWalls(toCreateMapPart);
        }

        private void CreateSouthAndNorthWalls(in ToCreateMapPartEvent toCreateMapPart)
        {
            for (int x = 0; x < toCreateMapPart.Size.X; x++)
            {
                var southPosition = new Int2(x, 0) + toCreateMapPart.OffsetOnMap;
                var northPosition = new Int2(x, toCreateMapPart.Size.Y - 1) + toCreateMapPart.OffsetOnMap;
                CreateWallTile(southPosition);
                CreateWallTile(northPosition);
            }
        }

        private void CreateWestAndEastWalls(in ToCreateMapPartEvent toCreateMapPart)
        {
            for (int y = 1; y < toCreateMapPart.Size.Y - 1; y++)
            {
                var westPosition = new Int2(0, y) + toCreateMapPart.OffsetOnMap;
                var eastPosition = new Int2(toCreateMapPart.Size.X - 1, y) + toCreateMapPart.OffsetOnMap;
                CreateWallTile(westPosition);
                CreateWallTile(eastPosition);
            }
        }

        private void CreateWallTile(in Int2 position)
        {
            var entity = _world.NewEntity();
            ref var foregroundTile = ref entity.Get<FgTileComponent>();
            foregroundTile = new FgTileComponent { Position = position, TileId = FgTileId.Wall };
            entity.Get<ToPresentEvent>();
        }
    }
}
