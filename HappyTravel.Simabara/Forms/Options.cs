using System;
using System.Net.Http;
using System.Windows.Forms;
using HappyTravel.Simabara.Infrastructure;
using HappyTravel.Simabara.Settings;
using Newtonsoft.Json;
using Serilog;

namespace HappyTravel.Simabara.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            var settings = SettingsManager.Get();
            Log.Debug($"Load settings complete");
            identityUrlTextBox.Text = settings.IdentityUrl;
            apiUrlTextBox.Text = settings.ApiUrl;
            clientSecretTextBox.Text = settings.ClientSecret.ToInsecureString();
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            foreach (var textBox in new [] { identityUrlTextBox, apiUrlTextBox, clientSecretTextBox })
            {
                errorProvider.SetError(textBox, string.Empty);
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    hasError = true;
                    errorProvider.SetError(textBox, "Field is required");
                }
            }

            if (hasError)
                return;

            var settings = new AppSettings(identityUrlTextBox.Text, apiUrlTextBox.Text, clientSecretTextBox.Text.ToSecureString());
            try
            {
                Log.Debug($"Validating settings: {JsonConvert.SerializeObject(settings)}");
                await EdoClientProvider.Create(settings)
                    .GetSharedSettings()
                    .ConfigureAwait(true);
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is InvalidOperationException )
            {
                Log.Warning($"Failed to validate settings: {ex.Message}");
                Log.Debug($"Error stacktrace: '{ex.StackTrace}'");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SettingsManager.Set(settings);
            Log.Debug("Saving settings to file");
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}