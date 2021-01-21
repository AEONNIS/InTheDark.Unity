using UnityEngine;

namespace InTheDark.Model.Maps
{
    public class MapModuleGenerator
    {
        private readonly Range<int> _binaryPartitioningRange;

        public MapModule Generate(Vector2Int size)
        {
            var moduleCells = new ModuleCell[size.x, size.y];
            CreatingExtaernalWalls(ref moduleCells);

            return new MapModule(moduleCells);
        }

        private void CreatingExtaernalWalls(ref ModuleCell[,] moduleCells)
        {

        }
    }
}
