package com.affise.attribution.unity;


import com.affise.attribution.internal.AffiseApiMethod;
import com.affise.attribution.internal.callback.AffiseResult;
import com.affise.attribution.internal.utils.JSONObjectExtKt;

import org.json.JSONObject;

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

        return (T) result.getResult();
    }


    public void apiCallVoid(String apiName, String json) throws Exception {
        apiCall(apiName, json);
    }

    public abstract void apiCall(AffiseApiMethod api, Map<String, ?> data, AffiseResult result);
}
