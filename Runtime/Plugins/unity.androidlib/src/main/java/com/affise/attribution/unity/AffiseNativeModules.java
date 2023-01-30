package com.affise.attribution.unity;

import android.app.Application;

import com.affise.attribution.unity.common.NativeEventCallback;
import com.affise.attribution.unity.common.NativeCallHandler;
import com.affise.attribution.unity.common.Result;

import org.json.JSONObject;

public class AffiseNativeModules extends NativeCallHandler {

    private AffiseWrapper wrapper;

    public AffiseNativeModules(Application app, NativeEventCallback callback) {
        wrapper = new AffiseWrapper(app);
        wrapper.setEventCallback(callback);
    }

    @Override
    public void onMethodCall(String methodName, JSONObject json, Result result) {
        wrapper.handle(methodName, json, result);
    }
}
