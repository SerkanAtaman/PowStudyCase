using System;
using UnityEngine;
using POW.Gameplay.MatchingArea;

namespace POW.BroadcastingChannels.MatchChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Match/CubeReserveChannel")]
    public class CubeReserveChannel : ScriptableObject
    {
        public Action<ReservedCubes> OnCubeReserved;
    }
}