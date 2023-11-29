# Affise Unity package

| Artifact      | Version              |
|---------------|----------------------|
| `attribution` | [`1.6.10`](/releases) |

- [Affise Unity package](#affise-unity-package)
- [Description](#description)
  - [Quick start](#quick-start)
  - [Integration](#integration)
    - [Integrate unity package](#integrate-unity-package)
    - [Integrate unitypackage file](#integrate-unitypackage-file)
    - [Initialize](#initialize)
      - [Unity asset](#unity-asset)
        - [Domain](#domain)
      - [Manual](#manual)
        - [Domain](#domain-1)
    - [Requirements](#requirements)
      - [iOS](#ios)
    - [Add platform modules](#add-platform-modules)
      - [Android](#android)
      - [iOS](#ios-1)
  - [Build](#build)
    - [iOS](#ios-2)
- [Features](#features)
  - [ProviderType identifiers collection](#providertype-identifiers-collection)
    - [Attribution](#attribution)
    - [Advertising](#advertising)
    - [Network](#network)
    - [Phone](#phone)
  - [Events tracking](#events-tracking)
    - [Custom events tracking](#custom-events-tracking)
  - [Predefined event parameters](#predefined-event-parameters)
    - [PredefinedString](#predefinedstring)
    - [PredefinedLong](#predefinedlong)
    - [PredefinedFloat](#predefinedfloat)
    - [PredefinedObject](#predefinedobject)
    - [PredefinedListObject](#predefinedlistobject)
    - [PredefinedListString](#predefinedliststring)
  - [Events buffering](#events-buffering)
  - [Push token tracking](#push-token-tracking)
  - [Deeplinks](#deeplinks)
    - [Android](#android-1)
    - [iOS](#ios-3)
  - [Offline mode](#offline-mode)
  - [Disable tracking](#disable-tracking)
  - [Disable background tracking](#disable-background-tracking)
  - [Get random user Id](#get-random-user-id)
  - [Get random device Id](#get-random-device-id)
  - [Get providers](#get-providers)
  - [Get module state](#get-module-state)
  - [Platform specific](#platform-specific)
    - [Get referrer](#get-referrer)
    - [Get referrer value](#get-referrer-value)
      - [Referrer keys](#referrer-keys)
    - [StoreKit Ad Network](#storekit-ad-network)
- [SDK to SDK integrations](#sdk-to-sdk-integrations)
- [Debug](#debug)
  - [Validate credentials](#validate-credentials)
- [Troubleshoots](#troubleshoots)
  - [iOS](#ios-4)

# Description

Affise SDK is a software you can use to collect app usage statistics, device identifiers, deeplink usage, track install
referrer.

## Quick start

## Integration

### Integrate unity package

Open Package Manager(`Window / Package Manager`)

Add package from git url `https://github.com/affise/sdk-unity.git`

<div align=center>
    <img src="https://github.com/affise/sdk-unity/blob/assets/package_git.png?raw=true" alt="package_manager">
</div>

### Integrate unitypackage file

Download latest Affise SDK [`attribution-1.6.10.unitypackage`](https://github.com/affise/sdk-unity/releases/download/1.6.10/attribution-1.6.10.unitypackage)
from [releases page](https://github.com/affise/sdk-unity/releases) and drop this file to unity editor

### Initialize

#### Unity asset

After package is added to unity project, initialize affise settings.

Open Project Settings(`Edit / Project Settings`)

On Affise tab click `Create` button.

![affise_settings_new](https://github.com/affise/sdk-unity/blob/assets/affise_settings_new.png?raw=true)

This will create `Affise Settings.asset` in `Assets / Affise / Resources` directory.

> **Note**
>
> 🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦
>
> Settings set in `Edit / Project Settings / Affise` are marked as `Active Settings`
>
> Affise is using settings marked as `Active Settings`
>
> located in root of folder `Resources` which can be located in any folder
>
> Example `<Any folder> / Resources / <Your affise settings>.asset`
>
> 🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦🟦

> **Warning**
>
> 🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧
>
> Settings located in `Editor` folder are **invalid**.
>
> Example: `Editor / Resources / <Your affise settings>.asset`
>
> 🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧

Fill all required fields

![affise_settings](https://github.com/affise/sdk-unity/blob/assets/affise_settings.png?raw=true)

##### Domain

Set SDK server domain:

1. Open `Edit / Project Settings / Affise`
2. Unfold `Optional` section at the bottom
3. Fill `Domain` field

#### Manual

> Demo app [AffiseDemo.cs](Samples~/AffiseDemoApp/Scripts/AffiseDemo.cs)

```c#
Affise
    .Settings(
        affiseAppId: "Your appId", //Change to your app id
        secretKey: "Your SDK secretKey" //Change to your SDK secretKey
    )
    .Start(); // Start Affise SDK
```

##### Domain

Set SDK server domain:

```c#
Affise
    .Settings(
        affiseAppId: "Your appId",
        secretKey: "Your SDK secretKey"
    )
    .setDomain("https://YoureCustomDomain/") // Set custom domain
    .Start(); // Start Affise SDK
```

### Requirements

#### iOS

Affise SDK uses `AppTrackingTransparency` framework to get `advertisingIdentifier`
For working functionality your app needs to declare [`NSUserTrackingUsageDescription` permission](https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription):

Open XCode project `info.plist` and add key `NSUserTrackingUsageDescription` with string value

```xml
<plist version="1.0">
<dict>
    ...
	<key>NSUserTrackingUsageDescription</key>
	<string>Youre permission text</string>
</dict>
```

### Add platform modules

#### Android

Exported Unity project as Android project

Add modules to Android project gradle file `unityLibrary/build.gradle`

| Module               | Version                                                                                                                                                                      |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `module-advertising` | [![module-advertising](https://img.shields.io/maven-central/v/com.affise/module-advertising?label=latest)](https://mvnrepository.com/artifact/com.affise/module-advertising) |
| `module-network`     | [![module-network](https://img.shields.io/maven-central/v/com.affise/module-network?label=latest)](https://mvnrepository.com/artifact/com.affise/module-network)             |
| `module-phone`       | [![module-phone](https://img.shields.io/maven-central/v/com.affise/module-phone?label=latest)](https://mvnrepository.com/artifact/com.affise/module-phone)                   |
| `module-status`      | [![module-status](https://img.shields.io/maven-central/v/com.affise/module-status?label=latest)](https://mvnrepository.com/artifact/com.affise/module-status)                |

```gradle
dependencies {
  // ...
  // Affise modules
  implementation 'com.affise:module-advertising:1.6.20'
  implementation 'com.affise:module-network:1.6.20'
  implementation 'com.affise:module-phone:1.6.20'
  implementation 'com.affise:module-status:1.6.20'
}
```

#### iOS

Open `Podfile` in XCode project folder

Add modules to iOS project

| Module                | Version  |
|-----------------------|:--------:|
| `AffiseModule/Status` | [`1.6.17`](https://github.com/CocoaPods/Specs/tree/master/Specs/0/3/d/AffiseModule/) |

```rb
platform :ios, '11.0'

target 'UnityFramework' do
  pod 'AffiseInternal', '1.6.17'

  # Affise Modules
  pod 'AffiseModule/Status', `1.6.17`
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
```

## Build

### iOS

SDK is using Cocoapods

1. In `Build setting` select iOS platform and press `Build`
2. Select build folder (unity will exported iOS project to build folder)
3. Build folder should contain `Podfile`
4. In Terminal open build folder and run commend `pod install`
5. Open generated `*.worksapce` to build your unity project

> **Warning**
>
> 🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧
>
> If command `pod install` returns error `CocoaPods could not find compatible versions for pod "AffiseInternal"`
>
> Run `pod repo update` and then run `pod install` again
>
> 🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧


If Podfile hasn't generated you can create it manually using this [Podfile](Editor/Resources/iOS/AffisePodfile.rb) as template

Podfile:

```rb
platform :ios, '11.0'

target 'UnityFramework' do
  pod 'AffiseInternal', '1.6.17'

  # Affise Modules
  # pod 'AffiseModule/Status', `1.6.17`
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
```

# Features

## ProviderType identifiers collection

To match users with events and data library is sending, these `ProviderType` identifiers are collected:

### Attribution

- `AFFISE_APP_ID`
- `AFFISE_PKG_APP_NAME`
- `AFF_APP_NAME_DASHBOARD`
- `APP_VERSION`
- `APP_VERSION_RAW`
- `STORE`
- `TRACKER_TOKEN`
- `TRACKER_NAME`
- `FIRST_TRACKER_TOKEN`
- `FIRST_TRACKER_NAME`
- `LAST_TRACKER_TOKEN`
- `LAST_TRACKER_NAME`
- `OUTDATED_TRACKER_TOKEN`
- `INSTALLED_TIME`
- `FIRST_OPEN_TIME`
- `INSTALLED_HOUR`
- `FIRST_OPEN_HOUR`
- `INSTALL_FIRST_EVENT`
- `INSTALL_BEGIN_TIME`
- `INSTALL_FINISH_TIME`
- `REFERRER_INSTALL_VERSION`
- `REFERRAL_TIME`
- `REFERRER_CLICK_TIME`
- `REFERRER_CLICK_TIME_SERVER`
- `REFERRER_GOOGLE_PLAY_INSTANT`
- `CREATED_TIME`
- `CREATED_TIME_MILLI`
- `CREATED_TIME_HOUR`
- `UNINSTALL_TIME`
- `REINSTALL_TIME`
- `LAST_SESSION_TIME`
- `CPU_TYPE`
- `HARDWARE_NAME`
- `DEVICE_MANUFACTURER`
- `DEEPLINK_CLICK`
- `DEVICE_ATLAS_ID`
- `AFFISE_DEVICE_ID`
- `AFFISE_ALT_DEVICE_ID`
- `ANDROID_ID`
- `ANDROID_ID_MD5`
- `REFTOKEN`
- `REFTOKENS`
- `REFERRER`
- `USER_AGENT`
- `MCCODE`
- `MNCODE`
- `REGION`
- `COUNTRY`
- `LANGUAGE`
- `DEVICE_NAME`
- `DEVICE_TYPE`
- `OS_NAME`
- `PLATFORM`
- `SDK_PLATFORM`
- `API_LEVEL_OS`
- `AFFISE_SDK_VERSION`
- `OS_VERSION`
- `RANDOM_USER_ID`
- `AFFISE_SDK_POS`
- `TIMEZONE_DEV`
- `AFFISE_EVENT_NAME`
- `AFFISE_EVENT_TOKEN`
- `LAST_TIME_SESSION`
- `TIME_SESSION`
- `AFFISE_SESSION_COUNT`
- `LIFETIME_SESSION_COUNT`
- `AFFISE_DEEPLINK`
- `AFFISE_PART_PARAM_NAME`
- `AFFISE_PART_PARAM_NAME_TOKEN`
- `AFFISE_APP_TOKEN`
- `LABEL`
- `AFFISE_SDK_SECRET_ID`
- `UUID`
- `AFFISE_APP_OPENED`
- `PUSHTOKEN`
- `AFFISE_EVENTS_COUNT`
- `AFFISE_SDK_EVENTS_COUNT`
- `AFFISE_METRICS_EVENTS_COUNT`
- `AFFISE_INTERNAL_EVENTS_COUNT`
- `IS_ROOTED`
- `IS_EMULATOR`

### Advertising

- `GAID_ADID`
- `GAID_ADID_MD5`
- `OAID`
- `OAID_MD5`
- `ADID`
- `ALTSTR_ADID`
- `FIREOS_ADID`
- `COLOROS_ADID`

### Network

- `MAC_SHA1`
- `MAC_MD5`
- `CONNECTION_TYPE`
- `PROXY_IP_ADDRESS`

### Phone

- `NETWORK_TYPE`
- `ISP`

## Events tracking

For example, we want to track achievements. To send event first create it with
following code

```c#
class Presenter {
    void OnUnlockAchievement()
    {
        var achievement =  new JSONObject
        {
            ["achievement"] = "new level",
        };

        new UnlockAchievementEvent("best damage")
            .AddPredefinedParameter(PredefinedLong.USER_SCORE, 12552L)
            .AddPredefinedParameter(PredefinedString.ACHIEVEMENT_ID, "1334-1225-ASDZ")
            .AddPredefinedParameter(PredefinedObject.CONTENT, achievement)
            .Send();
    }
}
```

With above example you can implement other events:

- `AchieveLevel`
- `AddPaymentInfo`
- `AddToCart`
- `AddToWishlist`
- `AdRevenue`
- `ClickAdv`
- `CompleteRegistration`
- `CompleteStream`
- `CompleteTrial`
- `CompleteTutorial`
- `Contact`
- `ContentItemsView`
- `CustomizeProduct`
- `DeepLinked`
- `Donate`
- `FindLocation`
- `InitiateCheckout`
- `InitiatePurchase`
- `InitiateStream`
- `Invite`
- `LastAttributedTouch`
- `Lead`
- `ListView`
- `Login`
- `OpenedFromPushNotification`
- `Order`
- `OrderItemAdded`
- `OrderItemRemove`
- `OrderCancel`
- `OrderReturnRequest`
- `OrderReturnRequestCancel`
- `Purchase`
- `Rate`
- `ReEngage`
- `Reserve`
- `Sales`
- `Schedule`
- `Search`
- `Share`
- `SpendCredits`
- `StartRegistration`
- `StartTrial`
- `StartTutorial`
- `SubmitApplication`
- `Subscribe`
- `TravelBooking`
- `UnlockAchievement`
- `Unsubscribe`
- `Update`
- `ViewAdv`
- `ViewCart`
- `ViewContent`
- `ViewItem`
- `ViewItems`
- `InitialSubscription`
- `InitialTrial`
- `InitialOffer`
- `ConvertedTrial`
- `ConvertedOffer`
- `TrialInRetry`
- `OfferInRetry`
- `SubscriptionInRetry`
- `RenewedSubscription`
- `FailedSubscriptionFromRetry`
- `FailedOfferFromRetry`
- `FailedTrialFromRetry`
- `FailedSubscription`
- `FailedOfferise`
- `FailedTrial`
- `ReactivatedSubscription`
- `RenewedSubscriptionFromRetry`
- `ConvertedOfferFromRetry`
- `ConvertedTrialFromRetry`
- `Unsubscription`

### Custom events tracking

Use any of custom events if default doesn't fit your scenario:

- `CustomId01Event`
- `CustomId02Event`
- `CustomId03Event`
- `CustomId04Event`
- `CustomId05Event`
- `CustomId06Event`
- `CustomId07Event`
- `CustomId08Event`
- `CustomId09Event`
- `CustomId10Event`

## Predefined event parameters

To enrich your event with another dimension, you can use predefined parameters for most common cases.
Add it to any event:

```c#
class Presenter {
    void OnUnlockAchievement()
    {
        var achievement = new JSONObject
        {
            ["achievement"] = "new level",
        };
        
        new UnlockAchievementEvent(
            userData: "best damage"
        )
            .AddPredefinedParameter(PredefinedString.DESCRIPTION, "best damage")
            .AddPredefinedParameter(PredefinedObject.CONTENT, achievement)
            .Send();
    }
}
```

In examples above `PredefinedParameters.DESCRIPTION` and `PredefinedObject.CONTENT` is used, but many others is available:

| PredefinedParameter                           | Type                   |
|-----------------------------------------------|------------------------|
| [PredefinedString](#predefinedstring)         | string                 |
| [PredefinedLong](#predefinedlong)             | long                   |
| [PredefinedFloat](#predefinedfloat)           | float                  |
| [PredefinedObject](#predefinedobject)         | JSONObject             |
| [PredefinedListObject](#predefinedlistobject) | List&lt;JSONObject&gt; |
| [PredefinedListString](#predefinedliststring) | List&lt;string&gt;     |

### PredefinedString

- `ACHIEVEMENT_ID`
- `ADREV_AD_TYPE`
- `BRAND`
- `BRICK`
- `CAMPAIGN_ID`
- `CATALOGUE_ID`
- `CHANNEL_TYPE`
- `CITY`
- `CLASS`
- `CLICK_ID`
- `CONTENT_ID`
- `CONTENT_NAME`
- `CONTENT_TYPE`
- `CONVERSION_ID`
- `COUNTRY`
- `COUPON_CODE`
- `CURRENCY`
- `CUSTOMER_SEGMENT`
- `CUSTOMER_TYPE`
- `CUSTOMER_USER_ID`
- `DEEP_LINK`
- `DESCRIPTION`
- `DESTINATION_A`
- `DESTINATION_B`
- `DESTINATION_LIST`
- `EVENT_NAME`
- `NEW_VERSION`
- `OLD_VERSION`
- `ORDER_ID`
- `PARAM_01`
- `PARAM_02`
- `PARAM_03`
- `PARAM_04`
- `PARAM_05`
- `PARAM_06`
- `PARAM_07`
- `PARAM_08`
- `PARAM_09`
- `PARAM_10`
- `PAYMENT_INFO_AVAILABLE`
- `PID`
- `PREFERRED_NEIGHBORHOODS`
- `PRODUCT_ID`
- `PRODUCT_NAME`
- `PURCHASE_CURRENCY`
- `RECEIPT_ID`
- `REGION`
- `REGISTRATION_METHOD`
- `REVIEW_TEXT`
- `SEARCH_STRING`
- `SEGMENT`
- `STATUS`
- `SUBSCRIPTION_ID`
- `SUCCESS`
- `SUGGESTED_DESTINATIONS`
- `SUGGESTED_HOTELS`
- `TUTORIAL_ID`
- `UTM_CAMPAIGN`
- `UTM_MEDIUM`
- `UTM_SOURCE`
- `VALIDATED`
- `VERTICAL`
- `VIRTUAL_CURRENCY_NAME`
- `VOUCHER_CODE`

### PredefinedLong

- `AMOUNT`
- `DATE_A`
- `DATE_B`
- `DEPARTING_ARRIVAL_DATE`
- `DEPARTING_DEPARTURE_DATE`
- `HOTEL_SCORE`
- `LEVEL`
- `MAX_RATING_VALUE`
- `NUM_ADULTS`
- `NUM_CHILDREN`
- `NUM_INFANTS`
- `PREFERRED_NUM_STOPS`
- `PREFERRED_STAR_RATINGS`
- `QUANTITY`
- `RATING_VALUE`
- `RETURNING_ARRIVAL_DATE`
- `RETURNING_DEPARTURE_DATE`
- `SCORE`
- `TRAVEL_START`
- `TRAVEL_END`
- `USER_SCORE`
- `EVENT_START`
- `EVENT_END`

### PredefinedFloat

- `PREFERRED_PRICE_RANGE`
- `PRICE`
- `REVENUE`
- `LAT`
- `LONG`

### PredefinedObject

- `CONTENT`

### PredefinedListObject

- `CONTENT_LIST`

### PredefinedListString

- `CONTENT_IDS`

## Events buffering

Affise library will send any pending events with first opportunity,
but if there is no network connection or device is disabled, events are kept locally for 7 days before deletion.

## Push token tracking

To let affise track push token you need to receive it from your push service provider, and pass to Affise library.
First add firebase integration to your app completing these steps: Firebase [iOS](https://firebase.google.com/docs/cloud-messaging/ios/client) or [Android](https://firebase.google.com/docs/cloud-messaging/android/client) Docs

```c#
Affise.AddPushToken(token);
```

## Deeplinks

- register applink callback right after `Affise.Settings(affiseAppId,secretKey).Start()`

```c#
Affise.RegisterDeeplinkCallback((uri) =>
{
    string value = uri.Query.GetValueByKeyExt("<your_uri_key>");
    if (value == "your_uri_key_value") {
        // handle value
    }
    // return true if deeplink is handled successfully
    return true;
});
```

### Android

To integrate deeplink support in android you need:

Add intent filter to `AndroidManifest.xml`. For more info read [Unity docs](https://docs.unity3d.com/Manual/android-manifest.html)

```xml
<intent-filter android:autoVerify="true">
    <action android:name="android.intent.action.VIEW" />
    
    <category android:name="android.intent.category.DEFAULT" />
    <category android:name="android.intent.category.BROWSABLE" />
    
    <data
        android:host="YOUR_DOMAIN"
        android:scheme="unity" />
</intent-filter>
```

### iOS

To integrate deeplink support in iOS you need:

Add key `CFBundleURLTypes` to `Info.plist` file in Xcode project folder

```xml
<key>CFBundleURLTypes</key>
<array>
    <dict>
        <key>CFBundleTypeRole</key>
        <string>Editor</string>
        <key>CFBundleURLName</key>
        <string>YOUR_DOMAIN</string>
        <key>CFBundleURLSchemes</key>
        <array>
            <string>unity</string>
        </array>
    </dict>
</array>
```

## Offline mode

In some scenarios you would want to limit Affise network usage, to pause that activity call anywhere in your application following code after Affise init:

```c#
Affise.SetOfflineModeEnabled(true) // to enable offline mode
Affise.SetOfflineModeEnabled(false) // to disable offline mode
```

While offline mode is enabled, your metrics and other events are kept locally, and will be delivered once offline mode is disabled.
Offline mode is persistent as Application lifecycle, and will be disabled with process termination automatically.
To check current offline mode status call:

```c#
Affise.IsOfflineModeEnabled() // returns true or false describing current tracking state
```

## Disable tracking

To disable any tracking activity, storing events and gathering device identifiers and metrics call anywhere in your application following code after Affise init:

```c#
Affise.SetTrackingEnabled(true) // to enable tracking
Affise.SetTrackingEnabled(false) // to disable tracking
```

By default tracking is enabled.

While tracking mode is disabled, metrics and other identifiers is not generated locally.
Keep in mind that this flag is persistent until app reinstall, and don't forget to reactivate tracking when needed.
To check current status of tracking call:

```c#
Affise.IsTrackingEnabled() // returns true or false describing current tracking state
```

## Disable background tracking

To disable any background tracking activity, storing events and gathering device identifiers and metrics call anywhere in your application following code after Affise init:

```c#
Affise.SetBackgroundTrackingEnabled(true) // to enable background tracking
Affise.SetBackgroundTrackingEnabled(false) // to disable background tracking
```

By default background tracking is enabled.

While background tracking mode is disabled, metrics and other identifiers is not generated locally.
Background tracking mode is persistent as Application lifecycle, and will be re-enabled with process termination automatically.
To check current status of background tracking call:

```c#
Affise.IsBackgroundTrackingEnabled() // returns true or false describing current background tracking state
```

## Get random user Id

```c#
Affise.GetRandomUserId();
```

## Get random device Id

```c#
Affise.GetRandomDeviceId();
```

## Get providers

Returns providers map with [ProviderType](#providertype-identifiers-collection) as key

```c#
var providers = Affise.GetProviders();
var key = ProviderType.AFFISE_APP_TOKEN;
if (providers.ContainsKey(key)) {
    var value = providers[key];
}
```

## Get module state

```C#
Affise.GetStatus(AffiseModules.Status, response => {
    // handle response
});
```

## Platform specific

### Get referrer

> `Android Only`

> **Warning**
>
> 🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧
>
> Don't call this method directly in `Awake()` it may cause `NullReferenceException`
>
> 🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧

Use the next public method of SDK to get referrer

```C#
Affise.Android.GetReferrer(referrer => {
    // handle referrer
});
```

### Get referrer value

> `Android Only`

Use the next public method of SDK to get referrer value by

```C#
Affise.Android.GetReferrerValue(ReferrerKey.CLICK_ID, referrer => {
    // handle referrer value
});
```

#### Referrer keys

In examples above `ReferrerKey.CLICK_ID` is used, but many others is available:

- `AD_ID`
- `CAMPAIGN_ID`
- `CLICK_ID`
- `AFFISE_AD`
- `AFFISE_AD_ID`
- `AFFISE_AD_TYPE`
- `AFFISE_ADSET`
- `AFFISE_ADSET_ID`
- `AFFISE_AFFC_ID`
- `AFFISE_CHANNEL`
- `AFFISE_CLICK_LOOK_BACK`
- `AFFISE_COST_CURRENCY`
- `AFFISE_COST_MODEL`
- `AFFISE_COST_VALUE`
- `AFFISE_DEEPLINK`
- `AFFISE_KEYWORDS`
- `AFFISE_MEDIA_TYPE`
- `AFFISE_MODEL`
- `AFFISE_OS`
- `AFFISE_PARTNER`
- `AFFISE_REF`
- `AFFISE_SITE_ID`
- `AFFISE_SUB_SITE_ID`
- `AFFC`
- `PID`
- `SUB_1`
- `SUB_2`
- `SUB_3`
- `SUB_4`
- `SUB_5`

### StoreKit Ad Network

> `iOS Only`

For ios prior `16.1` first call

```C#
Affise.IOS.RegisterAppForAdNetworkAttribution(error =>
{
    // Handle error
});
```

Updates the fine and coarse conversion values, and calls a completion handler if the update fails.
Second argument coarseValue is available in iOS 16.1+

```C#
Affise.IOS.UpdatePostbackConversionValue(1, SKAdNetwork.CoarseConversionValue.Medium, error =>
{
    // Handle error
});
```

Configure your app to send postback copies to Affise:

Add key `NSAdvertisingAttributionReportEndpoint` to project `Info.plist`
Set key value to `https://affise-skadnetwork.com/`

```xml
<key>CFBundleURLTypes</key>
<array>
    <dict>
      <key>NSAdvertisingAttributionReportEndpoint</key>
      <string>https://affise-skadnetwork.com/</string>
    </dict>
</array>
```

# SDK to SDK integrations

```c#
// Send AdRevenue info
new AffiseAdRevenue(AffiseAdSource.ADMOB)
        .SetRevenue(2.5f, "ImpressionData_Currency")
        .SetNetwork("ImpressionData_Network")
        .SetUnit("ImpressionData_Unit")
        .SetPlacement("ImpressionData_Placement")
        .Send();
```

# Debug

## Validate credentials

> **Warning**
>
> 🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥
>
> Debug methods WON'T work on Production 
>
> 🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥

Validate your credentials by receiving `ValidationStatus` values:

- `VALID` - your credentials are valid
- `INVALID_APP_ID` - your app id is not valid 
- `INVALID_SECRET_KEY` - your SDK secretKey is not valid
- `PACKAGE_NAME_NOT_FOUND` - your application package name not found
- `NOT_WORKING_ON_PRODUCTION` - you using debug method on production
- `NETWORK_ERROR` - network or server not available (for example `Airoplane mode` is active)

```c#
Affise
    .Settings(
        affiseAppId: "Your appId",
        secretKey: "Your SDK secretKey"
    )
    .SetProduction(false) //To enable debug methods set Production to false
    .Start(); // Start Affise SDK

Affise.Debug.Validate(status =>
{
    // Handle validation status
});
```

# Troubleshoots

## iOS

> **Warning**
>
> 🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥
>
> This app has crashed because it attempted to access privacy-sensitive data without a usage description.
>
> The app's `Info.plist` must contain an `NSUserTrackingUsageDescription` key with a string value explaining
>
> to the user how the app uses this data.
>
> 🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥🟥

Open `info.plist` and add key `NSUserTrackingUsageDescription` with string value. For more information [read requirements](#requirements)
