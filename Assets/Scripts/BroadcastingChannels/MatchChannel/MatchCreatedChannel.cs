using System;
using UnityEngine;
using POW.Cubes;

namespace POW.BroadcastingChannels.MatchChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Match/MatchCreatedChannel")]
    public class MatchCreatedChannel : ScriptableObject
    {
        public Action<CubeMono[]> OnMatchCreatedWCubes;
        public Action OnMatchCreated;
    }
}