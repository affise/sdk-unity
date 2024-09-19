#nullable enable

using System.Collections.Generic;

namespace AffiseAttributionLib.Module.Subscription
{
    public class AffiseProductsResult
    {
        public List<AffiseProduct> Products { get; }
        public List<string> InvalidIds { get; }

        public AffiseProductsResult(List<AffiseProduct> products, List<string> invalidIds)
        {
            Products = products;
            InvalidIds = invalidIds;
        }
        
        public override string ToString()
        {
            return $"AffiseProductsResult(products=[{string.Join(", ", Products)}], invalidIds=[{string.Join(", ", InvalidIds)}])";
        }
    }
}