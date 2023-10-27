import AffiseInternal

@objc 
public class AffiseNativeModule : NativeCallHandler {
    
    @objc 
    public static let shared = AffiseNativeModule()
        
    private var apiWrapper: AffiseApiWrapper? = nil
       
    @objc(callback:)
    public func setCallback(callback: @escaping (String, String) -> Void) {
        apiWrapper?.setCallback { (apiName: String, data: [String: Any?]) in
            DispatchQueue.main.async {
                callback(apiName, data.toArray().jsonString())
            }
        }
    }
    
    @objc(launchOptions:)
    public func Init(_ launchOptions: [UIApplication.LaunchOptionsKey: Any]?) {
        let app = UIApplication.shared
        apiWrapper = AffiseApiWrapper(app, launchOptions: launchOptions)
        apiWrapper?.unity()
    }
    
    @objc(handleDeeplink:)
    public func handleDeeplink(_ url: URL?) {
        guard let link = url?.absoluteString else { return }
        apiWrapper?.handleDeeplink(link)
    }

    override func apiCall(_ api: AffiseApiMethod, data: [String: Any?], result: inout AffiseResult) {
        apiWrapper?.call(api, map: data, result: result)
    }
}
