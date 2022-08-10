using System;
using System.Collections;
using UnityEngine;

namespace AffiseAttributionLib.Executors
{
    internal class ExecutorServiceProviderImpl : IExecutorServiceProvider
    {
        public void Execute(IEnumerator execute)
        {
            AffiseWorker.Work(execute);
        }

        public void ExecuteWithDelay(Action action, float delay)
        {
            AffiseWorker.Work(ActionWithDelay(action, delay));
        }
        
        private IEnumerator ActionWithDelay(Action execute, float delay = 0f)
        {
            yield return new WaitForSeconds(delay);
            execute.Invoke();
        }
    }
}