using UnityEngine;

namespace POW.Gameplay.AbilitySystem.Classes
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Abilities/Undo")]
    public class UndoAbility : Ability
    {
        private void OnEnable()
        {
            AbilityType = AbilityType.Undo;
        }
    }
}