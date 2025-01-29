#nullable enable
using System;

namespace AffiseAttributionLib.Utils
{
    internal static class StringUtils
    {

        public static bool ToBoolean(this string value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}