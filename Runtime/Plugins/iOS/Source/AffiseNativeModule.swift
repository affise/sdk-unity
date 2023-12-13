import AffiseInternal

@objc 
public class AffiseNativeModule : NativeCallHandler {

    private static let KeyDelay = "AffiseDeepLinkStartDelay"
    private static let DefaultDelay = 3
    
    @objc 
    public static let shared = AffiseNativeModule()
        
    private var apiWrapper: AffiseApiWrapper? = nil
       
    public func setCallback(callback: @escaping (String, String) -> Void) {
        apiWrapper?.setCallback { (apiName: String, data: [String: Any?]) in
            DispatchQueue.main.async {
                callback(apiName, data.toArray().jsonString())
            }
        }
    }
    
    @objc(startAffiseWithOptions:)
    public func startAffise(_ launchOptions: [UIApplication.LaunchOptionsKey: Any]?) {
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

    func getDelay() -> Int {
        let delayKey = Bundle.main.object(forInfoDictionaryKey: AffiseNativeModule.KeyDelay) as? NSNumber
        let delay = delayKey?.intValue ?? AffiseNativeModule.DefaultDelay
        return delay
    }
}


extension AffiseNativeModule : ModuleAppDelegate {

    @objc
    public func applicationWillFinishLaunchingWithOptions(_ notification: Notification) {
        let options = notification.userInfo as? [UIApplication.LaunchOptionsKey : Any]
        startAffise(options)
        
        guard let url = options?[UIApplication.LaunchOptionsKey.url] as? URL else { return }
        DispatchQueue.global().asyncAfter(deadline: .now() + TimeInterval(getDelay())) {
            self.handleDeeplink(url)
        }
    }
    
    @objc
    public func onOpenURL(_ notification: Notification) {
        let options = notification.userInfo as? [String:Any?]
        let url: URL? = options?["url"] as? URL
        
        handleDeeplink(url)
    }
}
