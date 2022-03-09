namespace SMS
{
    partial class MessageQuota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.MessageQuotaText = new System.Windows.Forms.TextBox();
            this.MessageQuotaLabel = new System.Windows.Forms.Label();
            this.DevicesListBox = new System.Windows.Forms.ListBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageQuotaText
            // 
            this.MessageQuotaText.Location = new System.Drawing.Point(136, 184);
            this.MessageQuotaText.Name = "MessageQuotaText";
            this.MessageQuotaText.Size = new System.Drawing.Size(152, 20);
            this.MessageQuotaText.TabIndex = 25;
            // 
            // MessageQuotaLabel
            // 
            this.MessageQuotaLabel.AutoSize = true;
            this.MessageQuotaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MessageQuotaLabel.Location = new System.Drawing.Point(12, 184);
            this.MessageQuotaLabel.Name = "MessageQuotaLabel";
            this.MessageQuotaLabel.Size = new System.Drawing.Size(118, 18);
            this.MessageQuotaLabel.TabIndex = 24;
            this.MessageQuotaLabel.Text = "Message Quota:";
            // 
            // DevicesListBox
            // 
            this.DevicesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DevicesListBox.FormattingEnabled = true;
            this.DevicesListBox.ItemHeight = 16;
            this.DevicesListBox.Location = new System.Drawing.Point(15, 12);
            this.DevicesListBox.Name = "DevicesListBox";
            this.DevicesListBox.Size = new System.Drawing.Size(273, 164);
            this.DevicesListBox.TabIndex = 26;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SaveButton.Location = new System.Drawing.Point(15, 210);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(273, 24);
            this.SaveButton.TabIndex = 27;
            this.SaveButton.Text = "Save Quota";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // MessageQuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(300, 247);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DevicesListBox);
            this.Controls.Add(this.MessageQuotaText);
            this.Controls.Add(this.MessageQuotaLabel);
            this.Name = "MessageQuota";
            this.Text = "Message Quota";
            this.Load += new System.EventHandler(this.MessageQuota_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageQuotaText;
        private System.Windows.Forms.Label MessageQuotaLabel;
        private System.Windows.Forms.ListBox DevicesListBox;
        private System.Windows.Forms.Button SaveButton;
    }
}