namespace HT.LinkGenerator.Settings
{
    public class AppSettings
    {
        public AppSettings(string identityUrl, string apiUrl, string clientSecret)
        {
            IdentityUrl = identityUrl;
            ApiUrl = apiUrl;
            ClientSecret = clientSecret;
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(IdentityUrl) ||
                    string.IsNullOrWhiteSpace(ApiUrl) ||
                    string.IsNullOrWhiteSpace(ClientSecret))
                {
                    return false;
                }

                return true;
            }
        }
        
        public string IdentityUrl { get; }
        public string ApiUrl { get; }
        public string ClientSecret { get; }
    }
}