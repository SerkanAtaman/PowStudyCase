using UnityEngine;

namespace POW.Settings.Platform
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Settings/Platform")]
    public class CubePlatformSettings : ScriptableObject
    {
        [field:SerializeField] public Vector3Int CubePlatformSize { get; private set; }
    }
}