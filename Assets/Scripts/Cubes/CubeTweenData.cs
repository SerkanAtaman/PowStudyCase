using System;
using UnityEngine;

namespace POW.Cubes
{
    public enum CubeTweenType
    {
        TPosition,
        TRotation,
        TPositionAndRotation,
        TPositionRotationScale
    }

    public class CubeTweenData
    {
        public CubeTweenType Type { get; private set; }

        public Transform Cube { get; private set; }

        public Vector3 TargetPosition { get; private set; }
        public Vector3 TargetScale { get; private set; }
        public Quaternion TargetRotation { get; private set; }

        public Space Space { get; private set; }

        public Action OnTweenEnd { get; private set; }

        public CubeTweenData(Transform cube, CubeTweenType type, Vector3 targetPos, Space space = Space.World, Action onEnd = null)
        {
            Type = type;
            TargetPosition = targetPos;
            Cube = cube;
            Space = space;
            OnTweenEnd = onEnd;
        }

        public CubeTweenData(Transform cube, CubeTweenType type, Quaternion targetRot, Space space = Space.World, Action onEnd = null)
        {
            Type = type;
            TargetRotation = targetRot;
            Cube = cube;
            Space = space;
            OnTweenEnd = onEnd;
        }

        public CubeTweenData(Transform cube, CubeTweenType type, Vector3 targetPos, Quaternion targetRot, Space space = Space.World, Action onEnd = null)
        {
            Type = type;
            TargetPosition = targetPos;
            TargetRotation = targetRot;
            Cube = cube;
            Space = space;
            OnTweenEnd = onEnd;
        }

        public CubeTweenData(Transform cube, CubeTweenType type, Vector3 targetPos, Quaternion targetRot, Vector3 targetScale, Space space = Space.World, Action onEnd = null)
        {
            Type = type;
            TargetPosition = targetPos;
            TargetRotation = targetRot;
            Cube = cube;
            Space = space;
            TargetScale = targetScale;
            OnTweenEnd = onEnd;
        }
    }
}