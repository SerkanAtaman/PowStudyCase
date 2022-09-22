using System;
using UnityEngine;
using POW.Cubes;

namespace POW.BroadcastingChannels.CubeAnimationChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/CubeAnimation/CubeTweenChannel")]
    public class CubeTweenChannel : ScriptableObject
    {
        public Action<CubeTweenData> OnCubeTweenDemanded;
    }
}