using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.UUID]
     */
    internal class UuidProvider : StringPropertyProvider
    {
        public override float Order => 64.0f;
        public override string Key => Parameters.UUID;
        public override string Provide()
        {
            return Uuid.Generate();
        }
    }
}