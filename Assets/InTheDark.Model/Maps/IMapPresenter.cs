using InTheDark.Model.Components;

namespace InTheDark.Model.Maps
{
    public interface IMapPresenter
    {
        public void Present(in BgTileComponent bgTile);

        public void Present(in FgTileComponent fgTile);
    }
}
