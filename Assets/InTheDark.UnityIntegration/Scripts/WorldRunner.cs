﻿using InTheDark.Model;
using InTheDark.UnityIntegration.Input;
using InTheDark.UnityIntegration.Presentation.Map;
using UnityEngine;

namespace InTheDark.UnityIntegration
{
    public class WorldRunner : MonoBehaviour
    {
        [SerializeField] private PlayerPresenter _playerPresenterPrefab;
        [SerializeField] private MapPresenter _mapPresenter;
        [SerializeField] private InputController _inputController;

        private PlayerPresenter _playerPresenter;
        private readonly World _world = new World();

        #region Unity
        private void Awake()
        {
            _playerPresenter = Instantiate(_playerPresenterPrefab);

            _world.Inject(_playerPresenter);
            _world.Inject(_mapPresenter);
            _world.Init();
            _inputController = new InputController(_world);
        }

        private void OnEnable() => _inputController.Enable();

        private void OnDisable() => _inputController.Disable();

        private void Update() => _world.Update();
        #endregion
    }
}
