package com.affise.attribution.unity.factories;

import com.affise.attribution.events.Event;
import com.affise.attribution.events.subscription.ConvertedOfferEvent;
import com.affise.attribution.events.subscription.ConvertedOfferFromRetryEvent;
import com.affise.attribution.events.subscription.ConvertedTrialEvent;
import com.affise.attribution.events.subscription.ConvertedTrialFromRetryEvent;
import com.affise.attribution.events.subscription.FailedOfferFromRetryEvent;
import com.affise.attribution.events.subscription.FailedOfferiseEvent;
import com.affise.attribution.events.subscription.FailedSubscriptionEvent;
import com.affise.attribution.events.subscription.FailedSubscriptionFromRetryEvent;
import com.affise.attribution.events.subscription.FailedTrialEvent;
import com.affise.attribution.events.subscription.FailedTrialFromRetryEvent;
import com.affise.attribution.events.subscription.InitialOfferEvent;
import com.affise.attribution.events.subscription.InitialSubscriptionEvent;
import com.affise.attribution.events.subscription.InitialTrialEvent;
import com.affise.attribution.events.subscription.OfferInRetryEvent;
import com.affise.attribution.events.subscription.ReactivatedSubscriptionEvent;
import com.affise.attribution.events.subscription.RenewedSubscriptionEvent;
import com.affise.attribution.events.subscription.RenewedSubscriptionFromRetryEvent;
import com.affise.attribution.events.subscription.SubscriptionInRetryEvent;
import com.affise.attribution.events.subscription.SubscriptionParameters;
import com.affise.attribution.events.subscription.TrialInRetryEvent;

import org.json.JSONObject;

public class AffiseSubtypeEventsFactory extends AffiseBaseEvensFactory {

    @Override
    public Event event(JSONObject json) {
        switch (json.optString(KEY_SUBTYPE)) {
            case SubscriptionParameters.AFFISE_SUB_INITIAL_SUBSCRIPTION:
                return eventInitialSubscriptionEvent(json);
            case SubscriptionParameters.AFFISE_SUB_INITIAL_TRIAL:
                return eventInitialTrialEvent(json);
            case SubscriptionParameters.AFFISE_SUB_INITIAL_OFFER:
                return eventInitialOfferEvent(json);
            case SubscriptionParameters.AFFISE_SUB_FAILED_TRIAL:
                return eventFailedTrialEvent(json);
            case SubscriptionParameters.AFFISE_SUB_FAILED_OFFERISE:
                return eventFailedOfferiseEvent(json);
            case SubscriptionParameters.AFFISE_SUB_FAILED_SUBSCRIPTION:
                return eventFailedSubscriptionEvent(json);
            case SubscriptionParameters.AFFISE_SUB_FAILED_TRIAL_FROM_RETRY:
                return eventFailedTrialFromRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_FAILED_OFFER_FROM_RETRY:
                return eventFailedOfferFromRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_FAILED_SUBSCRIPTION_FROM_RETRY:
                return eventFailedSubscriptionFromRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_TRIAL_IN_RETRY:
                return eventTrialInRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_OFFER_IN_RETRY:
                return eventOfferInRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_SUBSCRIPTION_IN_RETRY:
                return eventSubscriptionInRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_CONVERTED_TRIAL:
                return eventConvertedTrialEvent(json);
            case SubscriptionParameters.AFFISE_SUB_CONVERTED_OFFER:
                return eventConvertedOfferEvent(json);
            case SubscriptionParameters.AFFISE_SUB_REACTIVATED_SUBSCRIPTION:
                return eventReactivatedSubscriptionEvent(json);
            case SubscriptionParameters.AFFISE_SUB_RENEWED_SUBSCRIPTION:
                return eventRenewedSubscriptionEvent(json);
            case SubscriptionParameters.AFFISE_SUB_CONVERTED_TRIAL_FROM_RETRY:
                return eventConvertedTrialFromRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_CONVERTED_OFFER_FROM_RETRY:
                return eventConvertedOfferFromRetryEvent(json);
            case SubscriptionParameters.AFFISE_SUB_RENEWED_SUBSCRIPTION_FROM_RETRY:
                return eventRenewedSubscriptionFromRetryEvent(json);
        }
        return null;
    }

    private JSONObject getDataJSONObject(JSONObject json) {
        JSONObject result = json.optJSONObject(KEY_DATA);
        if (result == null) return new JSONObject();
        return result;
    }

    private Event eventInitialSubscriptionEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new InitialSubscriptionEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }


    private Event eventInitialTrialEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new InitialTrialEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventInitialOfferEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new InitialOfferEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventFailedTrialEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new FailedTrialEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventFailedOfferiseEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new FailedOfferiseEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventFailedSubscriptionEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new FailedSubscriptionEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventFailedTrialFromRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new FailedTrialFromRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventFailedOfferFromRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new FailedOfferFromRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventFailedSubscriptionFromRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new FailedSubscriptionFromRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventTrialInRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new TrialInRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventOfferInRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new OfferInRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventSubscriptionInRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new SubscriptionInRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventConvertedTrialEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new ConvertedTrialEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventConvertedOfferEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new ConvertedOfferEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventReactivatedSubscriptionEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new ReactivatedSubscriptionEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventRenewedSubscriptionEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new RenewedSubscriptionEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventConvertedTrialFromRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new ConvertedTrialFromRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventConvertedOfferFromRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new ConvertedOfferFromRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }

    private Event eventRenewedSubscriptionFromRetryEvent(JSONObject json) {
        String userData = getUserData(json);
        JSONObject data = getDataJSONObject(json);
        Event event = new RenewedSubscriptionFromRetryEvent(data, userData);

        addPredefinedParameters(event, json);
        return event;
    }
}
