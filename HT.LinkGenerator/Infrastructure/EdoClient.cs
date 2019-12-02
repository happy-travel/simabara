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
using Serilog;

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
            
            Log.Information($"Getting shared settings from {_apiUrl}");
            var settingsString = await _edoHttpClient
                .GetStringAsync(UrlHelper.CombineUri(_apiUrl, GetSettingsUrl));

            Log.Debug($"Loaded shared settings: '{settingsString}'");
            return JsonConvert.DeserializeObject<PaymentLinkSettings>(settingsString);

            async Task<bool> IsVersionNotSupported()
            {
                Log.Debug("Checking app version against server's supported versions");
                var supportedVersionsString = await _edoHttpClient.GetStringAsync(UrlHelper.CombineUri(_apiUrl, SupportedVersionsUrl));
                var supportedVersions = JsonConvert
                    .DeserializeObject<List<DeserializableVersion>>(supportedVersionsString);

                var appVersion = Assembly.GetExecutingAssembly().GetName().Version;
                Log.Debug($"App version: '{appVersion}', supported versions: {string.Join(";", supportedVersions)}");

                return !supportedVersions.Any(v => v.Version.Major == appVersion.Major &&
                                                  v.Version.Minor == appVersion.Minor);
            }
        }

        public async Task SendLink(PaymentLinkData linkData)
        {
            var requestString = JsonConvert.SerializeObject(linkData);
            Log.Information($"Sending link to e-mail. Link data: {requestString}");
            var result = await _edoHttpClient.PostAsync(UrlHelper.CombineUri(_apiUrl, SendLinkUrl),
                new StringContent(requestString, Encoding.UTF8, "application/json"));

            if (!result.IsSuccessStatusCode)
            {
                Log.Error($"Failed to send link, response: {result.Content.ReadAsStringAsync().Result}");
                throw new HttpRequestException(result.ReasonPhrase);
            }
        }
        
        public async Task<string> GenerateUrl(PaymentLinkData linkData)
        {
            var requestString = JsonConvert.SerializeObject(linkData);
            Log.Information($"Sending link to e-mail. Link data: {requestString}");
            var result = await _edoHttpClient.PostAsync(UrlHelper.CombineUri(_apiUrl, GenerateLinkUrl),
                new StringContent(requestString, Encoding.UTF8, "application/json"));

            if (!result.IsSuccessStatusCode)
            {
                Log.Error($"Failed to generate link, response: {result.Content.ReadAsStringAsync().Result}");
                throw new HttpRequestException(result.ReasonPhrase);
            }

            return JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
        }

        

        public void Dispose()
        {
            _edoHttpClient?.Dispose();
        }

        private const string ControllerUrl = "en/api/1.0/external/payment-links";
        private static readonly string GetSettingsUrl = $"{ControllerUrl}/settings";
        private static readonly string SendLinkUrl = $"{ControllerUrl}/send";
        private static readonly string GenerateLinkUrl = ControllerUrl;
        private static readonly string SupportedVersionsUrl = $"{ControllerUrl}/versions";
        private readonly string _apiUrl;
        private readonly HttpClient _edoHttpClient;

        
    }
}