using System;
using UnityEngine;

namespace POW.BroadcastingChannels.CubePlatformChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/CubePlatform/PlatformCreatedChannel")]
    public class PlatformCreatedChannel : ScriptableObject
    {
        public Action<Transform> OnCubePlatformCreated;
    }
}