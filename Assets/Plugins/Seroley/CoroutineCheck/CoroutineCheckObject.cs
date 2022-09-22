using System.Collections;
using UnityEngine;

namespace Seroley.CoroutineCheck
{
    public class CoroutineCheckObject : MonoBehaviour
    {
        public void StartBooleanCheck(CoroutineBoolCheck check)
        {
            StartCoroutine(BooleanCheck(check));
        }

        private IEnumerator BooleanCheck(CoroutineBoolCheck check)
        {
            while (!check.CheckAction())
            {
                yield return null;
            }

            check.CheckTrueAction?.Invoke();
        }
    }
}