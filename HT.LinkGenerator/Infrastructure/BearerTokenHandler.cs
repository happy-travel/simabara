using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Serilog;

namespace HT.LinkGenerator.Infrastructure
{
    public class BearerTokenHandler : DelegatingHandler
    {
        public BearerTokenHandler(string identityUrl, string clientSecret) : base(new HttpClientHandler())
        {
            _identityUrl = identityUrl;
            _clientSecret = clientSecret;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Log.Debug($"Handling request to '{request.RequestUri}' using {nameof(BearerTokenHandler)}");
            request.SetBearerToken(await GetToken());
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> GetToken()
        {
            Log.Debug($"Requesting token from '{_identityUrl}'");
            var tokenResponse = await IdentityHttpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = UrlHelper.CombineUri(_identityUrl, "/connect/token"),
                    ClientId = "link_generator",
                    ClientSecret = _clientSecret,
                    Scope = "edo"
                });

            if (tokenResponse.IsError)
            {
                Log.Warning($"Failed to authorize on identity server: '{tokenResponse.Error}'");
                throw new HttpRequestException("Authorization failed");
            }
                
            Log.Debug("Access token retrieved");    
            return tokenResponse.AccessToken;
        }
        
        private static readonly HttpClient IdentityHttpClient = new HttpClient();
        private readonly string _clientSecret;
        private readonly string _identityUrl;
    }
}