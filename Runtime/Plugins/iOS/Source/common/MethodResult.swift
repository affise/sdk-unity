public class MethodResult : NativeResult {
    
    private var result: Any?
    private var error: MethodError?
    private var implemented: Bool = false
    
    func success(_ result: Any?) {
        self.result = result
    }
    
    func error(_ message: String) {
        self.error = MethodError(message: message)
    }
    
    func error(_ errorCode: String, errorMessage: String? = nil, errorDetails: Any? = nil) {
        self.error = MethodError(errorCode: errorCode, errorMessage: errorMessage, errorDetails: errorDetails)
    }
    
    func notImplemented() {
        implemented = true;
    }
    
    func getResult() -> Any? {
        return result
    }
    
    func getError() -> MethodError? {
        return error
    }
    
    func isError() -> Bool {
        return error != nil
    }
    
    func isNotImplemented() -> Bool {
        return implemented
    }
}
