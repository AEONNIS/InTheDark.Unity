using InTheDark.UnityIntegration.Input;
using InTheDark.UnityIntegration.Presentation;
using UnityEngine;

namespace InTheDark.UnityIntegration
{
    public class WorldRunner : MonoBehaviour
    {
        [SerializeField] private MapPresenter _mapPresenter;
        [SerializeField] private InputController _inputController;

        private World _world = null;

        #region Unity
        private void Awake()
        {
            _world = new World();
            _inputController.Init(_world);
        }

        private void Start()
        {
            _world.Inject(_mapPresenter);
            _world.Init();
        }

        private void Update() => _world.Update();
        #endregion
    }
}
