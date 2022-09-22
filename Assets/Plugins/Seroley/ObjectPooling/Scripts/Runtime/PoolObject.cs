using UnityEngine;

namespace Seroley.ObjectPooling
{
    public class PoolObject : MonoBehaviour
    {
        public PoolDefiner.PoolType PoolType { get; private set; }

        public void SetPoolType(PoolDefiner.PoolType type)
        {
            PoolType = type;
        }

        public void DestroyObject()
        {
            ObjectPoolSystem.SendObjectBackToPool(PoolType, this);
        }
    }
}