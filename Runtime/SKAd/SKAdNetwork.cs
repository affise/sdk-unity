namespace AffiseAttributionLib.SKAd
{
    public class SKAdNetwork
    {
        public static SKAdNetwork CoarseConversionValue => new SKAdNetwork();

        private SKAdNetwork()
        {
        }

        public CoarseValue High => new CoarseValue("high");

        public CoarseValue Low => new CoarseValue("low");

        public CoarseValue Medium => new CoarseValue("medium");

        public CoarseValue Custom(string value) => new CoarseValue(value);
    }
}