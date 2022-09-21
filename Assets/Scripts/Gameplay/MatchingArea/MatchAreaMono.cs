using System;
using UnityEngine;
using POW.BroadcastingChannels.InteractionChannel;
using POW.Cubes;

namespace POW.Gameplay.MatchingArea
{
    public class MatchAreaMono : MonoBehaviour
    {
        [SerializeField] private int _maxCubeSize;
        [SerializeField] private Vector3 _cubeStartPosition;
        [SerializeField] private float _distanceBtwCubes;
        [SerializeField] private float _cubeScale;
        [SerializeField] private Transform _reserveHolder;

        [Header("Listening To")]
        [SerializeField] private CubeReserveChannel _cubeReserveChannel;

        private ReservedCubes _reservedCubes;

        private Vector3 _nextCubePos;

        private void Awake()
        {
            _reservedCubes = new ReservedCubes();
            _nextCubePos = _cubeStartPosition;
        }

        private void OnEnable()
        {
            _cubeReserveChannel.OnCubeReserveDemanded += TryReservingCube;
        }

        private void OnDisable()
        {
            _cubeReserveChannel.OnCubeReserveDemanded -= TryReservingCube;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnreserveCube();
            }
        }

        private void TryReservingCube(CubeMono cube, Action onReservingSuccessed)
        {
            if (_reservedCubes.Size >= _maxCubeSize) return;

            ReserveCube(cube);
            
            onReservingSuccessed?.Invoke();
        }

        private void UnreserveCube()
        {
            if (_reservedCubes.Size <= 0) return;

            _reservedCubes.UnreserveCube().GetBackToPlatform();

            _nextCubePos.x -= _distanceBtwCubes;
        }

        private void ReserveCube(CubeMono cube)
        {
            Quaternion rot = _reservedCubes.CommonLocalRotation;

            _reservedCubes.ReserveNewCube(cube);

            cube.transform.SetParent(_reserveHolder);
            cube.transform.localPosition = _nextCubePos;
            cube.transform.localRotation = rot;
            cube.transform.localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);

            _nextCubePos.x += _distanceBtwCubes;
        }
    }
}