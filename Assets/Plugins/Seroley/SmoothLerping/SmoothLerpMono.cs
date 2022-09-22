using System.Collections;
using UnityEngine;

namespace Seroley.SmoothLerping
{
    public class SmoothLerpMono : MonoBehaviour
    {
        public void StartLPosition(SmoothLerpPosition lerp)
        {
            StartCoroutine(SLerpPosition(lerp));
        }

        public void StartLPositionRotation(SmoothLerpPositionRotation lPosRot)
        {
            StartCoroutine(SLerpPositionRotation(lPosRot));
        }

        private IEnumerator SLerpPosition(SmoothLerpPosition lerp)
        {
            float delta = 0.0f;
            float speed = 1.0f / lerp.Duration;

            while (delta <= 1.0f)
            {
                delta += Time.deltaTime * speed;

                lerp.Transform.position = Vector3.Lerp(lerp.StartPos, lerp.TargetPos, delta);

                yield return null;
            }

            lerp.OnLerpEnded?.Invoke();
        }

        private IEnumerator SLerpPositionRotation(SmoothLerpPositionRotation lPosRot)
        {
            float delta = 0.0f;
            float speed = 1.0f / lPosRot.Duration;

            while (delta <= 1.0f)
            {
                delta += Time.deltaTime * speed;

                lPosRot.Transform.SetPositionAndRotation(Vector3.Lerp(lPosRot.StartPos, lPosRot.TargetPos, delta), Quaternion.Lerp(lPosRot.StartRot, lPosRot.TargetRot, delta));

                yield return null;
            }

            lPosRot.OnLerpEnded?.Invoke();
        }
    }
}