using UnityEngine;
using POW.Creators;
using POW.Settings.Platform;
using POW.BroadcastingChannels.GameStateChannels;
using POW.BroadcastingChannels.MatchChannel;
using POW.BroadcastingChannels.CubePlatformChannel;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private CubePlatformSettings _platformSettings;

    [Header("Broadcasting On")]
    [SerializeField] private GameStateChangedChannel _stateChangedChannel;
    [SerializeField] private PlatformCreatedChannel _platformCreatedChannel;

    [Header("Listening To")]
    [SerializeField] private CubeReserveStartedChannel _cubeReserveStartedChannel;
    [SerializeField] private InitializationEndChannel _initializationEndChannel;
    [SerializeField] private MatchFailedChannel _matchFailedChannel;
    [SerializeField] private MatchAnimEndChannel _animEndChannel;

    private GameState _currentState;
    private CubePlatformCreator _creator;

    private void Start()
    {
        _creator = new CubePlatformCreator();
        _creator.CreateCubePlatform(_platformSettings.CubePlatformSize, _platformCreatedChannel.OnCubePlatformCreated);

        _currentState = GameState.Initialization;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
    }

    private void OnEnable()
    {
        _cubeReserveStartedChannel.OnStartedCubeReserve += OnCubeReserveStarted;
        _initializationEndChannel.OnInitializationEnd += OnInitializationEnd;
        _matchFailedChannel.OnMatchFailed += OnMatchFailed;
        _animEndChannel.OnMatchAnimEnded += OnMatchAnimEnded;
    }

    private void OnDisable()
    {
        _cubeReserveStartedChannel.OnStartedCubeReserve -= OnCubeReserveStarted;
        _initializationEndChannel.OnInitializationEnd -= OnInitializationEnd;
        _matchFailedChannel.OnMatchFailed -= OnMatchFailed;
        _animEndChannel.OnMatchAnimEnded -= OnMatchAnimEnded;
    }

    private void OnCubeReserveStarted()
    {
        _currentState = GameState.MatchCheck;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
    }

    private void OnInitializationEnd()
    {
        _currentState = GameState.Gameplay;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
    }

    private void OnMatchFailed()
    {
        _currentState = GameState.Gameplay;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
    }

    private void OnMatchAnimEnded()
    {
        if(References.Instance.CubePlatformData.Size <= 0)
        {
            OnPlatformEmptied();
            return;
        }

        _currentState = GameState.Gameplay;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
    }

    private void OnPlatformEmptied()
    {
        _currentState = GameState.PlatformRecreation;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
        _creator.RecreateCubePlatform(_platformSettings.CubePlatformSize, _platformCreatedChannel.OnCubePlatformCreated);
    }
}