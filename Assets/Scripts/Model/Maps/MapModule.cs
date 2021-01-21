namespace InTheDark.Model.Maps
{
    public readonly struct MapModule
    {
        public MapModule(ModuleCell[,] cells) => Cells = cells;

        public readonly ModuleCell[,] Cells { get; }
    }
}
