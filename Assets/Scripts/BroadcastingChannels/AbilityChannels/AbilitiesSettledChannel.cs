using UnityEngine;
using System;

namespace POW.BroadcastingChannels.AbilityChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Ability/AbilitiesSettled")]
    public class AbilitiesSettledChannel : ScriptableObject
    {
        public Action OnAbilitiesSettled;
    }
}