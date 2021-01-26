using InTheDark.Components.Events;
using Leopotam.Ecs.Types;
using UnityEngine;

namespace InTheDark.UnityIntegration.Input
{
    public class InputController : MonoBehaviour
    {
        private InputControls _inputControls = new InputControls();
        private World _world;

        public void Init(World world)
        {
            _world = world;
            _inputControls.Player.Move.performed += context => OnPlayerMove(context.ReadValue<Vector2>());
        }

        #region Unity
        private void OnEnable() => _inputControls.Enable();

        private void OnDisable() => _inputControls.Disable();
        #endregion

        private void OnPlayerMove(Vector2 direction)
        {
            var playerMoveInput = new PlayerMoveInputEvent { Direction = new Int2((int)direction.x, (int)direction.y) };
            _world.Send(playerMoveInput);
        }
    }
}
