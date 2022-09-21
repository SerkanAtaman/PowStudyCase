using POW.Datas;
using UnityEngine;

namespace POW.Creators
{
    public class CubePlatformCreator
    {
        private CubeDataContainer[,,] _cubeDataContainer;
        private CubeCreator _cubeCreator;
        
        private readonly int _width = 3;
        private readonly int _height = 5;
        private readonly int _length = 4;

        public void CreateCubePlatform()
        {
            _cubeDataContainer = new CubeDataContainer[_width, _height, _length];
            _cubeCreator = new CubeCreator();

            GameObject holder = new GameObject("CubePlatform");
            holder.transform.position = new Vector3(_width * 0.5f - 0.5f, _height * 0.5f - 0.5f, _length * 0.5f - 0.5f);

            SetContainers();

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        _cubeCreator.CreateCube(_cubeDataContainer[i, j, k], holder.transform);
                    }
                }
            }

            References.Instance.PlatformCreatedChannel.OnCubePlatformCreated?.Invoke(holder.transform);
        }

        private void SetContainers()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        _cubeDataContainer[i, j, k] = new CubeDataContainer(i, j, k, Cubes.CubeType.Default);
                    }
                }
            }
        }
    }
}