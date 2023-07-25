using System;
using System.Collections;

namespace AffiseAttributionLib.Executors
{
    public interface IExecutorServiceProvider
    {
        void Execute(IEnumerator execute);

        void ExecuteWithDelay(long delay, Action action);
    }
}