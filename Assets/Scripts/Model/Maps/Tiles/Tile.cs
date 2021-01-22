namespace InTheDark.Model.Maps
{
    public struct Tile : ITile
    {
        public LayerTile Background { get; set; }

        public LayerTile Foreground { get; set; }
    }
}