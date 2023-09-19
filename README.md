# Affise Unity package

| Artifact      | Version              |
|---------------|----------------------|
| `attribution` | [`1.6.5`](/releases) |

- [Affise Unity package](#affise-unity-package)
- [Description](#description)
  - [Quick start](#quick-start)
  - [Integration](#integration)
    - [Integrate unity package](#integrate-unity-package)
    - [Integrate unitypackage file](#integrate-unitypackage-file)
    - [Initialize](#initialize)
      - [Unity asset](#unity-asset)
      - [Manual](#manual)
    - [Add platform modules](#add-platform-modules)
      - [Android](#android)
      - [iOS](#ios)
  - [Build](#build)
    - [iOS](#ios-1)
- [Features](#features)
  - [Device identifiers collection](#device-identifiers-collection)
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
    - [iOS](#ios-2)
  - [Get random user Id](#get-random-user-id)
  - [Get random device Id](#get-random-device-id)
  - [Get module state](#get-module-state)
  - [Platform specific](#platform-specific)
    - [Get referrer](#get-referrer)
    - [Get referrer value](#get-referrer-value)
      - [Referrer keys](#referrer-keys)
    - [StoreKit Ad Network](#storekit-ad-network)
- [SDK to SDK integrations](#sdk-to-sdk-integrations)
- [Troubleshoots](#troubleshoots)
  - [iOS](#ios-3)

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

Download latest Affise SDK [`attribution-1.6.5.unitypackage`](https://github.com/affise/sdk-unity/releases/download/1.6.5/attribution-1.6.5.unitypackage)
from [releases page](https://github.com/affise/sdk-unity/releases) and drop this file to unity editor

### Initialize

#### Unity asset

After package is added to unity project, initialize affise settings.

Open Project Settings(`Edit / Project Settings`)

On Affise tab click `Create` button.

![affise_settings_new](https://github.com/affise/sdk-unity/blob/assets/affise_settings_new.png?raw=true)

This will create `Affise Settings.asset` in `Assets / Affise / Resources` directory.

> **Note**
> Settings set in `Edit / Project Settings / Affise` are marked as `Active Settings`
>
> Affise is using settings marked as `Active Settings`
>
> located in root of folder `Resources` which can be located in any folder
>
> Example `<Any folder> / Resources / <Your affise settings>.asset`

> **Warning**
> Settings located in `Editor` folder are **invalid**. Example: `Editor / Resources / <Your affise settings>.asset`

Fill all required fields

![affise_settings](https://github.com/affise/sdk-unity/blob/assets/affise_settings.png?raw=true)

#### Manual

> Demo app [AffiseDemo.cs](Samples~/AffiseDemoApp/Scripts/AffiseDemo.cs)

```c#
var properties = new AffiseInitProperties(
    affiseAppId: "Your appId", //Change to your app id
    secretKey: "Your SDK secretKey" //Change to your SDK secretKey
);
Affise.Init(properties);
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
  implementation 'com.affise:module-advertising:1.6.+'
  implementation 'com.affise:module-network:1.6.+'
  implementation 'com.affise:module-phone:1.6.+'
  implementation 'com.affise:module-status:1.6.+'
}
```

#### iOS

Open `Podfile` in XCode project folder

Add modules to iOS project

| Module                | Version  |
|-----------------------|:--------:|
| `AffiseModule/Status` | `1.6.11` |

```rb
platform :ios, '11.0'

target 'UnityFramework' do
  pod 'AffiseInternal', '~> 1.6.11'

  # Affise Modules
  pod 'AffiseModule/Status', `~> 1.6.11`
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
4. In Terminal open build folder and run commend `pod update` or `pod install`
5. Open generated `*.worksapce` to build your unity project

If Podfile hasn't generated you can create it manually using this [Podfile](Editor/Resources/iOS/AffisePodfile.rb) as template

Podfile:

```rb
platform :ios, '11.0'

target 'UnityFramework' do
  pod 'AffiseInternal', '~> 1.6.11'

  # Affise Modules
  # pod 'AffiseModule/Status', `~> 1.6.11`
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
```

# Features

## Device identifiers collection

To match users with events and data library is sending, these identifiers are collected:

- `AFFISE_APP_ID`
- `AFFISE_PKG_APP_NAME`
- `APP_VERSION`
- `APP_VERSION_RAW`
- `STORE`
- `INSTALLED_TIME`
- `FIRST_OPEN_TIME`
- `INSTALLED_HOUR`
- `FIRST_OPEN_HOUR`
- `INSTALL_BEGIN_TIME`
- `INSTALL_FINISH_TIME`
- `REFERRAL_TIME`
- `CREATED_TIME`
- `CREATED_TIME_MILLI`
- `CREATED_TIME_HOUR`
- `LAST_SESSION_TIME`
- `CONNECTION_TYPE`
- `CPU_TYPE`
- `HARDWARE_NAME`
- `NETWORK_TYPE`
- `DEVICE_MANUFACTURER`
- `PROXY_IP_ADDRESS`
- `DEEPLINK_CLICK`
- `DEVICE_ATLAS_ID`
- `AFFISE_DEVICE_ID`
- `AFFISE_ALT_DEVICE_ID`
- `ADID`
- `ANDROID_ID`
- `ANDROID_ID_MD5`
- `MAC_SHA1`
- `MAC_MD5`
- `GAID_ADID`
- `GAID_ADID_MD5`
- `OAID`
- `OAID_MD5`
- `REFTOKEN`
- `REFTOKENS`
- `REFERRER`
- `USER_AGENT`
- `MCCODE`
- `MNCODE`
- `ISP`
- `REGION`
- `COUNTRY`
- `LANGUAGE`
- `DEVICE_NAME`
- `DEVICE_TYPE`
- `OS_NAME`
- `PLATFORM`
- `API_LEVEL_OS`
- `AFFISE_SDK_VERSION`
- `OS_VERSION`
- `RANDOM_USER_ID`
- `AFFISE_SDK_POS`
- `TIMEZONE_DEV`
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
- `EVENTS`
- `AFFISE_EVENTS_COUNT`

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

        var anlockAchievement = new UnlockAchievementEvent("best damage");
        
        anlockAchievement
          .AddPredefinedParameter(PredefinedLong.USER_SCORE, 12552L)
          .AddPredefinedParameter(PredefinedString.ACHIEVEMENT_ID, "1334-1225-ASDZ")
          .AddPredefinedParameter(PredefinedObject.CONTENT, achievement);

        Affise.SendEvent(anlockAchievement);
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
        
        var anlockAchievement = new UnlockAchievementEvent(
            userData: "best damage",
            timeStampMillis: DateTime.UtcNow.GetTimeInMillis()
        );

        anlockAchievement
          .AddPredefinedParameter(PredefinedString.DESCRIPTION, "best damage")
          .AddPredefinedParameter(PredefinedObject.CONTENT, achievement);

        Affise.SendEvent(anlockAchievement);
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

## Deeplinks

- register applink callback right after Affise.Init(..)

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
        android:host="YOUR_AFFISE_APP_ID.affattr.com"
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
        <string>YOUR_AFFISE_APP_ID.affattr.com</string>
        <key>CFBundleURLSchemes</key>
        <array>
            <string>unity</string>
        </array>
    </dict>
</array>
```

## Get random user Id

```c#
Affise.GetRandomUserId();
```

## Get random device Id

```c#
Affise.GetRandomDeviceId();
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
> Don't call this method directly in `Awake()` it may cause `NullReferenceException`

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

# Troubleshoots

## iOS

> **Warning**
> This app has crashed because it attempted to access privacy-sensitive data without a usage description.
> The app's `Info.plist` must contain an `NSUserTrackingUsageDescription` key with a string value explaining
> to the user how the app uses this data.

Open `info.plist` and add key `NSUserTrackingUsageDescription` with string value
