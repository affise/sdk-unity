import AffiseInternal

class ApiResult : InternalResult {
    
    private var result: Any?
    private var error: String?
    private var implemented: Bool = false
    
    func success(_ result: Any?) {
        self.result = result
    }
    
    public func error(_ error: String) {
        self.error = error
    }
        
    public func notImplemented() {
        implemented = true;
    }
    
    func getResult() -> Any? {
        return result
    }
    
    func getError() -> String? {
        return error
    }
    
    func isNotImplemented() -> Bool {
        return implemented
    }
}
