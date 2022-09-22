using UnityEngine;
using POW.Gameplay.AbilitySystem;

namespace POW.Datas.PlayerDatas
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Datas/Player/AbilityData")]
    public class PlayerAbilityData : ScriptableObject
    {
        [field:SerializeField] public Ability[] ActiveAbilities { get; private set; }
    }
}