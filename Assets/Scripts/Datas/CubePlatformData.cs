using POW.Cubes;
using UnityEngine;
using POW.Utilities.Collections;

namespace POW.Datas
{
    public class CubePlatformData
    {
        private readonly CustomDictionary<Vector3Int, CubeMono> _cubes;

        public Transform PlatformHolder;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Length { get; private set; }
        public int Size { get; private set; }

        public int MaxSize
        {
            get
            {
                int maxSize = Width;
                if(Height > maxSize) maxSize = Height;
                if(Length > maxSize) maxSize = Length;

                return maxSize;
            }
        }


        public CubePlatformData(int x, int y, int z)
        {
            _cubes = new CustomDictionary<Vector3Int, CubeMono>();
            Width = x;
            Height = y;
            Length = z;
        }

        public void RemoveCube(CubeMono cube)
        {
            Size--;
            _cubes.Remove(cube.Coordinates);
        }

        public void AddCube(CubeMono cube)
        {
            Size++;
            _cubes.Add(cube.Coordinates, cube);
        }

        public CubeMono GetCube(Vector3Int coords)
        {
            return _cubes.GetValue(coords);
        }

        public CubeMono GetCube(int index)
        {
            return _cubes.GetValueOnIndex(index);
        }

        public CubeMono GetCubeBySameType(CubeType type)
        {
            CubeMono mono;

            for(int i = 0; i < Size; i++)
            {
                if(_cubes.GetValueOnIndex(i).Type == type)
                {
                    mono = _cubes.GetValueOnIndex(i);
                    return mono;
                }
            }

            return null;
        }

        public CubeMono[] GetMatchedCubes()
        {
            CubeMono[] matchedCubes = new CubeMono[3];
            CubeType type = GetRandomTypeFromPlatform();
            int index = 0;

            for(int i = 0; i < Size; i++)
            {
                if(_cubes.GetValueOnIndex(i).Type == type)
                {
                    matchedCubes[index] = _cubes.GetValueOnIndex(i);
                    index++;
                    if (index >= 3) return matchedCubes;
                }
            }

            return null;
        }

        private CubeType GetRandomTypeFromPlatform()
        {
            return _cubes.GetValue(_cubes.GetRandomKey()).Type;
        }
    }
}