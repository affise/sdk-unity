#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.AppsFlyer
{
    public interface IAffiseAppsFlyerApi : IAffiseModuleApi
    {
        void LogEvent<T>(string eventName, Dictionary<string, T> eventValues);
    }
}