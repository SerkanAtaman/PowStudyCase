using UnityEngine;
using Seroley.ObjectPooling;

public static class GameObjectExtentioner
{
    public static void TryDestroyWithPool(this GameObject obj)
    {
        if (obj.TryGetComponent(out PoolObject pObject))
        {
            pObject.DestroyObject();
        }
        else
        {
            GameObject.Destroy(obj);
        }
    }
}