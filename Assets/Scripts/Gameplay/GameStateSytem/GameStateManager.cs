using UnityEngine;
using POW.BroadcastingChannels.GameStateChannels;
using POW.BroadcastingChannels.MatchChannel;

public class GameStateManager : MonoBehaviour
{
    [Header("Broadcasting On")]
    [SerializeField] private GameStateChangedChannel _stateChangedChannel;

    [Header("Listening To")]
    [SerializeField] private CubeReserveStartedChannel _cubeReserveStartedChannel;
    [SerializeField] private InitializationEndChannel _initializationEndChannel;
    [SerializeField] private MatchFailedChannel _matchFailedChannel;
    [SerializeField] private MatchAnimEndChannel _animEndChannel;

    private GameState _currentState;

    private void Start()
    {
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
        _currentState = GameState.Gameplay;
        _stateChangedChannel.OnGameStateChanged?.Invoke(_currentState);
    }
}