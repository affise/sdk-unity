package com.affise.attribution.unity.common;


import org.json.JSONObject;

public abstract class NativeCallHandler {

    public <T> T invokeMethod(String methodName, String json) throws Exception {
        MethodResult result = new MethodResult();

        JSONObject jsonObject = new JSONObject(json);
        onMethodCall(methodName, jsonObject, result);

        if (result.isNotImplemented()) {
            throw new MethodError(String.format("NotImplemented: %s", methodName));
        }
        if (result.isError()) {
            throw result.getError();
        }

        return (T) result.getResult();
    }

    public <T> T invokeMethod(String methodName) throws Exception {
        return invokeMethod(methodName, "{}");
    }

    public void invokeMethodVoid(String methodName, String json) throws Exception {
        invokeMethod(methodName, json);
    }

    public void invokeMethodVoid(String methodName) throws Exception {
        invokeMethod(methodName, "{}");
    }

    public abstract void onMethodCall(String methodName, JSONObject json, Result result);
}
