using UnityEngine;
using POW.BroadcastingChannels.InputChannel;
using POW.Utilities.Physic;

namespace POW.Controls
{
    public class InteractableDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayer;

        [Header("Listening To")]
        [SerializeField] private ClickReceiverChannel _clickChannel;

        private void OnEnable()
        {
            _clickChannel.OnPointerClicked += CheckInteractableOnPoint;
        }

        private void OnDisable()
        {
            _clickChannel.OnPointerClicked -= CheckInteractableOnPoint;
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