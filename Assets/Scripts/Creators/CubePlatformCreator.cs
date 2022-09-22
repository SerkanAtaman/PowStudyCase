using POW.Datas;
using UnityEngine;

namespace POW.Creators
{
    public class CubePlatformCreator
    {
        private CubeCreator _cubeCreator;
        
        private readonly int _width = 4;
        private readonly int _height = 5;
        private readonly int _length = 6;

        public void CreateCubePlatform()
        {
            _cubeCreator = new CubeCreator(_width, _height, _length);
            References.Instance.CubePlatformData = new CubePlatformData(_width, _height, _length);

            GameObject holder = new GameObject("CubePlatform");
            holder.transform.position = new Vector3(_width * 0.5f - 0.5f, _height * 0.5f - 0.5f, _length * 0.5f - 0.5f);

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        _cubeCreator.CreateCube(new Vector3Int(i, j, k), holder.transform);
                    }
                }
            }

            References.Instance.CubePlatformData.PlatformHolder = holder.transform;
            References.Instance.PlatformCreatedChannel.OnCubePlatformCreated?.Invoke(References.Instance.CubePlatformData);
        }
    }
}