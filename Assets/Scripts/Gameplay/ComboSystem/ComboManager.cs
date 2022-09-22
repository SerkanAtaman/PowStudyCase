using System.Collections;
using UnityEngine;
using POW.Datas.ComboDatas;
using POW.BroadcastingChannels.MatchChannel;

namespace POW.Gameplay.ComboSystem
{
    public class ComboManager : MonoBehaviour
    {
        [SerializeField] private ComboData _comboData;

        [Header("Listening To")]
        [SerializeField] private MatchCreatedChannel _matchCreatedChannel;

        private bool _consuming;

        private void Awake()
        {
            _consuming = false;
            _comboData.SetCombo(1);
            _comboData.SetStamina(0f);
            _matchCreatedChannel.OnMatchCreated += IncreaseCombo;
        }

        private void IncreaseCombo()
        {
            _comboData.SetCombo(_comboData.CurrentCombo + 1);
            _comboData.SetStamina(1.0f);

            if (!_consuming) StartCoroutine(ConsumeComboStamina());
        }

        private IEnumerator ConsumeComboStamina()
        {
            _consuming = true;

            while (_comboData.CurrentComboStamina > 0.0f)
            {
                _comboData.DecreaseStamina(Time.deltaTime * _comboData.ComboSettings.ComboStaminaConsumeSpeed);

                yield return null;
            }

            _comboData.SetCombo(1);
            _comboData.SetStamina(0f);
            _consuming = false;
        }
    }
}