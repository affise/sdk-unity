using System.Collections.Generic;
using AffiseAttributionLib.Events.Parameters;
using SimpleJSON;

namespace AffiseAttributionLib.Events
{
    public abstract class AffiseEvent
    {
        /**
         * Event predefined parameters
         */
        private readonly Dictionary<string, object> _predefinedParameters = new();

        /**
         * Is first for user, default false
         */
        private bool _firstForUser;

        /**
         * Serialize event to JSONObject
         *
         * @return JSONObject
         */
        public abstract JSONNode Serialize();

        /**
         * Name of event
         *
         * @return name
         */
        public abstract string GetName();

        /**
         * Category of event
         *
         * @return category
         */
        public abstract string GetCategory();

        /**
         * User data
         *
         * @return userData
         */
        public abstract string GetUserData();

        /**
         * Is first for user, default false
         *
         * @return is first for user or not
         */
        public bool IsFirstForUser()
        {
            return _firstForUser;
        }

        internal void SetFirstForUser(bool firstForUser)
        {
            _firstForUser = firstForUser;
        }

        /**
         * Add predefined [parameter] with [value] of string to event
         */
        public void AddPredefinedParameter(PredefinedString parameter, string value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
        }

        /**
         * Add predefined [parameter] with [value] of List string to event
         */
        public void AddPredefinedParameter(PredefinedListString parameter, List<string> value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
        }

        /**
         * Add predefined [parameter] with [value] of long to event
         */
        public void AddPredefinedParameter(PredefinedLong parameter, long value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
        }

        /**
         * Add predefined [parameter] with [value] of float to event
         */
        public void AddPredefinedParameter(PredefinedFloat parameter, float value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
        }

        /**
         * Add predefined [parameter] with [value] of JSONObject to event
         */
        public void AddPredefinedParameter(PredefinedObject parameter, JSONObject value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
        }

        /**
         * Add predefined [parameter] with [value] of List<JSONObject> to event
         */
        public void AddPredefinedParameter(PredefinedListObject parameter, List<JSONObject> value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
        }

        /**
         * Get map of predefined parameter
         *
         * @return map of predefined parameter
         */
        internal Dictionary<string, object> GetPredefinedParameters() => _predefinedParameters;
    }
}