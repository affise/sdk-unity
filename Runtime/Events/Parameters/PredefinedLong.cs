namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedLong
    {
        AMOUNT,
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
            return $"{PredefinedConstants.PREFIX}{param.Value()}";
        }

        private static string Value(this PredefinedLong param)
        {
            return param switch
            {
                PredefinedLong.AMOUNT => "amount",
                PredefinedLong.DATE_A => "date_a",
                PredefinedLong.DATE_B => "date_b",
                PredefinedLong.DEPARTING_ARRIVAL_DATE => "departing_arrival_date",
                PredefinedLong.DEPARTING_DEPARTURE_DATE => "departing_departure_date",
                PredefinedLong.HOTEL_SCORE => "hotel_score",
                PredefinedLong.LEVEL => "level",
                PredefinedLong.MAX_RATING_VALUE => "max_rating_value",
                PredefinedLong.NUM_ADULTS => "num_adults",
                PredefinedLong.NUM_CHILDREN => "num_children",
                PredefinedLong.NUM_INFANTS => "num_infants",
                PredefinedLong.PREFERRED_NUM_STOPS => "preferred_num_stops",
                PredefinedLong.PREFERRED_STAR_RATINGS => "preferred_star_ratings",
                PredefinedLong.QUANTITY => "quantity",
                PredefinedLong.RATING_VALUE => "rating_value",
                PredefinedLong.RETURNING_ARRIVAL_DATE => "returning_arrival_date",
                PredefinedLong.RETURNING_DEPARTURE_DATE => "returning_departure_date",
                PredefinedLong.SCORE => "score",
                PredefinedLong.TRAVEL_START => "travel_start",
                PredefinedLong.TRAVEL_END => "travel_end",
                PredefinedLong.USER_SCORE => "user_score",
                PredefinedLong.EVENT_START => "event_start",
                PredefinedLong.EVENT_END => "event_end",
                _ => null
            };
        }
    }
}