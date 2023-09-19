using SimpleJSON;

namespace AffiseAttributionLib.Init
{
    public class AffiseInitProperties
    {
        public string AffiseAppId { get; }
        
        public string SecretKey { get; set; }

        public string PartParamName { get; }

        public string PartParamNameToken { get; }

        public string AppToken { get; }

        public bool IsProduction { get; }

        public AffiseInitProperties(string affiseAppId, string secretKey) : this(
            affiseAppId: affiseAppId,
            secretKey: secretKey,
            partParamName: "",
            partParamNameToken: "",
            appToken: "",
            isProduction: true
        )
        {
        }

        public AffiseInitProperties(
            string affiseAppId,
            string secretKey,
            string partParamName = "",
            string partParamNameToken = "",
            string appToken = "",
            bool isProduction = true
        )
        {
            AffiseAppId = affiseAppId;
            PartParamName = partParamName;
            PartParamNameToken = partParamNameToken;
            AppToken = appToken;
            SecretKey = secretKey;
            IsProduction = isProduction;
        }

        private AffiseInitProperties(AffiseInitProperties props)
        {
            AffiseAppId = props.AffiseAppId;
            PartParamName = props.PartParamName;
            PartParamNameToken = props.PartParamNameToken;
            AppToken = props.AppToken;
            SecretKey = props.SecretKey;
            IsProduction = props.IsProduction;
        }

        public AffiseInitProperties Copy() => new(this);

        public JSONObject ToJson =>
            new()
            {
                ["affiseAppId"] = AffiseAppId,
                ["isProduction"] = IsProduction,
                ["partParamName"] = PartParamName,
                ["partParamNameToken"] = PartParamNameToken,
                ["appToken"] = AppToken,
                ["secretId"] = SecretKey,
            };
    }
}