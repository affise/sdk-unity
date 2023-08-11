using System.Collections.Generic;

namespace AffiseAttributionLib.Events.Parameters
{
    public class PredefinedGroup
    {
        public static readonly string NAME = $"{PredefinedConstants.PREFIX}list_group";

        /**
         * Group predefined parameters
         */
        private readonly Dictionary<string, object> _predefinedParameters = new();
        
        /**
         * Add predefined [parameter] with [value] of string to group
         */
        public PredefinedGroup AddPredefinedParameter(PredefinedString parameter, string value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
            return this;
        }

        /**
         * Add predefined [parameter] with [value] of long to group
         */
        public PredefinedGroup AddPredefinedParameter(PredefinedLong parameter, long value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
            return this;
        }

        /**
         * Add predefined [parameter] with [value] of float to group
         */
        public PredefinedGroup AddPredefinedParameter(PredefinedFloat parameter, float value)
        {
            _predefinedParameters.Add(parameter.ToValue(), value);
            return this;
        }
        
        /**
         * Get map of predefined parameter
         *
         * @return map of predefined parameter
         */
        internal Dictionary<string, object> GetPredefinedParameters() => _predefinedParameters;
    }
}