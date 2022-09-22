using System;
using UnityEngine;

namespace POW.BroadcastingChannels.GameStateChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/GameState/InitializationEnd")]
    public class InitializationEndChannel : ScriptableObject
    {
        public Action OnInitializationEnd;
    }
}