using System;
using UnityEngine;

namespace POW.BroadcastingChannels.MatchChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Match/MatchCreatedChannel")]
    public class MatchCreatedChannel : ScriptableObject
    {
        public Action OnMatchCreated;
    }
}