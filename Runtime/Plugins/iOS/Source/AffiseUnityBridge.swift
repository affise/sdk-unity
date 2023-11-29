@_cdecl("_c_affise_api_set_callback")
public func callback(_ handler: @convention(c) @escaping (UnsafePointer<CChar>?, UnsafePointer<CChar>?) -> Void) {
    AffiseNativeModule.shared.setCallback { apiName, data in
        handler(apiName.toUnsafePointer(), data.toUnsafePointer())
    }
}

@_cdecl("_c_affise_api_call")
public func apiCall(_ apiNameRaw: UnsafePointer<CChar>?, _ jsonRaw: UnsafePointer<CChar>?) {
    guard let (apiName, json) = getApiData(apiNameRaw, jsonRaw) else { return }
    AffiseNativeModule.shared.apiCallAny(apiName, json: json)
}

@_cdecl("_c_affise_api_call_bool")
public func apiCallToBool(_ apiNameRaw: UnsafePointer<CChar>?, _ jsonRaw: UnsafePointer<CChar>?) -> Int {
    guard let (apiName, json) = getApiData(apiNameRaw, jsonRaw) else { return 0 }
    let result = AffiseNativeModule.shared.apiCallToType(apiName, json: json) ?? false
    return result ? 1 : 0
}

@_cdecl("_c_affise_api_call_string")
public func apiCallToString(_ apiNameRaw: UnsafePointer<CChar>?, _ jsonRaw: UnsafePointer<CChar>?) -> UnsafePointer<CChar>? {
    guard let (apiName, json) = getApiData(apiNameRaw, jsonRaw) else { return nil }
    let result: String? = AffiseNativeModule.shared.apiCallToType(apiName, json: json)
    return result?.toUnsafePointer()
}

func getApiData(_ apiNameRaw: UnsafePointer<CChar>?, _ jsonRaw: UnsafePointer<CChar>?) -> (String, String)? {
    guard let apiName = toString(apiNameRaw) else { return nil }
    guard let json = toString(jsonRaw) else { return nil }
    return (apiName, json)
}
