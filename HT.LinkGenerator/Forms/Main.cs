using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HT.LinkGenerator.Infrastructure;
using HT.LinkGenerator.Model;
using HT.LinkGenerator.Settings;

namespace HT.LinkGenerator.Forms
{
    public partial class Main : Form
    {
        private readonly PaymentLinkSettings _linkSettings;

        public Main(PaymentLinkSettings linkSettings)
        {
            _linkSettings = linkSettings;
            InitializeComponent();
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatePrice();
        }


        private void eMailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            var hasError = false;
            hasError |= !ValidateEmail();
            hasError |= !ValidatePrice();
            foreach (var comboBox in new[] {currenciesComboBox, serviceTypeComboBox})
                hasError |= !ValidateComboBox(comboBox);

            if (hasError)
                return;

            var buttonText = sendButton.Text;
            try
            {
                sendButton.Enabled = false;
                sendButton.Text = "Sending...";
                
                var linkData = GetLinkData();

                await EdoClientProvider.Create(SettingsManager.Get())
                    .SendLink(linkData)
                    .ConfigureAwait(true);

                MessageBox.Show("Message sent", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sendButton.Text = buttonText;
                sendButton.Enabled = true;
            }
        }
        
        private async void generateUrlButton_Click(object sender, EventArgs e)
        {
            var hasError = false;
            hasError |= !ValidateEmail();
            hasError |= !ValidatePrice();
            foreach (var comboBox in new[] {currenciesComboBox, serviceTypeComboBox})
                hasError |= !ValidateComboBox(comboBox);

            if (hasError)
                return;

            var buttonText = generateUrlButton.Text;
            try
            {
                generateUrlButton.Enabled = false;
                generateUrlButton.Text = "Generating...";
                
                var linkData = GetLinkData();

                var linkUrl = await EdoClientProvider.Create(SettingsManager.Get())
                    .GenerateUrl(linkData)
                    .ConfigureAwait(true);

                var linkForm = new GeneratedLink(linkUrl);
                linkForm.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                generateUrlButton.Text = buttonText;
                generateUrlButton.Enabled = true;
            }
        }

        private PaymentLinkData GetLinkData()
        {
            return new PaymentLinkData(Convert.ToDecimal(priceTextBox.Text),
                eMailTextBox.Text,
                Convert.ToString(serviceTypeComboBox.SelectedValue),
                Enum.Parse<Currencies>(currenciesComboBox.Text),
                commentsTextBox.Text);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            currenciesComboBox.DataSource = _linkSettings.Currencies;
            serviceTypeComboBox.ValueMember =  nameof(KeyValuePair<string, string>.Key);
            serviceTypeComboBox.DisplayMember = nameof(KeyValuePair<string, string>.Value);
            serviceTypeComboBox.DataSource = _linkSettings.ServiceTypes.ToList();
        }

        private void comboBox_Changed(object sender, EventArgs e)
        {
            ValidateComboBox((ComboBox) sender);
        }

        private void pinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox) sender;
            TopMost = checkBox.Checked;
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            var optionsForm = new Options();
            optionsForm.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool ValidateComboBox(ComboBox comboBox)
        {
            errorProvider.SetError(comboBox, string.Empty);
            
            if (comboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBox, "Invalid selection");
                return false;
            }

            return true;
        }

        private bool ValidatePrice()
        {
            errorProvider.SetError(priceTextBox, string.Empty);
            if (!IsPriceValid(priceTextBox.Text))
            {
                errorProvider.SetError(priceTextBox, "Invalid price");
                return false;
            }

            return true;

            static bool IsPriceValid(string priceString)
            {
                return decimal.TryParse(priceString, out var price) &&
                       price > 0 &&
                       price * 100 == Math.Floor(price * 100);
            }
        }

        private bool ValidateEmail()
        {
            errorProvider.SetError(eMailTextBox, string.Empty);
            if (!IsValidEmail(eMailTextBox.Text))
            {
                errorProvider.SetError(eMailTextBox, "Invalid e-mail");
                return false;
            }

            return true;

            static bool IsValidEmail(string email)
            {
                if (string.IsNullOrEmpty(email))
                    return false;

                // From https://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/
                const string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                                 + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                                 + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                return new Regex(validEmailPattern, RegexOptions.IgnoreCase)
                    .IsMatch(email);
            }
        }
    }
}