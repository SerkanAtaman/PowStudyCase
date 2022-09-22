using System;
using UnityEngine;

namespace Seroley.SmoothLerping
{
    public class SmoothLerpPosition
    {
        public Transform Transform { get; private set; }

        public Vector3 StartPos { get; private set; }
        public Vector3 TargetPos { get; private set; }
        public float Duration { get; private set; }

        public Action OnLerpEnded { get; private set; }

        public SmoothLerpPosition(Transform transform, Vector3 startPos, Vector3 targetPos, float duration, Action onLerpEnded)
        {
            Transform = transform;
            StartPos = startPos;
            TargetPos = targetPos;
            Duration = duration;
            OnLerpEnded = onLerpEnded;

            SmoothLerpHandler.LerpPosition(this);
        }
    }
}