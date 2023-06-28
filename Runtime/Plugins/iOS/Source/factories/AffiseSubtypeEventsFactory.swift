import Foundation
import AffiseAttributionLib

internal class AffiseSubtypeEventsFactory : AffiseBaseEvensFactory, AffiseBaseEvens {
    func event(_ map: [String: Any?]?) -> Event? {
        let subtype = map?["subtype"] as? String?
        
        switch subtype {
        case SubscriptionParameters.AFFISE_SUB_INITIAL_SUBSCRIPTION.rawValue: return eventInitialSubscriptionEvent(map)
        case SubscriptionParameters.AFFISE_SUB_INITIAL_TRIAL.rawValue: return eventInitialTrialEvent(map)
        case SubscriptionParameters.AFFISE_SUB_INITIAL_OFFER.rawValue: return eventInitialOfferEvent(map)
        case SubscriptionParameters.AFFISE_SUB_FAILED_TRIAL.rawValue: return eventFailedTrialEvent(map)
        case SubscriptionParameters.AFFISE_SUB_FAILED_OFFERISE.rawValue: return eventFailedOfferiseEvent(map)
        case SubscriptionParameters.AFFISE_SUB_FAILED_SUBSCRIPTION.rawValue: return eventFailedSubscriptionEvent(map)
        case SubscriptionParameters.AFFISE_SUB_FAILED_TRIAL_FROM_RETRY.rawValue: return eventFailedTrialFromRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_FAILED_OFFER_FROM_RETRY.rawValue: return eventFailedOfferFromRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_FAILED_SUBSCRIPTION_FROM_RETRY.rawValue: return eventFailedSubscriptionFromRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_TRIAL_IN_RETRY.rawValue: return eventTrialInRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_OFFER_IN_RETRY.rawValue: return eventOfferInRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_SUBSCRIPTION_IN_RETRY.rawValue: return eventSubscriptionInRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_CONVERTED_TRIAL.rawValue: return eventConvertedTrialEvent(map)
        case SubscriptionParameters.AFFISE_SUB_CONVERTED_OFFER.rawValue: return eventConvertedOfferEvent(map)
        case SubscriptionParameters.AFFISE_SUB_REACTIVATED_SUBSCRIPTION.rawValue: return eventReactivatedSubscriptionEvent(map)
        case SubscriptionParameters.AFFISE_SUB_RENEWED_SUBSCRIPTION.rawValue: return eventRenewedSubscriptionEvent(map)
        case SubscriptionParameters.AFFISE_SUB_CONVERTED_TRIAL_FROM_RETRY.rawValue: return eventConvertedTrialFromRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_CONVERTED_OFFER_FROM_RETRY.rawValue: return eventConvertedOfferFromRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_RENEWED_SUBSCRIPTION_FROM_RETRY.rawValue: return eventRenewedSubscriptionFromRetryEvent(map)
        case SubscriptionParameters.AFFISE_SUB_UNSUBSCRIPTION.rawValue: return eventUnsubscriptionEvent(map)
        default:
            return nil
        }
    }
   
    private func eventInitialSubscriptionEvent(_ map: [String: Any?]?) -> Event {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = InitialSubscriptionEvent(
            data: data,
            userData: userData
        )

       addPredefinedParameters(event: &event, map: map)
       return event
    }

    private func eventInitialTrialEvent(_ map: [String: Any?]?) -> InitialTrialEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = InitialTrialEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventInitialOfferEvent(_ map: [String: Any?]?) -> InitialOfferEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = InitialOfferEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventFailedTrialEvent(_ map: [String: Any?]?) -> FailedTrialEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = FailedTrialEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventFailedOfferiseEvent(_ map: [String: Any?]?) -> FailedOfferiseEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = FailedOfferiseEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventFailedSubscriptionEvent(_ map: [String: Any?]?) -> FailedSubscriptionEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = FailedSubscriptionEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventFailedTrialFromRetryEvent(_ map: [String: Any?]?) -> FailedTrialFromRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = FailedTrialFromRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventFailedOfferFromRetryEvent(_ map: [String: Any?]?) -> FailedOfferFromRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = FailedOfferFromRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventFailedSubscriptionFromRetryEvent(_ map: [String: Any?]?) -> FailedSubscriptionFromRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = FailedSubscriptionFromRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventTrialInRetryEvent(_ map: [String: Any?]?) -> TrialInRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = TrialInRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventOfferInRetryEvent(_ map: [String: Any?]?) -> OfferInRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = OfferInRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventSubscriptionInRetryEvent(_ map: [String: Any?]?) -> SubscriptionInRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = SubscriptionInRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventConvertedTrialEvent(_ map: [String: Any?]?) -> ConvertedTrialEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = ConvertedTrialEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventConvertedOfferEvent(_ map: [String: Any?]?) -> ConvertedOfferEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = ConvertedOfferEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventReactivatedSubscriptionEvent(_ map: [String: Any?]?) -> ReactivatedSubscriptionEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = ReactivatedSubscriptionEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventRenewedSubscriptionEvent(_ map: [String: Any?]?) -> RenewedSubscriptionEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = RenewedSubscriptionEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventConvertedTrialFromRetryEvent(_ map: [String: Any?]?) -> ConvertedTrialFromRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = ConvertedTrialFromRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventConvertedOfferFromRetryEvent(_ map: [String: Any?]?) -> ConvertedOfferFromRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = ConvertedOfferFromRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventRenewedSubscriptionFromRetryEvent(_ map: [String: Any?]?) -> RenewedSubscriptionFromRetryEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = RenewedSubscriptionFromRetryEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventUnsubscriptionEvent(_ map: [String: Any?]?) -> UnsubscriptionEvent {
        let userData = getUserData(map)
        let data = getDataArray(map)

        var event = UnsubscriptionEvent(
            data: data,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }
}
