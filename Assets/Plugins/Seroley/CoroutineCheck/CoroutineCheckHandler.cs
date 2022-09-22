using UnityEngine;

namespace Seroley.CoroutineCheck
{
    public static class CoroutineCheckHandler
    {
        private static CoroutineCheckObject _coroutineObject;

        private static void Init()
        {
            GameObject delayer = new GameObject();
            delayer.name = "CoroutineCheckObject";
            delayer.AddComponent(typeof(CoroutineCheckObject));
            Object.DontDestroyOnLoad(delayer);

            _coroutineObject = delayer.GetComponent<CoroutineCheckObject>();
        }

        public static void StartBooleanCheck(CoroutineBoolCheck check)
        {
            if (!_coroutineObject) Init();

            _coroutineObject.StartBooleanCheck(check);
        }
    }
}