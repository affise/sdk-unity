package com.affise.attribution.unity.common;

public class MethodError extends Exception {
    private String errorCode = "MethodError";
    private String errorMessage = "";
    private Object errorDetails = null;

    public MethodError(String message) {
        super(message);
        this.errorMessage = message;
    }

    public MethodError(String errorCode, String errorMessage, Object errorDetails) {
        super(errorCode);
        this.errorCode = errorCode;
        this.errorMessage = errorMessage;
        this.errorDetails = errorDetails;
    }

    public String getErrorCode() {
        return errorCode;
    }

    public String getErrorMessage() {
        return errorMessage;
    }

    public Object getErrorDetails() {
        return errorDetails;
    }
}
