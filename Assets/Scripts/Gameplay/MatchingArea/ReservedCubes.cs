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

        private readonly MatchArea _matchArea;

        private int _dirtyIndex;

        public ReservedCubes(MatchArea area)
        {
            _matchArea = area;
            Size = 0;
            _reservedCubes = new List<CubeMono>();
        }

        private int GetCubeIndex(CubeMono cube)
        {
            for (int i = 0; i < Size; i++)
            {
                if (_reservedCubes[i].Type == cube.Type)
                {
                    return i;
                }
            }

            return 0;
        }

        public void ReserveNewCube(CubeMono cube)
        {
            Size++;
            _reservedCubes.Add(cube);
        }

        public void ReserveNewCube(CubeMono cube, int index)
        {
            _reservedCubes[index] = cube;
        }

        public void ExpandListFromThis(CubeMono cube)
        {
            int startIndex = GetCubeIndex(cube);

            Size++;
            _reservedCubes.Add(null);

            for(int i = Size - 1; i > startIndex + 1; i--)
            {
                _reservedCubes[i] = _reservedCubes[i - 1];
                _reservedCubes[i].SetPositionInReserve(_matchArea.GetCubePositionInReserve(i));
            }
        }

        public void RemoveCubes(CubeMono[] cubes)
        {
            int startIndex = GetCubeIndex(cubes[0]);

            foreach(CubeMono c in cubes)
            {
                _reservedCubes.Remove(c);
                Size--;
            }

            _dirtyIndex = startIndex;
        }

        public void Reorder()
        {
            if (_dirtyIndex >= Size) return;
            if (_dirtyIndex < 0) return;

            while (_dirtyIndex < Size)
            {
                _reservedCubes[_dirtyIndex].SetPositionInReserve(_matchArea.GetCubePositionInReserve(_dirtyIndex));

                _dirtyIndex++;
            }

            _dirtyIndex = -1;
        }

        public CubeMono UnreserveCube()
        {
            CubeMono cube = _reservedCubes[Size - 1];

            _reservedCubes.RemoveAt(Size - 1);

            Size--;

            return cube;
        }

        public CubeMono GetCubeReadyToMatch()
        {
            CubeMono cube = null;

            for (int i = 0; i < Size - 1; i++)
            {
                if (_reservedCubes[i].Type == _reservedCubes[i + 1].Type)
                {
                    cube = _reservedCubes[i];
                    return cube;
                }
            }

            return null;
        }

        public bool ContainsSameCube(CubeMono cubeToMatch)
        {
            bool contains = false;

            for(int i = 0; i < Size; i++)
            {
                if(_reservedCubes[i].Type == cubeToMatch.Type)
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public int GetTargetIndexForNewCube(CubeMono cube)
        {
            if (!ContainsSameCube(cube))
            {
                return Size;
            }

            return GetCubeIndex(cube) + 1;
        }

        public CubeMono[] GetMatchedCubes()
        {
            CubeMono[] matchedCubes = null;

            for(int i = 0; i < Size - 2; i++)
            {
                if(_reservedCubes[i].IsMatchableWith(_reservedCubes[i + 1]))
                {
                    if (_reservedCubes[i + 1].IsMatchableWith(_reservedCubes[i + 2]))
                    {
                        matchedCubes = new CubeMono[3];
                        matchedCubes[0] = _reservedCubes[i];
                        matchedCubes[1] = _reservedCubes[i + 1];
                        matchedCubes[2] = _reservedCubes[i + 2];
                        return matchedCubes;
                    }
                }
            }

            return null;
        }
    }
}