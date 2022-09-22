using UnityEngine;

namespace POW.Settings.Combo
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Settings/ComboSettings")]
    public class ComboSettings : ScriptableObject
    {
        [field:SerializeField] public float ComboStaminaConsumeSpeed { get; private set; }
    }
}