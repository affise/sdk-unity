using System;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Events.Predefined;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.AffiseParameters;
using SimpleJSON;

namespace AffiseAttributionLib.Converter
{
    public class EventToSerializedEventConverter : IConverter<AffiseEvent, SerializedEvent>
    {
        public SerializedEvent Convert(AffiseEvent from)
        {
            var id = Guid.NewGuid().ToString();
            var json = new JSONObject
            {
                [Parameters.AFFISE_EVENT_ID] = id,
                [Parameters.AFFISE_EVENT_NAME] = from.GetName(),
                [Parameters.AFFISE_EVENT_CATEGORY] = from.GetCategory(),
                [Parameters.AFFISE_EVENT_TIMESTAMP] = DateTime.UtcNow.GetTimeInMillis(),
                [Parameters.AFFISE_EVENT_FIRST_FOR_USER] = from.IsFirstForUser(),
                [Parameters.AFFISE_EVENT_USER_DATA] = from.GetUserData(),
                [Parameters.AFFISE_EVENT_DATA] = from.Serialize(),
                [Parameters.AFFISE_PARAMETERS] = GetPredefinedParameters(from)
            };

            return new SerializedEvent(id, json);
        }

        private JSONObject GetPredefinedParameters(AffiseEvent from)
        {
            var data = from.GetPredefinedParameters();
            var result = new JSONObject();
            foreach (var (key, value) in data)
            {
                var jsonKey = key.ToValue();
                if (jsonKey is not null)
                {
                    result[jsonKey] = value;
                }
            }

            return result;
        }
    }
}