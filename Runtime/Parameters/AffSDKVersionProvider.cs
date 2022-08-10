using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_SDK_VERSION]
     */
    internal class AffSDKVersionProvider : StringPropertyProvider
    {
        private readonly IInitPropertiesStorage _initPropertiesStorage;

        public AffSDKVersionProvider(IInitPropertiesStorage initPropertiesStorage)
        {
            _initPropertiesStorage = initPropertiesStorage;
        }

        public override string Provide() => _initPropertiesStorage.GetProperties().buildInfo?.version ?? "unknown";
    }
}