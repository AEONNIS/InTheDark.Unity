using InTheDark.Model.Components;

namespace InTheDark.Model.Player
{
    public interface IInitPlayerPresenter
    {
        public void Init(in PlayerComponent player);
    }
}
