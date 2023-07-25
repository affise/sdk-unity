using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SearchEvent : NativeEvent
    {
        public SearchEvent(): base()
        {}
        public SearchEvent(string userData): base(userData: userData)
        {}
        public SearchEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use SearchEvent(userData, timeStampMillis)")]
        public SearchEvent(JSONArray search, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = search;
        }

        public override string GetName() => EventName.SEARCH.ToValue();
    }
}