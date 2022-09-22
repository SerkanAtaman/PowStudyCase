using System;
using UnityEngine;

namespace POW.BroadcastingChannels.PlayerStatsChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/PlayerStats/StarGained")]
    public class PlayerStarGainChannel : ScriptableObject
    {
        public Action<int, int> OnPlayerGainedStars;
    }
}