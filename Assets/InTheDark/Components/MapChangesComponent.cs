namespace InTheDark.Components
{
    public struct MapChangesComponent
    {
        // Возможно, наличие ячеек с одинаковым положением, чего не должно быть.
        public MapCell[,] ChangedCells;
    }
}
