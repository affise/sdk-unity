using System;

namespace AffiseAttributionLib.Native
{
    internal enum AffiseApiMethod
    {
        INIT,
        IS_INITIALIZED,
        SEND_EVENTS,
        SEND_EVENT,
        ADD_PUSH_TOKEN,
        REGISTER_WEB_VIEW,
        UNREGISTER_WEB_VIEW,
        SET_SECRET_KEY,
        SET_AUTO_CATCHING_TYPES,
        SET_OFFLINE_MODE_ENABLED,
        IS_OFFLINE_MODE_ENABLED,
        SET_BACKGROUND_TRACKING_ENABLED,
        IS_BACKGROUND_TRACKING_ENABLED,
        SET_TRACKING_ENABLED,
        IS_TRACKING_ENABLED,
        FORGET,
        SET_ENABLED_METRICS,
        CRASH_APPLICATION,
        GET_RANDOM_USER_ID,
        GET_RANDOM_DEVICE_ID,

        // callbacks
        GET_REFERRER_CALLBACK,
        GET_REFERRER_VALUE_CALLBACK,
        GET_STATUS_CALLBACK,
        REGISTER_DEEPLINK_CALLBACK,
        SKAD_REGISTER_ERROR_CALLBACK,
        SKAD_POSTBACK_ERROR_CALLBACK,
    }
    
    internal static class AffiseApiMethodExt
    {
        public static AffiseApiMethod? ToAffiseApiMethod(this string name)
        {
            foreach (var value in Enum.GetValues(typeof(AffiseApiMethod)))
            {
                if (value is not AffiseApiMethod method) continue;
                if (name == method.ToValue()) return method;
            }
            return null;
        }

        public static string ToValue(this AffiseApiMethod method)
        {
            return method switch
            {
                AffiseApiMethod.INIT => "init",
                AffiseApiMethod.IS_INITIALIZED => "is_initialized",
                AffiseApiMethod.SEND_EVENTS => "send_events",
                AffiseApiMethod.SEND_EVENT => "send_event",
                AffiseApiMethod.ADD_PUSH_TOKEN => "add_push_token",
                AffiseApiMethod.REGISTER_WEB_VIEW => "register_web_view",
                AffiseApiMethod.UNREGISTER_WEB_VIEW => "unregister_web_view",
                AffiseApiMethod.SET_SECRET_KEY => "set_secret_id",
                AffiseApiMethod.SET_AUTO_CATCHING_TYPES => "set_auto_catching_types",
                AffiseApiMethod.SET_OFFLINE_MODE_ENABLED => "set_offline_mode_enabled",
                AffiseApiMethod.IS_OFFLINE_MODE_ENABLED => "is_offline_mode_enabled",
                AffiseApiMethod.SET_BACKGROUND_TRACKING_ENABLED => "set_background_tracking_enabled",
                AffiseApiMethod.IS_BACKGROUND_TRACKING_ENABLED => "is_background_tracking_enabled",
                AffiseApiMethod.SET_TRACKING_ENABLED => "set_tracking_enabled",
                AffiseApiMethod.IS_TRACKING_ENABLED => "is_tracking_enabled",
                AffiseApiMethod.FORGET => "forget",
                AffiseApiMethod.SET_ENABLED_METRICS => "set_enabled_metrics",
                AffiseApiMethod.CRASH_APPLICATION => "crash_application",
                AffiseApiMethod.GET_RANDOM_USER_ID => "get_random_user_id",
                AffiseApiMethod.GET_RANDOM_DEVICE_ID => "get_random_device_id",
                // callbacks
                AffiseApiMethod.GET_REFERRER_CALLBACK => "get_referrer_callback",
                AffiseApiMethod.GET_REFERRER_VALUE_CALLBACK => "get_referrer_value_callback",
                AffiseApiMethod.GET_STATUS_CALLBACK => "get_status_callback",
                AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK => "register_deeplink_callback",
                AffiseApiMethod.SKAD_REGISTER_ERROR_CALLBACK => "skad_register_error_callback",
                AffiseApiMethod.SKAD_POSTBACK_ERROR_CALLBACK => "skad_postback_error_callback",
                _ => null
            };
        }
    }
}