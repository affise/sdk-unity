import AffiseAttributionLib

internal class AffiseEvensFactory: AffiseBaseEvensFactory, AffiseBaseEvens {
    
    private let subscriptionEventsFactory = AffiseSubtypeEventsFactory();
    
    func event(_ map: [String: Any?]?) -> Event? {
        let name = map?["name"] as? String?
        
        switch name {
        case "AchieveLevel": return eventAchieveLevelEvent(map)
        case "AddPaymentInfo": return eventAddPaymentInfoEvent(map)
        case "AddToCart": return eventAddToCartEvent(map)
        case "AddToWishlist": return eventAddToWishlistEvent(map)
        case "ClickAdv": return eventClickAdv(map)
        case "CompleteRegistration": return eventCompleteRegistrationEvent(map)
        case "CompleteStream": return eventCompleteStreamEvent(map)
        case "CompleteTrial": return eventCompleteTrialEvent(map)
        case "CompleteTutorial": return eventCompleteTutorialEvent(map)
        case "ContentItemsView": return eventContentItemsViewEvent(map)
        case "CustomId01": return eventCustomId01Event(map)
        case "CustomId02": return eventCustomId02Event(map)
        case "CustomId03": return eventCustomId03Event(map)
        case "CustomId04": return eventCustomId04Event(map)
        case "CustomId05": return eventCustomId05Event(map)
        case "CustomId06": return eventCustomId06Event(map)
        case "CustomId07": return eventCustomId07Event(map)
        case "CustomId08": return eventCustomId08Event(map)
        case "CustomId09": return eventCustomId09Event(map)
        case "CustomId10": return eventCustomId10Event(map)
        case "DeepLinked": return eventDeepLinkedEvent(map)
        case "InitiatePurchase": return eventInitiatePurchaseEvent(map)
        case "InitiateStream": return eventInitiateStreamEvent(map)
        case "Invite": return eventInviteEvent(map)
        case "LastAttributedTouch": return eventLastAttributedTouchEvent(map)
        case "ListView": return eventListViewEvent(map)
        case "Login": return eventLoginEvent(map)
        case "OpenedFromPushNotification": return eventOpenedFromPushNotificationEvent(map)
        case "Purchase": return eventPurchaseEvent(map)
        case "Rate": return eventRateEvent(map)
        case "ReEngage": return eventReEngageEvent(map)
        case "Reserve": return eventReserveEvent(map)
        case "Sales": return eventSalesEvent(map)
        case "Search": return eventSearchEvent(map)
        case "Share": return eventShareEvent(map)
        case "SpendCredits": return eventSpendCreditsEvent(map)
        case "StartRegistration": return eventStartRegistrationEvent(map)
        case "StartTrial": return eventStartTrialEvent(map)
        case "StartTutorial": return eventStartTutorialEvent(map)
        case "Subscribe": return eventSubscribeEvent(map)
        case "TravelBooking": return eventTravelBookingEvent(map)
        case "UnlockAchievement": return eventUnlockAchievementEvent(map)
        case "Unsubscribe": return eventUnsubscribeEvent(map)
        case "Update": return eventUpdateEvent(map)
        case "ViewAdv": return eventViewAdvEvent(map)
        case "ViewCart": return eventViewCartEvent(map)
        case "ViewItem": return eventViewItemEvent(map)
        case "ViewItems": return eventViewItemsEvent(map)
            
        case SubscriptionParameters.AFFISE_UNSUBSCRIPTION.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_ACTIVATION.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_CANCELLATION.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_FIRST_CONVERSION.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_REACTIVATION.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL.rawValue: return subscriptionEventsFactory.event(map)
        case SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY.rawValue: return subscriptionEventsFactory.event(map)
            
        default:
            return nil
        }
    }
    
