using System.Collections.Generic;
using AffiseAttributionLib.Events.Predefined;
using SimpleJSON;

namespace AffiseAttributionLib.Events
{
    public abstract class AffiseEvent
    {
        private readonly Dictionary<PredefinedParameters, string> _predefinedParameters = new();

        public abstract JSONNode Serialize();
        public abstract string GetName();

        public abstract string GetCategory();

        public abstract string GetUserData();

        public bool IsFirstForUser()
        {
            return false;
        }

        public void AddPredefinedParameter(PredefinedParameters parameter, string value)
        {
            _predefinedParameters.Add(parameter, value);
        }

        public Dictionary<PredefinedParameters, string> GetPredefinedParameters() => _predefinedParameters;
    }
}