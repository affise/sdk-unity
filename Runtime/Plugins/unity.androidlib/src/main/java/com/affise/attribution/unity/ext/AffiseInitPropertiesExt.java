package com.affise.attribution.unity.ext;

import com.affise.attribution.events.autoCatchingClick.AutoCatchingType;
import com.affise.attribution.init.AffiseInitProperties;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class AffiseInitPropertiesExt {
    public static final String FIELD_AFFISE_APP_ID = "affiseAppId";
    public static final String FIELD_PART_PARAM_NAME = "partParamName";
    public static final String FIELD_PART_PARAM_NAME_TOKEN = "partParamNameToken";
    public static final String FIELD_APP_TOKEN = "appToken";
    public static final String FIELD_SECRET_ID = "secretId";
    public static final String FIELD_AUTO_CATCHING_CLICK_EVENTS = "autoCatchingClickEvents";
    public static final String FIELD_IS_PRODUCTION = "isProduction";
    public static final String FIELD_ENABLED_METRICS = "enabledMetrics";

    static public AffiseInitProperties toAffiseInitProperties(JSONObject json) {
        return new AffiseInitProperties(
            json.optString(FIELD_AFFISE_APP_ID),
            json.optBoolean(FIELD_IS_PRODUCTION),
            json.optString(FIELD_PART_PARAM_NAME),
            json.optString(FIELD_PART_PARAM_NAME_TOKEN),
            json.optString(FIELD_APP_TOKEN),
            json.optString(FIELD_SECRET_ID),
            getAutoCatchingClickEvents(json),
            json.optBoolean(FIELD_ENABLED_METRICS)
        );
    }

    static private List<AutoCatchingType> getAutoCatchingClickEvents(JSONObject json) {
        List<AutoCatchingType> result = new ArrayList<>();
        JSONArray jsonArray = json.optJSONArray(FIELD_AUTO_CATCHING_CLICK_EVENTS);
        if (jsonArray == null) return result;
        AutoCatchingType type;
        for (int i = 0; i < jsonArray.length(); i++) {
            type = AutoCatchingTypeExt.toAutoCatchingType(jsonArray.optString(i));
            if (type == null) continue;
            result.add(type);
        }
        return result;
    }
}
