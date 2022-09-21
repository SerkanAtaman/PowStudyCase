using System;
using UnityEngine;

namespace POW.BroadcastingChannels.InputChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Input/ClickReceiverChannel")]
    public class ClickReceiverChannel : ScriptableObject
    {
        public Action<Vector3> OnPointerClicked;
    }
}