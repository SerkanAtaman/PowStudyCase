using POW.Datas;
using POW.Cubes;
using UnityEngine;

namespace POW.Creators
{
    public class CubeCreator
    {
        public void CreateCube(int x, int y, int z, Transform holder)
        {
            Vector3 pos = new Vector3(x, y, z);

            GameObject cube = Object.Instantiate(References.Instance.CubePref, pos, Quaternion.identity, holder);
            cube.name = $"[{x},{y},{z}]";

            CubeMono mono = cube.GetComponent<CubeMono>();

            mono.Init(CubeType.Default, new Vector3Int(x, y, z));
            References.Instance.CubePlatformData.UpdateCube(x, y, z, mono);
        }
    }
}