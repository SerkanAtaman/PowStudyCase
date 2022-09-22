using System;
using UnityEngine;
using POW.Gameplay.AbilitySystem;

namespace POW.BroadcastingChannels.AbilityChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Ability/AbilityUsed")]
    public class AbilityUsedChannel : ScriptableObject
    {
        public Action<Ability> OnAbilityUsed;
    }
}