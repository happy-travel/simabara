using HappyTravel.Simabara.Settings;

namespace HappyTravel.Simabara.Infrastructure
{
    public static class EdoClientProvider
    {
        public static EdoClient Create(AppSettings settings)
        {
            lock (Locker)
            {
                if (_currentClientInfo == default || !settings.Equals(_currentClientInfo.Settings))
                {
                    _currentClientInfo.Client?.Dispose();
                    _currentClientInfo = (settings, CreateClient(settings));
                }

                return _currentClientInfo.Client;
            }

            static EdoClient CreateClient(AppSettings settings)
            {
                return new EdoClient(settings.ApiUrl, new BearerTokenHandler(settings.IdentityUrl, settings.ClientSecret.ToInsecureString()));
            }
        }
        
        private static readonly object Locker = new object();
        private static (AppSettings Settings, EdoClient Client) _currentClientInfo;
    }
}