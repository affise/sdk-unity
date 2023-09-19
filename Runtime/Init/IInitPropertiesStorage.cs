namespace AffiseAttributionLib.Init
{
    public interface IInitPropertiesStorage
    {
        AffiseInitProperties GetProperties();

        void SetProperties(AffiseInitProperties properties);

        void UpdateSecretKey(string secretKey);
    }
}