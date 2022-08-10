using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib
{
    internal interface IAffiseApi
    {
        public FirstAppOpenUseCase FirstAppOpenUseCase { get; }
        public ISetPropertiesWhenAppInitializedUseCase SetPropertiesWhenInitUseCase { get; }
        public EventsManager EventsManager { get; }
        public IStoreEventUseCase StoreEventUseCase { get; }
        public IInitPropertiesStorage InitPropertiesStorage { get; }
        public IDeeplinkManager DeeplinkManager { get; }
        public InstallReferrerProvider InstallReferrerProvider { get; }
    }
}