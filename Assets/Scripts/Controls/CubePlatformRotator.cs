using UnityEngine;
using POW.BroadcastingChannels.InputChannel;
using POW.BroadcastingChannels.CubePlatformChannel;

namespace POW.Controls
{
    public class CubePlatformRotator : MonoBehaviour
    {
        [Header("Listening To")]
        [SerializeField] private InputReceiveChannel _inputChannel;
        [SerializeField] private PlatformCreatedChannel _platformCreatedChannel;

        [SerializeField] private float _rotateSpeed = 0.1f;

        private Transform _platform;

        private void OnEnable()
        {
            _inputChannel.OnInputReceived += RotatePlatform;
            _platformCreatedChannel.OnCubePlatformCreated += ReceiveCreatedPlatform;
        }

        private void OnDisable()
        {
            _inputChannel.OnInputReceived -= RotatePlatform;
            _platformCreatedChannel.OnCubePlatformCreated -= ReceiveCreatedPlatform;
        }

        private void ReceiveCreatedPlatform(Transform platform)
        {
            _platform = platform;
        }

        private void RotatePlatform(InputData inputData)
        {
            Vector3 dragInput = inputData.CurrentInput - inputData.PreviousInput;

            Vector3 axis = new Vector3(dragInput.y * _rotateSpeed, -dragInput.x * _rotateSpeed, 0);

            _platform.Rotate(axis, Space.World);
        }
    }
}