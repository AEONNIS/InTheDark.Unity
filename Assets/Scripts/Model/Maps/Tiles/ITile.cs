namespace InTheDark.Model.Maps
{
    public interface ITile
    {
        LayerTile Background { get; }
        LayerTile Foreground { get; }
    }
}