using UnityEngine;
using UnityEditor;

namespace Seroley.ObjectPooling
{
    public class PoolCreatorWindow : EditorWindow
    {/*
        string _poolName;
        string _bundlePath;
        Object _poolPrefab;
        int _startSize;
        PoolObjectType _poolType;

        public static void Init()
        {
            PoolCreatorWindow window = (PoolCreatorWindow)GetWindow(typeof(PoolCreatorWindow));
            window.maximized = false;
            window.titleContent.text = "ObjectPoolCreator";
            window.Show();
        }

        private void OnEnable()
        {
            _poolName = "New ObjectPool";
            _poolPrefab = null;
            _startSize = 1;
            //_poolType = PoolDefiner.PoolObjectType.TroopExplodeFX;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Pool Name");
            _poolName = EditorGUILayout.TextArea(_poolName);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("PoolObject prefab");
            _poolPrefab = EditorGUILayout.ObjectField(_poolPrefab, typeof(Object), true);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("PoolObject Prefab Bundle Path");
            _bundlePath = EditorGUILayout.TextArea(_bundlePath);
            EditorGUILayout.EndHorizontal();

            _startSize = EditorGUILayout.IntField("Pool start size", _startSize);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Pool type");
            _poolType = (PoolObjectType)EditorGUILayout.EnumFlagsField(_poolType);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            if (GUILayout.Button("Create Pool"))
            {
                ObjectPoolWindow.AddPool(_poolName, _poolPrefab, _bundlePath, _startSize, _poolType);

                Close();
            }
        }*/
    }
}