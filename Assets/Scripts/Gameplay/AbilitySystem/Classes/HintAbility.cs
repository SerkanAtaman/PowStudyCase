using UnityEngine;

namespace POW.Gameplay.AbilitySystem.Classes
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Abilities/Hint")]
    public class HintAbility : Ability
    {
        private void OnEnable()
        {
            AbilityType = AbilityType.Hint;
        }
    }
}