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
        protected AffiseComponent? _api => Affise._api;
#endif

        protected abstract AffiseModules Module { get; }

        private API? _moduleApi;

        protected API? ModuleApi
        {
            get
            {
                if (_moduleApi is not null) return _moduleApi;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
#else
                if (_api?.ModuleManager is null) return _moduleApi;
                _moduleApi = _api.ModuleManager.Api<API>(Module);
#endif
                return _moduleApi;
            }
        }

        protected bool IsModuleInit
        {
            get
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                return _native?.GetModules().Contains(Module) ?? false;
#else
                return _api?.ModuleManager.HasModule(Module) ?? false;
#endif
            }
        }
    }
}