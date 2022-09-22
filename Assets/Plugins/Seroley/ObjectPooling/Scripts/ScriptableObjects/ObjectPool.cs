using UnityEngine;

namespace Seroley.ObjectPooling
{
    [CreateAssetMenu(menuName = "Seroley/ObjectPooling/NewObjectPool", fileName = "ObjectPool")]
    public class ObjectPool : ScriptableObject
    {
        [field:SerializeField] public string PoolName { get; private set; }
        [field:SerializeField] public GameObject PoolObjectPrefab { get; private set; }
        [field:SerializeField] public int PoolStartSize { get; private set; }
        [field:SerializeField] public PoolDefiner.PoolType PoolType { get; private set; }
    }
}