# Affise Unity package

| Artifact | Version |
| -------- | ------- |
| attribution  | [1.6.1](/releases) |

- [Affise Unity package](#affise-unity-package)
- [Description](#description)
  - [Quick start](#quick-start)
  - [Integration](#integration)
    - [Integrate unity package](#integrate-unity-package)
    - [Integrate unitypackage file](#integrate-unitypackage-file)
    - [Initialize](#initialize)
  - [Build](#build)
    - [iOS](#ios)
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
    - [Android](#android)
  - [Get random user Id](#get-random-user-id)
  - [Get random device Id](#get-random-device-id)
  - [Get module state](#get-module-state)
  - [Platform specific](#platform-specific)
    - [Get referrer](#get-referrer)
    - [Get referrer value](#get-referrer-value)
      - [Referrer keys](#referrer-keys)
- [Troubleshoots](#troubleshoots)
  - [iOS](#ios-1)

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

Download latest Affise SDK [`attribution-1.6.1.unitypackage`](https://github.com/affise/sdk-unity/releases/download/1.6.1/attribution-1.6.1.unitypackage)
from [releases page](https://github.com/affise/sdk-unity/releases) and drop this file to unity editor

### Initialize

After package is added to unity project, initialize affise settings.

Open Project Settings(`Edit / Project Settings`)

On Affise tab click `Create` button.

![affise_settings_new](https://github.com/affise/sdk-unity/blob/assets/affise_settings_new.png?raw=true)

This will create `Affise Settings.asset` in `Assets / Affise / Resources` directory.

> Affise is using settings file with exact name `Affise Settings.asset`
>
> in root of folder `Resources` which can be located in any folder
>
> `<Any folder> / Resources`
>
> except `Editor` folder

Fill all required fields

![affise_settings](https://github.com/affise/sdk-unity/blob/assets/affise_settings.png?raw=true)

## Build

### iOS

SDK is using Cocoapods

1. In `Build setting` select iOS platform and press `Build`
2. Select build folder (unity will exported iOS projetc to build folder)
3. Build folder should contain `Podfile`
4. In Terminal open build folder and run commend `pod update` or `pod install`
5. Open genereated `*.worksapce` to build your unity project

If Podfile hasn't generated you can create it manually using this [Podfile](Editor/Resources/iOS/AffisePodfile.rb) as template

Podfile:

```rb
platform :ios, '11.0'

target 'UnityFramework' do
   pod 'AffiseInternal', '~> 1.6.2'
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

        var event = new UnlockAchievementEvent("best damage");
        
        event.AddPredefinedParameter(PredefinedLong.USER_SCORE, 12552L);
        evtnt.AddPredefinedParameter(PredefinedString.ACHIEVEMENT_ID, "1334-1225-ASDZ");
        event.AddPredefinedParameter(PredefinedObject.CONTENT, achievement);

        Affise.SendEvent(event);
    }
}
```

With above example you can implement other events:

- `AchieveLevel`
- `AddPaymentInfo`
- `AddToCart`
- `AddToWishlist`
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
        
        var event = new UnlockAchievementEvent(
            userData: "best damage",
            timeStampMillis: DateTime.UtcNow.GetTimeInMillis()
        );

        event.AddPredefinedParameter(PredefinedString.DESCRIPTION, "best damage");
        event.AddPredefinedParameter(PredefinedObject.CONTENT, achievement);

        Affise.SendEvent(event);
    }
}
```

In examples above `PredefinedParameters.DESCRIPTION` and `PredefinedObject.CONTENT` is used, but many others is available:

| PredefinedParameter                           | Type                  |
|-----------------------------------------------|-----------------------|
| [PredefinedString](#predefinedstring)         | string                |
| [PredefinedLong](#predefinedlong)             | long                  |
| [PredefinedFloat](#predefinedfloat)           | float                 |
| [PredefinedObject](#predefinedobject)         | JSONObject            |
| [PredefinedListObject](#predefinedlistobject) | List&lt;JSONObject&gt; |
| [PredefinedListString](#predefinedliststring) | List&lt;string&gt;     |

### PredefinedString

- `ADREV_AD_TYPE`
- `CITY`
- `COUNTRY`
- `REGION`
- `CLASS`
- `CONTENT_ID`
- `CONTENT_TYPE`
- `CURRENCY`
- `CUSTOMER_USER_ID`
- `DESCRIPTION`
- `DESTINATION_A`
- `DESTINATION_B`
- `DESTINATION_LIST`
- `ORDER_ID`
- `PAYMENT_INFO_AVAILABLE`
- `PREFERRED_NEIGHBORHOODS`
- `PURCHASE_CURRENCY`
- `RECEIPT_ID`
- `REGISTRATION_METHOD`
- `SEARCH_STRING`
- `SUBSCRIPTION_ID`
- `SUCCESS`
- `SUGGESTED_DESTINATIONS`
- `SUGGESTED_HOTELS`
- `VALIDATED`
- `ACHIEVEMENT_ID`
- `COUPON_CODE`
- `CUSTOMER_SEGMENT`
- `DEEP_LINK`
- `NEW_VERSION`
- `OLD_VERSION`
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
- `REVIEW_TEXT`
- `TUTORIAL_ID`
- `VIRTUAL_CURRENCY_NAME`
- `STATUS`

### PredefinedLong

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
First add firebase integration to your app completing theese steps: Firebase [iOS](https://firebase.google.com/docs/cloud-messaging/ios/client) or [Android](https://firebase.google.com/docs/cloud-messaging/android/client) Docs

## Deeplinks

- register applink callback right after Affise.init(..)

```c#
RegisterDeeplinkCallback((uri) =>
{
    string screen = uri.Query.GetValueByKeyExt("");
    if (screen == "special_offer") {
        // open special offer screen
    } else {
        // open another activity
    }
    // return true if deeplink is handled successfully
    return true;
});
```

### Android

To integrate applink support you need:

- add intent filter to one of your activities, replacing YOUR_AFFISE_APP_ID with id from your affise personal cabinet

```xml
<intent-filter android:autoVerify="true">
  <action android:name="android.intent.action.VIEW" />
  <category android:name="android.intent.category.DEFAULT" />
  <category android:name="android.intent.category.BROWSABLE" />
  <data android:scheme="https" />
  <data android:host="YOUR_AFFISE_APP_ID.affattr.com" />
</intent-filter>
```

## Get random user Id

Use the next public method of SDK

```c#
Affise.GetRandomUserId();
```

## Get random device Id

Use the next public method of SDK

```c#
Affise.GetRandomDeviceId();
```

## Get module state

> Implemented for `Android`

```C#
Affise.GetStatus(AffiseModules.Status, response => {
    // handle response
});
```

## Platform specific

### Get referrer

> `Android Only`

> **Warning** Don't call this method directly in `Awake()` it may cause `NullReferenceException`

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

# Troubleshoots

## iOS

> This app has crashed because it attempted to access privacy-sensitive data without a usage description.
> The app's Info.plist must contain an NSUserTrackingUsageDescription key with a string value explaining
> to the user how the app uses this data.

Open info.plist and add key `NSUserTrackingUsageDescription` with string value
