using UnityEngine;
using UnityEngine.UI;
using POW.BroadcastingChannels.AbilityChannels;
using POW.BroadcastingChannels.GameStateChannels;

namespace POW.Gameplay.AbilitySystem
{
    public class AbilitySlot : MonoBehaviour
    {
        [SerializeField] private Ability _ability;
        [SerializeField] private Text _abilityCountText;

        [Header("Broadcasting On")]
        [SerializeField] private AbilitySlotChannel _abilitySlotChannel;

        [Header("Listening To")]
        [SerializeField] private GameStateChangedChannel _stateChangedChannel;

        private bool _enabled;

        private void Awake()
        {
            _abilityCountText.text = _ability.AbilityCount.ToString();
            _enabled = true;
        }

        private void OnEnable()
        {
            _stateChangedChannel.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            _stateChangedChannel.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            _enabled = state == GameState.Gameplay;
        }

        public void SlotButton()
        {
            if (!_enabled) return;
            if (_ability.AbilityCount <= 0) return;

            _abilitySlotChannel.OnAbilitySlotUsed?.Invoke(_ability);

            _abilityCountText.text = _ability.AbilityCount.ToString();
        }
    }
}