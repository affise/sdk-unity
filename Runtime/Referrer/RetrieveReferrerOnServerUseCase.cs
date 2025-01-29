#nullable enable
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Referrer
{
    internal class RetrieveReferrerOnServerUseCase
    {
        private readonly AffiseModuleManager _moduleManager;
        private ReferrerCallback? _referrerCallback;

        public RetrieveReferrerOnServerUseCase(AffiseModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        private ReferrerCallback? GetReferrerModule()
        {
            if (_referrerCallback is not null) return _referrerCallback;
            var module = _moduleManager.GetModule(AffiseModules.Status);
            _referrerCallback = module as ReferrerCallback;
            return _referrerCallback;
        }

        private void HandleReferrerOnServer(OnReferrerCallback callback)
        {
            var referrerModule = GetReferrerModule();
            if ( referrerModule is not null)
            {
                referrerModule.GetReferrer(callback);
            }
            else
            {
                callback.Invoke(null);
            }
        }

        public void GetReferrerOnServer(OnReferrerCallback callback)
        {
            HandleReferrerOnServer((referrer) =>
            {
                callback.Invoke(referrer);
            });
        }

        public void GetReferrerOnServerValue(ReferrerKey key, OnReferrerCallback callback)
        {
            HandleReferrerOnServer((referrer) =>
            {
                callback.Invoke(referrer.GetReferrerValue(key));
            });
        }
    }
}