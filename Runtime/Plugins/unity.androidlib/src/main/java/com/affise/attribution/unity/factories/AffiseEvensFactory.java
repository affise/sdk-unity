package com.affise.attribution.unity.factories;

import com.affise.attribution.events.Event;
import com.affise.attribution.events.predefined.AchieveLevelEvent;
import com.affise.attribution.events.predefined.AddPaymentInfoEvent;
import com.affise.attribution.events.predefined.AddToCartEvent;
import com.affise.attribution.events.predefined.AddToWishlistEvent;
import com.affise.attribution.events.predefined.ClickAdvEvent;
import com.affise.attribution.events.predefined.CompleteRegistrationEvent;
import com.affise.attribution.events.predefined.CompleteStreamEvent;
import com.affise.attribution.events.predefined.CompleteTrialEvent;
import com.affise.attribution.events.predefined.CompleteTutorialEvent;
import com.affise.attribution.events.predefined.ContentItemsViewEvent;
import com.affise.attribution.events.predefined.CustomId01Event;
import com.affise.attribution.events.predefined.CustomId02Event;
import com.affise.attribution.events.predefined.CustomId03Event;
import com.affise.attribution.events.predefined.CustomId04Event;
import com.affise.attribution.events.predefined.CustomId05Event;
import com.affise.attribution.events.predefined.CustomId06Event;
import com.affise.attribution.events.predefined.CustomId07Event;
import com.affise.attribution.events.predefined.CustomId08Event;
import com.affise.attribution.events.predefined.CustomId09Event;
import com.affise.attribution.events.predefined.CustomId10Event;
import com.affise.attribution.events.predefined.DeepLinkedEvent;
import com.affise.attribution.events.predefined.InitiatePurchaseEvent;
import com.affise.attribution.events.predefined.InitiateStreamEvent;
import com.affise.attribution.events.predefined.InviteEvent;
import com.affise.attribution.events.predefined.LastAttributedTouchEvent;
import com.affise.attribution.events.predefined.ListViewEvent;
import com.affise.attribution.events.predefined.LoginEvent;
import com.affise.attribution.events.predefined.OpenedFromPushNotificationEvent;
import com.affise.attribution.events.predefined.PurchaseEvent;
import com.affise.attribution.events.predefined.RateEvent;
import com.affise.attribution.events.predefined.ReEngageEvent;
import com.affise.attribution.events.predefined.ReserveEvent;
import com.affise.attribution.events.predefined.SalesEvent;
import com.affise.attribution.events.predefined.SearchEvent;
import com.affise.attribution.events.predefined.ShareEvent;
import com.affise.attribution.events.predefined.SpendCreditsEvent;
import com.affise.attribution.events.predefined.StartRegistrationEvent;
import com.affise.attribution.events.predefined.StartTrialEvent;
import com.affise.attribution.events.predefined.StartTutorialEvent;
import com.affise.attribution.events.predefined.SubscribeEvent;
import com.affise.attribution.events.predefined.TouchType;
import com.affise.attribution.events.predefined.TravelBookingEvent;
import com.affise.attribution.events.predefined.UnlockAchievementEvent;
import com.affise.attribution.events.predefined.UnsubscribeEvent;
import com.affise.attribution.events.predefined.UpdateEvent;
import com.affise.attribution.events.predefined.ViewAdvEvent;
import com.affise.attribution.events.predefined.ViewCartEvent;
import com.affise.attribution.events.predefined.ViewItemEvent;
import com.affise.attribution.events.predefined.ViewItemsEvent;
import com.affise.attribution.events.subscription.SubscriptionParameters;
import com.affise.attribution.unity.ext.TouchTypeExt;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.List;

public class AffiseEvensFactory extends AffiseBaseEvensFactory {

    private static final String TAG = "!aff";

    private final AffiseSubtypeEventsFactory subscriptionEventsFactory = new AffiseSubtypeEventsFactory();

