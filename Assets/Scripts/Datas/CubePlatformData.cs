using POW.Cubes;
using UnityEngine;

namespace POW.Datas
{
    public class CubePlatformData
    {
        private readonly CubeMono[,,] _cubes;

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
            _cubes = new CubeMono[x, y, z];
            Width = x;
            Height = y;
            Length = z;
        }

        public void RemoveCube(CubeMono cube)
        {
            Size--;
            _cubes[cube.Coordinates.x, cube.Coordinates.y, cube.Coordinates.z] = null;
        }

        public void AddCube(CubeMono cube)
        {
            Size++;
            _cubes[cube.Coordinates.x, cube.Coordinates.y, cube.Coordinates.z] = cube;
        }

        public CubeMono GetCube(int x, int y, int z)
        {
            return _cubes[x, y, z];
        }

        public CubeMono GetCubeBySameType(CubeType type)
        {
            CubeMono mono = null;

            for(int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    for (int k = 0; k < Length; k++)
                    {
                        if(_cubes[i, j, k] != null && _cubes[i, j, k].Type == type)
                        {
                            mono = _cubes[i, j, k];
                            return mono;
                        }
                    }
                }
            }

            return null;
        }

        public Vector3 GetCubeWorldPos(Vector3Int coords)
        {
            return new Vector3(coords.x, coords.y, coords.z);
        }

        public CubeMono[] GetMatchedCubes()
        {
            CubeMono[] matchedCubes = new CubeMono[3];
            CubeType type = GetRandomTypeFromPlatform();
            int index = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    for (int k = 0; k < Length; k++)
                    {
                        if (_cubes[i, j, k] != null && _cubes[i, j, k].Type == type)
                        {
                            matchedCubes[index] = _cubes[i, j, k];
                            index++;
                            if (index >= 3) return matchedCubes;
                        }
                    }
                }
            }

            return null;
        }

        private CubeType GetRandomTypeFromPlatform()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    for (int k = 0; k < Length; k++)
                    {
                        if (_cubes[i, j, k] != null)
                        {
                            return _cubes[i, j, k].Type;
                        }
                    }
                }
            }

            return default;
        }
    }
}