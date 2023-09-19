namespace AffiseAttributionLib.Init
{
    public class InitPropertiesStorageImpl : IInitPropertiesStorage
    {
        private AffiseInitProperties _properties;

        public AffiseInitProperties GetProperties() => _properties;

        public void SetProperties(AffiseInitProperties properties)
        {
            _properties = properties;
        }

        public void UpdateSecretKey(string secretKey)
        {
            _properties = _properties.Copy();
            _properties.SecretKey = secretKey;
        }
    }
}