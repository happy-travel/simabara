using System.ComponentModel;

namespace HT.LinkGenerator.Forms
{
    partial class GeneratedLink
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
            this.linkTextBox = new System.Windows.Forms.RichTextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.copyLinkButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkTextBox
            // 
            this.linkTextBox.Location = new System.Drawing.Point(14, 44);
            this.linkTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.linkTextBox.Name = "linkTextBox";
            this.linkTextBox.ReadOnly = true;
            this.linkTextBox.Size = new System.Drawing.Size(554, 76);
            this.linkTextBox.TabIndex = 0;
            this.linkTextBox.Text = "";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(323, 128);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(245, 32);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 24);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(204, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copied to clipboard";
            // 
            // copyLinkButton
            // 
            this.copyLinkButton.Location = new System.Drawing.Point(14, 128);
            this.copyLinkButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copyLinkButton.Name = "copyLinkButton";
            this.copyLinkButton.Size = new System.Drawing.Size(303, 32);
            this.copyLinkButton.TabIndex = 3;
            this.copyLinkButton.Text = "Copy";
            this.copyLinkButton.UseVisualStyleBackColor = true;
            this.copyLinkButton.Click += new System.EventHandler(this.copyLinkButton_Click_1);
            // 
            // GeneratedLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 176);
            this.Controls.Add(this.copyLinkButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.linkTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratedLink";
            this.ShowIcon = false;
            this.Text = "Payment link";
            this.Load += new System.EventHandler(this.GeneratedLink_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox linkTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button copyLinkButton;
    }
}