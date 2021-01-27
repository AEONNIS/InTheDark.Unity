using InTheDark.Model;
using InTheDark.Model.Components;
using Leopotam.Ecs.Types;
using UnityEngine;

namespace InTheDark.UnityIntegration.Input
{
    public class InputController
    {
        private readonly InputControls _inputControls = new InputControls();
        private readonly World _world;

        public InputController(World world)
        {
            _world = world;
            _inputControls.Player.Move.performed += context => OnPlayerMove(context.ReadValue<Vector2>());
        }

        public void Enable() => _inputControls.Enable();

        public void Disable() => _inputControls.Disable();

        private void OnPlayerMove(Vector2 direction)
        {
            var playerMoveInput = new PlayerMoveInputEvent { Direction = new Int2((int)direction.x, (int)direction.y) };
            _world.Send(playerMoveInput);
        }
    }
}
