using UnityEngine;
using UnityEngine.UI;
using POW.BroadcastingChannels.ComboChannels;

namespace POW.UserInterface
{
    public class ComboField : MonoBehaviour
    {
        [SerializeField] private Image _comboBarInside;
        [SerializeField] private Text _comboText;

        [Header("Listening To")]
        [SerializeField] private ComboChangedChannel _comboIncreaseChannel;
        [SerializeField] private ComboStaminaChangedChannel _comboStaminaChangedChannel;

        private void Awake()
        {
            _comboBarInside.fillAmount = 0.0f;
            _comboText.text = "x" + 1;
        }

        private void OnEnable()
        {
            _comboIncreaseChannel.OnComboChanged += SetComboField;
            _comboStaminaChangedChannel.OnComboStaminaChanged += SetComboStamina;
        }

        private void OnDisable()
        {
            _comboIncreaseChannel.OnComboChanged -= SetComboField;
            _comboStaminaChangedChannel.OnComboStaminaChanged -= SetComboStamina;
        }

        private void SetComboField(int currentCombo)
        {
            _comboText.text = "x" + currentCombo;
            _comboBarInside.fillAmount = 1.0f;
        }

        private void SetComboStamina(float stamina)
        {
            _comboBarInside.fillAmount = stamina;
        }
    }
}