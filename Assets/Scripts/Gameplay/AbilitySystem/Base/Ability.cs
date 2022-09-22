using UnityEngine;

namespace POW.Gameplay.AbilitySystem
{
    public abstract class Ability : ScriptableObject
    {
        [field:SerializeField] public int AbilityCount { get; protected set; }
        [field: SerializeField] public Sprite AbilityIcon { get; protected set; }
        [field:SerializeField] public AbilityAction[] AbilityActions { get; protected set; }

        public AbilityType AbilityType { get; protected set; }

        public void Rise()
        {
            foreach (var action in AbilityActions)
            {
                action.AbilityFunction.Invoke(OnAbilitySuccessed);
            }
        }

        private void OnAbilitySuccessed()
        {
            AbilityCount--;
        }
    }
}