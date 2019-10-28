using System.Configuration;
using System.Reflection;

namespace HT.LinkGenerator.Settings
{
    public static class SettingsManager
    {
        public static AppSettings Get()
        {
            var configuration = ConfigurationManager.
                OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            var appSettings = configuration.AppSettings.Settings;
            
            return new AppSettings(appSettings[nameof(AppSettings.IdentityUrl)]?.Value, 
                appSettings[nameof(AppSettings.ApiUrl)]?.Value,
                appSettings[nameof(AppSettings.ClientSecret)]?.Value);
        }

        public static void Set(AppSettings settings)
        {
            var configuration = ConfigurationManager.
                OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            UpdateSetting(nameof(AppSettings.ApiUrl), settings.ApiUrl);
            UpdateSetting(nameof(AppSettings.IdentityUrl), settings.IdentityUrl);
            UpdateSetting(nameof(AppSettings.ClientSecret), settings.ClientSecret);
            
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