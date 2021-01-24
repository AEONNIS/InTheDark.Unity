using InTheDark.Components;

namespace InTheDark
{
    public interface IMapPresenter
    {
        public void Present(in BgTileComponent bgTile);

        public void Present(in FgTileComponent fgTile);
    }
}
