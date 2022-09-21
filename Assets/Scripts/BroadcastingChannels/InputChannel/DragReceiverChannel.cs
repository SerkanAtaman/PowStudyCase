using System;
using UnityEngine;

namespace POW.BroadcastingChannels.InputChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Input/DragReceiveeChannel")]
    public class DragReceiverChannel : ScriptableObject
    {
        public Action<bool> OnDragStateChanged;
    }
}