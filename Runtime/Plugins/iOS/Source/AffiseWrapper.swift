import AffiseAttributionLib


internal class AffiseWrapper {

    private let AFFISE_INIT = "init"
    private let AFFISE_SEND_EVENTS = "send_events"
    private let AFFISE_SEND_EVENT = "send_event"
    private let AFFISE_ADD_PUSH_TOKEN = "add_push_token"
    private let AFFISE_REGISTER_WEB_VIEW = "register_web_view"
    private let AFFISE_UNREGISTER_WEB_VIEW = "unregister_web_view"
    private let AFFISE_REGISTER_DEEPLINK_CALLBACK = "register_Deeplink_Callback"
    private let AFFISE_SET_SECRET_ID = "set_secret_id"
    private let AFFISE_SET_AUTO_CATCHING_TYPES = "set_auto_catching_types"
    private let AFFISE_SET_OFFLINE_MODE_ENABLED = "set_offline_mode_enabled"
    private let AFFISE_IS_OFFLINE_MODE_ENABLED = "is_offline_mode_enabled"
    private let AFFISE_SET_BACKGROUND_TRACKING_ENABLED = "set_background_tracking_enabled"
    private let AFFISE_IS_BACKGROUND_TRACKING_ENABLED = "is_background_tracking_enabled"
    private let AFFISE_SET_TRACKING_ENABLED = "set_tracking_enabled"
    private let AFFISE_IS_TRACKING_ENABLED = "is_tracking_enabled"
    private let AFFISE_FORGET = "forget"
    private let AFFISE_SET_ENABLED_METRICS = "set_enabled_metrics"
    private let AFFISE_CRASH_APPLICATION = "crash_application"
    private let AFFISE_GET_REFERRER = "get_referrer"
    private let AFFISE_SKAD_REGISTER = "skad_register"
    private let AFFISE_SKAD_POSTBACK = "skad_postback"

    private let AFFISE_HANDLE_INITIAL_LINK = "handle_initial_link"

    private let UNITY_SKAD_REGISTER_ERROR = "skadRegisterError"
    private let UNITY_SKAD_POSTBACK_ERROR = "skadPostbackError"
    
    private let evensFactory: AffiseEvensFactory = AffiseEvensFactory()

    var application: UIApplication?
    var launchOptions: [UIApplication.LaunchOptionsKey: Any]?
    var deepLink: String?
    
    private var sendEvent: ((String, String)->Void)? = nil
    
    public func SetEventCallback(_ callback: @escaping (String, String)->Void) {
        sendEvent = callback
    }
    
    public func handle(method: String, data: [String: Any?], result: NativeResult) {
        switch method {
        case AFFISE_INIT: nativeInit(data: data, result: result)
        case AFFISE_SEND_EVENTS: nativeSendEvents(data: data, result: result)
        case AFFISE_SEND_EVENT: nativeSendEvent(data: data, result: result)
        case AFFISE_ADD_PUSH_TOKEN: nativeAddPushToken(data: data, result: result)
        case AFFISE_REGISTER_WEB_VIEW: nativeRegisterWebView(data: data, result: result)
        case AFFISE_UNREGISTER_WEB_VIEW: nativeUnregisterWebView(data: data, result: result)
        case AFFISE_REGISTER_DEEPLINK_CALLBACK: nativeRegisterDeeplinkCallback(data: data, result: result)
        case AFFISE_SET_SECRET_ID: nativeSetSecretId(data: data, result: result)
        case AFFISE_SET_AUTO_CATCHING_TYPES: nativeSetAutoCatchingTypes(data: data, result: result)
        case AFFISE_SET_OFFLINE_MODE_ENABLED: nativeSetOfflineModeEnabled(data: data, result: result)
        case AFFISE_IS_OFFLINE_MODE_ENABLED: nativeIsOfflineModeEnabled(data: data, result: result)
        case AFFISE_SET_BACKGROUND_TRACKING_ENABLED: nativeSetBackgroundTrackingEnabled(data: data, result: result)
        case AFFISE_IS_BACKGROUND_TRACKING_ENABLED: nativeIsBackgroundTrackingEnabled(data: data, result: result)
        case AFFISE_SET_TRACKING_ENABLED: nativeSetTrackingEnabled(data: data, result: result)
        case AFFISE_IS_TRACKING_ENABLED: nativeIsTrackingEnabled(data: data, result: result)
        case AFFISE_FORGET: nativeForget(data: data, result: result)
        case AFFISE_SET_ENABLED_METRICS: nativeSetEnabledMetrics(data: data, result: result)
        case AFFISE_CRASH_APPLICATION: nativeCrashApplication(data: data, result: result)
        case AFFISE_GET_REFERRER: nativeGetReferrer(data: data, result: result)
        case AFFISE_HANDLE_INITIAL_LINK: nativeHandleInitialLink(data: data, result: result)
        case AFFISE_SKAD_REGISTER: nativeSkadRegister(data: data, result: result)
        case AFFISE_SKAD_POSTBACK: nativeSkadPostback(data: data, result: result)
        default:
            result.notImplemented()
        }
    }
    
