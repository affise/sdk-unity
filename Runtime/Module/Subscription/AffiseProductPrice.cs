#nullable enable

namespace AffiseAttributionLib.Module.Subscription
{
    public class AffiseProductPrice
    {
        public float Value { get; }
        public string CurrencyCode { get; }
        public string FormattedPrice { get; }

        public AffiseProductPrice(float value, string currencyCode, string formattedPrice)
        {
            Value = value;
            CurrencyCode = currencyCode;
            FormattedPrice = formattedPrice;
        }
        
        public override string ToString()
        {
            return $"AffiseProductPrice(value={Value}, currencyCode={CurrencyCode}, formattedPrice={FormattedPrice})";
        }
    }
}