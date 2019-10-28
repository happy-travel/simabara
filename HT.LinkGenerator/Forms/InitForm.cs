using System;
using System.Net.Http;
using System.Windows.Forms;
using HT.LinkGenerator.Infrastructure;
using HT.LinkGenerator.Settings;

namespace HT.LinkGenerator.Forms
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
        }

        private async void InitForm_Load(object sender, EventArgs e)
        {
            while (true)
            {
                var settings = SettingsManager.Get();
                if (!settings.IsValid)
                {
                    MessageBox.Show("Invalid settings", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var result = new Options().ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        Close();
                        return;
                    }

                    continue;
                }

                try
                {
                    var linkSettings = await EdoClientProvider.Create(settings)
                        .GetSharedSettings()
                        .ConfigureAwait(true);

                    new Main(linkSettings).Show();
                    Hide();
                    break;
                }
                catch (Exception ex) when (ex is HttpRequestException || ex is InvalidOperationException )
                {
                    var result = new Options().ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        Close();
                        return;
                    }
                }
                
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }
    }
}