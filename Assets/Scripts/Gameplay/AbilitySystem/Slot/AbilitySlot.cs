using UnityEngine;
using UnityEngine.UI;
using POW.BroadcastingChannels.AbilityChannels;

namespace POW.Gameplay.AbilitySystem
{
    public class AbilitySlot : MonoBehaviour
    {
        [SerializeField] private Ability _ability;
        [SerializeField] private Text _abilityCountText;

        [Header("Broadcasting On")]
        [SerializeField] private AbilitySlotChannel _abilitySlotChannel;

        private void Awake()
        {
            _abilityCountText.text = _ability.AbilityCount.ToString();
        }

        public void SlotButton()
        {
            if (_ability.AbilityCount <= 0) return;

            _abilitySlotChannel.OnAbilitySlotUsed?.Invoke(_ability);

            _abilityCountText.text = _ability.AbilityCount.ToString();
        }
    }
}