using System;

namespace Seroley.CoroutineCheck
{
    public class CoroutineBoolCheck
    {
        public delegate bool CheckDelegate();

        public readonly CheckDelegate CheckAction;
        public readonly Action CheckTrueAction;

        public CoroutineBoolCheck(CheckDelegate checkDelegate, Action trueAction)
        {
            CheckAction = checkDelegate;
            CheckTrueAction = trueAction;

            CoroutineCheckHandler.StartBooleanCheck(this);
        }
    }
}