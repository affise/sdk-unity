#nullable enable

namespace AffiseAttributionLib.Module.Link.UseCase
{
    internal interface ILinkResolveUseCase
    {
        void LinkResolve(string url, AffiseLinkCallback callback);
    }
}