using System;
using UnityEngine;

namespace Seroley.SmoothLerping
{
    public class SmoothLerpPositionRotation
    {
        public Transform Transform { get; private set; }

        public Vector3 StartPos { get; private set; }
        public Vector3 TargetPos { get; private set; }

        public Quaternion StartRot { get; private set; }
        public Quaternion TargetRot { get; private set; }

        public float Duration { get; private set; }

        public Action OnLerpEnded { get; private set; }

        public SmoothLerpPositionRotation(Transform transform, Vector3 startPos, Vector3 targetPos, Quaternion startRot, Quaternion targetRot, float duration, Action onLerpEnded)
        {
            Transform = transform;
            StartPos = startPos;
            TargetPos = targetPos;
            StartRot = startRot;
            TargetRot = targetRot;
            Duration = duration;
            OnLerpEnded = onLerpEnded;

            SmoothLerpHandler.LerpPositionRotation(this);
        }
    }
}