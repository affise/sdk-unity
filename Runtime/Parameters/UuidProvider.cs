using System;
using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.UUID]
     */
    internal class UuidProvider : StringPropertyProvider
    {
        public override string Provide()
        {
            return Guid.NewGuid().ToString();
        }
    }
}