@objc
public class NativeCallHandler: NSObject  {

    func WrapperMethodAny(_ methodName: String, json: String) -> Any? {
        var result = MethodResult()

        do {
            if let dict = try JSONSerialization.jsonObject(with: Data(json.utf8), options: .mutableContainers) as? [String: Any?] {
                OnMethodCall(methodName, data: dict, result: &result)
            }
        } catch {
            print("Affise iOS native error: \(error.localizedDescription)")
            return nil
        }
        
        if result.isNotImplemented() {
            print("Affise iOS native method not implemented: \(methodName)")
            return nil
        }

        if result.isError() {
            var errMessage = "Affise iOS native error"
            if let err = result.getError()?.getErrorMessage() {
                errMessage = "Affise iOS native error: \(err)"
            }
            print(errMessage)
            return nil
        }

        return result.getResult()
    }
    
    func WrapperMethod<T>(_ methodName: String, json: String) -> T? {
        if let result = WrapperMethodAny(methodName, json: json) {
            switch result {
            case is Bool:
                return result as? T
            case is String:
                return result as? T
            default:
                print("Affise iOS native unseported return type for method: \(methodName)")
                return nil
            }
        }

        return nil
    }
    
    @objc(voidMethod:json:)
    public func InvokeMethod(_ methodName: String, json: String) {
        let _ = WrapperMethodAny(methodName, json: json)
    }
    
    @objc(stringMethod:json:)
    public func InvokeMethod(_ methodName: String, json: String) -> String? {
        return WrapperMethod(methodName, json: json)
    }
    
    @objc(boolMethod:json:)
    public func InvokeMethod(_ methodName: String, json: String) -> Bool {
        return WrapperMethod(methodName, json: json) ?? false
    }
    
    func OnMethodCall(_ methodName: String, data: [String: Any?], result: inout MethodResult) {
        print("Affise iOS native methods not implemented")
    }
}
