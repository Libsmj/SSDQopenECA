namespace SSDQopenECA
{
    partial class Input_screen2
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
            this.EPRIpictureBox = new System.Windows.Forms.PictureBox();
            this.Heading = new System.Windows.Forms.Label();
            this.StoredMeasurementBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputChannelList = new System.Windows.Forms.CheckedListBox();
            this.UpdateChannels = new System.Windows.Forms.Button();
            this.OutputDevice_combobox = new System.Windows.Forms.ComboBox();
            this.InputChannelListgroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshChannelsbutton = new System.Windows.Forms.Button();
            this.InputChannelList = new System.Windows.Forms.CheckedListBox();
            this.AllMeasbutton = new System.Windows.Forms.Button();
            this.Deselect_IPchannels = new System.Windows.Forms.Button();
            this.DevicegroupBox = new System.Windows.Forms.GroupBox();
            this.Deselect_devices = new System.Windows.Forms.Button();
            this.Adddevices_button = new System.Windows.Forms.Button();
            this.DeviceCheckList = new System.Windows.Forms.CheckedListBox();
            this.AllDevicesbutton = new System.Windows.Forms.Button();
            this.MeasTypegroupbox = new System.Windows.Forms.GroupBox();
            this.DeselectTypes_button = new System.Windows.Forms.Button();
            this.SelectAllTypes_button = new System.Windows.Forms.Button();
            this.Addmeastypes_button = new System.Windows.Forms.Button();
            this.MeasTypecheckList = new System.Windows.Forms.CheckedListBox();
            this.Create_Framework_button = new System.Windows.Forms.Button();
            this.SearchFrameworkbutton = new System.Windows.Forms.Button();
            this.Framework_LocationBox = new System.Windows.Forms.TextBox();
            this.Config_locationbox = new System.Windows.Forms.GroupBox();
            this.SSDQactionBox = new System.Windows.Forms.GroupBox();
            this.DatagroupBox = new System.Windows.Forms.GroupBox();
            this.PlotButton = new System.Windows.Forms.Button();
            this.RecordData_button = new System.Windows.Forms.Button();
            this.StopSSDQbutton = new System.Windows.Forms.Button();
            this.ParameterSettingsButton = new System.Windows.Forms.Button();
            this.RunSSDQButton = new System.Windows.Forms.Button();
            this.Savegroupbox = new System.Windows.Forms.GroupBox();
            this.CSVlocationlabel = new System.Windows.Forms.Label();
            this.Locationlabel = new System.Windows.Forms.Label();
            this.SaveFrameworkbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EPRIpictureBox)).BeginInit();
            this.StoredMeasurementBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.InputChannelListgroupBox.SuspendLayout();
            this.DevicegroupBox.SuspendLayout();
            this.MeasTypegroupbox.SuspendLayout();
            this.Config_locationbox.SuspendLayout();
            this.SSDQactionBox.SuspendLayout();
            this.DatagroupBox.SuspendLayout();
            this.Savegroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EPRIpictureBox
            // 
            this.EPRIpictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EPRIpictureBox.BackgroundImage = global::SSDQopenECA.Properties.Resources.EPRI_Logo;
            this.EPRIpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EPRIpictureBox.Location = new System.Drawing.Point(58, 9);
            this.EPRIpictureBox.Name = "EPRIpictureBox";
            this.EPRIpictureBox.Size = new System.Drawing.Size(159, 79);
            this.EPRIpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.EPRIpictureBox.TabIndex = 15;
            this.EPRIpictureBox.TabStop = false;
            // 
            // Heading
            // 
            this.Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Heading.AutoSize = true;
            this.Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.ForeColor = System.Drawing.Color.Navy;
            this.Heading.Location = new System.Drawing.Point(311, 9);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(750, 61);
            this.Heading.TabIndex = 14;
            this.Heading.Text = "SSDQopenECA Configuration";
            // 
            // StoredMeasurementBox
            // 
            this.StoredMeasurementBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StoredMeasurementBox.Controls.Add(this.groupBox2);
            this.StoredMeasurementBox.Controls.Add(this.InputChannelListgroupBox);
            this.StoredMeasurementBox.Controls.Add(this.DevicegroupBox);
            this.StoredMeasurementBox.Controls.Add(this.MeasTypegroupbox);
            this.StoredMeasurementBox.Controls.Add(this.Create_Framework_button);
            this.StoredMeasurementBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredMeasurementBox.Location = new System.Drawing.Point(12, 137);
            this.StoredMeasurementBox.Name = "StoredMeasurementBox";
            this.StoredMeasurementBox.Size = new System.Drawing.Size(1040, 487);
            this.StoredMeasurementBox.TabIndex = 16;
            this.StoredMeasurementBox.TabStop = false;
            this.StoredMeasurementBox.Text = "Stored openECA Framework Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.OutputChannelList);
            this.groupBox2.Controls.Add(this.UpdateChannels);
            this.groupBox2.Controls.Add(this.OutputDevice_combobox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(653, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 406);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Measurement Channel Details";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select Output Device";
            // 
            // OutputChannelList
            // 
            this.OutputChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputChannelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputChannelList.FormattingEnabled = true;
            this.OutputChannelList.Location = new System.Drawing.Point(18, 118);
            this.OutputChannelList.Name = "OutputChannelList";
            this.OutputChannelList.Size = new System.Drawing.Size(340, 276);
            this.OutputChannelList.TabIndex = 14;
            this.OutputChannelList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckList_ItemCheck);
            // 
            // UpdateChannels
            // 
            this.UpdateChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateChannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UpdateChannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateChannels.Location = new System.Drawing.Point(18, 78);
            this.UpdateChannels.Name = "UpdateChannels";
            this.UpdateChannels.Size = new System.Drawing.Size(340, 34);
            this.UpdateChannels.TabIndex = 20;
            this.UpdateChannels.Text = "Create/Update Output Measurement Channels";
            this.UpdateChannels.UseVisualStyleBackColor = false;
            this.UpdateChannels.Click += new System.EventHandler(this.UpdateChannels_Click);
            // 
            // OutputDevice_combobox
            // 
            this.OutputDevice_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDevice_combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputDevice_combobox.FormattingEnabled = true;
            this.OutputDevice_combobox.Location = new System.Drawing.Point(18, 48);
            this.OutputDevice_combobox.Name = "OutputDevice_combobox";
            this.OutputDevice_combobox.Size = new System.Drawing.Size(340, 24);
            this.OutputDevice_combobox.TabIndex = 21;
            // 
            // InputChannelListgroupBox
            // 
            this.InputChannelListgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.InputChannelListgroupBox.Controls.Add(this.RefreshChannelsbutton);
            this.InputChannelListgroupBox.Controls.Add(this.InputChannelList);
            this.InputChannelListgroupBox.Controls.Add(this.AllMeasbutton);
            this.InputChannelListgroupBox.Controls.Add(this.Deselect_IPchannels);
            this.InputChannelListgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputChannelListgroupBox.Location = new System.Drawing.Point(310, 30);
            this.InputChannelListgroupBox.Name = "InputChannelListgroupBox";
            this.InputChannelListgroupBox.Size = new System.Drawing.Size(337, 406);
            this.InputChannelListgroupBox.TabIndex = 28;
            this.InputChannelListgroupBox.TabStop = false;
            this.InputChannelListgroupBox.Text = "Input Measurement Channels Details";
            // 
            // RefreshChannelsbutton
            // 
            this.RefreshChannelsbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RefreshChannelsbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RefreshChannelsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshChannelsbutton.Location = new System.Drawing.Point(30, 21);
            this.RefreshChannelsbutton.Name = "RefreshChannelsbutton";
            this.RefreshChannelsbutton.Size = new System.Drawing.Size(286, 28);
            this.RefreshChannelsbutton.TabIndex = 26;
            this.RefreshChannelsbutton.Text = "Refresh Input Measurement Channels";
            this.RefreshChannelsbutton.UseVisualStyleBackColor = false;
            this.RefreshChannelsbutton.Click += new System.EventHandler(this.RefreshChannelsbutton_Click);
            // 
            // InputChannelList
            // 
            this.InputChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.InputChannelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputChannelList.FormattingEnabled = true;
            this.InputChannelList.Location = new System.Drawing.Point(6, 55);
            this.InputChannelList.Name = "InputChannelList";
            this.InputChannelList.Size = new System.Drawing.Size(323, 310);
            this.InputChannelList.TabIndex = 1;
            // 
            // AllMeasbutton
            // 
            this.AllMeasbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AllMeasbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllMeasbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllMeasbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllMeasbutton.Location = new System.Drawing.Point(30, 371);
            this.AllMeasbutton.Name = "AllMeasbutton";
            this.AllMeasbutton.Size = new System.Drawing.Size(84, 23);
            this.AllMeasbutton.TabIndex = 19;
            this.AllMeasbutton.Text = "Select All";
            this.AllMeasbutton.UseVisualStyleBackColor = false;
            this.AllMeasbutton.Click += new System.EventHandler(this.AllMeasbutton_Click);
            // 
            // Deselect_IPchannels
            // 
            this.Deselect_IPchannels.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Deselect_IPchannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_IPchannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_IPchannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_IPchannels.Location = new System.Drawing.Point(212, 371);
            this.Deselect_IPchannels.Name = "Deselect_IPchannels";
            this.Deselect_IPchannels.Size = new System.Drawing.Size(104, 23);
            this.Deselect_IPchannels.TabIndex = 25;
            this.Deselect_IPchannels.Text = "Deselect All";
            this.Deselect_IPchannels.UseVisualStyleBackColor = false;
            this.Deselect_IPchannels.Click += new System.EventHandler(this.Deselect_IPchannels_Click);
            // 
            // DevicegroupBox
            // 
            this.DevicegroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DevicegroupBox.Controls.Add(this.Deselect_devices);
            this.DevicegroupBox.Controls.Add(this.Adddevices_button);
            this.DevicegroupBox.Controls.Add(this.DeviceCheckList);
            this.DevicegroupBox.Controls.Add(this.AllDevicesbutton);
            this.DevicegroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevicegroupBox.Location = new System.Drawing.Point(6, 25);
            this.DevicegroupBox.Name = "DevicegroupBox";
            this.DevicegroupBox.Size = new System.Drawing.Size(285, 226);
            this.DevicegroupBox.TabIndex = 27;
            this.DevicegroupBox.TabStop = false;
            this.DevicegroupBox.Text = "Device List";
            // 
            // Deselect_devices
            // 
            this.Deselect_devices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Deselect_devices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_devices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_devices.Location = new System.Drawing.Point(170, 196);
            this.Deselect_devices.Name = "Deselect_devices";
            this.Deselect_devices.Size = new System.Drawing.Size(103, 23);
            this.Deselect_devices.TabIndex = 33;
            this.Deselect_devices.Text = "Deselect All";
            this.Deselect_devices.UseVisualStyleBackColor = false;
            this.Deselect_devices.Click += new System.EventHandler(this.Deselect_devices_Click);
            // 
            // Adddevices_button
            // 
            this.Adddevices_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Adddevices_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Adddevices_button.Location = new System.Drawing.Point(48, 21);
            this.Adddevices_button.Name = "Adddevices_button";
            this.Adddevices_button.Size = new System.Drawing.Size(192, 23);
            this.Adddevices_button.TabIndex = 33;
            this.Adddevices_button.Text = "Update Input Devices";
            this.Adddevices_button.UseVisualStyleBackColor = false;
            this.Adddevices_button.Click += new System.EventHandler(this.Adddevices_button_Click);
            // 
            // DeviceCheckList
            // 
            this.DeviceCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DeviceCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceCheckList.FormattingEnabled = true;
            this.DeviceCheckList.Location = new System.Drawing.Point(10, 50);
            this.DeviceCheckList.Name = "DeviceCheckList";
            this.DeviceCheckList.Size = new System.Drawing.Size(263, 140);
            this.DeviceCheckList.TabIndex = 17;
            // 
            // AllDevicesbutton
            // 
            this.AllDevicesbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AllDevicesbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllDevicesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllDevicesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDevicesbutton.Location = new System.Drawing.Point(10, 196);
            this.AllDevicesbutton.Name = "AllDevicesbutton";
            this.AllDevicesbutton.Size = new System.Drawing.Size(84, 23);
            this.AllDevicesbutton.TabIndex = 32;
            this.AllDevicesbutton.Text = "Select All";
            this.AllDevicesbutton.UseVisualStyleBackColor = false;
            this.AllDevicesbutton.Click += new System.EventHandler(this.AllDevicesbutton_Click);
            // 
            // MeasTypegroupbox
            // 
            this.MeasTypegroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MeasTypegroupbox.Controls.Add(this.DeselectTypes_button);
            this.MeasTypegroupbox.Controls.Add(this.SelectAllTypes_button);
            this.MeasTypegroupbox.Controls.Add(this.Addmeastypes_button);
            this.MeasTypegroupbox.Controls.Add(this.MeasTypecheckList);
            this.MeasTypegroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasTypegroupbox.Location = new System.Drawing.Point(6, 257);
            this.MeasTypegroupbox.Name = "MeasTypegroupbox";
            this.MeasTypegroupbox.Size = new System.Drawing.Size(285, 188);
            this.MeasTypegroupbox.TabIndex = 13;
            this.MeasTypegroupbox.TabStop = false;
            this.MeasTypegroupbox.Text = "Measurement Type";
            // 
            // DeselectTypes_button
            // 
            this.DeselectTypes_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeselectTypes_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeselectTypes_button.Location = new System.Drawing.Point(170, 156);
            this.DeselectTypes_button.Name = "DeselectTypes_button";
            this.DeselectTypes_button.Size = new System.Drawing.Size(103, 23);
            this.DeselectTypes_button.TabIndex = 3;
            this.DeselectTypes_button.Text = "Deselect All";
            this.DeselectTypes_button.UseVisualStyleBackColor = false;
            this.DeselectTypes_button.Click += new System.EventHandler(this.DeselectTypes_button_Click);
            // 
            // SelectAllTypes_button
            // 
            this.SelectAllTypes_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SelectAllTypes_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SelectAllTypes_button.Location = new System.Drawing.Point(10, 156);
            this.SelectAllTypes_button.Name = "SelectAllTypes_button";
            this.SelectAllTypes_button.Size = new System.Drawing.Size(89, 23);
            this.SelectAllTypes_button.TabIndex = 2;
            this.SelectAllTypes_button.Text = "Select All";
            this.SelectAllTypes_button.UseVisualStyleBackColor = false;
            this.SelectAllTypes_button.Click += new System.EventHandler(this.SelectAllTypes_button_Click);
            // 
            // Addmeastypes_button
            // 
            this.Addmeastypes_button.Location = new System.Drawing.Point(22, 26);
            this.Addmeastypes_button.Name = "Addmeastypes_button";
            this.Addmeastypes_button.Size = new System.Drawing.Size(235, 29);
            this.Addmeastypes_button.TabIndex = 1;
            this.Addmeastypes_button.Text = "Update Measurement Types";
            this.Addmeastypes_button.UseVisualStyleBackColor = true;
            this.Addmeastypes_button.Click += new System.EventHandler(this.Addmeastypes_button_Click);
            // 
            // MeasTypecheckList
            // 
            this.MeasTypecheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasTypecheckList.FormattingEnabled = true;
            this.MeasTypecheckList.Location = new System.Drawing.Point(10, 61);
            this.MeasTypecheckList.Name = "MeasTypecheckList";
            this.MeasTypecheckList.Size = new System.Drawing.Size(263, 89);
            this.MeasTypecheckList.TabIndex = 0;
            // 
            // Create_Framework_button
            // 
            this.Create_Framework_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Create_Framework_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Create_Framework_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Create_Framework_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Framework_button.Location = new System.Drawing.Point(434, 442);
            this.Create_Framework_button.Name = "Create_Framework_button";
            this.Create_Framework_button.Size = new System.Drawing.Size(262, 36);
            this.Create_Framework_button.TabIndex = 7;
            this.Create_Framework_button.Text = "Load openECA Framework";
            this.Create_Framework_button.UseVisualStyleBackColor = false;
            this.Create_Framework_button.Click += new System.EventHandler(this.Create_Framework_button_Click);
            // 
            // SearchFrameworkbutton
            // 
            this.SearchFrameworkbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SearchFrameworkbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchFrameworkbutton.Location = new System.Drawing.Point(814, 22);
            this.SearchFrameworkbutton.Name = "SearchFrameworkbutton";
            this.SearchFrameworkbutton.Size = new System.Drawing.Size(93, 27);
            this.SearchFrameworkbutton.TabIndex = 28;
            this.SearchFrameworkbutton.Text = "Search";
            this.SearchFrameworkbutton.UseVisualStyleBackColor = false;
            this.SearchFrameworkbutton.Click += new System.EventHandler(this.SearchFrameworkbutton_Click);
            // 
            // Framework_LocationBox
            // 
            this.Framework_LocationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Framework_LocationBox.Location = new System.Drawing.Point(16, 25);
            this.Framework_LocationBox.Name = "Framework_LocationBox";
            this.Framework_LocationBox.Size = new System.Drawing.Size(774, 22);
            this.Framework_LocationBox.TabIndex = 29;
            // 
            // Config_locationbox
            // 
            this.Config_locationbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Config_locationbox.Controls.Add(this.Framework_LocationBox);
            this.Config_locationbox.Controls.Add(this.SearchFrameworkbutton);
            this.Config_locationbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_locationbox.Location = new System.Drawing.Point(233, 73);
            this.Config_locationbox.Name = "Config_locationbox";
            this.Config_locationbox.Size = new System.Drawing.Size(950, 58);
            this.Config_locationbox.TabIndex = 30;
            this.Config_locationbox.TabStop = false;
            this.Config_locationbox.Text = "Provide Stored openECA Framework CSV File";
            // 
            // SSDQactionBox
            // 
            this.SSDQactionBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SSDQactionBox.Controls.Add(this.DatagroupBox);
            this.SSDQactionBox.Controls.Add(this.StopSSDQbutton);
            this.SSDQactionBox.Controls.Add(this.ParameterSettingsButton);
            this.SSDQactionBox.Controls.Add(this.RunSSDQButton);
            this.SSDQactionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSDQactionBox.Location = new System.Drawing.Point(1058, 203);
            this.SSDQactionBox.Name = "SSDQactionBox";
            this.SSDQactionBox.Size = new System.Drawing.Size(207, 358);
            this.SSDQactionBox.TabIndex = 31;
            this.SSDQactionBox.TabStop = false;
            this.SSDQactionBox.Text = "SSDQ Actions";
            // 
            // DatagroupBox
            // 
            this.DatagroupBox.Controls.Add(this.PlotButton);
            this.DatagroupBox.Controls.Add(this.RecordData_button);
            this.DatagroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatagroupBox.Location = new System.Drawing.Point(15, 207);
            this.DatagroupBox.Name = "DatagroupBox";
            this.DatagroupBox.Size = new System.Drawing.Size(167, 134);
            this.DatagroupBox.TabIndex = 33;
            this.DatagroupBox.TabStop = false;
            this.DatagroupBox.Text = "Data Visualization";
            // 
            // PlotButton
            // 
            this.PlotButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PlotButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlotButton.Location = new System.Drawing.Point(22, 37);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(122, 34);
            this.PlotButton.TabIndex = 31;
            this.PlotButton.Text = "PLOT";
            this.PlotButton.UseVisualStyleBackColor = false;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // RecordData_button
            // 
            this.RecordData_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RecordData_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RecordData_button.Location = new System.Drawing.Point(22, 77);
            this.RecordData_button.Name = "RecordData_button";
            this.RecordData_button.Size = new System.Drawing.Size(122, 40);
            this.RecordData_button.TabIndex = 32;
            this.RecordData_button.Text = "Record Data";
            this.RecordData_button.UseVisualStyleBackColor = false;
            this.RecordData_button.Click += new System.EventHandler(this.RecordData_button_Click);
            // 
            // StopSSDQbutton
            // 
            this.StopSSDQbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StopSSDQbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StopSSDQbutton.Location = new System.Drawing.Point(35, 153);
            this.StopSSDQbutton.Name = "StopSSDQbutton";
            this.StopSSDQbutton.Size = new System.Drawing.Size(122, 33);
            this.StopSSDQbutton.TabIndex = 30;
            this.StopSSDQbutton.Text = "Stop SSDQ";
            this.StopSSDQbutton.UseVisualStyleBackColor = false;
            this.StopSSDQbutton.Click += new System.EventHandler(this.StopSSDQbutton_Click);
            // 
            // ParameterSettingsButton
            // 
            this.ParameterSettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ParameterSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ParameterSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterSettingsButton.Location = new System.Drawing.Point(6, 42);
            this.ParameterSettingsButton.Name = "ParameterSettingsButton";
            this.ParameterSettingsButton.Size = new System.Drawing.Size(186, 34);
            this.ParameterSettingsButton.TabIndex = 12;
            this.ParameterSettingsButton.Text = "Parameter Settings";
            this.ParameterSettingsButton.UseVisualStyleBackColor = false;
            this.ParameterSettingsButton.Click += new System.EventHandler(this.ParameterSettingsButton_Click_1);
            // 
            // RunSSDQButton
            // 
            this.RunSSDQButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RunSSDQButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RunSSDQButton.Location = new System.Drawing.Point(35, 108);
            this.RunSSDQButton.Name = "RunSSDQButton";
            this.RunSSDQButton.Size = new System.Drawing.Size(122, 31);
            this.RunSSDQButton.TabIndex = 29;
            this.RunSSDQButton.Text = "Run SSDQ";
            this.RunSSDQButton.UseVisualStyleBackColor = false;
            this.RunSSDQButton.Click += new System.EventHandler(this.RunSSDQButton_Click);
            // 
            // Savegroupbox
            // 
            this.Savegroupbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Savegroupbox.Controls.Add(this.CSVlocationlabel);
            this.Savegroupbox.Controls.Add(this.Locationlabel);
            this.Savegroupbox.Controls.Add(this.SaveFrameworkbutton);
            this.Savegroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savegroupbox.Location = new System.Drawing.Point(40, 630);
            this.Savegroupbox.Name = "Savegroupbox";
            this.Savegroupbox.Size = new System.Drawing.Size(916, 73);
            this.Savegroupbox.TabIndex = 32;
            this.Savegroupbox.TabStop = false;
            this.Savegroupbox.Text = "Save openECA Framework";
            // 
            // CSVlocationlabel
            // 
            this.CSVlocationlabel.AutoSize = true;
            this.CSVlocationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVlocationlabel.Location = new System.Drawing.Point(315, 48);
            this.CSVlocationlabel.Name = "CSVlocationlabel";
            this.CSVlocationlabel.Size = new System.Drawing.Size(0, 16);
            this.CSVlocationlabel.TabIndex = 29;
            // 
            // Locationlabel
            // 
            this.Locationlabel.AutoSize = true;
            this.Locationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Locationlabel.Location = new System.Drawing.Point(6, 48);
            this.Locationlabel.Name = "Locationlabel";
            this.Locationlabel.Size = new System.Drawing.Size(299, 16);
            this.Locationlabel.TabIndex = 28;
            this.Locationlabel.Text = "Recent Saved Framework (.csv) Location: ";
            // 
            // SaveFrameworkbutton
            // 
            this.SaveFrameworkbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SaveFrameworkbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveFrameworkbutton.Location = new System.Drawing.Point(430, 15);
            this.SaveFrameworkbutton.Name = "SaveFrameworkbutton";
            this.SaveFrameworkbutton.Size = new System.Drawing.Size(115, 27);
            this.SaveFrameworkbutton.TabIndex = 27;
            this.SaveFrameworkbutton.Text = "Save";
            this.SaveFrameworkbutton.UseVisualStyleBackColor = false;
            this.SaveFrameworkbutton.Click += new System.EventHandler(this.SaveFrameworkbutton_Click);
            // 
            // Input_screen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1277, 714);
            this.Controls.Add(this.Savegroupbox);
            this.Controls.Add(this.SSDQactionBox);
            this.Controls.Add(this.Config_locationbox);
            this.Controls.Add(this.StoredMeasurementBox);
            this.Controls.Add(this.EPRIpictureBox);
            this.Controls.Add(this.Heading);
            this.Name = "Input_screen2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSDQ openECA Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputScreen2_FormClosing);
            this.Load += new System.EventHandler(this.Input_screen2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EPRIpictureBox)).EndInit();
            this.StoredMeasurementBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.InputChannelListgroupBox.ResumeLayout(false);
            this.DevicegroupBox.ResumeLayout(false);
            this.MeasTypegroupbox.ResumeLayout(false);
            this.Config_locationbox.ResumeLayout(false);
            this.Config_locationbox.PerformLayout();
            this.SSDQactionBox.ResumeLayout(false);
            this.DatagroupBox.ResumeLayout(false);
            this.Savegroupbox.ResumeLayout(false);
            this.Savegroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox EPRIpictureBox;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.GroupBox StoredMeasurementBox;
        private System.Windows.Forms.Button Deselect_IPchannels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OutputDevice_combobox;
        private System.Windows.Forms.Button UpdateChannels;
        private System.Windows.Forms.Button AllMeasbutton;
        private System.Windows.Forms.CheckedListBox DeviceCheckList;
        private System.Windows.Forms.CheckedListBox OutputChannelList;
        private System.Windows.Forms.GroupBox MeasTypegroupbox;
        private System.Windows.Forms.CheckedListBox InputChannelList;
        private System.Windows.Forms.Button Create_Framework_button;
        private System.Windows.Forms.Button SearchFrameworkbutton;
        private System.Windows.Forms.TextBox Framework_LocationBox;
        private System.Windows.Forms.GroupBox Config_locationbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox InputChannelListgroupBox;
        private System.Windows.Forms.GroupBox DevicegroupBox;
        private System.Windows.Forms.GroupBox SSDQactionBox;
        private System.Windows.Forms.Button RecordData_button;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.Button StopSSDQbutton;
        private System.Windows.Forms.Button ParameterSettingsButton;
        private System.Windows.Forms.Button RunSSDQButton;
        private System.Windows.Forms.CheckedListBox MeasTypecheckList;
        private System.Windows.Forms.GroupBox DatagroupBox;
        private System.Windows.Forms.Button Deselect_devices;
        private System.Windows.Forms.Button AllDevicesbutton;
        private System.Windows.Forms.Button RefreshChannelsbutton;
        private System.Windows.Forms.Button Adddevices_button;
        private System.Windows.Forms.Button Addmeastypes_button;
        private System.Windows.Forms.Button DeselectTypes_button;
        private System.Windows.Forms.Button SelectAllTypes_button;
        private System.Windows.Forms.GroupBox Savegroupbox;
        private System.Windows.Forms.Label CSVlocationlabel;
        private System.Windows.Forms.Label Locationlabel;
        private System.Windows.Forms.Button SaveFrameworkbutton;
    }
}