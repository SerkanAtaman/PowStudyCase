using System.Collections.Generic;
using UnityEngine;

namespace Seroley.ObjectPooling
{
    public class Pool
    {
        public PoolDefiner.PoolType PoolType { get; private set; }

        private Queue<PoolObject> _pool;

        private GameObject _poolObjectPrefab;
        private Transform _poolObjectHolder;

        private int _poolSize;

        public Pool(ObjectPool objectPool, Transform poolObjectHolder)
        {
            _pool = new Queue<PoolObject>();
            _poolObjectPrefab = objectPool.PoolObjectPrefab;
            _poolObjectHolder = poolObjectHolder;
            PoolType = objectPool.PoolType;
            ExpandPool(objectPool.PoolStartSize);
        }

        private void ExpandPool(int expandAmount)
        {
            for (int i = 0; i < expandAmount; i++)
            {
                GameObject obj = GameObject.Instantiate(_poolObjectPrefab, _poolObjectHolder);
                obj.SetActive(false);

                if (obj.TryGetComponent(out PoolObject pObject))
                {
                    pObject.SetPoolType(PoolType);
                }
                else
                {
                    obj.AddComponent(typeof(PoolObject));
                    pObject = obj.GetComponent<PoolObject>();
                    pObject.SetPoolType(PoolType);
                }
                
                _pool.Enqueue(pObject);
                _poolSize++;
            }
        }

        public PoolObject Pull()
        {
            if (_poolSize <= 0) ExpandPool(1);

            _poolSize--;

            return _pool.Dequeue();
        }

        public void Push(PoolObject poolObject)
        {
            _poolSize++;
            poolObject.gameObject.SetActive(false);
            poolObject.transform.SetParent(_poolObjectHolder);
            _pool.Enqueue(poolObject);
        }
    }
}