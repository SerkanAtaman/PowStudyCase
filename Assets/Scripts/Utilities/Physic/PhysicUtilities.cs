using UnityEngine;
using System.Collections.Generic;

namespace POW.Utilities.Physic
{
    public static class PhysicUtilities
    {
        private static Ray _tempRay;
        private static RaycastHit _tempRaycastHit;

        public static T GetInteractableOnRayPoint<T>(Vector3 position, LayerMask layerMask)
        {
            _tempRay = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(_tempRay, out _tempRaycastHit, float.MaxValue, layerMask))
                return _tempRaycastHit.collider.gameObject.GetComponent<T>();
            else return default;
        }

        public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    key = pair.Key;
                    break;
                }
            }
            UnityEngine.Debug.Log(key);
            return key;
        }
    }
}