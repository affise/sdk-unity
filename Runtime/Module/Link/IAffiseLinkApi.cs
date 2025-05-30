#nullable enable
using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.Link
{
    public interface IAffiseLinkApi : IAffiseModuleApi
    {
        void Resolve(string uri, AffiseLinkCallback callback);
    }
}