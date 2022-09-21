using System.Collections.Generic;
using POW.Cubes;
using UnityEngine;

namespace POW.Gameplay.MatchingArea
{
    public class ReservedCubes
    {
        private readonly List<CubeMono> _reservedCubes;

        public int Size { get; private set; }

        public Quaternion CommonLocalRotation
        {
            get
            {
                if(Size <= 0) return Quaternion.identity;

                return _reservedCubes[0].transform.localRotation;
            }
        }

        public ReservedCubes()
        {
            Size = 0;
            _reservedCubes = new List<CubeMono>();
        }

        public void ReserveNewCube(CubeMono cube)
        {
            Size++;
            _reservedCubes.Add(cube);
        }

        public CubeMono UnreserveCube()
        {
            CubeMono cube = _reservedCubes[Size - 1];

            _reservedCubes.RemoveAt(Size - 1);

            Size--;

            return cube;
        }
    }
}