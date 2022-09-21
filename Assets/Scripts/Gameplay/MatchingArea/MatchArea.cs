using UnityEngine;
using POW.Cubes;

namespace POW.Gameplay.MatchingArea
{
    public class MatchArea
    {
        public readonly ReservedCubes ReservedCubes;

        private readonly MatchAreaMono _areaMono;

        public MatchArea(MatchAreaMono areaMono)
        {
            ReservedCubes = new ReservedCubes(this);

            _areaMono = areaMono;
        }

        public void ReserveCube(CubeMono cube)
        {
            int targetIndexInList = ReservedCubes.GetTargetIndexForNewCube(cube);
            Vector3 targetPos = _areaMono.CubeStartPosition + new Vector3(_areaMono.DistanceBtwCubes * targetIndexInList, 0, 0);
            Quaternion rot = ReservedCubes.CommonLocalRotation;

            if (ReservedCubes.ContainsSameCube(cube))
            {
                ReservedCubes.ExpandListFromThis(cube, _areaMono.DistanceBtwCubes);
                ReservedCubes.ReserveNewCube(cube, targetIndexInList);
                cube.GoToMatchArea(_areaMono.ReserveHolder, targetPos, rot, _areaMono.CubeScale);

                return;
            }

            ReservedCubes.ReserveNewCube(cube);
            cube.GoToMatchArea(_areaMono.ReserveHolder, targetPos, rot, _areaMono.CubeScale);
        }

        public void UnreserveCube()
        {
            if (ReservedCubes.Size <= 0) return;

            ReservedCubes.UnreserveCube().GetBackToPlatform();
        }

        public Vector3 GetCubePositionInReserve(int index)
        {
            return _areaMono.CubeStartPosition + new Vector3(_areaMono.DistanceBtwCubes * index, 0, 0);
        }
    }
}