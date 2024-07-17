#nullable enable
using System;
using AffiseAttributionLib.Utils;
using UnityEngine;

namespace AffiseAttributionLib.Deeplink
{
    internal class DeeplinkManagerImpl : IDeeplinkManager
    {
        private readonly IDeeplinkClickRepository _deeplinkClickRepository;
        private readonly IActivityActionsManager _activityActionsManager;
        
        /**
         * Callback that is going to be triggered when deeplink is received by application
         */
        private DeeplinkCallback? _deeplinkCallback;
        
        /**
         * Listener for resume activities
         */
        private Action<string>? _onDeepLinkActivated;

        public DeeplinkManagerImpl(
            IDeeplinkClickRepository deeplinkClickRepository,
            IActivityActionsManager activityActionsManager
        )
        {
            _deeplinkClickRepository = deeplinkClickRepository;
            _activityActionsManager = activityActionsManager;
        }

        public void Init()
        {
            if (_onDeepLinkActivated is not null) return;
            
            _onDeepLinkActivated = (uri) =>
            {
                HandleDeeplink(new Uri(uri));
            };
            
            _activityActionsManager.OnDeepLinkActivated += _onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                _onDeepLinkActivated(Application.absoluteURL);
            }
        }

        public void SetDeeplinkCallback(DeeplinkCallback callback)
        {
            _deeplinkCallback = callback;
        }

        public void HandleDeeplink(Uri uri)
        {
            _deeplinkClickRepository.SetDeeplinkClick(true);
            _deeplinkClickRepository.SetDeeplink(uri.ToString());
            _deeplinkCallback?.Invoke(uri.ToDeeplinkValue());
        }
    }
}