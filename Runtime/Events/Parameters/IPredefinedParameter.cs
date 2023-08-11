using System.Collections.Generic;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Parameters
{
    public interface IPredefinedParameter
    {
        /**
         * Add predefined [parameter] with [value] of string
         */
        IPredefinedParameter AddPredefinedParameter(PredefinedString parameter, string value);

        /**
         * Add predefined [parameter] with [value] of long
         */
        IPredefinedParameter AddPredefinedParameter(PredefinedLong parameter, long value);

        /**
         * Add predefined [parameter] with [value] of float
         */
        IPredefinedParameter AddPredefinedParameter(PredefinedFloat parameter, float value);

        /**
         * Add predefined [parameter] with [value] of List string
         */
        IPredefinedParameter AddPredefinedParameter(PredefinedListString parameter, List<string> value);

        /**
         * Add predefined [parameter] with [value] of JSONObject
         */
        IPredefinedParameter AddPredefinedParameter(PredefinedObject parameter, JSONObject value);

        /**
         * Add predefined [parameter] with [value] of List<JSONObject>
         */
        IPredefinedParameter AddPredefinedParameter(PredefinedListObject parameter, List<JSONObject> value);
        
        /**
         * Add predefined ListGroup [value] of List<PredefinedGroup>
         */
        // TODO PredefinedGroup
        // IPredefinedParameter AddPredefinedListGroup(List<PredefinedGroup> value);
    }
}