import Foundation

@objc 
public class AffiseNativeModule : NativeCallHandler {
    
    @objc 
    public static let shared = AffiseNativeModule()
        
    private var wrapper: AffiseWrapper = AffiseWrapper()
       
    @objc(eventCallback:)
    public func SetEventCallback(callback: @escaping (String, String)->Void) {
        wrapper.SetEventCallback(callback)
    }
    
    @objc(application:launchOptions:)
    public func Init(application: UIApplication?, launchOptions: [UIApplication.LaunchOptionsKey: Any]?) {
        wrapper.application = application
        wrapper.launchOptions = launchOptions
    }
    
    @objc(deeplink:)
    public func HandleDeeplink(deepLink: String?) {
        wrapper.deepLink = deepLink
        wrapper.nativeHandleDeeplink(wrapper.deepLink)
    }
   
    override func OnMethodCall(_ methodName: String, data: [String: Any?], result: inout MethodResult) {
        wrapper.handle(method: methodName, data: data, result: result)
    }
}
