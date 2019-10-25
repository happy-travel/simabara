using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HT.LinkGenerator.Model;
using Newtonsoft.Json;

namespace HT.LinkGenerator.Infrastructure
{
    public class EdoClient
    {
        private EdoClient(string apiUrl, BearerTokenHandler bearerTokenHandler)
        {
            _edoHttpClient = new HttpClient(bearerTokenHandler);
            _apiUrl = apiUrl;
        }
        
        public static EdoClient Create()
        {
            var settings = SettingsManager.GetSettings();
            return new EdoClient(settings.ApiUrl, new BearerTokenHandler(settings.IdentityUrl, settings.ClientSecret));
        }

        public async Task<PaymentLinkSettings> GetSettings()
        {
            var currenciesString = await _edoHttpClient
                .GetStringAsync($"{_apiUrl}/{GetSettingsUrl}");

            return JsonConvert.DeserializeObject<PaymentLinkSettings>(currenciesString);
        }

        public async Task SendLink(string email, PaymentLinkData linkData)
        {
            var requestString = JsonConvert.SerializeObject(new SendPaymentLinkRequest(email, linkData));
            var result = await _edoHttpClient.PostAsync($"{_apiUrl}/{SendLinkUrl}",
                new StringContent(requestString, Encoding.UTF8, "application/json"));

            if (result.StatusCode != HttpStatusCode.NoContent)
                throw new HttpRequestException(result.ReasonPhrase);
        }
        
        private const string GetSettingsUrl = "en/api/1.0/paymentLinks/settings";
        private const string SendLinkUrl = "en/api/1.0/paymentLinks/send";
        private readonly string _apiUrl;
        private readonly HttpClient _edoHttpClient;
    }
}