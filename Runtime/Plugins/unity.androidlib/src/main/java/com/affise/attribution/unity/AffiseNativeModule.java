package com.affise.attribution.unity;

import android.app.Activity;

import com.affise.attribution.internal.AffiseApiMethod;
import com.affise.attribution.internal.AffiseApiWrapper;
import com.affise.attribution.internal.callback.InternalResult;
import com.affise.attribution.internal.callback.OnAffiseCallback;

import java.util.Map;

public class AffiseNativeModule extends NativeCallHandler {

    private final AffiseApiWrapper apiWrapper;

    public AffiseNativeModule(Activity activity, OnAffiseCallback callback) {
        apiWrapper = new AffiseApiWrapper(activity.getApplication());
        apiWrapper.setActivity(activity);
        apiWrapper.unity();
        apiWrapper.setCallback(callback);
    }

    @Override
    public void apiCall(AffiseApiMethod api, Map<String, ?> data, InternalResult result) {
        if (apiWrapper == null) return;
        apiWrapper.call(api, data, result);
    }
    
    public void nativeHandleDeeplink(String url) {
        if (apiWrapper == null) return;
        apiWrapper.handleDeeplink(url);
    }
}
