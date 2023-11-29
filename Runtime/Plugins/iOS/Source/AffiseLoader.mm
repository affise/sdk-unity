#import "AppDelegateListener.h"
#include "UnityFramework/UnityFramework-Swift.h"

@interface AffiseLoader: NSObject<AppDelegateListener>
@end

@implementation AffiseLoader

// The runtime sends the load message to each class object, 
// very soon after the class object is loaded in the process's address space.
// For classes that are part of the program's executable file,
// the runtime sends the load message very early in the process's lifetime. 
+ (void)load {
    @try {
        // As Objective-C is based on message passing
        // https://en.wikipedia.org/wiki/Objective-C#Messages
        // cast shared object with fake objective-c protocol 
        // to unity AppDelegateListener<LifeCycleListener>
        // for calling messages with matching names
        UnityRegisterAppDelegateListener((AffiseLoader*)[AffiseNativeModule shared]);
    }
    @catch (NSException *exception) {
        NSLog (@"Affise cannot start plugin. error: %@", [exception reason]);
    }
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
//    [[AffiseNativeModule shared] startAffiseWithOptions:options];
//}
//
//- (void)onOpenURL:(NSNotification*)notification {
//    NSDictionary* options = notification.userInfo;
//    NSURL* url = [options valueForKey:@"url"];
//    [[AffiseNativeModule shared] handleDeeplink:url];
//}
//@end
