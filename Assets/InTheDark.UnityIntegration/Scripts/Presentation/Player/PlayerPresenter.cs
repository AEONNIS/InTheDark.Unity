using InTheDark.Model.Components;
using InTheDark.Model.Player;
using UnityEngine;

namespace InTheDark.UnityIntegration.Presentation.Map
{
    public class PlayerPresenter : MonoBehaviour, IPlayerPresenter, IPlayerMovementPresenter
    {
        [SerializeField] private Vector3 _alignmentOffset = new Vector3(0.5f, 0.5f, 0f);

        public void Present(in PlayerComponent player) => transform.position = new Vector3(player.Position.X, player.Position.Y, 0f) + _alignmentOffset;

        public void Present(in MovementPresentationEvent movementPresentation)
            => transform.position += new Vector3(movementPresentation.Movement.X, movementPresentation.Movement.Y, 0f);
    }
}
