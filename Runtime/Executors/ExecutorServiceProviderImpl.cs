using System;
using System.Collections;
using AffiseAttributionLib.Coroutine;

namespace AffiseAttributionLib.Executors
{
    internal class ExecutorServiceProviderImpl : IExecutorServiceProvider
    {
        public void Execute(IEnumerator execute)
        {
            AffiseWorker.Run(execute);
        }

        public void ExecuteWithDelay(long delay, Action action)
        {
            AffiseWorker.DelayRun(delay, action);
        }
    }
}