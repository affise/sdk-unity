using System;

namespace AffiseAttributionLib.Utils
{
    public static class Uuid
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}