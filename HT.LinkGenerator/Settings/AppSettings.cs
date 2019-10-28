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

        public bool IsValid => !string.IsNullOrWhiteSpace(IdentityUrl) &&
                               !string.IsNullOrWhiteSpace(ApiUrl) &&
                               !string.IsNullOrWhiteSpace(ClientSecret);
        
        public bool Equals(AppSettings other)
        {
            return (IdentityUrl, ApiUrl, ClientSecret) == (other.IdentityUrl, other.ApiUrl, other.ClientSecret);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AppSettings) obj);
        }

        public override int GetHashCode() => (IdentityUrl, ApiUrl, ClientSecret).GetHashCode();
        
        public string IdentityUrl { get; }
        public string ApiUrl { get; }
        public string ClientSecret { get; }
    }
}