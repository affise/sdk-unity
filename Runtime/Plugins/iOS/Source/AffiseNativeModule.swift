import AffiseAttributionLib
import AffiseInternal

@objc 
public class AffiseNativeModule : NativeCallHandler {
    
    @objc 
    public static let shared = AffiseNativeModule()
        
    private var apiWrapper: AffiseApiWrapper? = nil
       
    @objc(callback:)
    public func setCallback(callback: @escaping (String, String)->Void) {
        apiWrapper?.setCallback(callback)
    }
    
    @objc(application:launchOptions:)
    public func Init(_ app: UIApplication?, launchOptions: [UIApplication.LaunchOptionsKey: Any]?) {
        guard let app = app else { return }
        apiWrapper = AffiseApiWrapper(app, launchOptions: launchOptions)
        apiWrapper?.unity()
    }
    
    @objc(handleDeeplink:)
    public func handleDeeplink(_ link: String?) {
        apiWrapper?.handleDeeplink(link)
    }

    override func apiCall(_ api: AffiseApiMethod, data: [String: Any?], result: inout AffiseResult) {
        apiWrapper?.call(api, map: data, result: result)
    }
}
