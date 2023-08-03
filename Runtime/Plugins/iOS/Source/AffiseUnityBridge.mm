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

typedef void (*NativeCallback)(const char* apiName, const char* data);

extern "C" {

    void _c_register_callback(NativeCallback callback) {
        if (callback == NULL) return;
        [[AffiseNativeModule shared] callback: ^(NSString* apiName, NSString* data) {
            callback(cStringCopy([apiName UTF8String]), cStringCopy([data UTF8String]));
        }];
    }
    
    void _c_void_method_json(const char* apiName, const char* json) {
        NSString *api = CreateNSString(apiName); 
        NSString *data = CreateNSString(json);
        
        [[AffiseNativeModule shared] apiCallVoid:api json:data];
    }

    bool _c_bool_method_json(const char* apiName, const char* json) {
        NSString *api = CreateNSString(apiName); 
        NSString *data = CreateNSString(json);
        
        return [[AffiseNativeModule shared] apiCallBool:api json:data];
    }

    const char* _c_string_method_json(const char* apiName, const char* json) {
        NSString *api = CreateNSString(apiName); 
        NSString *data = CreateNSString(json);
        
        NSString *result = [[AffiseNativeModule shared] apiCallString:api json:data];
        return cStringCopy([result UTF8String]);
    }
}
