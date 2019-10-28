using System;
using System.Net.Http;
using System.Windows.Forms;
using HT.LinkGenerator.Infrastructure;
using HT.LinkGenerator.Settings;

namespace HT.LinkGenerator.Forms
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
            identityUrlTextBox.Text = settings.IdentityUrl;
            apiUrlTextBox.Text = settings.ApiUrl;
            clientSecretTextBox.Text = settings.ClientSecret;
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

            var settings = new AppSettings(identityUrlTextBox.Text, apiUrlTextBox.Text, clientSecretTextBox.Text);
            try
            {
                await EdoClientProvider.Create(settings)
                    .GetSharedSettings()
                    .ConfigureAwait(true);
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is InvalidOperationException )
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SettingsManager.Set(settings);
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}