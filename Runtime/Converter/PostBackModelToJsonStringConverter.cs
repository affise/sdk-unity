using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Network.Entity;
using SimpleJSON;

namespace AffiseAttributionLib.Converter
{
    public class PostBackModelToJsonStringConverter : IConverter<List<PostBackModel>, string>
    {
        private const string EVENTS_KEY = "events";
        private const string SDK_EVENTS_KEY = "sdk_events";

        public string Convert(List<PostBackModel> from)
        {
            var jsonArray = new JSONArray();
            foreach (var model in from)
            {
                var jsonObject = MakeParameters(model);
                jsonArray.Add(jsonObject);
            }

            return jsonArray.ToString();
        }

        private JSONObject MakeParameters(PostBackModel obj)
        {
            var result = new JSONObject();

            //Events
            var eventsArray = new JSONArray();
            foreach (var evt in obj.Events)
            {
                eventsArray.Add(evt.Data);
            }

            //Logs
            var logsArray = new JSONArray();
            foreach (var log in obj.Logs)
            {
                logsArray.Add(log.Data);
            }

            foreach (var parameter in obj.Parameters)
            {
                result.AddAny(parameter.Key, parameter.Value);
            }

            result[Parameters.AFFISE_EVENTS_COUNT] = eventsArray.Count;
            result[EVENTS_KEY] = eventsArray;
            result[Parameters.AFFISE_SDK_EVENTS_COUNT] = logsArray.Count;
            result[SDK_EVENTS_KEY] = logsArray;

            return result;
        }
    }
}