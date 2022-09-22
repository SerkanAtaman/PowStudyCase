using System;
using UnityEngine;
using POW.Datas;

namespace POW.BroadcastingChannels.CubePlatformChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/CubePlatform/PlatformCreatedChannel")]
    public class PlatformCreatedChannel : ScriptableObject
    {
        public Action<CubePlatformData> OnCubePlatformCreated;
    }
}