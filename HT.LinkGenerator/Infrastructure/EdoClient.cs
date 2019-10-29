using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HT.LinkGenerator.Model;
using Newtonsoft.Json;

namespace HT.LinkGenerator.Infrastructure
{
    public class EdoClient : IDisposable
    {
        public EdoClient(string apiUrl, BearerTokenHandler bearerTokenHandler)
        {
            _edoHttpClient = new HttpClient(bearerTokenHandler);
            _apiUrl = apiUrl;
        }
        
        public async Task<PaymentLinkSettings> GetSharedSettings()
        {
            if(await IsVersionNotSupported())
                throw new Exception("Version is not supported. Please install a new version of this app");
            
            var settingsString = await _edoHttpClient
                .GetStringAsync($"{_apiUrl}/{GetSettingsUrl}");

            return JsonConvert.DeserializeObject<PaymentLinkSettings>(settingsString);

            async Task<bool> IsVersionNotSupported()
            {
                var supportedVersionsString = await _edoHttpClient.GetStringAsync($"{_apiUrl}/{SupportedVersionsUrl}");
                var supportedVersions = JsonConvert
                    .DeserializeObject<List<DeserializableVersion>>(supportedVersionsString);

                var appVersion = Assembly.GetExecutingAssembly().GetName().Version;

                return !supportedVersions.Any(v => v.Version.Major == appVersion.Major &&
                                                  v.Version.Minor == appVersion.Minor);
            }
        }

        public async Task SendLink(string email, PaymentLinkData linkData)
        {
            var requestString = JsonConvert.SerializeObject(new SendPaymentLinkRequest(email, linkData));
            var result = await _edoHttpClient.PostAsync($"{_apiUrl}/{SendLinkUrl}",
                new StringContent(requestString, Encoding.UTF8, "application/json"));

            if (result.StatusCode != HttpStatusCode.NoContent)
                throw new HttpRequestException(result.ReasonPhrase);
        }
        
        public void Dispose()
        {
            _edoHttpClient?.Dispose();
        }
        
        private const string GetSettingsUrl = "en/api/1.0/external/payment-links/settings";
        private const string SendLinkUrl = "en/api/1.0/external/payment-links";
        private const string SupportedVersionsUrl = "en/api/1.0/external/payment-links/versions";
        private readonly string _apiUrl;
        private readonly HttpClient _edoHttpClient;
    }
}