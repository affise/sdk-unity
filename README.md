# Affise Unity package

- [Affise Unity package](#affise-unity-package)
- [Description](#description)
  - [Quick start](#quick-start)
  - [Integration](#integration)
    - [Integrate unity package](#integrate-unity-package)
    - [Initialize](#initialize)
- [Features](#features)
  - [Device identifiers collection](#device-identifiers-collection)
  - [Events tracking](#events-tracking)
    - [Custom events tracking](#custom-events-tracking)
  - [Predefined event parameters](#predefined-event-parameters)
  - [Deeplinks](#deeplinks)
    - [Android](#android)
  - [Platform specific](#platform-specific)
    - [Get referrer](#get-referrer)

# Description

Affise SDK is a software you can use to collect app usage statistics, device identifiers, deeplink usage, track install
referrer.

## Quick start

## Integration

### Integrate unity package

Open Package Manager(`Window / Package Manager`)

Add package from git url `https://github.com/affise/sdk-unity.git`

![after_step_1](https://user-images.githubusercontent.com/10216417/170314456-4af5bed8-15a4-4ea8-bd2c-e7a74cefd0e1.jpg)

![after_step_2](https://user-images.githubusercontent.com/10216417/184088446-f4ae23c7-0287-41e6-a666-7aee34f0e57b.jpg)

### Initialize

After package is added to unity project, initialize affise settings.

Open Project Settings(`Edit / Project Settings`)

On Affise tab click `Create` button.

![after_step_3](https://user-images.githubusercontent.com/10216417/170314553-51b2c8dd-eb82-4c2e-8d72-28464fb943ac.jpg)

This will create `Affise Settings.asset` in `Assets / Affise / Resources` directory.

> Affise is using settings file with exact name `Affise Settings.asset`
>
> in root of folder `Resources` which can be located in any folder
>
> `<Any folder> / Resources`
>
> except `Editor` folder

Fill all required fields

![after_step_4](https://user-images.githubusercontent.com/10216417/184090017-dc32c837-f78f-4e13-92d6-8fa794a1eb90.jpg)

# Features

## Device identifiers collection

To match users with events and data library is sending, these identifiers are collected:

- `AFFISE_APP_ID`
- `AFFISE_PKG_APP_NAME`
- `APP_VERSION`
- `APP_VERSION_RAW`
- `FIRST_OPEN_TIME`
- `CREATED_TIME`
- `CREATED_TIME_MILLI`
- `CREATED_TIME_HOUR`
- `CPU_TYPE`
- `HARDWARE_NAME`
- `AFFISE_DEVICE_ID`
- `AFFISE_ALT_DEVICE_ID`
- `DEVICE_NAME`
- `DEVICE_TYPE`
- `OS_NAME`
- `PLATFORM`
- `AFFISE_PART_PARAM_NAME`
- `AFFISE_PART_PARAM_NAME_TOKEN`
- `AFFISE_APP_TOKEN`
- `AFFISE_EVENTS_COUNT`
- `AFFISE_SDK_EVENTS_COUNT`

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
        Affise.SendEvent(new UnlockAchievementEvent(achievement, DateTime.UtcNow.GetTimeInMillis(), "best damage"));
    }
}
```

With above example you can implement other events:

- `AchieveLevelEvent`
- `AddPaymentInfoEvent`
- `AddToCartEvent`
- `AddToWishlistEvent`
- `ClickAdvEvent`
- `CompleteRegistrationEvent`
- `CompleteStreamEvent`
- `CompleteTrialEvent`
- `CompleteTutorialEvent`
- `ContentItemsViewEvent`
- `DeepLinkedEvent`
- `InitiatePurchaseEvent`
- `InitiateStreamEvent`
- `InviteEvent`
- `LastAttributedTouchEvent`
- `ListViewEvent`
- `LoginEvent`
- `OpenedFromPushNotificationEvent`
- `PurchaseEvent`
- `RateEvent`
- `ReEngageEvent`
- `ReserveEvent`
- `SalesEvent`
- `SearchEvent`
- `ShareEvent`
- `SpendCreditsEvent`
- `StartRegistrationEvent`
- `StartTrialEvent`
- `StartTutorialEvent`
- `SubscribeEvent`
- `TravelBookingEvent`
- `UnlockAchievementEvent`
- `UnsubscribeEvent`
- `UpdateEvent`
- `ViewAdvEvent`
- `ViewCartEvent`
- `ViewItemEvent`
- `ViewItemsEvent`

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
        var achievementEvent = new UnlockAchievementEvent(
            achievement: new JSONObject
            {
                ["achievement"] = "new level",
            },
            timeStampMillis: DateTime.UtcNow.GetTimeInMillis(),
            userData: "best damage"
        );

        achievementEvent.AddPredefinedParameter(PredefinedParameters.DESCRIPTION, "best damage");

        Affise.SendEvent(achievementEvent);
    }
}
```

In examples above `PredefinedParameters.DESCRIPTION` is used, but many others is available:

- `ADREV_AD_TYPE`,
- `CITY`,
- `COUNTRY`,
- `REGION`,
- `CLASS`,
- `CONTENT`,
- `CONTENT_ID`,
- `CONTENT_LIST`,
- `CONTENT_TYPE`,
- `CURRENCY`,
- `CUSTOMER_USER_ID`,
- `DATE_A`,
- `DATE_B`,
- `DEPARTING_ARRIVAL_DATE`,
- `DEPARTING_DEPARTURE_DATE`,
- `DESCRIPTION`,
- `DESTINATION_A`,
- `DESTINATION_B`,
- `DESTINATION_LIST`,
- `HOTEL_SCORE`,
- `LEVEL`,
- `MAX_RATING_VALUE`,
- `NUM_ADULTS`,
- `NUM_CHILDREN`,
- `NUM_INFANTS`,
- `ORDER_ID`,
- `PAYMENT_INFO_AVAILABLE`,
- `PREFERRED_NEIGHBORHOODS`,
- `PREFERRED_NUM_STOPS`,
- `PREFERRED_PRICE_RANGE`,
- `PREFERRED_STAR_RATINGS`,
- `PRICE`,
- `PURCHASE_CURRENCY`,
- `QUANTITY`,
- `RATING_VALUE`,
- `RECEIPT_ID`,
- `REGISTRATION_METHOD`,
- `RETURNING_ARRIVAL_DATE`,
- `RETURNING_DEPARTURE_DATE`,
- `REVENUE`,
- `SCORE`,
- `SEARCH_STRING`,
- `SUBSCRIPTION_ID`,
- `SUCCESS`,
- `SUGGESTED_DESTINATIONS`,
- `SUGGESTED_HOTELS`,
- `TRAVEL_START`,
- `TRAVEL_END`,
- `USER_SCORE`,
- `VALIDATED`,
- `ACHIEVEMENT_ID`,
- `COUPON_CODE`,
- `CUSTOMER_SEGMENT`,
- `DEEP_LINK`,
- `EVENT_START`,
- `EVENT_END`,
- `LAT`,
- `LONG`,
- `NEW_VERSION`,
- `OLD_VERSION`,
- `PARAM_01`,
- `PARAM_02`,
- `PARAM_03`,
- `PARAM_04`,
- `PARAM_05`,
- `PARAM_06`,
- `PARAM_07`,
- `PARAM_08`,
- `PARAM_09`,
- `PARAM_10`,
- `REVIEW_TEXT`,
- `TUTORIAL_ID`,
- `VIRTUAL_CURRENCY_NAME`

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

## Platform specific

### Get referrer

> `Android Only`

> :warning: Don't call this method directly in `Awake()` it may cause `NullReferenceException`

Use the next public method of SDK to get referrer

```C#
Affise.Android.GetReferrer(referrer => {
    // handle referrer
});
```
