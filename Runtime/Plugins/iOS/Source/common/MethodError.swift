internal class MethodError {
    private var errorCode: String = "MethodError"
    private var errorMessage: String? = nil
    private var errorDetails: Any? = nil

    init(message: String) {
        errorMessage = message
    }

    init(errorCode: String, errorMessage: String?, errorDetails: Any?) {
        self.errorCode = errorCode
        self.errorMessage = errorMessage
        self.errorDetails = errorDetails
    }

    func  getErrorCode() -> String {
        return errorCode
    }

    func getErrorMessage() -> String? {
        return errorMessage
    }

    func getErrorDetails() -> Any? {
        return errorDetails
    }
}