    private func nativeInit(data: [String: Any?], result: NativeResult) {        
        if application == nil {
            result.error("No application context")
            return
        }

        Affise._crossPlatform.unity()
        Affise.shared.load(app: application!, initProperties: data.toAffiseInitProperties , launchOptions: launchOptions)
    }
    
    private func nativeSendEvent(data: [String: Any?], result: NativeResult) {
        if let event = evensFactory.event(data) {
            Affise.shared.sendEvent(event: event)
        } else {
            result.error("Wrong argument map")
        }
    }
    
    private func nativeSendEvents(data: [String: Any?], result: NativeResult) {
        Affise.shared.sendEvents()
    }
    
    private func nativeAddPushToken(data: [String: Any?], result: NativeResult) {
        if let pushToken = data[AFFISE_ADD_PUSH_TOKEN] as? String {
            Affise.shared.addPushToken(pushToken: pushToken)
        }
    }
    
    private func nativeRegisterWebView(data: [String: Any?], result: NativeResult) {
        // TODO registerWebView
        // Affise.shared.registerWebView(webView)
        result.notImplemented()
    }
    
    private func nativeUnregisterWebView(data: [String: Any?], result: NativeResult) {
        Affise.shared.unregisterWebView()
    }
    
    private func nativeRegisterDeeplinkCallback(data: [String: Any?], result: NativeResult) {
        registerCallback()
    }
    
    private func nativeSetSecretId(data: [String: Any?], result: NativeResult) {
        if let secretId = data[AFFISE_SET_SECRET_ID] as? String {
            Affise.shared.setSecretId(secretId: secretId)
        }
    }
    
    private func nativeSetAutoCatchingTypes(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }
    
    private func nativeSetOfflineModeEnabled(data: [String: Any?], result: NativeResult) {
        let enabled = data[AFFISE_SET_OFFLINE_MODE_ENABLED] as? Bool ?? false
        Affise.shared.setOfflineModeEnabled(enabled: enabled)
    }
    
    private func nativeIsOfflineModeEnabled(data: [String: Any?], result: NativeResult) {
        result.success(Affise.shared.isOfflineModeEnabled())
    }
    
    private func nativeSetBackgroundTrackingEnabled(data: [String: Any?], result: NativeResult) {
        let enabled = data[AFFISE_SET_BACKGROUND_TRACKING_ENABLED] as? Bool ?? false
        Affise.shared.setBackgroundTrackingEnabled(enabled: enabled)
    }
    
    private func nativeIsBackgroundTrackingEnabled(data: [String: Any?], result: NativeResult) {
        result.success(Affise.shared.isBackgroundTrackingEnabled())
    }
    
    private func nativeSetTrackingEnabled(data: [String: Any?], result: NativeResult) {
        let enabled = data[AFFISE_SET_TRACKING_ENABLED] as? Bool ?? false
        Affise.shared.setTrackingEnabled(enabled: enabled)
    }
    
    private func nativeIsTrackingEnabled(data: [String: Any?], result: NativeResult) {
        result.success(Affise.shared.isTrackingEnabled())
    }
    
    private func nativeForget(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }
    
    private func nativeSetEnabledMetrics(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }
    
    private func nativeCrashApplication(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }
    
    private func nativeGetReferrer(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }

    private func nativeHandleInitialLink(data: [String: Any?], result: NativeResult) {
        nativeHandleDeeplink(deepLink)
    }

    private func nativeSkadRegister(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }

    private func nativeSkadPostback(data: [String: Any?], result: NativeResult) {
        result.notImplemented()
    }

    private func registerCallback() {
        Affise.shared.registerDeeplinkCallback {url in
        }
    }

    func nativeHandleDeeplink(_ url: String?) {
        if let url = url, !url.isEmpty {
            Affise._crossPlatform.handleDeeplink(uri: url)
            sendEvent?(AFFISE_REGISTER_DEEPLINK_CALLBACK, url)
        }
    }
}
