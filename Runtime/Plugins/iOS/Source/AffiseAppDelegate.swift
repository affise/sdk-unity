@objc
public class AffiseAppDelegate: NSObject {
    
    @objc
    public static let shared = AffiseAppDelegate()
    
    override init() {
        super.init()
        
        // names from AppDelegateListener.h
        let notifications = [
            "kUnityWillFinishLaunchingWithOptions": #selector(self.launchingWithOptions(_:)),
            "kUnityOnOpenURL": #selector(self.onOpenURL(_:)),
        ]
        
        // Subscribe all events
        for (key, value) in notifications {
            addObserver(key, value)
        }
    }
    
    func addObserver( _ name: String, _ selector: Selector) {
        NotificationCenter.default.addObserver(
            self,
            selector: selector,
            name: Notification.Name(name),
            object: nil
        )
    }
    
    @objc
    public func launchingWithOptions(_ notification: NSNotification) {
        let options = notification.userInfo as? [UIApplication.LaunchOptionsKey : Any]
        AffiseNativeModule.shared.Init(options)
        
        let url: URL? = options?[UIApplication.LaunchOptionsKey.url] as? URL
        handleDeeplink(url)
    }
    
    @objc
    public func onOpenURL(_ notification: NSNotification) {
        let options = notification.userInfo as? [String:Any?]
        let url: URL? = options?["url"] as? URL
        handleDeeplink(url)
    }
    
    func handleDeeplink(_ url: URL? ) {
        AffiseNativeModule.shared.handleDeeplink(url)
    }
}
