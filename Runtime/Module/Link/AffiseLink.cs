#nullable enable
using AffiseAttributionLib.Modules;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
using AffiseAttributionLib.Native;
#endif

namespace AffiseAttributionLib.Module.Link
{
    internal class AffiseLink : AffiseModuleApiWrapper<IAffiseLinkApi>, IAffiseLinkApi
    {
        protected override AffiseModules Module => AffiseModules.Link;

        public void Resolve(string uri, AffiseLinkCallback callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.LinkResolve(uri, callback);
#else
            ModuleApi?.Resolve(uri, callback);
#endif
        }
    }
}