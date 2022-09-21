using POW.Datas;
using UnityEngine;

namespace POW.Creators
{
    public class CubeCreator
    {
        public void CreateCube(CubeDataContainer cubeContainer)
        {
            Vector3 pos = new Vector3(cubeContainer.X, cubeContainer.Y, cubeContainer.Z);

            Object.Instantiate(References.Instance.CubePref, pos, Quaternion.identity);
        }
    }
}