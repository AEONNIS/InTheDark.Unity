using InTheDark.Components;
using Leopotam.Ecs;

namespace InTheDark.Systems
{
    internal class MapModuleGeneratorSystem : IEcsRunSystem
    {
        private EcsFilter<MapComponent, CreateMapModuleComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref MapComponent map = ref _filter.Get1(i);
                ref CreateMapModuleComponent mapModule = ref _filter.Get2(i);

                for (int x = 0; x < mapModule.Size.X; x++)
                {
                    for (int y = 0; y < mapModule.Size.Y; y++)
                    {
                        Vector2Int position = new Vector2Int { X = x, Y = y };
                        map.Cells[position] = new Tile { Background = LayerTileId.Floor, Foreground = LayerTileId.None };
                    }
                }
            }
        }
    }
}