    private func eventAchieveLevelEvent(_ map: [String: Any?]?) -> AchieveLevelEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_achieve_level_timestamp"
        )
        let level = getArrayOfData(map, "affise_event_achieve_level")
        
        var event = AchieveLevelEvent(
            level: level,
            timeStampMillis: timeStamp,
            userData: userData
        )
        
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventAddPaymentInfoEvent(_ map: [String: Any?]?) -> AddPaymentInfoEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_add_payment_info_timestamp"
        )
        let paymentInfo = getArrayOfData(map, "affise_event_add_payment_info")
        
        var event = AddPaymentInfoEvent(
            paymentInfo: paymentInfo,
            timeStampMillis: timeStamp,
            userData: userData
        )
        
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventAddToCartEvent(_ map: [String: Any?]?) -> AddToCartEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_add_to_cart_timestamp"
        )
        let addToCartObject = getArrayOfData(map, "affise_event_add_to_cart")
        
        var event = AddToCartEvent(
            addToCartObject: addToCartObject,
            timeStampMillis: timeStamp,
            userData: userData
        )
        
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventAddToWishlistEvent(_ map: [String: Any?]?) -> AddToWishlistEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_add_to_wishlist_timestamp"
        )
        let wishList = getArrayOfData(map, "affise_event_add_to_wishlist")
        
        var event = AddToWishlistEvent(
            wishList: wishList,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventClickAdv(_ map: [String: Any?]?) -> ClickAdvEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_click_adv_timestamp"
        )
        let advertisement = getSerializeString(map, "affise_event_click_adv") ?? ""
        
        var event = ClickAdvEvent(
            advertisement: advertisement,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventCompleteRegistrationEvent(_ map: [String: Any?]?) -> CompleteRegistrationEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_complete_registration_timestamp"
        )
        let registration = getArrayOfData(map, "affise_event_complete_registration")
        
        var event = CompleteRegistrationEvent(
            registration: registration,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventCompleteStreamEvent(_ map: [String: Any?]?) -> CompleteStreamEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_complete_stream_timestamp"
        )
        let stream = getArrayOfData(map, "affise_event_complete_stream")
        
        var event = CompleteStreamEvent(
            stream: stream,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }
    
    private func eventCompleteTrialEvent(_ map: [String: Any?]?) -> CompleteTrialEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_complete_trial_timestamp"
        )
        let trial = getArrayOfData(map, "affise_event_complete_trial")

        var event = CompleteTrialEvent(
            trial: trial,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCompleteTutorialEvent(_ map: [String: Any?]?) -> CompleteTutorialEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_complete_tutorial_timestamp"
        )
        let tutorial = getArrayOfData(map, "affise_event_complete_tutorial")

        var event = CompleteTutorialEvent(
            tutorial: tutorial,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventContentItemsViewEvent(_ map: [String: Any?]?) -> ContentItemsViewEvent {
        let userData = getUserData(map)
        let objects = getSerializeArrayOfArray(map, "affise_event_content_items_view")

        var event = ContentItemsViewEvent(
            objects: objects,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId01Event(_ map: [String: Any?]?) -> CustomId01Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_01_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_01") ?? ""

        var event = CustomId01Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId02Event(_ map: [String: Any?]?) -> CustomId02Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_02_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_02") ?? ""

        var event = CustomId02Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId03Event(_ map: [String: Any?]?) -> CustomId03Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_03_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_03") ?? ""

        var event = CustomId03Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId04Event(_ map: [String: Any?]?) -> CustomId04Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_04_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_04") ?? ""

        var event = CustomId04Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId05Event(_ map: [String: Any?]?) -> CustomId05Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_05_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_05") ?? ""

        var event = CustomId05Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId06Event(_ map: [String: Any?]?) -> CustomId06Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_06_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_06") ?? ""

        var event = CustomId06Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId07Event(_ map: [String: Any?]?) -> CustomId07Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_07_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_07") ?? ""

        var event = CustomId07Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId08Event(_ map: [String: Any?]?) -> CustomId08Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_08_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_08") ?? ""

        var event = CustomId08Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId09Event(_ map: [String: Any?]?) -> CustomId09Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_09_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_09") ?? ""

        var event = CustomId09Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventCustomId10Event(_ map: [String: Any?]?) -> CustomId10Event {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_custom_id_10_timestamp"
        )
        let custom = getSerializeString(map, "affise_event_custom_id_10") ?? ""

        var event = CustomId10Event(
            custom: custom,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventDeepLinkedEvent(_ map: [String: Any?]?) -> DeepLinkedEvent {
        let userData = getUserData(map)
        let isLinked = getSerializeBool(map, "affise_event_deep_linked")

        var event = DeepLinkedEvent(
            isLinked: isLinked,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventInitiatePurchaseEvent(_ map: [String: Any?]?) -> InitiatePurchaseEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_initiate_purchase_timestamp"
        )
        let purchaseData = getArrayOfData(map, "affise_event_initiate_purchase")

        var event = InitiatePurchaseEvent(
            purchaseData: purchaseData,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventInitiateStreamEvent(_ map: [String: Any?]?) -> InitiateStreamEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_initiate_stream_timestamp"
        )
        let stream = getArrayOfData(map, "affise_event_initiate_stream")

        var event = InitiateStreamEvent(
            stream: stream,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventInviteEvent(_ map: [String: Any?]?) -> InviteEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_invite_timestamp"
        )
        let invite = getArrayOfData(map, "affise_event_invite")

        var event = InviteEvent(
            invite: invite,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventLastAttributedTouchEvent(_ map: [String: Any?]?) -> LastAttributedTouchEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(map, "affise_event_last_attributed_touch_timestamp")
        let touchType = toTouchType(getSerializeString(map, "affise_event_last_attributed_touch_type")) ?? TouchType.CLICK
        let touchData = getArrayOfData(map, "affise_event_last_attributed_touch_data")

        var event = LastAttributedTouchEvent(
            touchType: touchType,
            timeStampMillis: timeStamp,
            touchData: touchData,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventListViewEvent(_ map: [String: Any?]?) -> ListViewEvent {
        let userData = getUserData(map)
        let list = getArrayOfData(map, "affise_event_list_view")

        var event = ListViewEvent(
            list: list,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventLoginEvent(_ map: [String: Any?]?) -> LoginEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_login_timestamp"
        )
        let login = getArrayOfData(map, "affise_event_login")

        var event = LoginEvent(
            login: login,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventOpenedFromPushNotificationEvent(_ map: [String: Any?]?) -> OpenedFromPushNotificationEvent {
        let userData = getUserData(map)
        let details = getSerializeString(map, "affise_event_opened_from_push_notification") ?? ""

        var event = OpenedFromPushNotificationEvent(
            details: details,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventPurchaseEvent(_ map: [String: Any?]?) -> PurchaseEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_purchase_timestamp"
        )
        let purchaseData = getArrayOfData(map, "affise_event_purchase")

        var event = PurchaseEvent(
            purchaseData: purchaseData,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventRateEvent(_ map: [String: Any?]?) -> RateEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(map, "affise_event_rate_timestamp")
        let rate = getArrayOfData(map, "affise_event_rate")

        var event = RateEvent(
            rate: rate,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventReEngageEvent(_ map: [String: Any?]?) -> ReEngageEvent {
        let userData = getUserData(map)
        let reEngage = getSerializeString(map, "affise_event_re_engage") ?? ""

        var event = ReEngageEvent(
            reEngage: reEngage,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

   private func eventReserveEvent(_ map: [String: Any?]?) -> ReserveEvent {
       let (timeStamp, userData) = getUserDataAndTimeStamp(
           map,
           "affise_event_reserve_timestamp"
       )
       let reserve = getSerializeArrayOfArray(map, "affise_event_reserve")

       var event = ReserveEvent(
           reserve: reserve,
           timeStampMillis: timeStamp,
           userData: userData
       )
       addPredefinedParameters(event: &event, map: map)
       return event
   }

    private func eventSalesEvent(_ map: [String: Any?]?) -> SalesEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_sales_timestamp"
        )
        let salesData = getArrayOfData(map, "affise_event_sales")

        var event = SalesEvent(
            salesData: salesData,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventSearchEvent(_ map: [String: Any?]?) -> SearchEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_search_timestamp"
        )
         let search = getSerializeArrayOfAny(map, "affise_event_search")

        var event = SearchEvent(
            search: search,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventShareEvent(_ map: [String: Any?]?) -> ShareEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_share_timestamp"
        )
        let share = getArrayOfData(map, "affise_event_share")

        var event = ShareEvent(
            share: share,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventSpendCreditsEvent(_ map: [String: Any?]?) -> SpendCreditsEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_spend_credits_timestamp"
        )
        let credits = getSerializeNumber(map, "affise_event_spend_credits")?.int64Value ?? 0

        var event = SpendCreditsEvent(
            credits: credits,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventStartRegistrationEvent(_ map: [String: Any?]?) -> StartRegistrationEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_start_registration_timestamp"
        )
        let registration = getArrayOfData(map, "affise_event_start_registration")

        var event = StartRegistrationEvent(
            registration: registration,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventStartTrialEvent(_ map: [String: Any?]?) -> StartTrialEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_start_trial_timestamp"
        )
        let trial = getArrayOfData(map, "affise_event_start_trial")

        var event = StartTrialEvent(
            trial: trial,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventStartTutorialEvent(_ map: [String: Any?]?) -> StartTutorialEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_start_tutorial_timestamp"
        )
        let tutorial = getArrayOfData(map, "affise_event_start_tutorial")

        var event = StartTutorialEvent(
            tutorial: tutorial,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventSubscribeEvent(_ map: [String: Any?]?) -> SubscribeEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_subscribe_timestamp"
        )
        let subscribe = getArrayOfData(map, "affise_event_subscribe")

        var event = SubscribeEvent(
            subscribe: subscribe,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventTravelBookingEvent(_ map: [String: Any?]?) -> TravelBookingEvent {
        let userData = getUserData(map)
        let details = getSerializeArrayOfAny(map, "affise_event_travel_booking")

        var event = TravelBookingEvent(
            details: details,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventUnlockAchievementEvent(_ map: [String: Any?]?) -> UnlockAchievementEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_unlock_achievement_timestamp"
        )
        let achievement = getArrayOfData(map, "affise_event_unlock_achievement")

        var event = UnlockAchievementEvent(
            achievement: achievement,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventUnsubscribeEvent(_ map: [String: Any?]?) -> UnsubscribeEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_unsubscribe_timestamp"
        )
        let unsubscribe = getArrayOfData(map, "affise_event_unsubscribe")

        var event = UnsubscribeEvent(
            unsubscribe: unsubscribe,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventUpdateEvent(_ map: [String: Any?]?) -> UpdateEvent {
        let userData = getUserData(map)
        let details = getSerializeArrayOfAny(map, "affise_event_update")

        var event = UpdateEvent(
            details: details,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventViewAdvEvent(_ map: [String: Any?]?) -> ViewAdvEvent {
        let (timeStamp, userData) = getUserDataAndTimeStamp(
            map,
            "affise_event_view_adv_timestamp"
        )
        let ad = getArrayOfData(map, "affise_event_view_adv")

        var event = ViewAdvEvent(
            ad: ad,
            timeStampMillis: timeStamp,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventViewCartEvent(_ map: [String: Any?]?) -> ViewCartEvent {
        let userData = getUserData(map)
        let objects = getArrayOfData(map, "affise_event_view_cart")

        var event = ViewCartEvent(
            objects: objects,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventViewItemEvent(_ map: [String: Any?]?) -> ViewItemEvent {
        let userData = getUserData(map)
        let item = getArrayOfData(map, "affise_event_view_item")

        var event = ViewItemEvent(
            item: item,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }

    private func eventViewItemsEvent(_ map: [String: Any?]?) -> ViewItemsEvent {
        let userData = getUserData(map)
        let items = getSerializeArrayOfAny(map, "affise_event_view_items")

        var event = ViewItemsEvent(
            items:  items,
            userData: userData
        )
        addPredefinedParameters(event: &event, map: map)
        return event
    }
}
