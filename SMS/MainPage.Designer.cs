namespace SMS
{
    partial class MainPage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NumberText = new System.Windows.Forms.TextBox();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.NumbersListBox = new System.Windows.Forms.ListBox();
            this.DevicesLabel = new System.Windows.Forms.Label();
            this.Number_AddToListButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NumbersLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Message_SendAllButton = new System.Windows.Forms.Button();
            this.Message_SendSelectedButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectedDeviceLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.deviceRegistiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.deviceList = new System.Windows.Forms.ListView();
            this.RefreshPictureButton = new System.Windows.Forms.PictureBox();
            this.MessageStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckSelectedDevice_Timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshPictureButton)).BeginInit();
            this.SuspendLayout();
            // 
            // NumberText
            // 
            this.NumberText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.NumberText.Location = new System.Drawing.Point(116, 156);
            this.NumberText.Name = "NumberText";
            this.NumberText.Size = new System.Drawing.Size(150, 22);
            this.NumberText.TabIndex = 0;
            // 
            // MessageText
            // 
            this.MessageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MessageText.Location = new System.Drawing.Point(116, 7);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(254, 115);
            this.MessageText.TabIndex = 2;
            // 
            // NumbersListBox
            // 
            this.NumbersListBox.FormattingEnabled = true;
            this.NumbersListBox.Location = new System.Drawing.Point(116, 190);
            this.NumbersListBox.Name = "NumbersListBox";
            this.NumbersListBox.Size = new System.Drawing.Size(253, 147);
            this.NumbersListBox.TabIndex = 3;
            this.NumbersListBox.DoubleClick += new System.EventHandler(this.NumbersListBox_DoubleClick);
            // 
            // DevicesLabel
            // 
            this.DevicesLabel.AutoSize = true;
            this.DevicesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DevicesLabel.Location = new System.Drawing.Point(116, 7);
            this.DevicesLabel.Name = "DevicesLabel";
            this.DevicesLabel.Size = new System.Drawing.Size(77, 24);
            this.DevicesLabel.TabIndex = 4;
            this.DevicesLabel.Text = "Devices";
            // 
            // Number_AddToListButton
            // 
            this.Number_AddToListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Number_AddToListButton.Location = new System.Drawing.Point(269, 149);
            this.Number_AddToListButton.Name = "Number_AddToListButton";
            this.Number_AddToListButton.Size = new System.Drawing.Size(100, 36);
            this.Number_AddToListButton.TabIndex = 5;
            this.Number_AddToListButton.Text = "Add To List";
            this.Number_AddToListButton.UseVisualStyleBackColor = true;
            this.Number_AddToListButton.Click += new System.EventHandler(this.Number_AddToListButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(15, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number:";
            // 
            // NumbersLabel
            // 
            this.NumbersLabel.AutoSize = true;
            this.NumbersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.NumbersLabel.Location = new System.Drawing.Point(15, 190);
            this.NumbersLabel.Name = "NumbersLabel";
            this.NumbersLabel.Size = new System.Drawing.Size(88, 24);
            this.NumbersLabel.TabIndex = 8;
            this.NumbersLabel.Text = "Numbers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(15, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Message:";
            // 
            // Message_SendAllButton
            // 
            this.Message_SendAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Message_SendAllButton.Location = new System.Drawing.Point(116, 343);
            this.Message_SendAllButton.Name = "Message_SendAllButton";
            this.Message_SendAllButton.Size = new System.Drawing.Size(122, 34);
            this.Message_SendAllButton.TabIndex = 12;
            this.Message_SendAllButton.Text = "Send All";
            this.Message_SendAllButton.UseVisualStyleBackColor = true;
            this.Message_SendAllButton.Click += new System.EventHandler(this.Message_SendAllButton_Click);
            // 
            // Message_SendSelectedButton
            // 
            this.Message_SendSelectedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Message_SendSelectedButton.Location = new System.Drawing.Point(248, 343);
            this.Message_SendSelectedButton.Name = "Message_SendSelectedButton";
            this.Message_SendSelectedButton.Size = new System.Drawing.Size(122, 34);
            this.Message_SendSelectedButton.TabIndex = 13;
            this.Message_SendSelectedButton.Text = "Send Selected";
            this.Message_SendSelectedButton.UseVisualStyleBackColor = true;
            this.Message_SendSelectedButton.Click += new System.EventHandler(this.Message_SendSelectedButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(20, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Selected Device Count:";
            // 
            // SelectedDeviceLabel
            // 
            this.SelectedDeviceLabel.AutoSize = true;
            this.SelectedDeviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SelectedDeviceLabel.Location = new System.Drawing.Point(182, 373);
            this.SelectedDeviceLabel.Name = "SelectedDeviceLabel";
            this.SelectedDeviceLabel.Size = new System.Drawing.Size(16, 18);
            this.SelectedDeviceLabel.TabIndex = 15;
            this.SelectedDeviceLabel.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceRegistiraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // deviceRegistiraToolStripMenuItem
            // 
            this.deviceRegistiraToolStripMenuItem.Name = "deviceRegistiraToolStripMenuItem";
            this.deviceRegistiraToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.deviceRegistiraToolStripMenuItem.Text = "Device Registration";
            this.deviceRegistiraToolStripMenuItem.Click += new System.EventHandler(this.DeviceRegistiraToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(20, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Devices Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.StatusLabel.Location = new System.Drawing.Point(130, 397);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(82, 18);
            this.StatusLabel.TabIndex = 19;
            this.StatusLabel.Text = "Checking...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.deviceList);
            this.splitContainer1.Panel1.Controls.Add(this.DevicesLabel);
            this.splitContainer1.Panel1.Controls.Add(this.SelectedDeviceLabel);
            this.splitContainer1.Panel1.Controls.Add(this.RefreshPictureButton);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.StatusLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.MessageStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.NumbersListBox);
            this.splitContainer1.Panel2.Controls.Add(this.Message_SendSelectedButton);
            this.splitContainer1.Panel2.Controls.Add(this.NumberText);
            this.splitContainer1.Panel2.Controls.Add(this.Message_SendAllButton);
            this.splitContainer1.Panel2.Controls.Add(this.MessageText);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.Number_AddToListButton);
            this.splitContainer1.Panel2.Controls.Add(this.NumbersLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(764, 427);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 21;
            // 
            // deviceList
            // 
            this.deviceList.HideSelection = false;
            this.deviceList.Location = new System.Drawing.Point(23, 40);
            this.deviceList.MultiSelect = false;
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(273, 329);
            this.deviceList.TabIndex = 21;
            this.deviceList.UseCompatibleStateImageBehavior = false;
            this.deviceList.View = System.Windows.Forms.View.List;
            // 
            // RefreshPictureButton
            // 
            this.RefreshPictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshPictureButton.BackColor = System.Drawing.Color.Transparent;
            this.RefreshPictureButton.ImageLocation = "C:\\Users\\Win\\source\\repos\\SMS\\SMS\\refresh.png";
            this.RefreshPictureButton.Location = new System.Drawing.Point(271, 7);
            this.RefreshPictureButton.Name = "RefreshPictureButton";
            this.RefreshPictureButton.Size = new System.Drawing.Size(25, 22);
            this.RefreshPictureButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RefreshPictureButton.TabIndex = 20;
            this.RefreshPictureButton.TabStop = false;
            this.RefreshPictureButton.Click += new System.EventHandler(this.RefreshPictureButton_Click);
            // 
            // MessageStatus
            // 
            this.MessageStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageStatus.AutoSize = true;
            this.MessageStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MessageStatus.Location = new System.Drawing.Point(224, 391);
            this.MessageStatus.Name = "MessageStatus";
            this.MessageStatus.Size = new System.Drawing.Size(30, 18);
            this.MessageStatus.TabIndex = 21;
            this.MessageStatus.Text = "Idle";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(19, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 2);
            this.label1.TabIndex = 14;
            // 
            // CheckSelectedDevice_Timer
            // 
            this.CheckSelectedDevice_Timer.Tick += new System.EventHandler(this.CheckSelectedDevice_Timer_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(113, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Sending Status:";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(764, 451);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.ShowIcon = false;
            this.Text = "SMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefreshPictureButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumberText;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.ListBox NumbersListBox;
        private System.Windows.Forms.Label DevicesLabel;
        private System.Windows.Forms.Button Number_AddToListButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NumbersLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Message_SendAllButton;
        private System.Windows.Forms.Button Message_SendSelectedButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SelectedDeviceLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deviceRegistiraToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.PictureBox RefreshPictureButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer CheckSelectedDevice_Timer;
        private System.Windows.Forms.Label MessageStatus;
        private System.Windows.Forms.ListView deviceList;
        private System.Windows.Forms.Label label3;
    }
}

