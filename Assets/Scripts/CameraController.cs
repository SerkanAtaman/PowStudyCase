using UnityEngine;
using POW.BroadcastingChannels.CubePlatformChannel;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offsetFromPlatform;

    [Header("listening To")]
    [SerializeField] private PlatformCreatedChannel _platformCreatedChannel;

    private void OnEnable()
    {
        _platformCreatedChannel.OnCubePlatformCreated += SetOffset;
    }

    private void OnDisable()
    {
        _platformCreatedChannel.OnCubePlatformCreated -= SetOffset;
    }

    private void SetOffset()
    {
        transform.position = References.Instance.CubePlatformData.PlatformHolder.position + _offsetFromPlatform;
        transform.position -= transform.forward * (References.Instance.CubePlatformData.MaxSize * 0.75f);
    }
}