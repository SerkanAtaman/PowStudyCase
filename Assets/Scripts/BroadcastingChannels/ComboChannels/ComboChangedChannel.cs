using System;
using UnityEngine;

namespace POW.BroadcastingChannels.ComboChannels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Combo/ComboChanged")]
    public class ComboChangedChannel : ScriptableObject
    {
        public Action<int> OnComboChanged;
    }
}