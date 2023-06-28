package com.affise.attribution.unity.ext;

import com.affise.attribution.referrer.ReferrerKey;

public class ReferrerKeyExt {

    public static ReferrerKey toReferrerKey(String value) {
        switch (value) {                       
            case "ad_id":
                return ReferrerKey.AD_ID;
            case "campaign_id":
                return ReferrerKey.CAMPAIGN_ID;
            case "clickid":
                return ReferrerKey.CLICK_ID;
            case "affise_ad":
                return ReferrerKey.AFFISE_AD;
            case "affise_ad_id":
                return ReferrerKey.AFFISE_AD_ID;
            case "affise_ad_type":
                return ReferrerKey.AFFISE_AD_TYPE;
            case "affise_adset":
                return ReferrerKey.AFFISE_ADSET;
            case "affise_adset_id":
                return ReferrerKey.AFFISE_ADSET_ID;
            case "affise_affc_id":
                return ReferrerKey.AFFISE_AFFC_ID;
            case "affise_channel":
                return ReferrerKey.AFFISE_CHANNEL;
            case "affise_click_lookback":
                return ReferrerKey.AFFISE_CLICK_LOOK_BACK;
            case "affise_cost_currency":
                return ReferrerKey.AFFISE_COST_CURRENCY;
            case "affise_cost_model":
                return ReferrerKey.AFFISE_COST_MODEL;
            case "affise_cost_value":
                return ReferrerKey.AFFISE_COST_VALUE;
            case "affise_deeplink":
                return ReferrerKey.AFFISE_DEEPLINK;
            case "affise_keywords":
                return ReferrerKey.AFFISE_KEYWORDS;
            case "affise_media_type":
                return ReferrerKey.AFFISE_MEDIA_TYPE;
            case "affise_model":
                return ReferrerKey.AFFISE_MODEL;
            case "affise_os":
                return ReferrerKey.AFFISE_OS;
            case "affise_partner":
                return ReferrerKey.AFFISE_PARTNER;
            case "affise_ref":
                return ReferrerKey.AFFISE_REF;
            case "affise_siteid":
                return ReferrerKey.AFFISE_SITE_ID;
            case "affise_sub_siteid":
                return ReferrerKey.AFFISE_SUB_SITE_ID;
            case "affc":
                return ReferrerKey.AFFC;
            case "pid":
                return ReferrerKey.PID;
            case "sub1":
                return ReferrerKey.SUB_1;
            case "sub2":
                return ReferrerKey.SUB_2;
            case "sub3":
                return ReferrerKey.SUB_3;
            case "sub4":
                return ReferrerKey.SUB_4;
            case "sub5":
                return ReferrerKey.SUB_5;
        }
        return null;
    }
}
