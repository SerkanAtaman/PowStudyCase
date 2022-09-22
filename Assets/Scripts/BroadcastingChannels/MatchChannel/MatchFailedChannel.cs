using System;
using UnityEngine;

namespace POW.BroadcastingChannels.MatchChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Match/MatchFailed")]
    public class MatchFailedChannel : ScriptableObject
    {
        public Action OnMatchFailed;
    }
}