namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedLong
    {
        DATE_A,
        DATE_B,
        DEPARTING_ARRIVAL_DATE,
        DEPARTING_DEPARTURE_DATE,
        HOTEL_SCORE,
        LEVEL,
        MAX_RATING_VALUE,
        NUM_ADULTS,
        NUM_CHILDREN,
        NUM_INFANTS,
        PREFERRED_NUM_STOPS,
        PREFERRED_STAR_RATINGS,
        QUANTITY,
        RATING_VALUE,
        RETURNING_ARRIVAL_DATE,
        RETURNING_DEPARTURE_DATE,
        SCORE,
        TRAVEL_START,
        TRAVEL_END,
        USER_SCORE,
        EVENT_START,
        EVENT_END
    }
    
    public static class PredefinedLongExt
    {
        public static string ToValue(this PredefinedLong param)
        {
            return param switch
            {
                PredefinedLong.DATE_A => "affise_p_date_a",
                PredefinedLong.DATE_B => "affise_p_date_b",
                PredefinedLong.DEPARTING_ARRIVAL_DATE => "affise_p_departing_arrival_date",
                PredefinedLong.DEPARTING_DEPARTURE_DATE => "affise_p_departing_departure_date",
                PredefinedLong.HOTEL_SCORE => "affise_p_hotel_score",
                PredefinedLong.LEVEL => "affise_p_level",
                PredefinedLong.MAX_RATING_VALUE => "affise_p_max_rating_value",
                PredefinedLong.NUM_ADULTS => "affise_p_num_adults",
                PredefinedLong.NUM_CHILDREN => "affise_p_num_children",
                PredefinedLong.NUM_INFANTS => "affise_p_num_infants",
                PredefinedLong.PREFERRED_NUM_STOPS => "affise_p_preferred_num_stops",
                PredefinedLong.PREFERRED_STAR_RATINGS => "affise_p_preferred_star_ratings",
                PredefinedLong.QUANTITY => "affise_p_quantity",
                PredefinedLong.RATING_VALUE => "affise_p_rating_value",
                PredefinedLong.RETURNING_ARRIVAL_DATE => "affise_p_returning_arrival_date",
                PredefinedLong.RETURNING_DEPARTURE_DATE => "affise_p_returning_departure_date",
                PredefinedLong.SCORE => "affise_p_score",
                PredefinedLong.TRAVEL_START => "affise_p_travel_start",
                PredefinedLong.TRAVEL_END => "affise_p_travel_end",
                PredefinedLong.USER_SCORE => "affise_p_user_score",
                PredefinedLong.EVENT_START => "affise_p_event_start",
                PredefinedLong.EVENT_END => "affise_p_event_end",
                _ => null
            };
        }
    }
}