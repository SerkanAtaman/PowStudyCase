using UnityEngine;
using UnityEngine.UI;
using POW.BroadcastingChannels.AbilityChannels;
using POW.BroadcastingChannels.GameStateChannels;
using POW.Datas.PlayerDatas;

namespace POW.Gameplay.AbilitySystem
{
    public class AbilitySlot : MonoBehaviour
    {
        [SerializeField] private int _slotID;
        [SerializeField] private Text _abilityCountText;
        [SerializeField] private Image _abilityImage;
        [SerializeField] private PlayerAbilityData _abilityData;

        [Header("Broadcasting On")]
        [SerializeField] private AbilitySlotChannel _abilitySlotChannel;

        [Header("Listening To")]
        [SerializeField] private GameStateChangedChannel _stateChangedChannel;

        private bool _enabled;

        private void Awake()
        {
            _abilityCountText.text = _abilityData.ActiveAbilities[_slotID].AbilityCount.ToString();
            _abilityImage.sprite = _abilityData.ActiveAbilities[_slotID].AbilityIcon;
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
            if (_abilityData.ActiveAbilities[_slotID].AbilityCount <= 0) return;

            _abilitySlotChannel.OnAbilitySlotUsed?.Invoke(_abilityData.ActiveAbilities[_slotID]);

            _abilityCountText.text = _abilityData.ActiveAbilities[_slotID].AbilityCount.ToString();
        }
    }
}