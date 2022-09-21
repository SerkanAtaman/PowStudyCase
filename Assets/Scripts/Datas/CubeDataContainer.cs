using POW.Cubes;

namespace POW.Datas
{
    public class CubeDataContainer
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public CubeType Type { get; private set; }

        public CubeDataContainer(int x, int y, int z, CubeType type)
        {
            X = x;
            Y = y;
            Z = z;
            Type = type;
        }
    }
}