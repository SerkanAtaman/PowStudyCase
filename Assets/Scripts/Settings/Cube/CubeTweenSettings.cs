using UnityEngine;

namespace POW.Settings.Cube
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Settings/Cube/TweenSettings")]
    public class CubeTweenSettings : ScriptableObject
    {
        [field:SerializeField] public float TweenPosDuration { get; private set; }
        [field:SerializeField] public float TweenRotDuration { get; private set; }
        [field:SerializeField] public float TweenScaleDuration { get; private set; }
    }
}