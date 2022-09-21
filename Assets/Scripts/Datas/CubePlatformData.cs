using POW.Cubes;
using UnityEngine;

namespace POW.Datas
{
    public class CubePlatformData
    {
        private readonly CubeMono[,,] _cubes;

        public Transform PlatformHolder;

        public CubePlatformData(int x, int y, int z)
        {
            _cubes = new CubeMono[x, y, z];
        }

        public void UpdateCube(int x, int y, int z, CubeMono cube)
        {
            _cubes[x, y, z] = cube;
        }

        public CubeMono GetCube(int x, int y, int z)
        {
            return _cubes[x, y, z];
        }

        public Vector3 GetCubeWorldPos(Vector3Int coords)
        {
            return new Vector3(coords.x, coords.y, coords.z);
        }
    }
}