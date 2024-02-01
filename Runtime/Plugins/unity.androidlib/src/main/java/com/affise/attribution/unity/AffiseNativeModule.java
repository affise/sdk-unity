package com.affise.attribution.unity;

import android.app.Application;

import com.affise.attribution.internal.AffiseApiMethod;
import com.affise.attribution.internal.AffiseApiWrapper;
import com.affise.attribution.internal.callback.AffiseResult;
import com.affise.attribution.internal.callback.OnAffiseCallback;

import java.util.Map;

public class AffiseNativeModule extends NativeCallHandler {

    private final AffiseApiWrapper apiWrapper;

    public AffiseNativeModule(Application app, OnAffiseCallback callback) {
        apiWrapper = new AffiseApiWrapper(app);
        apiWrapper.unity();
        apiWrapper.setCallback(callback);
    }

    @Override
    public void apiCall(AffiseApiMethod api, Map<String, ?> data, AffiseResult result) {
        if (apiWrapper == null) return;
        apiWrapper.call(api, data, result);
    }
    
    public void nativeHandleDeeplink(String url) {
        if (apiWrapper == null) return;
        apiWrapper.handleDeeplink(url);
    }
}
