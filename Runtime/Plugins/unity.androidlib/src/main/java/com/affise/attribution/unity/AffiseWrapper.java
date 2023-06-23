package com.affise.attribution.unity;

import android.app.Application;
import android.content.Context;

import com.affise.attribution.Affise;
import com.affise.attribution.events.Event;
import com.affise.attribution.events.autoCatchingClick.AutoCatchingType;
import com.affise.attribution.init.AffiseInitProperties;
import com.affise.attribution.unity.common.NativeEventCallback;
import com.affise.attribution.unity.common.Result;
import com.affise.attribution.unity.ext.AffiseInitPropertiesExt;
import com.affise.attribution.unity.ext.AutoCatchingTypeExt;
import com.affise.attribution.unity.factories.AffiseEvensFactory;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class AffiseWrapper {

    private static final String AFFISE_INIT = "init";
    private static final String AFFISE_SEND_EVENTS = "send_events";
    private static final String AFFISE_SEND_EVENT = "send_event";
    private static final String AFFISE_ADD_PUSH_TOKEN = "add_push_token";
    private static final String AFFISE_REGISTER_WEB_VIEW = "register_web_view";
    private static final String AFFISE_UNREGISTER_WEB_VIEW = "unregister_web_view";
    private static final String AFFISE_REGISTER_DEEPLINK_CALLBACK = "register_deeplink_callback";
    private static final String AFFISE_SET_SECRET_ID = "set_secret_id";
    private static final String AFFISE_SET_AUTO_CATCHING_TYPES = "set_auto_catching_types";
    private static final String AFFISE_SET_OFFLINE_MODE_ENABLED = "set_offline_mode_enabled";
    private static final String AFFISE_IS_OFFLINE_MODE_ENABLED = "is_offline_mode_enabled";
    private static final String AFFISE_SET_BACKGROUND_TRACKING_ENABLED = "set_background_tracking_enabled";
    private static final String AFFISE_IS_BACKGROUND_TRACKING_ENABLED = "is_background_tracking_enabled";
    private static final String AFFISE_SET_TRACKING_ENABLED = "set_tracking_enabled";
    private static final String AFFISE_IS_TRACKING_ENABLED = "is_tracking_enabled";
    private static final String AFFISE_FORGET = "forget";
    private static final String AFFISE_SET_ENABLED_METRICS = "set_enabled_metrics";
    private static final String AFFISE_CRASH_APPLICATION = "crash_application";
    private static final String AFFISE_GET_REFERRER = "get_referrer";

    private final Context applicationContext;
    private final AffiseEvensFactory evensFactory;
    private NativeEventCallback eventCallback;

    public AffiseWrapper(Context applicationContext) {
        this.applicationContext = applicationContext;
        evensFactory = new AffiseEvensFactory();
    }

    public void setEventCallback(NativeEventCallback eventCallback) {
        this.eventCallback = eventCallback;
    }

    public void handle(String methodName, JSONObject json, Result result) {
        switch (methodName) {
            case AFFISE_INIT:
                nativeInit(json, result);
                break;
            case AFFISE_SEND_EVENTS:
                nativeSendEvents(json, result);
                break;
            case AFFISE_SEND_EVENT:
                nativeSendEvent(json, result);
                break;
            case AFFISE_ADD_PUSH_TOKEN:
                nativeAddPushToken(json, result);
                break;
            case AFFISE_REGISTER_WEB_VIEW:
                nativeRegisterWebView(json, result);
                break;
            case AFFISE_UNREGISTER_WEB_VIEW:
                nativeUnregisterWebView(json, result);
                break;
            case AFFISE_REGISTER_DEEPLINK_CALLBACK:
                nativeRegisterDeeplinkCallback(json, result);
                break;
            case AFFISE_SET_SECRET_ID:
                nativeSetSecretId(json, result);
                break;
            case AFFISE_SET_AUTO_CATCHING_TYPES:
                nativeSetAutoCatchingTypes(json, result);
                break;
            case AFFISE_SET_OFFLINE_MODE_ENABLED:
                nativeSetOfflineModeEnabled(json, result);
                break;
            case AFFISE_IS_OFFLINE_MODE_ENABLED:
                nativeIsOfflineModeEnabled(json, result);
                break;
            case AFFISE_SET_BACKGROUND_TRACKING_ENABLED:
                nativeSetBackgroundTrackingEnabled(json, result);
                break;
            case AFFISE_IS_BACKGROUND_TRACKING_ENABLED:
                nativeIsBackgroundTrackingEnabled(json, result);
                break;
            case AFFISE_SET_TRACKING_ENABLED:
                nativeSetTrackingEnabled(json, result);
                break;
            case AFFISE_IS_TRACKING_ENABLED:
                nativeIsTrackingEnabled(json, result);
                break;
            case AFFISE_FORGET:
                nativeForget(json, result);
                break;
            case AFFISE_SET_ENABLED_METRICS:
                nativeSetEnabledMetrics(json, result);
                break;
            case AFFISE_CRASH_APPLICATION:
                nativeCrashApplication(json, result);
                break;
            case AFFISE_GET_REFERRER:
                nativeGetReferrer(json, result);
                break;
        }
    }

    private void nativeInit(JSONObject json, Result result) {
        Application app = (Application) applicationContext;
        if (app == null) {
            result.error("No application context", null, null);
            return;
        }
        AffiseInitProperties properties = AffiseInitPropertiesExt.toAffiseInitProperties(json);
        Affise._crossPlatform.unity();
        Affise.init(app, properties);
        Affise._crossPlatform.start();
    }

    private void nativeSendEvents(JSONObject json, Result result) {
        Affise.sendEvents();
    }

    private void nativeSendEvent(JSONObject json, Result result) {
        Event event = evensFactory.event(json);
        if (event == null) {
            result.error("Error event factory", null, null);
            return;
        }
        Affise.sendEvent(event);
    }

    private void nativeAddPushToken(JSONObject json, Result result) {
        String token = json.optString(AFFISE_ADD_PUSH_TOKEN);
        if (token.isEmpty()) {
            result.error("Error token is empty", null, null);
            return;
        }
        Affise.addPushToken(token);
    }

    private void nativeRegisterWebView(JSONObject json, Result result) {
        result.notImplemented();
    }

    private void nativeUnregisterWebView(JSONObject json, Result result) {
        result.notImplemented();
    }

    private void nativeRegisterDeeplinkCallback(JSONObject json, Result result) {
        Affise.registerDeeplinkCallback(uri -> {
            if (this.eventCallback != null) {
                this.eventCallback.HandleEvent(AFFISE_REGISTER_DEEPLINK_CALLBACK, uri.toString());
                return true;
            }
            return false;
        });
    }

    private void nativeSetSecretId(JSONObject json, Result result) {
        String secretId = json.optString(AFFISE_SET_SECRET_ID);
        if (secretId.isEmpty()) {
            result.error("Error secret id is empty", null, null);
            return;
        }
        Affise.setSecretId(secretId);
    }

    private void nativeSetAutoCatchingTypes(JSONObject json, Result result) {
        JSONArray data = json.optJSONArray(AFFISE_SET_AUTO_CATCHING_TYPES);
        if (data == null) {
            result.error("Error AutoCatchingTypes not set", null, null);
            return;
        }
        List<AutoCatchingType> types = new ArrayList<>();
        AutoCatchingType type;
        for (int i = 0; i < data.length(); i++) {
            type = AutoCatchingTypeExt.toAutoCatchingType(data.optString(i));
            if (type == null) continue;
            types.add(type);
        }

        Affise.setAutoCatchingTypes(types);
    }

    private void nativeSetOfflineModeEnabled(JSONObject json, Result result) {
        if (!json.has(AFFISE_SET_OFFLINE_MODE_ENABLED)) {
            result.error("Error offline mode value not set", null, null);
            return;
        }
        boolean enabled = json.optBoolean(AFFISE_SET_OFFLINE_MODE_ENABLED);
        Affise.setOfflineModeEnabled(enabled);
    }

    private void nativeIsOfflineModeEnabled(JSONObject json, Result result) {
        result.success(Affise.isOfflineModeEnabled());
    }

    private void nativeSetBackgroundTrackingEnabled(JSONObject json, Result result) {
        if (!json.has(AFFISE_SET_BACKGROUND_TRACKING_ENABLED)) {
            result.error("Error background tracking value not set", null, null);
            return;
        }
        boolean enabled = json.optBoolean(AFFISE_SET_BACKGROUND_TRACKING_ENABLED);
        Affise.setBackgroundTrackingEnabled(enabled);
    }

    private void nativeIsBackgroundTrackingEnabled(JSONObject json, Result result) {
        result.success(Affise.isBackgroundTrackingEnabled());
    }

    private void nativeSetTrackingEnabled(JSONObject json, Result result) {
        if (!json.has(AFFISE_SET_TRACKING_ENABLED)) {
            result.error("Error tracking value not set", null, null);
            return;
        }
        boolean enabled = json.optBoolean(AFFISE_SET_TRACKING_ENABLED);
        Affise.setTrackingEnabled(enabled);
    }

    private void nativeIsTrackingEnabled(JSONObject json, Result result) {
        result.success(Affise.isTrackingEnabled());
    }

    private void nativeForget(JSONObject json, Result result) {
        String userData = json.optString(AFFISE_FORGET);
        if (userData.isEmpty()) {
            result.error("Error forget userData is empty", null, null);
            return;
        }
        Affise.forget(userData);
    }

    private void nativeSetEnabledMetrics(JSONObject json, Result result) {
        if (!json.has(AFFISE_SET_ENABLED_METRICS)) {
            result.error("Error enabled metrics value not set", null, null);
            return;
        }
        boolean enabled = json.optBoolean(AFFISE_SET_ENABLED_METRICS);
        Affise.setEnabledMetrics(enabled);
    }

    private void nativeCrashApplication(JSONObject json, Result result) {
        Affise.crashApplication();
    }

    private void nativeGetReferrer(JSONObject json, Result result) {
        Affise.getReferrer(referrer -> {
            if (this.eventCallback != null) {
                this.eventCallback.HandleEvent(AFFISE_GET_REFERRER, referrer);
            }
        });
    }
}
