namespace SMS
{
    partial class DeviceRegister
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sendSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceNameLabel = new System.Windows.Forms.Label();
            this.DeviceNameText = new System.Windows.Forms.TextBox();
            this.DeviceListbox = new System.Windows.Forms.ListBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.PictureBox();
            this.setMessageQuotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshButton)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendSMSToolStripMenuItem,
            this.setMessageQuotaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(393, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sendSMSToolStripMenuItem
            // 
            this.sendSMSToolStripMenuItem.Name = "sendSMSToolStripMenuItem";
            this.sendSMSToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.sendSMSToolStripMenuItem.Text = "Send SMS";
            this.sendSMSToolStripMenuItem.Click += new System.EventHandler(this.sendSMSToolStripMenuItem_Click);
            // 
            // DeviceNameLabel
            // 
            this.DeviceNameLabel.AutoSize = true;
            this.DeviceNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DeviceNameLabel.Location = new System.Drawing.Point(12, 166);
            this.DeviceNameLabel.Name = "DeviceNameLabel";
            this.DeviceNameLabel.Size = new System.Drawing.Size(101, 18);
            this.DeviceNameLabel.TabIndex = 1;
            this.DeviceNameLabel.Text = "Device Name:";
            // 
            // DeviceNameText
            // 
            this.DeviceNameText.Location = new System.Drawing.Point(115, 164);
            this.DeviceNameText.Name = "DeviceNameText";
            this.DeviceNameText.Size = new System.Drawing.Size(152, 20);
            this.DeviceNameText.TabIndex = 2;
            // 
            // DeviceListbox
            // 
            this.DeviceListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DeviceListbox.FormattingEnabled = true;
            this.DeviceListbox.ItemHeight = 16;
            this.DeviceListbox.Location = new System.Drawing.Point(12, 56);
            this.DeviceListbox.Name = "DeviceListbox";
            this.DeviceListbox.Size = new System.Drawing.Size(370, 100);
            this.DeviceListbox.TabIndex = 4;
            this.DeviceListbox.SelectedIndexChanged += new System.EventHandler(this.DeviceListbox_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SaveButton.Location = new System.Drawing.Point(273, 162);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(108, 24);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save Device";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(150, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Devices";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.BackColor = System.Drawing.Color.Transparent;
            this.RefreshButton.ImageLocation = "C:\\Users\\Win\\source\\repos\\SMS\\SMS\\refresh.png";
            this.RefreshButton.Location = new System.Drawing.Point(355, 27);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(24, 26);
            this.RefreshButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RefreshButton.TabIndex = 21;
            this.RefreshButton.TabStop = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // setMessageQuotaToolStripMenuItem
            // 
            this.setMessageQuotaToolStripMenuItem.Name = "setMessageQuotaToolStripMenuItem";
            this.setMessageQuotaToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.setMessageQuotaToolStripMenuItem.Text = "Set Message Quota";
            this.setMessageQuotaToolStripMenuItem.Click += new System.EventHandler(this.setMessageQuotaToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 190);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 20);
            this.textBox1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Quota";
            // 
            // DeviceRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(393, 225);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeviceListbox);
            this.Controls.Add(this.DeviceNameText);
            this.Controls.Add(this.DeviceNameLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DeviceRegister";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Device Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceRegister_FormClosing);
            this.Load += new System.EventHandler(this.DeviceRegister_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendSMSToolStripMenuItem;
        private System.Windows.Forms.Label DeviceNameLabel;
        private System.Windows.Forms.TextBox DeviceNameText;
        private System.Windows.Forms.ListBox DeviceListbox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox RefreshButton;
        private System.Windows.Forms.ToolStripMenuItem setMessageQuotaToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}