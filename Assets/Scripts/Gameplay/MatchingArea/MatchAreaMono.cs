using System.Collections;
using UnityEngine;
using POW.BroadcastingChannels.InteractionChannel;
using POW.BroadcastingChannels.MatchChannel;
using POW.BroadcastingChannels.AbilityChannels;
using POW.Gameplay.AbilitySystem;
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
        [SerializeField] private AbilitiesSettledChannel _abilitiesSettledChannel;

        [Header("Broadcasting On")]
        [SerializeField] private CubeReserveChannel _cubeReserveChannel;
        [SerializeField] private CubeReserveStartedChannel _cubeReserveStartedChannel;

        [Header("Ability Actions")]
        [SerializeField] private AbilityAction _undoAbilityAction;
        [SerializeField] private AbilityAction _hintAbilityAction;

        private MatchArea _matchArea;

        private void Awake()
        {
            _matchArea = new MatchArea(this);
        }

        private void OnEnable()
        {
            _cubeReserveDemandChannel.OnCubeReserveDemanded += TryReservingCube;
            _matchAnimEndChannel.OnMatchAnimEnded += ReorderReservedCubes;
            _abilitiesSettledChannel.OnAbilitiesSettled += SetProperAbilities;
        }

        private void OnDisable()
        {
            _cubeReserveDemandChannel.OnCubeReserveDemanded -= TryReservingCube;
            _matchAnimEndChannel.OnMatchAnimEnded -= ReorderReservedCubes;
            _abilitiesSettledChannel.OnAbilitiesSettled -= SetProperAbilities;
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

        private void UndoAbilityAction(System.Action callback)
        {
            if (_matchArea.ReservedCubes.Size == 0) return;

            callback?.Invoke();
            UnreserveCube();
        }

        private void HintAbilityAction(System.Action callback)
        {
            StartCoroutine(HintAbility());

            callback?.Invoke();
        }

        private IEnumerator HintAbility()
        {
            CubeMono readyToMatch = _matchArea.ReservedCubes.GetCubeReadyToMatch();

            if (readyToMatch != null)
            {
                TryReservingCube(References.Instance.CubePlatformData.GetCubeBySameType(readyToMatch.Type));

                yield break;
            }


            CubeMono[] cubes = References.Instance.CubePlatformData.GetMatchedCubes();
            int index = -1;
            float timer = 1.0f;

            while (index < 2)
            {
                timer += Time.deltaTime;
                if(timer >= 0.3f)
                {
                    timer = 0.0f;
                    index++;
                    TryReservingCube(cubes[index]);
                }

                yield return null;
            }
        }

        private void SetProperAbilities()
        {
            _undoAbilityAction.AbilityFunction = UndoAbilityAction;
            _hintAbilityAction.AbilityFunction = HintAbilityAction;
        }
    }
}