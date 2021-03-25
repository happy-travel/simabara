using System;
using System.Net.Http;
using System.Windows.Forms;
using HappyTravel.Simabara.Infrastructure;
using HappyTravel.Simabara.Settings;
using Serilog;

namespace HappyTravel.Simabara.Forms
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
                Log.Verbose("Retrieving application settings");
                var settings = SettingsManager.Get();
                if (!settings.IsSet)
                {
                    Log.Verbose($"Settings are empty, showing {nameof(Options)} window");
                    var result = new Options().ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        Log.Verbose($"Saving settings was cancelled by user. Exiting application...");
                        Close();
                        return;
                    }
                    Log.Debug("Trying to get settings again");
                    continue;
                }

                try
                {
                    Log.Debug("Getting shared settings from server");
                    var linkSettings = await EdoClientProvider.Create(settings)
                        .GetSharedSettings()
                        .ConfigureAwait(true);

                    Log.Debug($"Shared settings loaded successful, opening {nameof(Main)} window");
                    new Main(linkSettings).Show();
                    Hide();
                    break;
                }
                catch (Exception ex) when (ex is HttpRequestException || ex is InvalidOperationException )
                {
                    Log.Warning($"Failed to get shared settings, error '{ex.Message}'. Showing {nameof(Options)} dialog again");
                    Log.Debug($"Error stacktrace {ex.StackTrace}");
                    var result = new Options().ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        Log.Debug($"Saving settings was cancelled by user. Exiting application...");
                        Close();
                        return;
                    }
                }
                
                catch (Exception exception)
                {
                    Log.Error(exception, $"Error loading shared settings from server: '{exception.Message} {exception.StackTrace}'");
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }
    }
}