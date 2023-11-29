#nullable enable
using System;
using System.Threading;

namespace AffiseAttributionLib.Executors
{
    public sealed class ContextThreadExecutor
    {
        private readonly SynchronizationContext? _contextThread;
        private readonly int _contextThreadId = 0;

        public ContextThreadExecutor()
        {
            _contextThread = SynchronizationContext.Current;
            _contextThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public void Run(Action action)
        {
            if (_contextThreadId != Thread.CurrentThread.ManagedThreadId)
            {
                _contextThread?.Post(_ => action.Invoke(), null);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}