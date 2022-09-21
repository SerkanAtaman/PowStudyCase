using System;
using POW.Cubes;
using UnityEngine;

namespace POW.BroadcastingChannels.InteractionChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Interaction/CubeReserveChannel")]
    public class CubeReserveChannel : ScriptableObject
    {
        public Action<CubeMono, Action> OnCubeReserveDemanded;
    }
}