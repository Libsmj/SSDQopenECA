namespace SSDQopenECA
{
    partial class Plot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plot));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MeasComboBox = new System.Windows.Forms.ComboBox();
            this.AvailableMeastypebutton = new System.Windows.Forms.Button();
            this.ChannelRefgroupbox = new System.Windows.Forms.GroupBox();
            this.RefreshPlotList = new System.Windows.Forms.Button();
            this.PlotChannelList = new System.Windows.Forms.CheckedListBox();
            this.SelectAllPlotChannels = new System.Windows.Forms.Button();
            this.Deselect_Plotchannels = new System.Windows.Forms.Button();
            this.PlotButton = new System.Windows.Forms.Button();
            this.Devicesgroupbox = new System.Windows.Forms.GroupBox();
            this.Deselect_devices = new System.Windows.Forms.Button();
            this.AllDevicesbutton = new System.Windows.Forms.Button();
            this.DevicecheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.ChannelRefgroupbox.SuspendLayout();
            this.Devicesgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MeasComboBox);
            this.groupBox1.Controls.Add(this.AvailableMeastypebutton);
            this.groupBox1.Controls.Add(this.ChannelRefgroupbox);
            this.groupBox1.Controls.Add(this.PlotButton);
            this.groupBox1.Controls.Add(this.Devicesgroupbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 696);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot Options";
            // 
            // MeasComboBox
            // 
            this.MeasComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasComboBox.FormattingEnabled = true;
            this.MeasComboBox.Location = new System.Drawing.Point(61, 321);
            this.MeasComboBox.Name = "MeasComboBox";
            this.MeasComboBox.Size = new System.Drawing.Size(246, 28);
            this.MeasComboBox.TabIndex = 48;
            // 
            // AvailableMeastypebutton
            // 
            this.AvailableMeastypebutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AvailableMeastypebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AvailableMeastypebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableMeastypebutton.Location = new System.Drawing.Point(51, 286);
            this.AvailableMeastypebutton.Name = "AvailableMeastypebutton";
            this.AvailableMeastypebutton.Size = new System.Drawing.Size(271, 29);
            this.AvailableMeastypebutton.TabIndex = 47;
            this.AvailableMeastypebutton.Text = "Get Available Measurement Types";
            this.AvailableMeastypebutton.UseVisualStyleBackColor = false;
            this.AvailableMeastypebutton.Click += new System.EventHandler(this.AvailableMeastypebutton_Click);
            // 
            // ChannelRefgroupbox
            // 
            this.ChannelRefgroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChannelRefgroupbox.Controls.Add(this.RefreshPlotList);
            this.ChannelRefgroupbox.Controls.Add(this.PlotChannelList);
            this.ChannelRefgroupbox.Controls.Add(this.SelectAllPlotChannels);
            this.ChannelRefgroupbox.Controls.Add(this.Deselect_Plotchannels);
            this.ChannelRefgroupbox.Location = new System.Drawing.Point(16, 355);
            this.ChannelRefgroupbox.Name = "ChannelRefgroupbox";
            this.ChannelRefgroupbox.Size = new System.Drawing.Size(337, 286);
            this.ChannelRefgroupbox.TabIndex = 46;
            this.ChannelRefgroupbox.TabStop = false;
            this.ChannelRefgroupbox.Text = "Select Measurement Channels";
            // 
            // RefreshPlotList
            // 
            this.RefreshPlotList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RefreshPlotList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshPlotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshPlotList.Location = new System.Drawing.Point(45, 30);
            this.RefreshPlotList.Name = "RefreshPlotList";
            this.RefreshPlotList.Size = new System.Drawing.Size(246, 32);
            this.RefreshPlotList.TabIndex = 11;
            this.RefreshPlotList.Text = "Refresh Selected Input Channels";
            this.RefreshPlotList.UseVisualStyleBackColor = false;
            this.RefreshPlotList.Click += new System.EventHandler(this.RefreshPlotList_Click);
            // 
            // PlotChannelList
            // 
            this.PlotChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PlotChannelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotChannelList.FormattingEnabled = true;
            this.PlotChannelList.Location = new System.Drawing.Point(25, 68);
            this.PlotChannelList.Name = "PlotChannelList";
            this.PlotChannelList.Size = new System.Drawing.Size(295, 174);
            this.PlotChannelList.TabIndex = 0;
            // 
            // SelectAllPlotChannels
            // 
            this.SelectAllPlotChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectAllPlotChannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SelectAllPlotChannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SelectAllPlotChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllPlotChannels.Location = new System.Drawing.Point(25, 248);
            this.SelectAllPlotChannels.Name = "SelectAllPlotChannels";
            this.SelectAllPlotChannels.Size = new System.Drawing.Size(84, 23);
            this.SelectAllPlotChannels.TabIndex = 13;
            this.SelectAllPlotChannels.Text = "Select All";
            this.SelectAllPlotChannels.UseVisualStyleBackColor = false;
            this.SelectAllPlotChannels.Click += new System.EventHandler(this.SelectAllPlotChannels_Click);
            // 
            // Deselect_Plotchannels
            // 
            this.Deselect_Plotchannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Deselect_Plotchannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_Plotchannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_Plotchannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_Plotchannels.Location = new System.Drawing.Point(200, 248);
            this.Deselect_Plotchannels.Name = "Deselect_Plotchannels";
            this.Deselect_Plotchannels.Size = new System.Drawing.Size(120, 23);
            this.Deselect_Plotchannels.TabIndex = 14;
            this.Deselect_Plotchannels.Text = "Deselect All";
            this.Deselect_Plotchannels.UseVisualStyleBackColor = false;
            this.Deselect_Plotchannels.Click += new System.EventHandler(this.Deselect_Plotchannels_Click);
            // 
            // PlotButton
            // 
            this.PlotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlotButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PlotButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotButton.Location = new System.Drawing.Point(125, 652);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(99, 36);
            this.PlotButton.TabIndex = 13;
            this.PlotButton.Text = "Plot";
            this.PlotButton.UseVisualStyleBackColor = false;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // Devicesgroupbox
            // 
            this.Devicesgroupbox.Controls.Add(this.Deselect_devices);
            this.Devicesgroupbox.Controls.Add(this.AllDevicesbutton);
            this.Devicesgroupbox.Controls.Add(this.DevicecheckedListBox);
            this.Devicesgroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Devicesgroupbox.Location = new System.Drawing.Point(16, 26);
            this.Devicesgroupbox.Name = "Devicesgroupbox";
            this.Devicesgroupbox.Size = new System.Drawing.Size(337, 254);
            this.Devicesgroupbox.TabIndex = 45;
            this.Devicesgroupbox.TabStop = false;
            this.Devicesgroupbox.Text = "Select Devices";
            // 
            // Deselect_devices
            // 
            this.Deselect_devices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_devices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_devices.Location = new System.Drawing.Point(217, 221);
            this.Deselect_devices.Name = "Deselect_devices";
            this.Deselect_devices.Size = new System.Drawing.Size(103, 23);
            this.Deselect_devices.TabIndex = 26;
            this.Deselect_devices.Text = "Deselect All";
            this.Deselect_devices.UseVisualStyleBackColor = false;
            this.Deselect_devices.Click += new System.EventHandler(this.Deselect_devices_Click);
            // 
            // AllDevicesbutton
            // 
            this.AllDevicesbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllDevicesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllDevicesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDevicesbutton.Location = new System.Drawing.Point(15, 221);
            this.AllDevicesbutton.Name = "AllDevicesbutton";
            this.AllDevicesbutton.Size = new System.Drawing.Size(84, 23);
            this.AllDevicesbutton.TabIndex = 25;
            this.AllDevicesbutton.Text = "Select All";
            this.AllDevicesbutton.UseVisualStyleBackColor = false;
            this.AllDevicesbutton.Click += new System.EventHandler(this.AllDevicesbutton_Click);
            // 
            // DevicecheckedListBox
            // 
            this.DevicecheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevicecheckedListBox.FormattingEnabled = true;
            this.DevicecheckedListBox.Location = new System.Drawing.Point(15, 41);
            this.DevicecheckedListBox.Name = "DevicecheckedListBox";
            this.DevicecheckedListBox.Size = new System.Drawing.Size(305, 174);
            this.DevicecheckedListBox.TabIndex = 0;
            // 
            // Plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(405, 723);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Plot_FormClosing);
            this.Load += new System.EventHandler(this.Plot_Load);
            this.groupBox1.ResumeLayout(false);
            this.ChannelRefgroupbox.ResumeLayout(false);
            this.Devicesgroupbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Devicesgroupbox;
        private System.Windows.Forms.Button Deselect_devices;
        private System.Windows.Forms.Button AllDevicesbutton;
        private System.Windows.Forms.CheckedListBox DevicecheckedListBox;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.GroupBox ChannelRefgroupbox;
        private System.Windows.Forms.Button RefreshPlotList;
        private System.Windows.Forms.CheckedListBox PlotChannelList;
        private System.Windows.Forms.Button SelectAllPlotChannels;
        private System.Windows.Forms.Button Deselect_Plotchannels;
        private System.Windows.Forms.Button AvailableMeastypebutton;
        private System.Windows.Forms.ComboBox MeasComboBox;
    }
}