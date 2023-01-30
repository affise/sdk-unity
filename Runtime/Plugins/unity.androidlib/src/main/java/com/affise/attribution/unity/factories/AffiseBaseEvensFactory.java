package com.affise.attribution.unity.factories;


import com.affise.attribution.events.Event;
import com.affise.attribution.events.predefined.PredefinedParameters;
import com.affise.attribution.unity.ext.PredefinedParametersExt;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public abstract class AffiseBaseEvensFactory {

    protected static final String KEY_NAME = "name";
    protected static final String KEY_SUBTYPE = "subtype";
    protected static final String KEY_DATA = "data";

    protected static final String KEY_SERIALIZE = "serialize";
    protected static final String KEY_USERDATA = "userData";
    protected static final String KEY_PREDEFINED_PARAMETERS = "predefinedParameters";

    public abstract Event event(JSONObject json);

    protected JSONObject getSerialize(JSONObject json) {
        return json.optJSONObject(KEY_SERIALIZE);
    }

    protected String getSerializeString(JSONObject json, String key) {
        JSONObject serialize = getSerialize(json);
        if (serialize == null) return "";
        return serialize.optString(key);
    }

    protected long getSerializeLong(JSONObject json, String key) {
        JSONObject serialize = getSerialize(json);
        if (serialize == null) return 0L;
        return serialize.optLong(key);
    }

    protected boolean getSerializeBoolean(JSONObject json, String key) {
        JSONObject serialize = getSerialize(json);
        if (serialize == null) return false;
        return serialize.optBoolean(key);
    }

    protected JSONArray getJSONArray(JSONObject json, String key) {
        JSONObject serialize = getSerialize(json);
        if (serialize == null) return new JSONArray();
        JSONArray result = serialize.optJSONArray(key);
        if (result == null) return new JSONArray();
        return  result;
    }

    protected JSONObject getJSONObject(JSONObject json, String key) {
        JSONObject serialize = getSerialize(json);
        if (serialize == null) return null;
        return serialize.optJSONObject(key);
    }

    protected void addPredefinedParameters(Event event, JSONObject json) {
        JSONObject map = json.optJSONObject(KEY_PREDEFINED_PARAMETERS);
        if (map == null) return;
        Iterator<String> keys = map.keys();

        while (keys.hasNext()) {
            String key = keys.next();
            Object value = map.opt(key);
            PredefinedParameters parameter = PredefinedParametersExt.toPredefinedParameters(key);
            if (parameter != null && value instanceof String) {
                event.addPredefinedParameter(parameter, (String) value);
            }
        }

    }

    protected String getUserData(JSONObject json) {
        return json.optString(KEY_USERDATA);
    }

    protected DataPair getUserDataAndTimeStamp(JSONObject json, String timeStampKey) {
        long timeStamp = getSerializeLong(json, timeStampKey);
        String userData = getUserData(json);
        return new DataPair(timeStamp, userData);
    }

    protected List<JSONObject> getJsonList(JSONObject json, String key) {
        JSONArray data = getJSONArray(json, key);
        List<JSONObject> result = new ArrayList<>();
        JSONObject value;
        for (int i = 0; i < data.length();i++) {
            value = data.optJSONObject(i);
            if (value == null) continue;
            result.add(value);
        }
        return result;
    }

    protected class DataPair {
        public long timeStamp = 0L;
        public String userData;

        public DataPair(long timeStamp, String userData) {
            this.timeStamp = timeStamp;
            this.userData = userData;
        }
    }
}
