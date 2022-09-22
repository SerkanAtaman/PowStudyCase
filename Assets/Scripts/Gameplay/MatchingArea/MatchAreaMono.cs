using UnityEngine;
using POW.BroadcastingChannels.InteractionChannel;
using POW.BroadcastingChannels.MatchChannel;
using POW.Cubes;

namespace POW.Gameplay.MatchingArea
{
    public class MatchAreaMono : MonoBehaviour
    {
        [field: SerializeField] public int MaxCubeSize { get; private set; }
        [field: SerializeField] public Vector3 CubeStartPosition { get; private set; }
        [field: SerializeField] public float DistanceBtwCubes { get; private set; }
        [field: SerializeField] public Vector3 CubeScale { get; private set; }
        [field: SerializeField] public Transform ReserveHolder { get; private set; }

        [Header("Listening To")]
        [SerializeField] private CubeReserveDemandChannel _cubeReserveDemandChannel;
        [SerializeField] private MatchAnimEndChannel _matchAnimEndChannel;

        [Header("Broadcasting On")]
        [SerializeField] private CubeReserveChannel _cubeReserveChannel;
        [SerializeField] private CubeReserveStartedChannel _cubeReserveStartedChannel;

        private MatchArea _matchArea;

        private void Awake()
        {
            _matchArea = new MatchArea(this);
        }

        private void OnEnable()
        {
            _cubeReserveDemandChannel.OnCubeReserveDemanded += TryReservingCube;
            _matchAnimEndChannel.OnMatchAnimEnded += ReorderReservedCubes;
        }

        private void OnDisable()
        {
            _cubeReserveDemandChannel.OnCubeReserveDemanded -= TryReservingCube;
            _matchAnimEndChannel.OnMatchAnimEnded -= ReorderReservedCubes;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnreserveCube();
            }
        }

        private void ReorderReservedCubes()
        {
            _matchArea.ReservedCubes.Reorder();
        }

        private void TryReservingCube(CubeMono cube)
        {
            if (_matchArea.ReservedCubes.Size >= MaxCubeSize) return;

            _cubeReserveStartedChannel.OnStartedCubeReserve?.Invoke();
            _matchArea.ReserveCube(cube, () => _cubeReserveChannel.OnCubeReserved?.Invoke(_matchArea.ReservedCubes));
        }

        private void UnreserveCube()
        {
            _matchArea.UnreserveCube(null);
        }
    }
}