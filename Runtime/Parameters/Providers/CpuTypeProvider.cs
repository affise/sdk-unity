using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.CPU_TYPE]
     */
    internal class CpuTypeProvider : StringPropertyProvider
    {
        public override float Order => 22.0f;
        public override ProviderType? Key => ProviderType.CPU_TYPE;
        public override string Provide() => Cpu.Type();
    }
}