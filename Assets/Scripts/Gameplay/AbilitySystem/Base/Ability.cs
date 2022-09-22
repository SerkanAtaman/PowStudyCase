using UnityEngine;

namespace POW.Gameplay.AbilitySystem
{
    public abstract class Ability : ScriptableObject
    {
        [field:SerializeField] public int AbilityCount { get; set; }

        public AbilityType AbilityType { get; protected set; }
    }
}