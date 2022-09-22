using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace Seroley.ObjectPooling
{
    public class ObjectPoolWindow : EditorWindow
    {/*
        private static ObjectPoolWindowPool[] _createdPools;

        AnimBool _showPoolsAnim;

        [MenuItem("Seroley/ObjectPooling/ObjectPoolWindow")]
        static void Init()
        {
            ObjectPoolWindow window = (ObjectPoolWindow)GetWindow(typeof(ObjectPoolWindow));
            window.maximized = false;
            window.titleContent.text = "ObjectPoolEditor";
            window.Show();
        }

        void OnEnable()
        {
            if (_createdPools == null) _createdPools = new ObjectPoolWindowPool[0];

            _showPoolsAnim = new AnimBool();
            _showPoolsAnim.valueChanged.AddListener(Repaint);
        }

        public static void AddPool(string poolName, Object objectPrefab, string bundlePath, int startSize, PoolObjectType poolType)
        {
            ObjectPoolWindowPool newPool = new ObjectPoolWindowPool(poolName, (GameObject)objectPrefab, bundlePath, startSize, poolType);

            if (newPool.PoolObjectPrefab == null)
            {
                Debug.LogError("The prefab of PoolObject can not be null");
                return;
            }

            ObjectPoolWindowPool[] cloneArray = new ObjectPoolWindowPool[_createdPools.Length + 1];

            int count = _createdPools.Length;

            for (int i = 0; i < count; i++)
            {
                cloneArray[i] = _createdPools[i];
            }

            cloneArray[count] = newPool;

            _createdPools = cloneArray;

            Debug.Log("Created " + cloneArray[count].PoolName);
        }

        private void OnGUI()
        {
            _showPoolsAnim.target = EditorGUILayout.Toggle("Show Created Pools", _showPoolsAnim.target);

            if (EditorGUILayout.BeginFadeGroup(_showPoolsAnim.faded))
            {
                EditorGUI.indentLevel++;
                foreach(ObjectPoolWindowPool pool in _createdPools)
                {
                    EditorGUILayout.LabelField(pool.PoolName);
                }
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndFadeGroup();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("Create new pool"))
            {
                PoolCreatorWindow.Init();
            }
            if (GUILayout.Button("Delete Pools"))
            {
                _createdPools = new ObjectPoolWindowPool[0];
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    public class ObjectPoolWindowPool
    {
        public string PoolName { get; private set; }
        public GameObject PoolObjectPrefab { get; private set; }
        public string PoolObjectPrefabBundlePath { get; private set; }
        public int PoolStartSize { get; private set; }
        public PoolObjectType PoolType { get; private set; }

        public ObjectPoolWindowPool(string poolName, GameObject objectPrefab, string prefabBundlePath, int startSize, PoolObjectType poolType)
        {
            PoolName = poolName;
            PoolObjectPrefab = objectPrefab;
            PoolStartSize = startSize;
            PoolType = poolType;
            PoolObjectPrefabBundlePath = prefabBundlePath;
        }*/
    }
}