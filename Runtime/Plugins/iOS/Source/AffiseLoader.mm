#import "AppDelegateListener.h"
#include "UnityFramework/UnityFramework-Swift.h"

@interface AffiseLoader: NSObject
@end

@implementation AffiseLoader

// runtime send the load message to each class object
+ (void)load {
    // Init NotificationCenter handler
    (void)[AffiseAppDelegate shared];
}

@end

//// Alternative Affise loader via AppDelegateListener
//@interface AffiseAppDelegateListener: NSObject<AppDelegateListener>
//@end

//@implementation AffiseAppDelegateListener
//
////Loader singleton
//static AffiseAppDelegateListener* _instance = nil;
//
//// runtime send the load message to each class object
//+ (void)load {
//    //Init loader
//    _instance = [[AffiseAppDelegateListener alloc] init];
//}
//
//- (instancetype)init
//{
//    self = [super init];
//    if (!self) return nil;
//    //Subscribe to AppDelegate events
//    UnityRegisterAppDelegateListener(self);
//    return self;
//}
//
//- (void)dealloc {
//    //Unsubscribe of AppDelegate events
//    UnityUnregisterAppDelegateListener(self);
//}
//
//- (void)applicationWillFinishLaunchingWithOptions:(NSNotification*)notification {
//    NSDictionary* options = notification.userInfo;
//    [[AffiseNativeModule shared] launchOptions:options];
//}
//
//- (void)onOpenURL:(NSNotification*)notification {
//    NSDictionary* options = notification.userInfo;
//    NSURL* url = [options valueForKey:@"url"];
//    [[AffiseNativeModule shared] handleDeeplink:url];
//}
//@end
