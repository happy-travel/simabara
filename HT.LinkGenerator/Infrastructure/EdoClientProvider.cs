using HT.LinkGenerator.Settings;

namespace HT.LinkGenerator.Infrastructure
{
    public static class EdoClientProvider
    {
        public static EdoClient Get()
        {
            lock (Locker)
            {
                var settings = SettingsManager.GetSettings();
                if (!settings.Equals(_currentClientInfo.Settings))
                {
                    _currentClientInfo.Client?.Dispose();
                    _currentClientInfo = (settings, CreateClient(settings));
                }

                return _currentClientInfo.Client;
            }

            static EdoClient CreateClient(AppSettings settings)
            {
                return new EdoClient(settings.ApiUrl, new BearerTokenHandler(settings.IdentityUrl, settings.ClientSecret));
            }
        }
        
        private static readonly object Locker = new object();
        private static (AppSettings Settings, EdoClient Client) _currentClientInfo;
    }
}