using POW.Datas;
using UnityEngine;

namespace POW.Creators
{
    public class CubePlatformCreator
    {
        private CubeCreator _cubeCreator;
        
        public void CreateCubePlatform(Vector3Int platformSize, System.Action callback)
        {
            _cubeCreator = new CubeCreator(platformSize.x, platformSize.y, platformSize.z);
            References.Instance.CubePlatformData = new CubePlatformData(platformSize.x, platformSize.y, platformSize.z);

            GameObject holder = new GameObject("CubePlatform");
            holder.transform.position = new Vector3(platformSize.x * 0.5f - 0.5f, platformSize.y * 0.5f - 0.5f, platformSize.z * 0.5f - 0.5f);

            for (int i = 0; i < platformSize.x; i++)
            {
                for (int j = 0; j < platformSize.y; j++)
                {
                    for (int k = 0; k < platformSize.z; k++)
                    {
                        _cubeCreator.CreateCube(new Vector3Int(i, j, k), holder.transform);
                    }
                }
            }

            References.Instance.CubePlatformData.PlatformHolder = holder.transform;
            callback?.Invoke();
        }

        public void RecreateCubePlatform(Vector3Int platformSize, System.Action callback)
        {
            _cubeCreator = new CubeCreator(platformSize.x, platformSize.y, platformSize.z);

            GameObject holder = References.Instance.CubePlatformData.PlatformHolder.gameObject;
            holder.transform.position = new Vector3(platformSize.x * 0.5f - 0.5f, platformSize.y * 0.5f - 0.5f, platformSize.z * 0.5f - 0.5f);

            References.Instance.CubePlatformData = new CubePlatformData(platformSize.x, platformSize.y, platformSize.z);

            for (int i = 0; i < platformSize.x; i++)
            {
                for (int j = 0; j < platformSize.y; j++)
                {
                    for (int k = 0; k < platformSize.z; k++)
                    {
                        _cubeCreator.CreateCube(new Vector3Int(i, j, k), holder.transform);
                    }
                }
            }

            References.Instance.CubePlatformData.PlatformHolder = holder.transform;
            callback?.Invoke();
        }
    }
}