    @Override
    public Event event(JSONObject json) {
        switch (json.optString(KEY_NAME)) {
            case "AchieveLevel":
                return eventAchieveLevelEvent(json);
            case "AddPaymentInfo":
                return eventAddPaymentInfoEvent(json);
            case "AddToCart":
                return eventAddToCartEvent(json);
            case "AddToWishlist":
                return eventAddToWishlistEvent(json);
            case "ClickAdv":
                return eventClickAdv(json);
            case "CompleteRegistration":
                return eventCompleteRegistrationEvent(json);
            case "CompleteStream":
                return eventCompleteStreamEvent(json);
            case "CompleteTrial":
                return eventCompleteTrialEvent(json);
            case "CompleteTutorial":
                return eventCompleteTutorialEvent(json);
            case "ContentItemsView":
                return eventContentItemsViewEvent(json);
            case "CustomId01":
                return eventCustomId01Event(json);
            case "CustomId02":
                return eventCustomId02Event(json);
            case "CustomId03":
                return eventCustomId03Event(json);
            case "CustomId04":
                return eventCustomId04Event(json);
            case "CustomId05":
                return eventCustomId05Event(json);
            case "CustomId06":
                return eventCustomId06Event(json);
            case "CustomId07":
                return eventCustomId07Event(json);
            case "CustomId08":
                return eventCustomId08Event(json);
            case "CustomId09":
                return eventCustomId09Event(json);
            case "CustomId10":
                return eventCustomId10Event(json);
            case "DeepLinked":
                return eventDeepLinkedEvent(json);
            case "InitiatePurchase":
                return eventInitiatePurchaseEvent(json);
            case "InitiateStream":
                return eventInitiateStreamEvent(json);
            case "Invite":
                return eventInviteEvent(json);
            case "LastAttributedTouch":
                return eventLastAttributedTouchEvent(json);
            case "ListView":
                return eventListViewEvent(json);
            case "Login":
                return eventLoginEvent(json);
            case "OpenedFromPushNotification":
                return eventOpenedFromPushNotificationEvent(json);
            case "Purchase":
                return eventPurchaseEvent(json);
            case "Rate":
                return eventRateEvent(json);
            case "ReEngage":
                return eventReEngageEvent(json);
            case "Reserve":
                return eventReserveEvent(json);
            case "Sales":
                return eventSalesEvent(json);
            case "Search":
                return eventSearchEvent(json);
            case "Share":
                return eventShareEvent(json);
            case "SpendCredits":
                return eventSpendCreditsEvent(json);
            case "StartRegistration":
                return eventStartRegistrationEvent(json);
            case "StartTrial":
                return eventStartTrialEvent(json);
            case "StartTutorial":
                return eventStartTutorialEvent(json);
            case "Subscribe":
                return eventSubscribeEvent(json);
            case "TravelBooking":
                return eventTravelBookingEvent(json);
            case "UnlockAchievement":
                return eventUnlockAchievementEvent(json);
            case "Unsubscribe":
                return eventUnsubscribeEvent(json);
            case "Update":
                return eventUpdateEvent(json);
            case "ViewAdv":
                return eventViewAdvEvent(json);
            case "ViewCart":
                return eventViewCartEvent(json);
            case "ViewItem":
                return eventViewItemEvent(json);
            case "ViewItems":
                return eventViewItemsEvent(json);
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_ACTIVATION:
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_CANCELLATION:
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY:
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_FIRST_CONVERSION:
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_REACTIVATION:
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL:
            case SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY:
                return subscriptionEventsFactory.event(json);
        }

        return null;
    }

