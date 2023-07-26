﻿namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedString
    {
        ADREV_AD_TYPE,
        CITY,
        COUNTRY,
        REGION,
        CLASS,
        CONTENT_ID,
        CONTENT_TYPE,
        CURRENCY,
        CUSTOMER_USER_ID,
        DESCRIPTION,
        DESTINATION_A,
        DESTINATION_B,
        DESTINATION_LIST,
        ORDER_ID,
        PAYMENT_INFO_AVAILABLE,
        PREFERRED_NEIGHBORHOODS,
        PURCHASE_CURRENCY,
        RECEIPT_ID,
        REGISTRATION_METHOD,
        SEARCH_STRING,
        SUBSCRIPTION_ID,
        SUCCESS,
        SUGGESTED_DESTINATIONS,
        SUGGESTED_HOTELS,
        VALIDATED,
        ACHIEVEMENT_ID,
        COUPON_CODE,
        CUSTOMER_SEGMENT,
        DEEP_LINK,
        NEW_VERSION,
        OLD_VERSION,
        PARAM_01,
        PARAM_02,
        PARAM_03,
        PARAM_04,
        PARAM_05,
        PARAM_06,
        PARAM_07,
        PARAM_08,
        PARAM_09,
        PARAM_10,
        REVIEW_TEXT,
        TUTORIAL_ID,
        VIRTUAL_CURRENCY_NAME,
        STATUS
    }
    
    public static class PredefinedStringExt
    {
        public static string ToValue(this PredefinedString param)
        {
            return param switch
            {
                PredefinedString.ADREV_AD_TYPE => "affise_p_adrev_ad_type",
                PredefinedString.CITY => "affise_p_city",
                PredefinedString.COUNTRY => "affise_p_country",
                PredefinedString.REGION => "affise_p_region",
                PredefinedString.CLASS => "affise_p_class",
                PredefinedString.CONTENT_ID => "affise_p_content_id",
                PredefinedString.CONTENT_TYPE => "affise_p_content_type",
                PredefinedString.CURRENCY => "affise_p_currency",
                PredefinedString.CUSTOMER_USER_ID => "affise_p_customer_user_id",
                PredefinedString.DESCRIPTION => "affise_p_description",
                PredefinedString.DESTINATION_A => "affise_p_destination_a",
                PredefinedString.DESTINATION_B => "affise_p_destination_b",
                PredefinedString.DESTINATION_LIST => "affise_p_destination_list",
                PredefinedString.ORDER_ID => "affise_p_order_id",
                PredefinedString.PAYMENT_INFO_AVAILABLE => "affise_p_payment_info_available",
                PredefinedString.PREFERRED_NEIGHBORHOODS => "affise_p_preferred_neighborhoods",
                PredefinedString.PURCHASE_CURRENCY => "affise_p_purchase_currency",
                PredefinedString.RECEIPT_ID => "affise_p_receipt_id",
                PredefinedString.REGISTRATION_METHOD => "affise_p_registration_method",
                PredefinedString.SEARCH_STRING => "affise_p_search_string",
                PredefinedString.SUBSCRIPTION_ID => "affise_p_subscription_id",
                PredefinedString.SUCCESS => "affise_p_success",
                PredefinedString.SUGGESTED_DESTINATIONS => "affise_p_suggested_destinations",
                PredefinedString.SUGGESTED_HOTELS => "affise_p_suggested_hotels",
                PredefinedString.VALIDATED => "affise_p_validated",
                PredefinedString.ACHIEVEMENT_ID => "affise_p_achievement_id",
                PredefinedString.COUPON_CODE => "affise_p_coupon_code",
                PredefinedString.CUSTOMER_SEGMENT => "affise_p_customer_segment",
                PredefinedString.DEEP_LINK => "affise_p_deep_link",
                PredefinedString.NEW_VERSION => "affise_p_new_version",
                PredefinedString.OLD_VERSION => "affise_p_old_version",
                PredefinedString.PARAM_01 => "affise_p_param_01",
                PredefinedString.PARAM_02 => "affise_p_param_02",
                PredefinedString.PARAM_03 => "affise_p_param_03",
                PredefinedString.PARAM_04 => "affise_p_param_04",
                PredefinedString.PARAM_05 => "affise_p_param_05",
                PredefinedString.PARAM_06 => "affise_p_param_06",
                PredefinedString.PARAM_07 => "affise_p_param_07",
                PredefinedString.PARAM_08 => "affise_p_param_08",
                PredefinedString.PARAM_09 => "affise_p_param_09",
                PredefinedString.PARAM_10 => "affise_p_param_10",
                PredefinedString.REVIEW_TEXT => "affise_p_review_text",
                PredefinedString.TUTORIAL_ID => "affise_p_tutorial_id",
                PredefinedString.VIRTUAL_CURRENCY_NAME => "affise_p_virtual_currency_name",
                PredefinedString.STATUS => "affise_p_status",
                _ => null
            };
        }
    }
}