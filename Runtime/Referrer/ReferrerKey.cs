namespace AffiseAttributionLib.Referrer
{
    public enum ReferrerKey
    {
        AD_ID,
        CAMPAIGN_ID,
        CLICK_ID,
        AFFISE_AD,
        AFFISE_AD_ID,
        AFFISE_AD_TYPE,
        AFFISE_ADSET,
        AFFISE_ADSET_ID,
        AFFISE_AFFC_ID,
        AFFISE_CHANNEL,
        AFFISE_CLICK_LOOK_BACK,
        AFFISE_COST_CURRENCY,
        AFFISE_COST_MODEL,
        AFFISE_COST_VALUE,
        AFFISE_DEEPLINK,
        AFFISE_KEYWORDS,
        AFFISE_MEDIA_TYPE,
        AFFISE_MODEL,
        AFFISE_OS,
        AFFISE_PARTNER,
        AFFISE_REF,
        AFFISE_SITE_ID,
        AFFISE_SUB_SITE_ID,
        AFFC,
        PID,
        SUB_1,
        SUB_2,
        SUB_3,
        SUB_4,
        SUB_5,
        AFFISE_SUB_1,
        AFFISE_SUB_2,
        AFFISE_SUB_3,
        AFFISE_SUB_4,
        AFFISE_SUB_5,
    }
    
    public static class ReferrerKeyExtensions
    {
        public static string ToValue(this ReferrerKey key)
        {
            return key switch
            {
                ReferrerKey.AD_ID => "ad_id",
                ReferrerKey.CAMPAIGN_ID => "campaign_id",
                ReferrerKey.CLICK_ID => "clickid",
                ReferrerKey.AFFISE_AD => "affise_ad",
                ReferrerKey.AFFISE_AD_ID => "affise_ad_id",
                ReferrerKey.AFFISE_AD_TYPE => "affise_ad_type",
                ReferrerKey.AFFISE_ADSET => "affise_adset",
                ReferrerKey.AFFISE_ADSET_ID => "affise_adset_id",
                ReferrerKey.AFFISE_AFFC_ID => "affise_affc_id",
                ReferrerKey.AFFISE_CHANNEL => "affise_channel",
                ReferrerKey.AFFISE_CLICK_LOOK_BACK => "affise_click_lookback",
                ReferrerKey.AFFISE_COST_CURRENCY => "affise_cost_currency",
                ReferrerKey.AFFISE_COST_MODEL => "affise_cost_model",
                ReferrerKey.AFFISE_COST_VALUE => "affise_cost_value",
                ReferrerKey.AFFISE_DEEPLINK => "affise_deeplink",
                ReferrerKey.AFFISE_KEYWORDS => "affise_keywords",
                ReferrerKey.AFFISE_MEDIA_TYPE => "affise_media_type",
                ReferrerKey.AFFISE_MODEL => "affise_model",
                ReferrerKey.AFFISE_OS => "affise_os",
                ReferrerKey.AFFISE_PARTNER => "affise_partner",
                ReferrerKey.AFFISE_REF => "affise_ref",
                ReferrerKey.AFFISE_SITE_ID => "affise_siteid",
                ReferrerKey.AFFISE_SUB_SITE_ID => "affise_sub_siteid",
                ReferrerKey.AFFC => "affc",
                ReferrerKey.PID => "pid",
                ReferrerKey.SUB_1 => "sub1",
                ReferrerKey.SUB_2 => "sub2",
                ReferrerKey.SUB_3 => "sub3",
                ReferrerKey.SUB_4 => "sub4",
                ReferrerKey.SUB_5 => "sub5",
                ReferrerKey.AFFISE_SUB_1 => "affise_sub1",
                ReferrerKey.AFFISE_SUB_2 => "affise_sub2",
                ReferrerKey.AFFISE_SUB_3 => "affise_sub3",
                ReferrerKey.AFFISE_SUB_4 => "affise_sub4",
                ReferrerKey.AFFISE_SUB_5 => "affise_sub5",
                _ => null
            };
        }
    }
}