#nullable enable

using System;

namespace AffiseAttributionLib.Module.Subscription
{
    public enum AffiseProductType
    {
        CONSUMABLE,
        NON_CONSUMABLE,
        RENEWABLE_SUBSCRIPTION,
        NON_RENEWABLE_SUBSCRIPTION,
    }
    
    internal static class AffiseProductTypeExt
    {
        public static string? ToValue(this AffiseProductType param)
        {
            return param switch
            {
                AffiseProductType.CONSUMABLE => "consumable",
                AffiseProductType.NON_CONSUMABLE => "non_consumable",
                AffiseProductType.RENEWABLE_SUBSCRIPTION => "renewable_subscription",
                AffiseProductType.NON_RENEWABLE_SUBSCRIPTION => "non_renewable_subscription",
                _ => null
            };
        }     
        
        internal static AffiseProductType? From(string? value)
        {
            if (value is null) return null;
            foreach (var type in Enum.GetValues(typeof(AffiseProductType)))
            {
                if (type is not AffiseProductType productType) continue;
                if (productType.ToValue() == value) return productType;
            }
            return null;
        }
    }
}