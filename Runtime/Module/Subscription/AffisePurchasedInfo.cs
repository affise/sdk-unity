#nullable enable

namespace AffiseAttributionLib.Module.Subscription
{
    public class AffisePurchasedInfo
    {
        public AffiseProduct? Product { get; }
        public string? OrderId { get; }
        public string? OriginalOrderId { get; }
        public string? Purchase { get; }

        public AffisePurchasedInfo(AffiseProduct? product, string? orderId, string? originalOrderId, string? purchase)
        {
            Product = product;
            OrderId = orderId;
            OriginalOrderId = originalOrderId;
            Purchase = purchase;
        }
        
        public override string ToString()
        {
            return $"AffisePurchasedInfo(product={Product}, orderId={OrderId}, originalOrderId={OriginalOrderId}, purchase={Purchase})";
        }
    }
}