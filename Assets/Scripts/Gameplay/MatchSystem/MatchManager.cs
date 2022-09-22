using UnityEngine;
using POW.BroadcastingChannels.MatchChannel;
using POW.Gameplay.MatchingArea;

namespace POW.Gameplay.MatchSystem
{
    public class MatchManager : MonoBehaviour
    {
        [Header("Listening To")]
        [SerializeField] private CubeReserveChannel _cubeReserveChannel;

        [Header("Broadcasting On")]
        [SerializeField] private MatchCreatedChannel _matchCreatedChannel;
        [SerializeField] private MatchFailedChannel _matchFailedChannel;

        private MatchHandler _matchHandler;

        private void Awake()
        {
            _matchHandler = new MatchHandler(this);
        }

        private void OnEnable()
        {
            _cubeReserveChannel.OnCubeReserved += CheckPossibleMatches;
        }

        private void OnDisable()
        {
            _cubeReserveChannel.OnCubeReserved -= CheckPossibleMatches;
        }

        private void CheckPossibleMatches(ReservedCubes reservedCubes)
        {
            if (_matchHandler.CheckMatches(reservedCubes, _matchCreatedChannel.OnMatchCreated)) return;

            _matchFailedChannel.OnMatchFailed?.Invoke();
        }
    }
}