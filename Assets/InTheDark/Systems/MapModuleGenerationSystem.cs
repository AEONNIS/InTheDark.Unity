using InTheDark.Components;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;
using UnityEngine;

namespace InTheDark.Systems
{
    public class MapModuleGenerationSystem : IEcsRunSystem
    {
        // Попробовать сделать readonly
        private EcsFilter<MapComponent, MapModuleCreationComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                Debug.Log($"{nameof(MapModuleGenerationSystem.Run)}: {i}");

                ref var entity = ref _filter.GetEntity(i);
                ref var map = ref _filter.Get1(i);
                ref var mapModuleCreation = ref _filter.Get2(i);
                ref var mapChanges = ref entity.Get<MapChangesComponent>();
                mapChanges.ChangedCells = new MapCell[mapModuleCreation.ModuleSize.X, mapModuleCreation.ModuleSize.Y];

                for (int x = 0; x < mapModuleCreation.ModuleSize.X; x++)
                {
                    for (int y = 0; y < mapModuleCreation.ModuleSize.Y; y++)
                    {
                        var position = new Int2(x, y) + mapModuleCreation.OffsetOnMap;
                        var tile = new Tile { Background = LayerTileId.Floor, Foreground = LayerTileId.None };
                        map.Cells[position] = tile;
                        mapChanges.ChangedCells[x, y] = new MapCell { Position = position, Tile = tile };
                    }
                }

                //entity.Del<MapModuleCreationComponent>();

                mapModuleCreation.ModuleSize = new Int2(16, 16);
                mapModuleCreation.OffsetOnMap = new Int2(Random.Range(-100, 100), Random.Range(-100, 100));
            }
        }
    }
}
