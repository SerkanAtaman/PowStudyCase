using POW.BroadcastingChannels.PlayerStatsChannel;
using POW.BroadcastingChannels.GameStateChannels;
using UnityEngine;

namespace POW.Datas.PlayerDatas
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Datas/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field:SerializeField] public int PlayerStars { get; private set; }

        [Header("Broadcasting On")]
        [SerializeField] private PlayerStarGainChannel _playerStarGainedChannel;

        [Header("Listening To")]
        [SerializeField] private GameStateChangedChannel _gameStateChangedChannel;

        private void OnEnable()
        {
            _gameStateChangedChannel.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            _gameStateChangedChannel.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if(state == GameState.Initialization) SetStarAmount(0);
        }

        public void GivePlayerStar(int starAmount)
        {
            PlayerStars += starAmount;

            _playerStarGainedChannel.OnPlayerGainedStars?.Invoke(starAmount, PlayerStars);
        }

        public void SetStarAmount(int amount)
        {
            PlayerStars = amount;
            _playerStarGainedChannel.OnPlayerGainedStars?.Invoke(0, PlayerStars);
        }
    }
}