package com.affise.attribution.unity;

import com.affise.attribution.internal.callback.InternalResult;

public class ApiResult implements InternalResult {

    private Object result;
    private String error;
    private boolean isNotImplemented = false;

    @Override
    public void success(Object result) {
        this.result = result;
    }

    @Override
    public void error(String errorMessage) {
        this.error = errorMessage;
    }

    @Override
    public void notImplemented() {
        isNotImplemented = true;
    }

    public Object getResult() {
        return result;
    }

    public String getError() {
        return error;
    }

    public boolean isError() {
        return error != null;
    }

    public boolean isNotImplemented() {
        return isNotImplemented;
    }
}
