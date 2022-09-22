using System;
using UnityEngine;
using POW.Gameplay.AbilitySystem;

namespace POW.BroadcastingChannels.AbilityChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Ability/AbilitySlot")]
    public class AbilitySlotChannel : ScriptableObject
    {
        public Action<Ability> OnAbilitySlotUsed;
    }
}