namespace AffiseAttributionLib.Init
{
    public class InitPropertiesStorageImpl : IInitPropertiesStorage
    {
        private AffiseInitProperties properties;

        public AffiseInitProperties GetProperties() => properties;

        public void SetProperties(AffiseInitProperties model)
        {
            properties = model;
        }

        public void UpdateSecretId(string secretId)
        {
            properties = properties.Copy();
            properties.secretId = secretId;
        }
    }
}