using InTheDark.Model.Components;
using InTheDark.Model.Map;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace InTheDark.Model.Systems
{
    public class MapGenerationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        // Rename Part to Region
        private readonly EcsFilter<MapPartCreationEvent> _mapPartCreationFilter = null;

        // To Config...
        private readonly Int2 _initOffsetOnMap = new Int2(0, 0);
        private readonly Int2 _mapRegionSize = new Int2(32, 32);
        private readonly int _splitsNumber = 15;
        private readonly float _limitingWallSplitting = 0.2f;

        public void Init()
        {
            var initMapPartCreation = new MapPartCreationEvent { Size = _mapRegionSize, OffsetOnMap = _initOffsetOnMap };
            CreateInitialMapPart(initMapPartCreation);
        }

        public void Run()
        {
            foreach (int i in _mapPartCreationFilter)
            {
                ref var entity = ref _mapPartCreationFilter.GetEntity(i);
                ref var mapPartCreation = ref _mapPartCreationFilter.Get1(i);
                CreateFloor(mapPartCreation);
                CreateExternalWalls(mapPartCreation);
            }
        }

        public void CreateInitialMapPart(in MapPartCreationEvent initMapPartCreation)
        {
            var entity = _world.NewEntity();
            ref var mapPartCreation = ref entity.Get<MapPartCreationEvent>();
            mapPartCreation = initMapPartCreation;
        }

        private void CreateFloor(in MapPartCreationEvent mapPartCreation)
        {
            for (int x = 0; x < mapPartCreation.Size.X; x++)
            {
                for (int y = 0; y < mapPartCreation.Size.Y; y++)
                {
                    var position = new Int2(x, y) + mapPartCreation.OffsetOnMap;
                    CreateFloorTile(position);
                }
            }
        }

        private void CreateFloorTile(in Int2 position)
        {
            var entity = _world.NewEntity();
            ref var backgroundTile = ref entity.Get<BackgroundTileComponent>();
            backgroundTile = new BackgroundTileComponent { Position = position, Id = BackgroundTileId.Floor };
            entity.Get<PresentationEvent>();
        }

        private void CreateExternalWalls(in MapPartCreationEvent mapPartCreation)
        {
            CreateSouthAndNorthWalls(mapPartCreation);
            CreateWestAndEastWalls(mapPartCreation);
        }

        private void CreateSouthAndNorthWalls(in MapPartCreationEvent mapPartCreation)
        {
            for (int x = 0; x < mapPartCreation.Size.X; x++)
            {
                var southPosition = new Int2(x, 0) + mapPartCreation.OffsetOnMap;
                var northPosition = new Int2(x, mapPartCreation.Size.Y - 1) + mapPartCreation.OffsetOnMap;
                CreateWallTile(southPosition);
                CreateWallTile(northPosition);
            }
        }

        private void CreateWestAndEastWalls(in MapPartCreationEvent mapPartCreation)
        {
            for (int y = 1; y < mapPartCreation.Size.Y - 1; y++)
            {
                var westPosition = new Int2(0, y) + mapPartCreation.OffsetOnMap;
                var eastPosition = new Int2(mapPartCreation.Size.X - 1, y) + mapPartCreation.OffsetOnMap;
                CreateWallTile(westPosition);
                CreateWallTile(eastPosition);
            }
        }

        private void CreateWallTile(in Int2 position)
        {
            var entity = _world.NewEntity();
            ref var foregroundTile = ref entity.Get<ForegroundTileComponent>();
            foregroundTile = new ForegroundTileComponent { Position = position, Id = ForegroundTileId.Wall };
            entity.Get<PresentationEvent>();
        }
    }
}
