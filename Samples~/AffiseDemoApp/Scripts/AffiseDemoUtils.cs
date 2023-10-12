#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib.Referrer;

namespace AffiseDemo
{
    public static class AffiseDemoUtils
    {
        public static List<string> ReferrerValues()
        {
            return Enum.GetValues(typeof(ReferrerKey))
                .Cast<ReferrerKey>()
                .Select(s => s.ToString())
                .ToList();
        }

        public static ReferrerKey ToReferrer(string referrerName)
        {
            Enum.TryParse(referrerName, out ReferrerKey referrer);
            return referrer;
        }
    }
}