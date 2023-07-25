using AffiseAttributionLib.Events;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Utils;
using SimpleJSON;

namespace AffiseAttributionLib.Converter
{
    public class EventToSerializedEventConverter : IConverter<AffiseEvent, SerializedEvent>
    {
        public SerializedEvent Convert(AffiseEvent from)
        {
            var id = Uuid.Generate();
            var json = new JSONObject
            {
                [Parameters.AFFISE_EVENT_ID] = id,
                [Parameters.AFFISE_EVENT_NAME] = from.GetName(),
                [Parameters.AFFISE_EVENT_CATEGORY] = from.GetCategory(),
                [Parameters.AFFISE_EVENT_TIMESTAMP] = Timestamp.New(),
                [Parameters.AFFISE_EVENT_FIRST_FOR_USER] = from.IsFirstForUser(),
                [Parameters.AFFISE_EVENT_USER_DATA] = from.GetUserData(),
                [Parameters.AFFISE_EVENT_DATA] = from.Serialize(),
                [Parameters.AFFISE_PARAMETERS] = from.GetPredefinedParameters().ToJsonObject(),
            };

            return new SerializedEvent(id, json);
        }
    }
}