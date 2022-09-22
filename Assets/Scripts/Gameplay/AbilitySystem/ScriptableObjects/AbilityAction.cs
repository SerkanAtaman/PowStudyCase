using UnityEngine;
using System;

namespace POW.Gameplay.AbilitySystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Abilities/AbilityAction")]
    public class AbilityAction : ScriptableObject
    {
        public Action<Action> AbilityFunction;
    }
}