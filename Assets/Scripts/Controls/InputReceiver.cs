using UnityEngine;
using UnityEngine.EventSystems;
using POW.BroadcastingChannels.InputChannel;

namespace POW.Controls
{
    public class InputReceiver : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private InputData _inputData;

        [Header("Broadcasting To")]
        [SerializeField] private DragReceiverChannel _dragChannel;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _dragChannel.OnDragStateChanged?.Invoke(true);
            _inputData.ReceiveInput(eventData.pointerCurrentRaycast.screenPosition, eventData.pointerCurrentRaycast.screenPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _inputData.ReceiveInput(eventData.pointerCurrentRaycast.screenPosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _dragChannel.OnDragStateChanged?.Invoke(false);
            _inputData.ResetData();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _inputData.ReceiveInput(new Vector2(0, 1));
            }
            if (Input.GetKey(KeyCode.S))
            {
                _inputData.ReceiveInput(new Vector2(0, -1));
            }
            if (Input.GetKey(KeyCode.D))
            {
                _inputData.ReceiveInput(new Vector2(1, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                _inputData.ReceiveInput(new Vector2(-1, 0));
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                _inputData.ResetData();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _inputData.ResetData();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _inputData.ResetData();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _inputData.ResetData();
            }
        }
    }
}