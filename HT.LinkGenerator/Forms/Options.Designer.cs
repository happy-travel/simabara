using System.ComponentModel;

namespace HT.LinkGenerator.Forms
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.identityUrlTextBox = new System.Windows.Forms.TextBox();
            this.apiUrlTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.clientSecretTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identity url *";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "EDO url *";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Client secret *";
            // 
            // identityUrlTextBox
            // 
            this.identityUrlTextBox.Location = new System.Drawing.Point(118, 9);
            this.identityUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.identityUrlTextBox.Name = "identityUrlTextBox";
            this.identityUrlTextBox.Size = new System.Drawing.Size(428, 27);
            this.identityUrlTextBox.TabIndex = 10;
            // 
            // apiUrlTextBox
            // 
            this.apiUrlTextBox.Location = new System.Drawing.Point(118, 42);
            this.apiUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.apiUrlTextBox.Name = "apiUrlTextBox";
            this.apiUrlTextBox.Size = new System.Drawing.Size(428, 27);
            this.apiUrlTextBox.TabIndex = 20;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(118, 115);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(144, 34);
            this.okButton.TabIndex = 40;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(268, 115);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(145, 34);
            this.cancelButton.TabIndex = 50;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // clientSecretTextBox
            // 
            this.clientSecretTextBox.Location = new System.Drawing.Point(118, 75);
            this.clientSecretTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clientSecretTextBox.Name = "clientSecretTextBox";
            this.clientSecretTextBox.PasswordChar = '*';
            this.clientSecretTextBox.Size = new System.Drawing.Size(428, 27);
            this.clientSecretTextBox.TabIndex = 30;
            this.clientSecretTextBox.UseSystemPasswordChar = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 168);
            this.Controls.Add(this.clientSecretTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.apiUrlTextBox);
            this.Controls.Add(this.identityUrlTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clientSecretTextBox;
        private System.Windows.Forms.TextBox identityUrlTextBox;
        private System.Windows.Forms.TextBox apiUrlTextBox;
    }
}