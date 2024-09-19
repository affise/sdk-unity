#nullable enable

namespace AffiseAttributionLib.Module.Subscription
{
    public class AffiseProduct
    {
        public string ProductId { get; }
        public string Title { get; }
        public string Description { get; }

        public AffiseProductType ProductType { get; }

        public AffiseProductPrice? Price { get; }

        public AffiseProductSubscriptionDetail? Subscription { get; }

        public AffiseProduct(
            string productId,
            string title,
            string description,
            AffiseProductType productType,
            AffiseProductPrice? price,
            AffiseProductSubscriptionDetail? subscription
        )
        {
            ProductId = productId;
            Title = title;
            Description = description;
            ProductType = productType;
            Price = price;
            Subscription = subscription;
        }
        
        public override string ToString()
        {
            return $"AffiseProduct(productId={ProductId}, title={Title}, description={Description}, productType={ProductType}, price={Price}, subscription={Subscription})";
        }
    }
}