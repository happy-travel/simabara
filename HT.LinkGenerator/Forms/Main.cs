using System;
using System.Net.Mail;
using System.Windows.Forms;
using HT.LinkGenerator.Infrastructure;
using HT.LinkGenerator.Model;

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
            foreach (var comboBox in new[] {currenciesComboBox, facilityTypeComboBox})
                hasError |= !ValidateComboBox(comboBox);

            if (hasError)
                return; 

            try
            {
                await EdoClient.Create().SendLink(eMailTextBox.Text, new PaymentLinkData(
                        Convert.ToDecimal(priceTextBox.Text),
                        facilityTypeComboBox.Text,
                        currenciesComboBox.Text, commentsTextBox.Text))
                    .ConfigureAwait(true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            currenciesComboBox.DataSource = _linkSettings.Currencies;
            facilityTypeComboBox.DataSource = _linkSettings.Facilities;
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
            if (comboBox.Items.IndexOf(comboBox.Text) < 0)
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

                try
                {
                    var mail = new MailAddress(email);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}