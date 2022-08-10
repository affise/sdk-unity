using System;
using System.Collections.Generic;
using System.Globalization;
using AffiseAttributionLib.AffiseParameters.Base;
using SystemInfo = UnityEngine.Device.SystemInfo;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CPU_TYPE]
     */
    internal class CpuTypeProvider : StringPropertyProvider
    {
        public override string Provide() => GetCpuType();

        private string GetCpuType()
        {
            var inf = new List<string>();
            if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(SystemInfo.processorType, "ARM", CompareOptions.IgnoreCase) >= 0)
            {
                inf.Add(Environment.Is64BitProcess ? "arm64" : "arm");
            }
            else
            {
                // Must be in the x86 family.
                inf.Add(Environment.Is64BitProcess ? "x86_64" : "x86");
            }

            inf.Add(SystemInfo.processorType);
            return String.Join(", ", inf);
        }
    }
}