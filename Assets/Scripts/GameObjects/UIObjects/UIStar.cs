using UnityEngine;
using DG.Tweening;

namespace POW.GameObjects.UIObjects
{
    public class UIStar
    {
        private readonly Transform _transform;

        private Vector3 _endPosition;

        public UIStar(Transform transform)
        {
            _transform = transform;
        }

        public void Init(Vector3 endPosition)
        {
            _endPosition = endPosition;

            _transform.position += new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), 0f);

            _transform.DOMove(_endPosition, 1f).onComplete += () => UnityEngine.Object.Destroy(_transform.gameObject);
        }
    }
}