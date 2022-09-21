using UnityEngine;

namespace POW.Cubes
{
    public class CubeRotator : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Vector3 _rotateAxis;

        private void Update()
        {
            _root.Rotate(Time.deltaTime * 10 * _rotateAxis, Space.Self);
        }
    }
}