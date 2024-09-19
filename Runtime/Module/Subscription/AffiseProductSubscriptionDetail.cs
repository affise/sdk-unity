#nullable enable

namespace AffiseAttributionLib.Module.Subscription
{
    public class AffiseProductSubscriptionDetail
    {
        public string? OfferToken { get; }
        public string? OfferId { get; }
        public TimeUnitType? TimeUnit { get; }
        public int? NumberOfUnits { get; }

        public AffiseProductSubscriptionDetail(string? offerToken, string? offerId, TimeUnitType? timeUnit, int? numberOfUnits)
        {
            OfferToken = offerToken;
            OfferId = offerId;
            TimeUnit = timeUnit;
            NumberOfUnits = numberOfUnits;
        }
        
        public override string ToString()
        {
            return $"AffiseProductSubscriptionDetail(offerToken={OfferToken}, offerId={OfferId}, timeUnit={TimeUnit?.ToValue()}, numberOfUnits={NumberOfUnits})";
        }
    }
}