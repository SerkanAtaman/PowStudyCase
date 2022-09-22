using System;
using UnityEngine;

namespace POW.BroadcastingChannels.GameStateChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/GameState/GameStateChanged")]
    public class GameStateChangedChannel : ScriptableObject
    {
        public Action<GameState> OnGameStateChanged;
    }
}