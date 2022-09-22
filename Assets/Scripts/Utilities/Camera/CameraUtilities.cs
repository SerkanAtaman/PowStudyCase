using UnityEngine;

namespace POW.Utilities.Camera
{
    public static class CameraUtilities
    {
        public static Vector3 GetWorldPosOfUIRect(RectTransform rect)
        {
            return UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(rect.position.x, rect.position.y, 10));
        }
    }
}