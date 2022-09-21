using System;
using POW.Cubes;
using UnityEngine;

namespace POW.BroadcastingChannels.InteractionChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Interaction/CubeReserveDemandChannel")]
    public class CubeReserveDemandChannel : ScriptableObject
    {
        public Action<CubeMono> OnCubeReserveDemanded;
    }
}