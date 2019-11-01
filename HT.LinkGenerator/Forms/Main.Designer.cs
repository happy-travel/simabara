namespace HT.LinkGenerator.Forms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sendButton = new System.Windows.Forms.Button();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currenciesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eMailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.commentsTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pinCheckBox = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.optionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider)).BeginInit();
            this.SuspendLayout();
            this.sendButton.Location = new System.Drawing.Point(12, 269);
            this.sendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(477, 28);
            this.sendButton.TabIndex = 60;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            this.priceTextBox.Location = new System.Drawing.Point(73, 15);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(198, 27);
            this.priceTextBox.TabIndex = 10;
            this.priceTextBox.Text = "0.00";
            this.priceTextBox.TextChanged += new System.EventHandler(this.priceTextBox_TextChanged);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Price";
            this.currenciesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.currenciesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.currenciesComboBox.FormattingEnabled = true;
            this.currenciesComboBox.Location = new System.Drawing.Point(370, 15);
            this.currenciesComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.currenciesComboBox.Name = "currenciesComboBox";
            this.currenciesComboBox.Size = new System.Drawing.Size(119, 28);
            this.currenciesComboBox.TabIndex = 20;
            this.currenciesComboBox.TextChanged += new System.EventHandler(this.comboBox_Changed);
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type";
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "eMail";
            this.eMailTextBox.Location = new System.Drawing.Point(73, 99);
            this.eMailTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eMailTextBox.Name = "eMailTextBox";
            this.eMailTextBox.Size = new System.Drawing.Size(416, 27);
            this.eMailTextBox.TabIndex = 40;
            this.eMailTextBox.TextChanged += new System.EventHandler(this.eMailTextBox_TextChanged);
            this.label5.Location = new System.Drawing.Point(294, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Currency";
            this.serviceTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.serviceTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.serviceTypeComboBox.FormattingEnabled = true;
            this.serviceTypeComboBox.Location = new System.Drawing.Point(73, 54);
            this.serviceTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serviceTypeComboBox.Name = "serviceTypeComboBox";
            this.serviceTypeComboBox.Size = new System.Drawing.Size(416, 28);
            this.serviceTypeComboBox.TabIndex = 30;
            this.serviceTypeComboBox.TextChanged += new System.EventHandler(this.comboBox_Changed);
            this.commentsTextBox.Location = new System.Drawing.Point(12, 166);
            this.commentsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(477, 96);
            this.commentsTextBox.TabIndex = 50;
            this.commentsTextBox.Text = "";
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Comment";
            this.pinCheckBox.Location = new System.Drawing.Point(431, 301);
            this.pinCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pinCheckBox.Name = "pinCheckBox";
            this.pinCheckBox.Size = new System.Drawing.Size(58, 28);
            this.pinCheckBox.TabIndex = 130;
            this.pinCheckBox.Text = "pin";
            this.pinCheckBox.UseVisualStyleBackColor = true;
            this.pinCheckBox.CheckedChanged += new System.EventHandler(this.pinCheckBox_CheckedChanged);
            this.errorProvider.ContainerControl = this;
            this.optionsButton.Location = new System.Drawing.Point(350, 301);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(75, 28);
            this.optionsButton.TabIndex = 131;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 338);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.pinCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.serviceTypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eMailTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currenciesComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.sendButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Payment link generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox eMailTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox currenciesComboBox;
        private System.Windows.Forms.ComboBox serviceTypeComboBox;
        private System.Windows.Forms.RichTextBox commentsTextBox;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.CheckBox pinCheckBox;
    }
}