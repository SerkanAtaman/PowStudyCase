using POW.Datas;

namespace POW.Creators
{
    public class CubePlatformCreator
    {
        private CubeDataContainer[,,] _cubeDataContainer;
        private CubeCreator _cubeCreator;
        
        private int _width = 3;
        private int _height = 5;
        private int _length = 4;

        public void CreateCubePlatform()
        {
            _cubeDataContainer = new CubeDataContainer[_width, _height, _length];
            _cubeCreator = new CubeCreator();

            SetContainers();

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        _cubeCreator.CreateCube(_cubeDataContainer[i, j, k]);
                    }
                }
            }
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