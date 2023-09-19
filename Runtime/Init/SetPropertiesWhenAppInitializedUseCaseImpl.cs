namespace AffiseAttributionLib.Init
{
    public class SetPropertiesWhenAppInitializedUseCaseImpl : ISetPropertiesWhenAppInitializedUseCase
    {
        private readonly IInitPropertiesStorage _storage;

        public SetPropertiesWhenAppInitializedUseCaseImpl(IInitPropertiesStorage storage)
        {
            _storage = storage;
        }

        public void Init(AffiseInitProperties initProperties)
        {
            _storage.SetProperties(initProperties);
        }
    }
}