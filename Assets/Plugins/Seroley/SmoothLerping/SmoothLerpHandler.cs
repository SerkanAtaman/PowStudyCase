using UnityEngine;

namespace Seroley.SmoothLerping
{
    public static class SmoothLerpHandler
    {
        private static SmoothLerpMono _lerper;

        private static void Init()
        {
            GameObject lerper = new GameObject();
            lerper.name = "SmoothLerpObject";
            lerper.AddComponent(typeof(SmoothLerpMono));
            GameObject.DontDestroyOnLoad(lerper);

            _lerper = lerper.GetComponent<SmoothLerpMono>();
        }

        public static void LerpPosition(SmoothLerpPosition lPosition)
        {
            if (!_lerper) Init();

            _lerper.StartLPosition(lPosition);
        }

        public static void LerpPositionRotation(SmoothLerpPositionRotation lPositionRotation)
        {
            if (!_lerper) Init();

            _lerper.StartLPositionRotation(lPositionRotation);
        }
    }
}