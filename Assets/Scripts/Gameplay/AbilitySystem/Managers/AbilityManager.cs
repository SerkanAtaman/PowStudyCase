using UnityEngine;
using POW.BroadcastingChannels.AbilityChannels;

namespace POW.Gameplay.AbilitySystem.Managers
{
    public class AbilityManager : MonoBehaviour
    {
        [Header("Broadcasting On")]
        [SerializeField] private AbilitiesSettledChannel _abilitiesSettledChannel;

        [Header("Listening To")]
        [SerializeField] private AbilitySlotChannel _abilitySlotChannel;

        private void Awake()
        {
            _abilitySlotChannel.OnAbilitySlotUsed += ProcessUsedAbilitySlot;
        }

        private void Start()
        {
            _abilitiesSettledChannel.OnAbilitiesSettled.Invoke();
        }

        private void ProcessUsedAbilitySlot(Ability ability)
        {
            ability.Rise();
        }
    }
}