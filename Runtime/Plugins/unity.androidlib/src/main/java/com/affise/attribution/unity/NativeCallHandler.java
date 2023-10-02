package com.affise.attribution.unity;


import com.affise.attribution.internal.AffiseApiMethod;
import com.affise.attribution.internal.callback.AffiseResult;
import com.affise.attribution.internal.utils.JSONObjectExtKt;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.List;
import java.util.Map;

public abstract class NativeCallHandler {

    public <T> T apiCall(String apiName, String json) throws Exception {
        ApiResult result = new ApiResult();
        JSONObject jsonObject = new JSONObject(json);

        apiCall(
                AffiseApiMethod.from(apiName),
                JSONObjectExtKt.toMap(jsonObject),
                result
        );

        if (result.isNotImplemented()) {
            throw new Exception(String.format("error: api [%s]: not implemented", apiName));
        }

        if (result.isError()) {
            throw new Exception(String.format("error: [%s]", result.getError()));
        }

        try {
            return asNativeData(result);
        } catch (Exception e) {
            throw new Exception(String.format("error: [%s]", e.getLocalizedMessage()));
        }
    }

    private <T> T asNativeData(ApiResult result) {
        Object data = result.getResult();

        if (data instanceof Map) {
            JSONObject json = new JSONObject((Map)data);
            return (T) json.toString();
        } else if (data instanceof List) {
            JSONArray json = new JSONArray((List)data);
            return (T) json.toString();
        }

        return (T) data;
    }

    public void apiCallVoid(String apiName, String json) throws Exception {
        apiCall(apiName, json);
    }

    public abstract void apiCall(AffiseApiMethod api, Map<String, ?> data, AffiseResult result);
}
