#nullable enable
using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.Link
{
    public interface IAffiseLinkApi : IAffiseModuleApi
    {
        void LinkResolve(string uri, AffiseLinkCallback callback);
    }
}