using POW.Cubes;

namespace POW.Helpers
{
    public static class CubeHelper
    {
        public static CubeType GetRandomCubeType()
        {
            var values = System.Enum.GetValues(typeof(CubeType));

            int randInt = UnityEngine.Random.Range(0, values.Length);

            return (CubeType)randInt;
        }

        public static int GetTotalCubeTypes()
        {
            return System.Enum.GetValues(typeof(CubeType)).Length;
        }
    }
}