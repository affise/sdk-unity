#nullable enable
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Events.Parameters;
using AffiseAttributionLib.Events.Predefined;

namespace AffiseAttributionLib.Ad
{
    public class AffiseAdRevenue
    {
        private AffiseEvent _event = new AdRevenueEvent();

        public AffiseAdRevenue(AffiseAdSource source)
        {
            _event.AddPredefinedParameter(PredefinedString.SOURCE, source.Type());
        }

        public AffiseAdRevenue SetRevenue(float revenue, string currency)
        {
            _event.AddPredefinedParameter(PredefinedFloat.REVENUE, revenue);
            _event.AddPredefinedParameter(PredefinedString.CURRENCY, currency);
            return this;
        }

        public AffiseAdRevenue SetRevenue(double revenue, string currency)
        {
            _event.AddPredefinedParameter(PredefinedFloat.REVENUE, (float)revenue);
            _event.AddPredefinedParameter(PredefinedString.CURRENCY, currency);
            return this;
        }
        
        public AffiseAdRevenue SetNetwork(string? network)
        {
            if (network is null) return this;
            _event.AddPredefinedParameter(PredefinedString.NETWORK, network);
            return this;
        }

        public AffiseAdRevenue SetUnit(string? unit)
        {
            if (unit is null) return this;
            _event.AddPredefinedParameter(PredefinedString.UNIT, unit);
            return this;
        }

        public AffiseAdRevenue SetPlacement(string? placement)
        {
            if (placement is null) return this;
            _event.AddPredefinedParameter(PredefinedString.PLACEMENT, placement);
            return this;
        }

        public void Send()
        {
            _event.Send();
        }
    }
}