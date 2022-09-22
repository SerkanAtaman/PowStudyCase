using System;
using UnityEngine;
using POW.GameObjects.UIObjects;

namespace POW.BroadcastingChannels.SpawnChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Spawn/UIStarChannel")]
    public class UIStarSpawnedChannel : ScriptableObject
    {
        public Action<UIStar> OnUIStarSpawned;
    }
}