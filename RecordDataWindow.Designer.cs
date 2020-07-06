namespace SSDQopenECA
{
    partial class RecordDataWindow
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
            this.RecordDataBox = new System.Windows.Forms.GroupBox();
            this.CSVgroupBox = new System.Windows.Forms.GroupBox();
            this.Saveasbutton = new System.Windows.Forms.Button();
            this.Locationlabel = new System.Windows.Forms.Label();
            this.CSVLocation = new System.Windows.Forms.TextBox();
            this.Stopbutton = new System.Windows.Forms.Button();
            this.Startbutton = new System.Windows.Forms.Button();
            this.ChannelRefgroupbox = new System.Windows.Forms.GroupBox();
            this.RefreshPlotList = new System.Windows.Forms.Button();
            this.PlotChannelList = new System.Windows.Forms.CheckedListBox();
            this.SelectAllPlotChannels = new System.Windows.Forms.Button();
            this.Deselect_Plotchannels = new System.Windows.Forms.Button();
            this.Meastypegroupbox = new System.Windows.Forms.GroupBox();
            this.DeselectAllMeasType = new System.Windows.Forms.Button();
            this.AllMeasTypebutton = new System.Windows.Forms.Button();
            this.MeasTypechecklist = new System.Windows.Forms.CheckedListBox();
            this.AvailableMeastypebutton = new System.Windows.Forms.Button();
            this.Devicesgroupbox = new System.Windows.Forms.GroupBox();
            this.Deselect_devices = new System.Windows.Forms.Button();
            this.AllDevicesbutton = new System.Windows.Forms.Button();
            this.DevicecheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.RecordDataBox.SuspendLayout();
            this.CSVgroupBox.SuspendLayout();
            this.ChannelRefgroupbox.SuspendLayout();
            this.Meastypegroupbox.SuspendLayout();
            this.Devicesgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecordDataBox
            // 
            this.RecordDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordDataBox.Controls.Add(this.CSVgroupBox);
            this.RecordDataBox.Controls.Add(this.ChannelRefgroupbox);
            this.RecordDataBox.Controls.Add(this.Meastypegroupbox);
            this.RecordDataBox.Controls.Add(this.Devicesgroupbox);
            this.RecordDataBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordDataBox.Location = new System.Drawing.Point(12, 12);
            this.RecordDataBox.Name = "RecordDataBox";
            this.RecordDataBox.Size = new System.Drawing.Size(857, 635);
            this.RecordDataBox.TabIndex = 11;
            this.RecordDataBox.TabStop = false;
            this.RecordDataBox.Text = "Record Data Settings";
            // 
            // CSVgroupBox
            // 
            this.CSVgroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CSVgroupBox.Controls.Add(this.Saveasbutton);
            this.CSVgroupBox.Controls.Add(this.Locationlabel);
            this.CSVgroupBox.Controls.Add(this.CSVLocation);
            this.CSVgroupBox.Controls.Add(this.Stopbutton);
            this.CSVgroupBox.Controls.Add(this.Startbutton);
            this.CSVgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVgroupBox.Location = new System.Drawing.Point(21, 517);
            this.CSVgroupBox.Name = "CSVgroupBox";
            this.CSVgroupBox.Size = new System.Drawing.Size(815, 100);
            this.CSVgroupBox.TabIndex = 46;
            this.CSVgroupBox.TabStop = false;
            this.CSVgroupBox.Text = "Export Data to a CSV File";
            // 
            // Saveasbutton
            // 
            this.Saveasbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Saveasbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Saveasbutton.Location = new System.Drawing.Point(669, 24);
            this.Saveasbutton.Name = "Saveasbutton";
            this.Saveasbutton.Size = new System.Drawing.Size(99, 31);
            this.Saveasbutton.TabIndex = 4;
            this.Saveasbutton.Text = "Save As";
            this.Saveasbutton.UseVisualStyleBackColor = false;
            this.Saveasbutton.Click += new System.EventHandler(this.Saveasbutton_Click);
            // 
            // Locationlabel
            // 
            this.Locationlabel.AutoSize = true;
            this.Locationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Locationlabel.Location = new System.Drawing.Point(30, 32);
            this.Locationlabel.Name = "Locationlabel";
            this.Locationlabel.Size = new System.Drawing.Size(154, 16);
            this.Locationlabel.TabIndex = 3;
            this.Locationlabel.Text = "Destination File Location";
            // 
            // CSVLocation
            // 
            this.CSVLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVLocation.Location = new System.Drawing.Point(207, 29);
            this.CSVLocation.Name = "CSVLocation";
            this.CSVLocation.Size = new System.Drawing.Size(433, 22);
            this.CSVLocation.TabIndex = 2;
            // 
            // Stopbutton
            // 
            this.Stopbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Stopbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Stopbutton.Location = new System.Drawing.Point(402, 60);
            this.Stopbutton.Name = "Stopbutton";
            this.Stopbutton.Size = new System.Drawing.Size(90, 29);
            this.Stopbutton.TabIndex = 1;
            this.Stopbutton.Text = "Stop";
            this.Stopbutton.UseVisualStyleBackColor = false;
            this.Stopbutton.Click += new System.EventHandler(this.Stopbutton_Click);
            // 
            // Startbutton
            // 
            this.Startbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Startbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Startbutton.Location = new System.Drawing.Point(267, 60);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(90, 29);
            this.Startbutton.TabIndex = 0;
            this.Startbutton.Text = "Start";
            this.Startbutton.UseVisualStyleBackColor = false;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // ChannelRefgroupbox
            // 
            this.ChannelRefgroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChannelRefgroupbox.Controls.Add(this.RefreshPlotList);
            this.ChannelRefgroupbox.Controls.Add(this.PlotChannelList);
            this.ChannelRefgroupbox.Controls.Add(this.SelectAllPlotChannels);
            this.ChannelRefgroupbox.Controls.Add(this.Deselect_Plotchannels);
            this.ChannelRefgroupbox.Location = new System.Drawing.Point(423, 25);
            this.ChannelRefgroupbox.Name = "ChannelRefgroupbox";
            this.ChannelRefgroupbox.Size = new System.Drawing.Size(413, 486);
            this.ChannelRefgroupbox.TabIndex = 17;
            this.ChannelRefgroupbox.TabStop = false;
            this.ChannelRefgroupbox.Text = "Select Measurement Channels";
            // 
            // RefreshPlotList
            // 
            this.RefreshPlotList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RefreshPlotList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RefreshPlotList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshPlotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshPlotList.Location = new System.Drawing.Point(91, 25);
            this.RefreshPlotList.Name = "RefreshPlotList";
            this.RefreshPlotList.Size = new System.Drawing.Size(246, 32);
            this.RefreshPlotList.TabIndex = 11;
            this.RefreshPlotList.Text = "Refresh Selected Input Channels";
            this.RefreshPlotList.UseVisualStyleBackColor = false;
            this.RefreshPlotList.Click += new System.EventHandler(this.RefreshPlotList_Click);
            // 
            // PlotChannelList
            // 
            this.PlotChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlotChannelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotChannelList.FormattingEnabled = true;
            this.PlotChannelList.Location = new System.Drawing.Point(38, 63);
            this.PlotChannelList.Name = "PlotChannelList";
            this.PlotChannelList.Size = new System.Drawing.Size(348, 378);
            this.PlotChannelList.TabIndex = 0;
            // 
            // SelectAllPlotChannels
            // 
            this.SelectAllPlotChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectAllPlotChannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SelectAllPlotChannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SelectAllPlotChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllPlotChannels.Location = new System.Drawing.Point(38, 447);
            this.SelectAllPlotChannels.Name = "SelectAllPlotChannels";
            this.SelectAllPlotChannels.Size = new System.Drawing.Size(84, 23);
            this.SelectAllPlotChannels.TabIndex = 13;
            this.SelectAllPlotChannels.Text = "Select All";
            this.SelectAllPlotChannels.UseVisualStyleBackColor = false;
            this.SelectAllPlotChannels.Click += new System.EventHandler(this.SelectAllPlotChannels_Click);
            // 
            // Deselect_Plotchannels
            // 
            this.Deselect_Plotchannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Deselect_Plotchannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_Plotchannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_Plotchannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_Plotchannels.Location = new System.Drawing.Point(267, 447);
            this.Deselect_Plotchannels.Name = "Deselect_Plotchannels";
            this.Deselect_Plotchannels.Size = new System.Drawing.Size(120, 23);
            this.Deselect_Plotchannels.TabIndex = 14;
            this.Deselect_Plotchannels.Text = "Deselect All";
            this.Deselect_Plotchannels.UseVisualStyleBackColor = false;
            this.Deselect_Plotchannels.Click += new System.EventHandler(this.Deselect_Plotchannels_Click);
            // 
            // Meastypegroupbox
            // 
            this.Meastypegroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Meastypegroupbox.Controls.Add(this.DeselectAllMeasType);
            this.Meastypegroupbox.Controls.Add(this.AllMeasTypebutton);
            this.Meastypegroupbox.Controls.Add(this.MeasTypechecklist);
            this.Meastypegroupbox.Controls.Add(this.AvailableMeastypebutton);
            this.Meastypegroupbox.Location = new System.Drawing.Point(21, 286);
            this.Meastypegroupbox.Name = "Meastypegroupbox";
            this.Meastypegroupbox.Size = new System.Drawing.Size(376, 225);
            this.Meastypegroupbox.TabIndex = 16;
            this.Meastypegroupbox.TabStop = false;
            this.Meastypegroupbox.Text = "Select Measurement Type";
            // 
            // DeselectAllMeasType
            // 
            this.DeselectAllMeasType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectAllMeasType.Location = new System.Drawing.Point(251, 192);
            this.DeselectAllMeasType.Name = "DeselectAllMeasType";
            this.DeselectAllMeasType.Size = new System.Drawing.Size(106, 23);
            this.DeselectAllMeasType.TabIndex = 21;
            this.DeselectAllMeasType.Text = "Deselect All";
            this.DeselectAllMeasType.UseVisualStyleBackColor = true;
            this.DeselectAllMeasType.Click += new System.EventHandler(this.DeselectAllMeasType_Click);
            // 
            // AllMeasTypebutton
            // 
            this.AllMeasTypebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllMeasTypebutton.Location = new System.Drawing.Point(21, 192);
            this.AllMeasTypebutton.Name = "AllMeasTypebutton";
            this.AllMeasTypebutton.Size = new System.Drawing.Size(90, 23);
            this.AllMeasTypebutton.TabIndex = 20;
            this.AllMeasTypebutton.Text = "Select All";
            this.AllMeasTypebutton.UseVisualStyleBackColor = true;
            this.AllMeasTypebutton.Click += new System.EventHandler(this.AllMeasTypebutton_Click);
            // 
            // MeasTypechecklist
            // 
            this.MeasTypechecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasTypechecklist.FormattingEnabled = true;
            this.MeasTypechecklist.Location = new System.Drawing.Point(21, 63);
            this.MeasTypechecklist.Name = "MeasTypechecklist";
            this.MeasTypechecklist.Size = new System.Drawing.Size(336, 123);
            this.MeasTypechecklist.TabIndex = 19;
            // 
            // AvailableMeastypebutton
            // 
            this.AvailableMeastypebutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AvailableMeastypebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AvailableMeastypebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableMeastypebutton.Location = new System.Drawing.Point(63, 25);
            this.AvailableMeastypebutton.Name = "AvailableMeastypebutton";
            this.AvailableMeastypebutton.Size = new System.Drawing.Size(271, 29);
            this.AvailableMeastypebutton.TabIndex = 18;
            this.AvailableMeastypebutton.Text = "Get Available Measurement Types";
            this.AvailableMeastypebutton.UseVisualStyleBackColor = false;
            this.AvailableMeastypebutton.Click += new System.EventHandler(this.AvailableMeastypebutton_Click);
            // 
            // Devicesgroupbox
            // 
            this.Devicesgroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Devicesgroupbox.Controls.Add(this.Deselect_devices);
            this.Devicesgroupbox.Controls.Add(this.AllDevicesbutton);
            this.Devicesgroupbox.Controls.Add(this.DevicecheckedListBox);
            this.Devicesgroupbox.Location = new System.Drawing.Point(21, 24);
            this.Devicesgroupbox.Name = "Devicesgroupbox";
            this.Devicesgroupbox.Size = new System.Drawing.Size(376, 255);
            this.Devicesgroupbox.TabIndex = 15;
            this.Devicesgroupbox.TabStop = false;
            this.Devicesgroupbox.Text = "Select Devices";
            // 
            // Deselect_devices
            // 
            this.Deselect_devices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Deselect_devices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_devices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_devices.Location = new System.Drawing.Point(254, 222);
            this.Deselect_devices.Name = "Deselect_devices";
            this.Deselect_devices.Size = new System.Drawing.Size(103, 23);
            this.Deselect_devices.TabIndex = 26;
            this.Deselect_devices.Text = "Deselect All";
            this.Deselect_devices.UseVisualStyleBackColor = false;
            this.Deselect_devices.Click += new System.EventHandler(this.Deselect_devices_Click);
            // 
            // AllDevicesbutton
            // 
            this.AllDevicesbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AllDevicesbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllDevicesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllDevicesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDevicesbutton.Location = new System.Drawing.Point(15, 222);
            this.AllDevicesbutton.Name = "AllDevicesbutton";
            this.AllDevicesbutton.Size = new System.Drawing.Size(84, 23);
            this.AllDevicesbutton.TabIndex = 25;
            this.AllDevicesbutton.Text = "Select All";
            this.AllDevicesbutton.UseVisualStyleBackColor = false;
            this.AllDevicesbutton.Click += new System.EventHandler(this.AllDevicesbutton_Click);
            // 
            // DevicecheckedListBox
            // 
            this.DevicecheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DevicecheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevicecheckedListBox.FormattingEnabled = true;
            this.DevicecheckedListBox.Location = new System.Drawing.Point(15, 25);
            this.DevicecheckedListBox.Name = "DevicecheckedListBox";
            this.DevicecheckedListBox.Size = new System.Drawing.Size(342, 191);
            this.DevicecheckedListBox.TabIndex = 0;
            // 
            // RecordDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(893, 659);
            this.Controls.Add(this.RecordDataBox);
            this.Name = "RecordDataWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Record Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordDataWindow_FormClosing);
            this.Load += new System.EventHandler(this.RecordDataWindow_Load);
            this.RecordDataBox.ResumeLayout(false);
            this.CSVgroupBox.ResumeLayout(false);
            this.CSVgroupBox.PerformLayout();
            this.ChannelRefgroupbox.ResumeLayout(false);
            this.Meastypegroupbox.ResumeLayout(false);
            this.Devicesgroupbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RecordDataBox;
        private System.Windows.Forms.GroupBox ChannelRefgroupbox;
        private System.Windows.Forms.Button RefreshPlotList;
        private System.Windows.Forms.CheckedListBox PlotChannelList;
        private System.Windows.Forms.Button SelectAllPlotChannels;
        private System.Windows.Forms.Button Deselect_Plotchannels;
        private System.Windows.Forms.GroupBox Meastypegroupbox;
        private System.Windows.Forms.GroupBox Devicesgroupbox;
        private System.Windows.Forms.CheckedListBox DevicecheckedListBox;
        private System.Windows.Forms.Button Deselect_devices;
        private System.Windows.Forms.Button AllDevicesbutton;
        private System.Windows.Forms.Button AvailableMeastypebutton;
        private System.Windows.Forms.GroupBox CSVgroupBox;
        private System.Windows.Forms.Button Saveasbutton;
        private System.Windows.Forms.Label Locationlabel;
        private System.Windows.Forms.TextBox CSVLocation;
        private System.Windows.Forms.Button Stopbutton;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.CheckedListBox MeasTypechecklist;
        private System.Windows.Forms.Button DeselectAllMeasType;
        private System.Windows.Forms.Button AllMeasTypebutton;
    }
}