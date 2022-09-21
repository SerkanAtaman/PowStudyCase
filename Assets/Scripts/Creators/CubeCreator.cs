using POW.Helpers;
using POW.Cubes;
using UnityEngine;
using POW.Utilities.Collections;

namespace POW.Creators
{
    public class CubeCreator
    {
        private readonly int _totalCubesToCreate;

        private readonly Vector3Int[] _coordsToSkip;

        private readonly CustomDictionary<int, int> _usableCubeTypes = new CustomDictionary<int, int>();

        public CubeCreator(int width, int height, int length)
        {
            _totalCubesToCreate = width * height * length;
            
            _coordsToSkip = new Vector3Int[_totalCubesToCreate % 3];
            for(int i = 0; i < _coordsToSkip.Length; i++)
            {
                _coordsToSkip[i] = new Vector3Int(Random.Range(0, width), Random.Range(0, height), Random.Range(0, length));
            }

            int totalTypes = (_totalCubesToCreate - _totalCubesToCreate % 3) / 3;

            while(totalTypes > 0)
            {
                int randType = (int)CubeHelper.GetRandomCubeType();

                if (_usableCubeTypes.ContainsKey(randType))
                {
                    int value = _usableCubeTypes.GetValue(randType);
                    value += 3;
                    _usableCubeTypes.UpdateValue(randType, value);
                }
                else
                {
                    _usableCubeTypes.Add(randType, 3);
                }
                totalTypes--;
            }
        }

        public void CreateCube(Vector3Int coords, Transform holder)
        {
            if (IsCubePosSkippable(coords)) return;

            Vector3 pos = new Vector3(coords.x, coords.y, coords.z);

            GameObject cube = Object.Instantiate(References.Instance.CubePref, pos, Quaternion.identity, holder);
            cube.name = $"[{coords.x},{coords.y},{coords.z}]";

            CubeMono mono = cube.GetComponent<CubeMono>();

            mono.Init(GetRandomTypeFromDict(), new Vector3Int(coords.x, coords.y, coords.z));
            References.Instance.CubePlatformData.UpdateCube(coords.x, coords.y, coords.z, mono);
        }

        private bool IsCubePosSkippable(Vector3Int coords)
        {
            for(int i = 0; i < _coordsToSkip.Length; i++)
            {
                if(_coordsToSkip[i] == coords)
                {
                    return true;
                }
            }

            return false;
        }

        private CubeType GetRandomTypeFromDict()
        {
            int randKey = _usableCubeTypes.GetRandomKey();
            int value = _usableCubeTypes.GetValue(randKey);
            value--;
            _usableCubeTypes.UpdateValue(randKey, value);
            if(value <= 0) _usableCubeTypes.Remove(randKey);

            return (CubeType)randKey;
        }
    }
}