using UnityEngine;
using POW.BroadcastingChannels.InputChannel;
using POW.BroadcastingChannels.GameStateChannels;

namespace POW.Controls
{
    public class ClickReceiver : MonoBehaviour
    {
        [Header("Listening To")]
        [SerializeField] private DragReceiverChannel _dragChannel;
        [SerializeField] private GameStateChangedChannel _gameStateChangedChannel;

        [Header("Broadcasting On")]
        [SerializeField] private ClickReceiverChannel _clickReceiveChannel;

        private void Awake()
        {
            _dragChannel.OnDragStateChanged += OnDragStateChanged;
            _gameStateChangedChannel.OnGameStateChanged += OnGameStateChanged;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _clickReceiveChannel.OnPointerClicked?.Invoke(Input.mousePosition);
            }
        }

        private void OnGameStateChanged(GameState state)
        {
            enabled = state == GameState.Gameplay;
        }

        private void OnDragStateChanged(bool dragStarted)
        {
            enabled = !dragStarted;
        }
    }
}