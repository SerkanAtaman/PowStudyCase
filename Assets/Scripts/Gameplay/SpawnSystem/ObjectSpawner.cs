using POW.GameObjects.UIObjects;
using POW.BroadcastingChannels.PlayerStatsChannel;
using POW.BroadcastingChannels.MatchChannel;
using POW.BroadcastingChannels.SpawnChannels;
using Seroley.DelayHandling;
using POW.Cubes;
using UnityEngine;

namespace POW.Gameplay.SpawnSystem
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _uiStarPref;

        [Header("Listening To")]
        [SerializeField] private PlayerStarGainChannel _starGainChannel;
        [SerializeField] private MatchCreatedChannel _matchCreatedChannel;

        [Header("Broadcasting On")]
        [SerializeField] private UIStarSpawnedChannel _uiStarSpawnChannel;

        private Vector3 _lastMatchPosition;

        private void OnEnable()
        {
            _starGainChannel.OnPlayerGainedStars += SpawnUIStars;
            _matchCreatedChannel.OnMatchCreatedWCubes += SetMatchPosition;
        }

        private void OnDisable()
        {
            _starGainChannel.OnPlayerGainedStars -= SpawnUIStars;
            _matchCreatedChannel.OnMatchCreatedWCubes -= SetMatchPosition;
        }

        private void SetMatchPosition(CubeMono[] cubes)
        {
            _lastMatchPosition = cubes[1].transform.position;
        }

        private void SpawnUIStars(int gainedStars, int totalStars)
        {
            for(int i = 0; i < gainedStars; i++)
            {
                new Delay(0.03f * i, SpawnSingleUIStar);
            }
        }

        private void SpawnSingleUIStar()
        {
            Transform star = Instantiate(_uiStarPref, _lastMatchPosition, Quaternion.identity).transform;

            _uiStarSpawnChannel.OnUIStarSpawned?.Invoke(new UIStar(star));
        }
    }
}