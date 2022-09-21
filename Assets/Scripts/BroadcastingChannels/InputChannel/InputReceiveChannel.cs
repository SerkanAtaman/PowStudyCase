using System;
using UnityEngine;
using POW.Controls;

namespace POW.BroadcastingChannels.InputChannel
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BroadcastChannels/Input/InputReceiveChannel")]
    public class InputReceiveChannel : ScriptableObject
    {
        public Action<InputData> OnInputReceived;
    }
}