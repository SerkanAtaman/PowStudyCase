using System;
using UnityEngine;

namespace POW.Gameplay.AbilitySystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Abilities/Action")]
    public class AbilityAction : ScriptableObject
    {
        public Action Action;
    }
}