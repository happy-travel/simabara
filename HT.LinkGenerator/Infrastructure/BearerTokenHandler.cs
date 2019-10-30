using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

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
            request.SetBearerToken(await GetToken());
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> GetToken()
        {
            var tokenResponse = await IdentityHttpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = UrlHelper.CombineUri(_identityUrl, "/connect/token"),
                    ClientId = "linkGenerator",
                    ClientSecret = _clientSecret,
                    Scope = "edo"
                });

            if (tokenResponse.IsError)
                throw new HttpRequestException("Authorization failed");
                
            return tokenResponse.AccessToken;
        }
        
        private static readonly HttpClient IdentityHttpClient = new HttpClient();
        private readonly string _clientSecret;
        private readonly string _identityUrl;
    }
}