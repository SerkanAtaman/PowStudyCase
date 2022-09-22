using UnityEngine;
using POW.BroadcastingChannels.AbilityChannels;

namespace POW.Gameplay.AbilitySystem.Managers
{
    public class AbilityManager : MonoBehaviour
    {
        [Header("Broadcasting On")]
        [SerializeField] private AbilityUsedChannel _abilityUsedChannel;

        [Header("Listening To")]
        [SerializeField] private AbilitySlotChannel _abilitySlotChannel;

        private void Awake()
        {
            _abilitySlotChannel.OnAbilitySlotUsed += ProcessUsedAbilitySlot;
        }

        private void ProcessUsedAbilitySlot(Ability ability)
        {
            _abilityUsedChannel.OnAbilityUsed?.Invoke(ability);
        }
    }
}