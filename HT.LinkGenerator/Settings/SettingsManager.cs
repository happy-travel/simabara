using System.Configuration;
using System.Reflection;
using HT.LinkGenerator.Infrastructure;
using Newtonsoft.Json;
using Serilog;

namespace HT.LinkGenerator.Settings
{
    public static class SettingsManager
    {
        public static AppSettings Get()
        {
            var settingsPath = Assembly.GetExecutingAssembly().Location;
            Log.Debug($"Loading settings from {settingsPath}");
            var configuration = ConfigurationManager.
                OpenExeConfiguration(settingsPath);

            var appSettings = configuration.AppSettings.Settings;
            var clientSecret = StringEncryptor.DecryptString(appSettings[nameof(AppSettings.ClientSecret)]?.Value);
            
            return new AppSettings(appSettings[nameof(AppSettings.IdentityUrl)]?.Value, 
                appSettings[nameof(AppSettings.ApiUrl)]?.Value,
                clientSecret);
        }

        public static void Set(AppSettings settings)
        {
            Log.Debug($"Saving settings to file: '{JsonConvert.SerializeObject(settings)}'");
            var configuration = ConfigurationManager.
                OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            UpdateSetting(nameof(AppSettings.ApiUrl), settings.ApiUrl);
            UpdateSetting(nameof(AppSettings.IdentityUrl), settings.IdentityUrl);

            var encryptedClientSecret = StringEncryptor.EncryptString(settings.ClientSecret);
            
            UpdateSetting(nameof(AppSettings.ClientSecret), encryptedClientSecret);
            
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");

            void UpdateSetting(string key, string value)
            {
                if(configuration.AppSettings.Settings[key] == null)
                    configuration.AppSettings.Settings.Add(key, value);
                else
                    configuration.AppSettings.Settings[key].Value = value;
            }
        }
    }
}