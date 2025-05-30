#nullable enable
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
using AffiseAttributionLib.Native;
#endif

namespace AffiseAttributionLib.Modules
{
    internal abstract class AffiseModuleApiWrapper<API> where API : IAffiseModuleApi
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        protected IAffiseNative? _native => Affise._native;
#else
        protected AffiseModuleManager? ModuleManager => Affise._api?.ModuleManager;
#endif
        
        protected abstract AffiseModules Module { get; }
        
        private API? _api;
        protected API? ModuleApi
        {
            get
            {
                if (_api is not null) return _api;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
#else
                if (ModuleManager is null) return _api;
                _api = ModuleManager.Api<API>(Module);
#endif
                return _api;
            }
        }
    }
}