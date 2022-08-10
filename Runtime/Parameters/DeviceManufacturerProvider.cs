using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.DEVICE_MANUFACTURER]
     */
    internal class DeviceManufacturerProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public DeviceManufacturerProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetDeviceManufacturer();
    }
}