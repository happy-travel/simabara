using System;
using System.Windows.Forms;

namespace HappyTravel.Simabara.Forms
{
    public partial class GeneratedLink : Form
    {
        private readonly string _link;

        public GeneratedLink(string link)
        {
            _link = link;
            InitializeComponent();
        }

        private void GeneratedLink_Load(object sender, EventArgs e)
        {
            linkTextBox.Text = _link;
            Clipboard.SetText(_link);
            linkTextBox.SelectAll();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyLinkButton_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(_link);
        }
    }
}