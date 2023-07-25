#import <Foundation/Foundation.h>
#import "UnityAppController.h"
#include "UnityFramework/UnityFramework-Swift.h"

@interface AffiseAppController : UnityAppController
{

}
@end

@implementation AffiseAppController
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    [[AffiseNativeModule shared] application:application launchOptions:launchOptions];
    NSURL *url = [launchOptions objectForKey:UIApplicationLaunchOptionsURLKey];
    [[AffiseNativeModule shared] handleDeeplink:url.absoluteString];
    return [super application:application didFinishLaunchingWithOptions:launchOptions];
}

- (BOOL) application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options {
    [[AffiseNativeModule shared] handleDeeplink:url.absoluteString];
    return [super application:app openURL:url options:options];
}

- (BOOL)application:(UIApplication *)application continueUserActivity:(NSUserActivity *)userActivity restorationHandler:(void (^)(NSArray<id<UIUserActivityRestoring>> * _Nullable))restorationHandler{
    BOOL result = false;
    if (userActivity.activityType == NSUserActivityTypeBrowsingWeb) {
        NSURL *url = userActivity.webpageURL;
        [[AffiseNativeModule shared] handleDeeplink:url.absoluteString];
        result = false;
    }
    result = [super application:application continueUserActivity:userActivity restorationHandler:restorationHandler];
    return result;
}
@end
IMPL_APP_CONTROLLER_SUBCLASS(AffiseAppController);

