import AffiseInternal

@objc
public class NativeCallHandler: NSObject {

    @discardableResult
    public func apiCallAny(_ apiName: String, json: String) -> Any? {
        var result: InternalResult = ApiResult()

        guard let api = AffiseApiMethod.from(apiName) else {
            print("AffiseApi [\(apiName)] error: method not found")
            return nil
        }

        do {
            if let dict = try JSONSerialization.jsonObject(with: Data(json.utf8), options: .mutableContainers) as? [String: Any?] {
                apiCall(api, data: dict, result: &result)
            }
        } catch {
            print("AffiseApi [\(apiName)] error: \(error.localizedDescription)")
            return nil
        }

        if (result as? ApiResult)?.isNotImplemented() == true {
            print("AffiseApi [\(apiName)] error: api not implemented")
            return nil
        }

        if let error = (result as? ApiResult)?.getError() {
            print("AffiseApi [\(apiName)] error: \(error)")
            return nil
        }

        return asNativeData(result)
    }
    
    private func asNativeData(_ result: InternalResult) -> Any? {
        guard let result = result as? ApiResult else { return nil }
        guard let data = result.getResult() else { return nil }
                
        switch data {
        case is [String:Any?]:
            guard let data = data as? [String:Any?] else { return "{}" }
            return data.toJson()
        case is [Any?]:
            guard let data = data as? [Any?] else { return "[]" }
            return data.toJson()
        default:
            return data
        }
    }

    public func apiCallToType<T>(_ apiName: String, json: String) -> T? {
        guard let result: Any = apiCallAny(apiName, json: json) else {
            return nil
        }
        switch result {
        case is Bool:
            return result as? T
        case is String:
            return result as? T
        default:
            print("AffiseApi [\(apiName)] error: unsupported return type")
            return nil
        }
    }

    func apiCall(_ api: AffiseApiMethod, data: [String: Any?], result _: inout InternalResult) {
        print("AffiseApi [\(api.method)] error: methods not implemented")
    }
}
