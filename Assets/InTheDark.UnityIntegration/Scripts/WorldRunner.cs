using UnityEngine;

namespace InTheDark.UnityIntegration
{
    public class WorldRunner : MonoBehaviour
    {
        [SerializeField] private MapPresenter _mapPresenter;
        private World _world = null;

        private void Start()
        {
            _world = new World();
            _world.Inject(_mapPresenter);
            _world.Init();
        }

        private void Update() => _world.Update();
    }
}
