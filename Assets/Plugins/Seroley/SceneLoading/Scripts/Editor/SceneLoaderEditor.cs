using UnityEngine;
using UnityEditor;

namespace Seroley.SceneLoading
{
    public class SceneLoaderEditor : Editor
    {
        [MenuItem("Seroley/SceneLoading/Create Scene Loader Object")]
        static void CreateSceneLoaderObject()
        {
            if (SceneLoader.Instance) return;

            Object loader = AssetDatabase.LoadAssetAtPath<Object>("Assets/ThirdParty/Seroley/SceneLoading/Resources/SceneLoader.prefab");

            Object obj = PrefabUtility.InstantiatePrefab(loader, null);
        }
    }
}