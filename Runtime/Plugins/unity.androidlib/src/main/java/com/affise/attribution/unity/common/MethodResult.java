package com.affise.attribution.unity.common;

public class MethodResult implements Result {

    private Object result;
    private MethodError error;
    private boolean notImplemented = false;

    public void success(Object result) {
        this.result = result;
    }

    public void error(String errorCode, String errorMessage, Object errorDetails) {
        this.error = new MethodError(errorCode, errorMessage, errorDetails);
    }

    public void notImplemented() {
        notImplemented = true;
    }

    public Object getResult() {
        return result;
    }

    public MethodError getError() {
        return error;
    }

    public boolean isError() {
        return error != null;
    }

    public boolean isNotImplemented() {
        return notImplemented;
    }
}
