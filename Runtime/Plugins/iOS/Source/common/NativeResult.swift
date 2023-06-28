protocol NativeResult {
    func success(_ result: Any?)
    func error(_ errorCode: String)
    func error(_ errorCode: String, errorMessage: String?, errorDetails: Any?)
    func notImplemented()
}
