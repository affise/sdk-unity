package com.affise.attribution.unity.common;

public interface Result {
    void success(Object result);

    void error(String errorCode, String errorMessage, Object errorDetails);

    void notImplemented();
}