    private Event eventAchieveLevelEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_achieve_level_timestamp"
        );
        JSONObject level = getJSONObject(json, "affise_event_achieve_level");
        Event event = new AchieveLevelEvent(level, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventAddPaymentInfoEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_add_payment_info_timestamp"
        );
        JSONObject paymentInfo = getJSONObject(json, "affise_event_add_payment_info");
        Event event = new AddPaymentInfoEvent(paymentInfo, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventAddToCartEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_add_to_cart_timestamp"
        );
        JSONObject addToCartObject = getJSONObject(json, "affise_event_add_to_cart");
        Event event = new AddToCartEvent(addToCartObject, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventAddToWishlistEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_add_to_wishlist_timestamp"
        );
        JSONObject wishList = getJSONObject(json, "affise_event_add_to_wishlist");
        Event event = new AddToWishlistEvent(wishList, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventClickAdv(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_click_adv_timestamp"
        );
        String advertisement = getSerializeString(json, "affise_event_click_adv");
        Event event = new ClickAdvEvent(advertisement, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCompleteRegistrationEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_complete_registration_timestamp"
        );
        JSONObject registration = getJSONObject(json, "affise_event_complete_registration");
        Event event = new CompleteRegistrationEvent(registration, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCompleteStreamEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_complete_stream_timestamp"
        );
        JSONObject stream = getJSONObject(json, "affise_event_complete_stream");
        Event event = new CompleteStreamEvent(stream, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCompleteTrialEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_complete_trial_timestamp"
        );
        JSONObject trial = getJSONObject(json, "affise_event_complete_trial");
        Event event = new CompleteTrialEvent(trial, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCompleteTutorialEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_complete_tutorial_timestamp"
        );
        JSONObject tutorial = getJSONObject(json, "affise_event_complete_tutorial");
        Event event = new CompleteTutorialEvent(tutorial, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventContentItemsViewEvent(JSONObject json) {
        String userData = getUserData(json);
        List<JSONObject> objects = getJsonList(json, "affise_event_content_items_view");
        Event event = new ContentItemsViewEvent(objects, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId01Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_01_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_01");
        Event event = new CustomId01Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId02Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_02_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_02");
        Event event = new CustomId02Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId03Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_03_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_03");
        Event event = new CustomId03Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId04Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_04_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_04");
        Event event = new CustomId04Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId05Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_05_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_05");
        Event event = new CustomId05Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId06Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_06_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_06");
        Event event = new CustomId06Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId07Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_07_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_07");
        Event event = new CustomId07Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId08Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_08_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_08");
        Event event = new CustomId08Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId09Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_09_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_09");
        Event event = new CustomId09Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventCustomId10Event(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_custom_id_10_timestamp"
        );
        String custom = getSerializeString(json, "affise_event_custom_id_10");
        Event event = new CustomId10Event(custom, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventDeepLinkedEvent(JSONObject json) {
        String userData = getUserData(json);
        boolean isLinked = getSerializeBoolean(json, "affise_event_deep_linked");
        Event event = new DeepLinkedEvent(isLinked, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventInitiatePurchaseEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_initiate_purchase_timestamp"
        );
        JSONObject purchaseData = getJSONObject(json, "affise_event_initiate_purchase");
        Event event = new InitiatePurchaseEvent(purchaseData, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventInitiateStreamEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_initiate_stream_timestamp"
        );
        JSONObject stream = getJSONObject(json, "affise_event_initiate_stream");
        Event event = new InitiateStreamEvent(stream, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventInviteEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_invite_timestamp"
        );
        JSONObject invite = getJSONObject(json, "affise_event_invite");
        Event event = new InviteEvent(invite, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventLastAttributedTouchEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_last_attributed_touch_timestamp"
        );
        String type = getSerializeString(json, "affise_event_last_attributed_touch_type");
        TouchType touchType = TouchType.CLICK;
        TouchType newTouchType = TouchTypeExt.toTouchType(type);
        if (newTouchType != null) {
            touchType = newTouchType;
        }
        JSONObject touchData = getJSONObject(json, "affise_event_last_attributed_touch_data");
        Event event = new LastAttributedTouchEvent(touchType, pair.timeStamp, touchData, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventListViewEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject list = getJSONObject(json, "affise_event_list_view");
        Event event = new ListViewEvent(list, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventLoginEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_login_timestamp"
        );
        JSONObject login = getJSONObject(json, "affise_event_login");
        Event event = new LoginEvent(login, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventOpenedFromPushNotificationEvent(JSONObject json) {
        String userData = getUserData(json);
        String details = getSerializeString(json, "affise_event_opened_from_push_notification");
        Event event = new OpenedFromPushNotificationEvent(details, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventPurchaseEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_purchase_timestamp"
        );
        JSONObject purchaseData = getJSONObject(json, "affise_event_purchase");
        Event event = new PurchaseEvent(purchaseData, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventRateEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_rate_timestamp"
        );
        JSONObject rate = getJSONObject(json, "affise_event_rate");
        Event event = new RateEvent(rate, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventReEngageEvent(JSONObject json) {
        String userData = getUserData(json);
        String reEngage = getSerializeString(json, "affise_event_re_engage");
        Event event = new ReEngageEvent(reEngage, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventReserveEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_reserve_timestamp"
        );
        List<JSONObject> reserve = getJsonList(json, "affise_event_reserve");
        Event event = new ReserveEvent(reserve, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventSalesEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_sales_timestamp"
        );
        JSONObject salesData = getJSONObject(json, "affise_event_sales");
        Event event = new SalesEvent(salesData, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventSearchEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_search_timestamp"
        );
        JSONArray search = getJSONArray(json, "affise_event_search");
        Event event = new SearchEvent(search, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventShareEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_share_timestamp"
        );
        JSONObject share = getJSONObject(json, "affise_event_share");
        Event event = new ShareEvent(share, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventSpendCreditsEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_spend_credits_timestamp"
        );
        long credits = getSerializeLong(json, "affise_event_spend_credits");
        Event event = new SpendCreditsEvent(credits, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventStartRegistrationEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_start_registration_timestamp"
        );
        JSONObject registration = getJSONObject(json, "affise_event_start_registration");
        Event event = new StartRegistrationEvent(registration, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventStartTrialEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_start_trial_timestamp"
        );
        JSONObject trial = getJSONObject(json, "affise_event_start_trial");
        Event event = new StartTrialEvent(trial, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventStartTutorialEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_start_tutorial_timestamp"
        );
        JSONObject tutorial = getJSONObject(json, "affise_event_start_tutorial");
        Event event = new StartTutorialEvent(tutorial, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventSubscribeEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_subscribe_timestamp"
        );
        JSONObject subscribe = getJSONObject(json, "affise_event_subscribe");
        Event event = new SubscribeEvent(subscribe, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventTravelBookingEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONArray details = getJSONArray(json, "affise_event_travel_booking");
        Event event = new TravelBookingEvent(details, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventUnlockAchievementEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_unlock_achievement_timestamp"
        );
        JSONObject achievement = getJSONObject(json, "affise_event_unlock_achievement");
        Event event = new UnlockAchievementEvent(achievement, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventUnsubscribeEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_unsubscribe_timestamp"
        );
        JSONObject unsubscribe = getJSONObject(json, "affise_event_unsubscribe");
        Event event = new UnsubscribeEvent(unsubscribe, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventUpdateEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONArray details = getJSONArray(json, "affise_event_update");
        Event event = new UpdateEvent(details, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventViewAdvEvent(JSONObject json) {
        DataPair pair = getUserDataAndTimeStamp(
                json,
                "affise_event_view_adv_timestamp"
        );
        JSONObject ad = getJSONObject(json, "affise_event_view_adv");
        Event event = new ViewAdvEvent(ad, pair.timeStamp, pair.userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventViewCartEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject objects = getJSONObject(json, "affise_event_view_cart");
        Event event = new ViewCartEvent(objects, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventViewItemEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject item = getJSONObject(json, "affise_event_view_item");
        Event event = new ViewItemEvent(item, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventViewItemsEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONArray items = getJSONArray(json, "affise_event_view_items");
        Event event = new ViewItemsEvent(items, userData);

        addPredefinedParameters(event, json);
        return event;
    }
}
