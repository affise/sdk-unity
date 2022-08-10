namespace AffiseAttributionLib.Init
{
    public interface IInitPropertiesStorage
    {
        AffiseInitProperties GetProperties();

        void SetProperties(AffiseInitProperties model);

        void UpdateSecretId(string secretId);
    }
}