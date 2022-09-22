using UnityEngine;
using POW.BroadcastingChannels.ComboChannels;
using POW.Settings.Combo;

namespace POW.Datas.ComboDatas
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Datas/ComboData")]
    public class ComboData : ScriptableObject
    {
        [field:SerializeField] public int CurrentCombo { get; private set; }
        [field:SerializeField] public float CurrentComboStamina { get; private set; }
        [field:SerializeField] public ComboSettings ComboSettings { get; private set; }

        [Header("Broadcasting On")]
        [SerializeField] private ComboChangedChannel _comboChangedChannel;
        [SerializeField] private ComboStaminaChangedChannel _comboStaminaChangedChannel;

        public void SetCombo(int combo)
        {
            CurrentCombo = combo;
            _comboChangedChannel.OnComboChanged?.Invoke(CurrentCombo);
        }

        public void SetStamina(float stamina)
        {
            CurrentComboStamina = stamina;
            _comboStaminaChangedChannel.OnComboStaminaChanged?.Invoke(CurrentComboStamina);
        }

        public void DecreaseStamina(float amount)
        {
            CurrentComboStamina -= amount;
            _comboStaminaChangedChannel.OnComboStaminaChanged?.Invoke(CurrentComboStamina);
        }
    }
}