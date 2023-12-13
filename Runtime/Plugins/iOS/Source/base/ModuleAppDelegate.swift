// As Objective-C is based on message passing 
// https://en.wikipedia.org/wiki/Objective-C#Messages
// creating fake objective-c protocol 
// with matching messaging names
// for unity AppDelegateListener<LifeCycleListener> calling
@objc
public protocol ModuleAppDelegate {
    func applicationWillFinishLaunchingWithOptions(_ notification: Notification)
    func onOpenURL(_ notification: Notification)
}