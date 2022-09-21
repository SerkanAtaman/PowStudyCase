using UnityEngine;

namespace POW.Datas.Assets
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Datas/AssetData")]
    public class AssetData : ScriptableObject
    {
        [field:SerializeField] public Material[] CubeMaterials { get; private set; }
    }
}