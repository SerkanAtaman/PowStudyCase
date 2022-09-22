using UnityEngine;
using POW.BroadcastingChannels.InputChannel;
using POW.BroadcastingChannels.GameStateChannels;
using POW.Utilities.Physic;

namespace POW.Controls
{
    public class InteractableDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayer;

        [Header("Listening To")]
        [SerializeField] private ClickReceiverChannel _clickChannel;
        [SerializeField] private GameStateChangedChannel _gameStateChangedChannel;

        private void Awake()
        {
            _gameStateChangedChannel.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnEnable()
        {
            _clickChannel.OnPointerClicked += CheckInteractableOnPoint;
        }

        private void OnDisable()
        {
            _clickChannel.OnPointerClicked -= CheckInteractableOnPoint;
        }

        private void OnGameStateChanged(GameState state)
        {
            enabled = state == GameState.Gameplay;
        }

        private void CheckInteractableOnPoint(Vector3 mousePos)
        {
            IInteractable interactable = PhysicUtilities.GetInteractableOnRayPoint<IInteractable>(mousePos, _targetLayer);

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}