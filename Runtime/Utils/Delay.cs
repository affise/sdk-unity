using System;
using AffiseAttributionLib.Coroutine;

namespace AffiseAttributionLib.Utils
{
    internal static class Delay
    {
        public static void Run(long delay, Action action)
        {
            AffiseWorker.DelayRun(delay, action);
        }
    }
}