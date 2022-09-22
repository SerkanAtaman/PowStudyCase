using UnityEngine;
using UnityEngine.UI;
using POW.BroadcastingChannels.PlayerStatsChannel;
using POW.BroadcastingChannels.SpawnChannels;
using POW.GameObjects.UIObjects;
using POW.Utilities.Camera;

namespace POW.UserInterface
{
    public class PlayerStarField : MonoBehaviour
    {
        [SerializeField] private Text _playerStarText;
        [SerializeField] private RectTransform _starImageRect;

        [Header("Listening To")]
        [SerializeField] private PlayerStarGainChannel _playerStarGainChannel;
        [SerializeField] private UIStarSpawnedChannel _uiStarSpawnedChannel;

        private void OnEnable()
        {
            _playerStarGainChannel.OnPlayerGainedStars += OnPlayerGainedStars;
            _uiStarSpawnedChannel.OnUIStarSpawned += SetSpawnedStar;
        }

        private void OnDisable()
        {
            _playerStarGainChannel.OnPlayerGainedStars -= OnPlayerGainedStars;
            _uiStarSpawnedChannel.OnUIStarSpawned -= SetSpawnedStar;
        }

        private void OnPlayerGainedStars(int gainedAmount, int totalAmount)
        {
            _playerStarText.text = totalAmount.ToString();
        }

        private void SetSpawnedStar(UIStar star)
        {
            star.Init(CameraUtilities.GetWorldPosOfUIRect(_starImageRect));
        }
    }
}