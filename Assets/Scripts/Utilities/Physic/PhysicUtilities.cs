using UnityEngine;

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
    }
}