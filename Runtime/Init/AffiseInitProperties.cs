namespace AffiseAttributionLib.Init
{
    public class AffiseInitProperties
    {
        public readonly string affiseAppId = "";

        public readonly string partParamName = "";

        public readonly string partParamNameToken = "";

        public readonly string appToken = "";

        public string secretId = "";

        public readonly bool isProduction = true;
        
        public readonly AffiseBuildInfo buildInfo;

        public AffiseInitProperties(
            string affiseAppId, string partParamName,
            string partParamNameToken, string appToken,
            string secretId, bool isProduction, AffiseBuildInfo buildInfo = null
        )
        {
            this.affiseAppId = affiseAppId;
            this.partParamName = partParamName;
            this.partParamNameToken = partParamNameToken;
            this.appToken = appToken;
            this.secretId = secretId;
            this.isProduction = isProduction;
            this.buildInfo = buildInfo;
        }

        private AffiseInitProperties(AffiseInitProperties props)
        {
            affiseAppId = props.affiseAppId;
            partParamName = props.partParamName;
            partParamNameToken = props.partParamNameToken;
            appToken = props.appToken;
            secretId = props.secretId;
            isProduction = props.isProduction;
            buildInfo = props.buildInfo;
        }

        public AffiseInitProperties Copy() => new(this);
    }
}