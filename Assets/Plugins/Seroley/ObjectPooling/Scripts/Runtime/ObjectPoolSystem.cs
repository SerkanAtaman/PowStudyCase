using UnityEngine;

namespace Seroley.ObjectPooling
{
    public static class ObjectPoolSystem
    {
        private readonly static Pool[] _allPools;

        static ObjectPoolSystem()
        {
            GameObject poolHolder = new GameObject("ObjectPool");

            Object.DontDestroyOnLoad(poolHolder);

            ObjectPool[] pools = Resources.LoadAll<ObjectPool>("ObjectPools");

            if(pools == null)
            {
                Debug.LogError("There is no valid ObjectPool in given path");
                return;
            }

            _allPools = new Pool[pools.Length];

            for (int i = 0; i < pools.Length; i++)
            {
                _allPools[i] = new Pool(pools[i], poolHolder.transform);
            }
        }

        /// <summary>
        /// Spawns requested PoolObject at default position without parent
        /// </summary>
        /// <param name="objectType">The PoolType of the gameObject</param>
        /// <returns></returns>
        public static GameObject SpawnObject(PoolDefiner.PoolType objectType)
        {
            int poolID = -1;

            for(int i = 0; i < _allPools.Length; i++)
            {
                if(_allPools[i].PoolType == objectType)
                {
                    poolID = i;
                    break;
                }
            }

            if(poolID < 0)
            {
                Debug.LogError("Requested type of " + objectType + " object is not exist in the pool");
                return null;
            }

            GameObject obj = _allPools[poolID].Pull().gameObject;
            obj.transform.SetParent(null);
            obj.SetActive(true);

            return obj;
        }

        /// <summary>
        /// Spawns requested PoolObject as a child of given parent
        /// </summary>
        /// <param name="objectType">The PoolType of the gameObject</param>
        /// <param name="parent">The parent of the spawned PoolObject</param>
        /// <returns></returns>
        public static GameObject SpawnObject(PoolDefiner.PoolType objectType, Transform parent)
        {
            int poolID = -1;

            for (int i = 0; i < _allPools.Length; i++)
            {
                if (_allPools[i].PoolType == objectType)
                {
                    poolID = i;
                    break;
                }
            }

            if (poolID < 0)
            {
                Debug.LogError("Requested type of " + objectType + " object is not exist in the pool");
                return null;
            }

            GameObject obj = _allPools[poolID].Pull().gameObject;
            obj.transform.SetParent(parent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.SetActive(true);
            
            return obj;
        }

        /// <summary>
        /// Spawns requested PoolObject at given position and rotation without parent
        /// </summary>
        /// <param name="objectType">The PoolType of the gameObject</param>
        /// <param name="position">The spawn position of the PoolObject</param>
        /// <param name="rotation">The spawn rotation of the PoolObject</param>
        /// <returns></returns>
        public static GameObject SpawnObject(PoolDefiner.PoolType objectType, Vector3 position, Quaternion rotation)
        {
            int poolID = -1;

            for (int i = 0; i < _allPools.Length; i++)
            {
                if (_allPools[i].PoolType == objectType)
                {
                    poolID = i;
                    break;
                }
            }

            if (poolID < 0)
            {
                Debug.LogError("Requested type of " + objectType + " object is not exist in the pool");
                return null;
            }

            GameObject obj = _allPools[poolID].Pull().gameObject;
            obj.transform.SetParent(null);
            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);

            return obj;
        }

        /// <summary>
        /// Spawns requested PoolObject as a child of given parent at given local position and rotation
        /// </summary>
        /// <param name="objectType">The PoolType of the gameObject</param>
        /// <param name="parent">The parent of the spawned PoolObject</param>
        /// <param name="localPosition">The spawn localPosition of the PoolObject</param>
        /// <param name="localRotation">The spawn localRotation of the PoolObject</param>
        /// <returns></returns>
        public static GameObject SpawnObject(PoolDefiner.PoolType objectType, Transform parent, Vector3 localPosition, Quaternion localRotation)
        {
            int poolID = -1;

            for (int i = 0; i < _allPools.Length; i++)
            {
                if (_allPools[i].PoolType == objectType)
                {
                    poolID = i;
                    break;
                }
            }

            if (poolID < 0)
            {
                Debug.LogError("Requested type of " + objectType + " object is not exist in the pool");
                return null;
            }

            GameObject obj = _allPools[poolID].Pull().gameObject;
            obj.transform.SetParent(parent);
            obj.transform.localPosition = localPosition;
            obj.transform.localRotation = localRotation;
            obj.SetActive(true);

            return obj;
        }

        /// <summary>
        /// Sends the given PoolObject back to its pool
        /// </summary>
        /// <param name="objectType">The type of PoolObject will be sent to pool</param>
        /// <param name="obj">The PoolObject to send its pool</param>
        public static void SendObjectBackToPool(PoolDefiner.PoolType objectType, PoolObject obj)
        {
            int poolID = -1;

            for (int i = 0; i < _allPools.Length; i++)
            {
                if (_allPools[i].PoolType == objectType)
                {
                    poolID = i;
                    break;
                }
            }

            if (poolID < 0)
            {
                Debug.LogError("Requested type of " + objectType + " object is not exist in the pool");
                return;
            }

            _allPools[poolID].Push(obj);
        }
    }
}