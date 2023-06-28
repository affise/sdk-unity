#import <Foundation/Foundation.h>
#include "UnityFramework/UnityFramework-Swift.h"

char* cStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;

    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);

    return res;
}

static NSString* CreateNSString(const char* string)
{
    return string ? [NSString stringWithUTF8String:string] : nil;
}

typedef void (*NativeEventCallback)(const char* eventName, const char* data);

extern "C" {

    void _c_register_callback(NativeEventCallback callback) {
        if (callback == NULL) return;
        
        [[AffiseNativeModule shared] eventCallback: ^(NSString* eventName, NSString* data) {
            callback(cStringCopy([eventName UTF8String]), cStringCopy([data UTF8String]));
        }];
    }
    
    void _c_void_method_json(const char* methodName, const char* json) {
        NSString *method = CreateNSString(methodName); 
        NSString *data = CreateNSString(json);
        
        [[AffiseNativeModule shared] voidMethod:method json:data];
    }

    bool _c_bool_method_json(const char* methodName, const char* json) {
        NSString *method = CreateNSString(methodName); 
        NSString *data = CreateNSString(json);
        
        return [[AffiseNativeModule shared] boolMethod:method json:data];
    }

    const char* _c_string_method_json(const char* methodName, const char* json) {
        NSString *method = CreateNSString(methodName); 
        NSString *data = CreateNSString(json);
        
        NSString *result = [[AffiseNativeModule shared] stringMethod:method json:data];
        return cStringCopy([result UTF8String]);
    }
}
