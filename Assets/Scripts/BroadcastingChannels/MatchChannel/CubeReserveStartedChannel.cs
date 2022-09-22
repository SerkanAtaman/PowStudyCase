using System;
using UnityEngine;

namespace POW.BroadcastingChannels.MatchChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Match/CubeReserveStartedChannel")]
    public class CubeReserveStartedChannel : ScriptableObject
    {
        
        public Action OnStartedCubeReserve;
    }
}