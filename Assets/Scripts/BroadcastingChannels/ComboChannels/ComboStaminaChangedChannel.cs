using System;
using UnityEngine;

namespace POW.BroadcastingChannels.ComboChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Combo/ComboStaminaChanged")]
    public class ComboStaminaChangedChannel : ScriptableObject
    {
        public Action<float> OnComboStaminaChanged;
    }
}