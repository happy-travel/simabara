using System.Security;

namespace HappyTravel.Simabara.Settings
{
    public class AppSettings
    {
        public AppSettings(string identityUrl, string apiUrl, SecureString clientSecret)
        {
            IdentityUrl = identityUrl;
            ApiUrl = apiUrl;
            ClientSecret = clientSecret;
        }

        public bool IsSet => !string.IsNullOrWhiteSpace(IdentityUrl) &&
                               !string.IsNullOrWhiteSpace(ApiUrl) &&
                               ClientSecret != null;
        
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
        public SecureString ClientSecret { get; }
    }
}