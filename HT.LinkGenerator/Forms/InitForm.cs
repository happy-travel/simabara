using System;
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
                var settings = SettingsManager.GetSettings();
                if (!settings.IsValid)
                {
                    MessageBox.Show("Invalid settings");
                    var result = new Options().ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        Close();
                        return;
                    }

                    continue;
                }
                
                try
                {
                    var linkSettings = await EdoClient.Create()
                        .GetSettings()
                        .ConfigureAwait(true);
                    
                    new Main(linkSettings).Show();
                    Hide();
                    break;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    var result = new Options().ShowDialog();
                    if (result != DialogResult.OK)
                        Close();
                }
            }
        }
    }
}