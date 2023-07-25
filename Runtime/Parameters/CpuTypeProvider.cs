using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CPU_TYPE]
     */
    internal class CpuTypeProvider : StringPropertyProvider
    {
        public override float Order => 22.0f;
        public override string Key => Parameters.CPU_TYPE;
        public override string Provide() => Cpu.Type();
    }
}