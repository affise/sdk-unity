import AffiseAttributionLib


internal func toPredefinedParameters(_ value: String?) -> PredefinedParameters? {
    switch value {
    case "affise_p_adrev_ad_type": return PredefinedParameters.ADREV_AD_TYPE
    case "affise_p_city": return PredefinedParameters.CITY
    case "affise_p_country": return PredefinedParameters.COUNTRY
    case "affise_p_region": return PredefinedParameters.REGION
    case "affise_p_class": return PredefinedParameters.CLASS
    case "affise_p_content": return PredefinedParameters.CONTENT
    case "affise_p_content_id": return PredefinedParameters.CONTENT_ID
    case "affise_p_content_list": return PredefinedParameters.CONTENT_LIST
    case "affise_p_content_type": return PredefinedParameters.CONTENT_TYPE
    case "affise_p_currency": return PredefinedParameters.CURRENCY
    case "affise_p_customer_user_id": return PredefinedParameters.CUSTOMER_USER_ID
    case "affise_p_date_a": return PredefinedParameters.DATE_A
    case "affise_p_date_b": return PredefinedParameters.DATE_B
    case "affise_p_departing_arrival_date": return PredefinedParameters.DEPARTING_ARRIVAL_DATE
    case "affise_p_departing_departure_date": return PredefinedParameters.DEPARTING_DEPARTURE_DATE
    case "affise_p_description": return PredefinedParameters.DESCRIPTION
    case "affise_p_destination_a": return PredefinedParameters.DESTINATION_A
    case "affise_p_destination_b": return PredefinedParameters.DESTINATION_B
    case "affise_p_destination_list": return PredefinedParameters.DESTINATION_LIST
    case "affise_p_hotel_score": return PredefinedParameters.HOTEL_SCORE
    case "affise_p_level": return PredefinedParameters.LEVEL
    case "affise_p_max_rating_value": return PredefinedParameters.MAX_RATING_VALUE
    case "affise_p_num_adults": return PredefinedParameters.NUM_ADULTS
    case "affise_p_num_children": return PredefinedParameters.NUM_CHILDREN
    case "affise_p_num_infants": return PredefinedParameters.NUM_INFANTS
    case "affise_p_order_id": return PredefinedParameters.ORDER_ID
    case "affise_p_payment_info_available": return PredefinedParameters.PAYMENT_INFO_AVAILABLE
    case "affise_p_preferred_neighborhoods": return PredefinedParameters.PREFERRED_NEIGHBORHOODS
    case "affise_p_preferred_num_stops": return PredefinedParameters.PREFERRED_NUM_STOPS
    case "affise_p_preferred_price_range": return PredefinedParameters.PREFERRED_PRICE_RANGE
    case "affise_p_preferred_star_ratings": return PredefinedParameters.PREFERRED_STAR_RATINGS
    case "affise_p_price": return PredefinedParameters.PRICE
    case "affise_p_purchase_currency": return PredefinedParameters.PURCHASE_CURRENCY
    case "affise_p_quantity": return PredefinedParameters.QUANTITY
    case "affise_p_rating_value": return PredefinedParameters.RATING_VALUE
    case "affise_p_receipt_id": return PredefinedParameters.RECEIPT_ID
    case "affise_p_registration_method": return PredefinedParameters.REGISTRATION_METHOD
    case "affise_p_returning_arrival_date": return PredefinedParameters.RETURNING_ARRIVAL_DATE
    case "affise_p_returning_departure_date": return PredefinedParameters.RETURNING_DEPARTURE_DATE
    case "affise_p_revenue": return PredefinedParameters.REVENUE
    case "affise_p_score": return PredefinedParameters.SCORE
    case "affise_p_search_string": return PredefinedParameters.SEARCH_STRING
    case "affise_p_subscription_id": return PredefinedParameters.SUBSCRIPTION_ID
    case "affise_p_success": return PredefinedParameters.SUCCESS
    case "affise_p_suggested_destinations": return PredefinedParameters.SUGGESTED_DESTINATIONS
    case "affise_p_suggested_hotels": return PredefinedParameters.SUGGESTED_HOTELS
    case "affise_p_travel_start": return PredefinedParameters.TRAVEL_START
    case "affise_p_travel_end": return PredefinedParameters.TRAVEL_END
    case "affise_p_user_score": return PredefinedParameters.USER_SCORE
    case "affise_p_validated": return PredefinedParameters.VALIDATED
    case "affise_p_achievement_id": return PredefinedParameters.ACHIEVEMENT_ID
    case "affise_p_coupon_code": return PredefinedParameters.COUPON_CODE
    case "affise_p_customer_segment": return PredefinedParameters.CUSTOMER_SEGMENT
    case "affise_p_deep_link": return PredefinedParameters.DEEP_LINK
    case "affise_p_event_start": return PredefinedParameters.EVENT_START
    case "affise_p_event_end": return PredefinedParameters.EVENT_END
    case "affise_p_lat": return PredefinedParameters.LAT
    case "affise_p_long": return PredefinedParameters.LONG
    case "affise_p_new_version": return PredefinedParameters.NEW_VERSION
    case "affise_p_old_version": return PredefinedParameters.OLD_VERSION
    case "affise_p_param_01": return PredefinedParameters.PARAM_01
    case "affise_p_param_02": return PredefinedParameters.PARAM_02
    case "affise_p_param_03": return PredefinedParameters.PARAM_03
    case "affise_p_param_04": return PredefinedParameters.PARAM_04
    case "affise_p_param_05": return PredefinedParameters.PARAM_05
    case "affise_p_param_06": return PredefinedParameters.PARAM_06
    case "affise_p_param_07": return PredefinedParameters.PARAM_07
    case "affise_p_param_08": return PredefinedParameters.PARAM_08
    case "affise_p_param_09": return PredefinedParameters.PARAM_09
    case "affise_p_param_10": return PredefinedParameters.PARAM_10
    case "affise_p_review_text": return PredefinedParameters.REVIEW_TEXT
    case "affise_p_tutorial_id": return PredefinedParameters.TUTORIAL_ID
    case "affise_p_virtual_currency_name": return PredefinedParameters.VIRTUAL_CURRENCY_NAME
        
    default:
        return nil
    }
}
