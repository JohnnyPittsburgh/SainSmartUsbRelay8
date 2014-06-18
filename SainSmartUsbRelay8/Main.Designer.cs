namespace SainSmartUsbRelay8
{
    partial class frmMain
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
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.tbDeviceCount = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblDeviceCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpRelays = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gbConnect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(6, 21);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(151, 21);
            this.cbDevices.TabIndex = 0;
            // 
            // gbConnect
            // 
            this.gbConnect.Controls.Add(this.tbDeviceCount);
            this.gbConnect.Controls.Add(this.btnConnect);
            this.gbConnect.Controls.Add(this.lblDeviceCount);
            this.gbConnect.Location = new System.Drawing.Point(13, 22);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(146, 85);
            this.gbConnect.TabIndex = 1;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Connect";
            // 
            // tbDeviceCount
            // 
            this.tbDeviceCount.Location = new System.Drawing.Point(93, 50);
            this.tbDeviceCount.Name = "tbDeviceCount";
            this.tbDeviceCount.ReadOnly = true;
            this.tbDeviceCount.Size = new System.Drawing.Size(36, 20);
            this.tbDeviceCount.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblDeviceCount
            // 
            this.lblDeviceCount.AutoSize = true;
            this.lblDeviceCount.Location = new System.Drawing.Point(15, 53);
            this.lblDeviceCount.Name = "lblDeviceCount";
            this.lblDeviceCount.Size = new System.Drawing.Size(72, 13);
            this.lblDeviceCount.TabIndex = 0;
            this.lblDeviceCount.Text = "Device Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flpRelays);
            this.groupBox1.Controls.Add(this.cbDevices);
            this.groupBox1.Location = new System.Drawing.Point(188, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 312);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB Relays";
            // 
            // flpRelays
            // 
            this.flpRelays.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRelays.Location = new System.Drawing.Point(6, 53);
            this.flpRelays.Name = "flpRelays";
            this.flpRelays.Size = new System.Drawing.Size(153, 248);
            this.flpRelays.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(394, 306);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 342);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbConnect);
            this.Name = "frmMain";
            this.Text = "SainSmart USB Relay8";
            this.gbConnect.ResumeLayout(false);
            this.gbConnect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.GroupBox gbConnect;
        private System.Windows.Forms.TextBox tbDeviceCount;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblDeviceCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flpRelays;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

