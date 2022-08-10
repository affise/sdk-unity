namespace AffiseAttributionLib.Deeplink
{
    internal class DeeplinkClickRepositoryImpl : IDeeplinkClickRepository
    {
        private bool _isDeeplinkClick;
        private string _deeplink;

        public void SetDeeplinkClick(bool isDeeplink)
        {
            _isDeeplinkClick = isDeeplink;
        }

        public bool IsDeeplinkClick()
        {
            return _isDeeplinkClick;
        }

        public void SetDeeplink(string deeplink)
        {
            _deeplink = deeplink;
        }

        public string GetDeeplink()
        {
            return _deeplink;
        }
    }
}