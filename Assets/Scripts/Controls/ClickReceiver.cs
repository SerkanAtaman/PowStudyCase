using UnityEngine;
using POW.BroadcastingChannels.InputChannel;

namespace POW.Controls
{
    public class ClickReceiver : MonoBehaviour
    {
        [Header("Listening To")]
        [SerializeField] private DragReceiverChannel _dragChannel;

        [Header("Broadcasting On")]
        [SerializeField] private ClickReceiverChannel _clickReceiveChannel;

        private void Start()
        {
            _dragChannel.OnDragStateChanged += OnDragStateChanged;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _clickReceiveChannel.OnPointerClicked?.Invoke(Input.mousePosition);
            }
        }

        private void OnDragStateChanged(bool dragStarted)
        {
            enabled = !dragStarted;
        }
    }
}