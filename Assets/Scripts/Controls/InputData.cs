using UnityEngine;
using POW.BroadcastingChannels.InputChannel;

namespace POW.Controls
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Controls/InputData")]
    public class InputData : ScriptableObject
    {
        public Vector2 CurrentInput { get; private set; }
        public Vector2 PreviousInput { get; private set; }

        [Header("Broadcasting On")]
        [SerializeField] private InputReceiveChannel _inputChannel;

        public void ReceiveInput(Vector2 currentInput)
        {
            PreviousInput = CurrentInput;
            CurrentInput = currentInput;

            _inputChannel.OnInputReceived?.Invoke(this);
        }

        public void ReceiveInput(Vector2 currentInput, Vector2 previousInput)
        {
            PreviousInput = previousInput;
            CurrentInput = currentInput;

            _inputChannel.OnInputReceived?.Invoke(this);
        }

        public void ResetData()
        {
            CurrentInput = Vector2.zero;
            PreviousInput = Vector2.zero;
        }
    }
}