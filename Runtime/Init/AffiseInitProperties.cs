using SimpleJSON;

namespace AffiseAttributionLib.Init
{
    public class AffiseInitProperties
    {
        public readonly string affiseAppId = "";

        public readonly string partParamName = "";

        public readonly string partParamNameToken = "";

        public readonly string appToken = "";

        public string secretKey = "";

        public readonly bool isProduction = true;
        
        public readonly AffiseBuildInfo buildInfo;

        public AffiseInitProperties(
            string affiseAppId, string partParamName,
            string partParamNameToken, string appToken,
            string secretKey, bool isProduction, AffiseBuildInfo buildInfo = null
        )
        {
            this.affiseAppId = affiseAppId;
            this.partParamName = partParamName;
            this.partParamNameToken = partParamNameToken;
            this.appToken = appToken;
            this.secretKey = secretKey;
            this.isProduction = isProduction;
            this.buildInfo = buildInfo;
        }

        private AffiseInitProperties(AffiseInitProperties props)
        {
            affiseAppId = props.affiseAppId;
            partParamName = props.partParamName;
            partParamNameToken = props.partParamNameToken;
            appToken = props.appToken;
            secretKey = props.secretKey;
            isProduction = props.isProduction;
            buildInfo = props.buildInfo;
        }

        public AffiseInitProperties Copy() => new(this);
        
        public JSONObject ToJson =>
            new()
            {
                ["affiseAppId"] = affiseAppId,
                ["isProduction"] = isProduction,
                ["partParamName"] = partParamName,
                ["partParamNameToken"] = partParamNameToken,
                ["appToken"] = appToken,
                ["secretId"] = secretKey,
            };
    }
}