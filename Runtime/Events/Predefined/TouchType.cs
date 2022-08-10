namespace AffiseAttributionLib.Events.Predefined
{
    public enum TouchType
    {
        CLICK,
        WEB_TO_APP_AUTO_REDIRECT,
        IMPRESSION
    }
    
    public static class TouchTypeExtensions
    {
        public static string ToValue(this TouchType type)
        {
            return type switch
            {
                TouchType.CLICK => "CLICK",
                TouchType.WEB_TO_APP_AUTO_REDIRECT => "WEB_TO_APP_AUTO_REDIRECT",
                TouchType.IMPRESSION => "IMPRESSION",
                _ => null
            };
        }
    }
}