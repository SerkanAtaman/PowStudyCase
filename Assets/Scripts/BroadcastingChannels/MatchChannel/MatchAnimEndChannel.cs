using System;
using UnityEngine;

namespace POW.BroadcastingChannels.MatchChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Match/MatchAnimEnded")]
    public class MatchAnimEndChannel : ScriptableObject
    {
        public Action OnMatchAnimEnded;
    }
}