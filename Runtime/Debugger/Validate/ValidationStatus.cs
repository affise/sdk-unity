#nullable enable
using System;

namespace AffiseAttributionLib.Debugger.Validate
{
    public enum ValidationStatus
    {
        VALID,
        INVALID_APP_ID,
        INVALID_SECRET_KEY,
        PACKAGE_NAME_NOT_FOUND,
        NOT_WORKING_ON_PRODUCTION,
        NETWORK_ERROR,
        UNKNOWN_ERROR,
    }
    
    public static class ValidationStatusExt
    {    
        public static string? ToStatus(this ValidationStatus method)
        {
            return method switch
            {
                ValidationStatus.VALID => "valid",
                ValidationStatus.INVALID_APP_ID => "invalid_app_id",
                ValidationStatus.INVALID_SECRET_KEY => "invalid_secret_key",
                ValidationStatus.PACKAGE_NAME_NOT_FOUND => "package_name_not_found",
                ValidationStatus.NOT_WORKING_ON_PRODUCTION => "not_working_on_production",
                ValidationStatus.NETWORK_ERROR => "network_error",
                ValidationStatus.UNKNOWN_ERROR => "unknown_error",
                _ => null
            };
        }
        internal static ValidationStatus? ToValidationStatus(this string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            foreach (var value in Enum.GetValues(typeof(ValidationStatus)))
            {
                if (value is not ValidationStatus method) continue;
                if (name == method.ToStatus()) return method;
            }
            return null;
        }
    }
}