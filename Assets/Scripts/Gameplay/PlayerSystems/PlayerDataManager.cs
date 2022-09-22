using UnityEngine;
using POW.BroadcastingChannels.MatchChannel;
using POW.Datas.PlayerDatas;

namespace POW.Gameplay.PlayerSystems
{
    public class PlayerDataManager : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        [Header("Listening To")]
        [SerializeField] private MatchCreatedChannel _matchCreatedChannel;

        private void Awake()
        {
            _matchCreatedChannel.OnMatchCreated += GivePlayerStar;
        }

        private void GivePlayerStar()
        {
            _playerData.GivePlayerStar(5);
        }
    }
}