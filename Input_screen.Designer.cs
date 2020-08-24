namespace SSDQopenECA
{
    partial class Input_screen
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
            this.Heading = new System.Windows.Forms.Label();
            this.InputChannelList = new System.Windows.Forms.CheckedListBox();
            this.Create_Framework_button = new System.Windows.Forms.Button();
            this.MeasurementBox = new System.Windows.Forms.GroupBox();
            this.Deselect_IPchannels = new System.Windows.Forms.Button();
            this.Deselect_devices = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputDevice_combobox = new System.Windows.Forms.ComboBox();
            this.UpdateChannels = new System.Windows.Forms.Button();
            this.AllMeasbutton = new System.Windows.Forms.Button();
            this.AllDevicesbutton = new System.Windows.Forms.Button();
            this.DeviceCheckList = new System.Windows.Forms.CheckedListBox();
            this.GetDeviceButton = new System.Windows.Forms.Button();
            this.OutputChannelList = new System.Windows.Forms.CheckedListBox();
            this.DataSourcegroupbox = new System.Windows.Forms.GroupBox();
            this.ExtPDC_DB = new System.Windows.Forms.CheckBox();
            this.openECA_DB = new System.Windows.Forms.CheckBox();
            this.MeasTypeNewgroupbox = new System.Windows.Forms.GroupBox();
            this.Freq_Button = new System.Windows.Forms.CheckBox();
            this.Curr_AngButton = new System.Windows.Forms.CheckBox();
            this.Curr_MagButton = new System.Windows.Forms.CheckBox();
            this.Volt_AngButton = new System.Windows.Forms.CheckBox();
            this.Volt_MagButton = new System.Windows.Forms.CheckBox();
            this.AvailableMeastypebutton = new System.Windows.Forms.Button();
            this.RefreshInputList = new System.Windows.Forms.Button();
            this.Savegroupbox = new System.Windows.Forms.GroupBox();
            this.CSVlocationlabel = new System.Windows.Forms.Label();
            this.Locationlabel = new System.Windows.Forms.Label();
            this.SaveFrameworkbutton = new System.Windows.Forms.Button();
            this.RunSSDQButton = new System.Windows.Forms.Button();
            this.ParameterSettingsButton = new System.Windows.Forms.Button();
            this.EPRIpictureBox = new System.Windows.Forms.PictureBox();
            this.SSDQactionBox = new System.Windows.Forms.GroupBox();
            this.Datagroupbox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RecordData_button = new System.Windows.Forms.Button();
            this.StopSSDQbutton = new System.Windows.Forms.Button();
            this.Config_locationbox = new System.Windows.Forms.GroupBox();
            this.Framework_LocationBox = new System.Windows.Forms.TextBox();
            this.SearchFrameworkbutton = new System.Windows.Forms.Button();
            this.MeasTypeOldgroupbox = new System.Windows.Forms.GroupBox();
            this.DeselectTypes_button = new System.Windows.Forms.Button();
            this.SelectAllTypes_button = new System.Windows.Forms.Button();
            this.Addmeastypes_button = new System.Windows.Forms.Button();
            this.MeasTypecheckList = new System.Windows.Forms.CheckedListBox();
            this.Adddevices_button = new System.Windows.Forms.Button();
            this.MeasurementBox.SuspendLayout();
            this.DataSourcegroupbox.SuspendLayout();
            this.MeasTypeNewgroupbox.SuspendLayout();
            this.Savegroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPRIpictureBox)).BeginInit();
            this.SSDQactionBox.SuspendLayout();
            this.Datagroupbox.SuspendLayout();
            this.Config_locationbox.SuspendLayout();
            this.MeasTypeOldgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Heading
            // 
            this.Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Heading.AutoSize = true;
            this.Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.ForeColor = System.Drawing.Color.Navy;
            this.Heading.Location = new System.Drawing.Point(223, 9);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(750, 61);
            this.Heading.TabIndex = 0;
            this.Heading.Text = "SSDQopenECA Configuration";
            // 
            // InputChannelList
            // 
            this.InputChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.InputChannelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputChannelList.FormattingEnabled = true;
            this.InputChannelList.Location = new System.Drawing.Point(329, 149);
            this.InputChannelList.Name = "InputChannelList";
            this.InputChannelList.Size = new System.Drawing.Size(286, 327);
            this.InputChannelList.TabIndex = 1;
            // 
            // Create_Framework_button
            // 
            this.Create_Framework_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Create_Framework_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Create_Framework_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Create_Framework_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Framework_button.Location = new System.Drawing.Point(388, 514);
            this.Create_Framework_button.Name = "Create_Framework_button";
            this.Create_Framework_button.Size = new System.Drawing.Size(262, 36);
            this.Create_Framework_button.TabIndex = 7;
            this.Create_Framework_button.Text = "Create openECA Framework";
            this.Create_Framework_button.UseVisualStyleBackColor = false;
            this.Create_Framework_button.Click += new System.EventHandler(this.Create_Framework_button_Click);
            // 
            // MeasurementBox
            // 
            this.MeasurementBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MeasurementBox.Controls.Add(this.MeasTypeOldgroupbox);
            this.MeasurementBox.Controls.Add(this.Deselect_IPchannels);
            this.MeasurementBox.Controls.Add(this.Deselect_devices);
            this.MeasurementBox.Controls.Add(this.label1);
            this.MeasurementBox.Controls.Add(this.OutputDevice_combobox);
            this.MeasurementBox.Controls.Add(this.UpdateChannels);
            this.MeasurementBox.Controls.Add(this.AllMeasbutton);
            this.MeasurementBox.Controls.Add(this.AllDevicesbutton);
            this.MeasurementBox.Controls.Add(this.DeviceCheckList);
            this.MeasurementBox.Controls.Add(this.GetDeviceButton);
            this.MeasurementBox.Controls.Add(this.OutputChannelList);
            this.MeasurementBox.Controls.Add(this.DataSourcegroupbox);
            this.MeasurementBox.Controls.Add(this.MeasTypeNewgroupbox);
            this.MeasurementBox.Controls.Add(this.RefreshInputList);
            this.MeasurementBox.Controls.Add(this.InputChannelList);
            this.MeasurementBox.Controls.Add(this.Create_Framework_button);
            this.MeasurementBox.Controls.Add(this.Adddevices_button);
            this.MeasurementBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasurementBox.Location = new System.Drawing.Point(20, 132);
            this.MeasurementBox.Name = "MeasurementBox";
            this.MeasurementBox.Size = new System.Drawing.Size(1044, 556);
            this.MeasurementBox.TabIndex = 9;
            this.MeasurementBox.TabStop = false;
            this.MeasurementBox.Text = "Framework Settings";
            // 
            // Deselect_IPchannels
            // 
            this.Deselect_IPchannels.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Deselect_IPchannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_IPchannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_IPchannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_IPchannels.Location = new System.Drawing.Point(489, 485);
            this.Deselect_IPchannels.Name = "Deselect_IPchannels";
            this.Deselect_IPchannels.Size = new System.Drawing.Size(103, 23);
            this.Deselect_IPchannels.TabIndex = 25;
            this.Deselect_IPchannels.Text = "Deselect All";
            this.Deselect_IPchannels.UseVisualStyleBackColor = false;
            this.Deselect_IPchannels.Click += new System.EventHandler(this.Deselect_IPchannels_Click);
            // 
            // Deselect_devices
            // 
            this.Deselect_devices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Deselect_devices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_devices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_devices.Location = new System.Drawing.Point(170, 329);
            this.Deselect_devices.Name = "Deselect_devices";
            this.Deselect_devices.Size = new System.Drawing.Size(103, 23);
            this.Deselect_devices.TabIndex = 24;
            this.Deselect_devices.Text = "Deselect All";
            this.Deselect_devices.UseVisualStyleBackColor = false;
            this.Deselect_devices.Click += new System.EventHandler(this.Deselect_devices_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(675, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select Output Device";
            // 
            // OutputDevice_combobox
            // 
            this.OutputDevice_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDevice_combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputDevice_combobox.FormattingEnabled = true;
            this.OutputDevice_combobox.Location = new System.Drawing.Point(678, 128);
            this.OutputDevice_combobox.Name = "OutputDevice_combobox";
            this.OutputDevice_combobox.Size = new System.Drawing.Size(310, 24);
            this.OutputDevice_combobox.TabIndex = 21;
            // 
            // UpdateChannels
            // 
            this.UpdateChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateChannels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UpdateChannels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateChannels.Location = new System.Drawing.Point(670, 167);
            this.UpdateChannels.Name = "UpdateChannels";
            this.UpdateChannels.Size = new System.Drawing.Size(331, 34);
            this.UpdateChannels.TabIndex = 20;
            this.UpdateChannels.Text = "Create/Update Output Measurement Channels";
            this.UpdateChannels.UseVisualStyleBackColor = false;
            this.UpdateChannels.Click += new System.EventHandler(this.UpdateChannels_Click);
            // 
            // AllMeasbutton
            // 
            this.AllMeasbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AllMeasbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllMeasbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllMeasbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllMeasbutton.Location = new System.Drawing.Point(329, 485);
            this.AllMeasbutton.Name = "AllMeasbutton";
            this.AllMeasbutton.Size = new System.Drawing.Size(103, 23);
            this.AllMeasbutton.TabIndex = 19;
            this.AllMeasbutton.Text = "Select All";
            this.AllMeasbutton.UseVisualStyleBackColor = false;
            this.AllMeasbutton.Click += new System.EventHandler(this.AllMeasbutton_Click);
            // 
            // AllDevicesbutton
            // 
            this.AllDevicesbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AllDevicesbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllDevicesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllDevicesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDevicesbutton.Location = new System.Drawing.Point(23, 329);
            this.AllDevicesbutton.Name = "AllDevicesbutton";
            this.AllDevicesbutton.Size = new System.Drawing.Size(103, 23);
            this.AllDevicesbutton.TabIndex = 18;
            this.AllDevicesbutton.Text = "Select All";
            this.AllDevicesbutton.UseVisualStyleBackColor = false;
            this.AllDevicesbutton.Click += new System.EventHandler(this.AllDevicesbutton_Click);
            // 
            // DeviceCheckList
            // 
            this.DeviceCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DeviceCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceCheckList.FormattingEnabled = true;
            this.DeviceCheckList.Location = new System.Drawing.Point(6, 149);
            this.DeviceCheckList.Name = "DeviceCheckList";
            this.DeviceCheckList.Size = new System.Drawing.Size(294, 174);
            this.DeviceCheckList.TabIndex = 17;
            // 
            // GetDeviceButton
            // 
            this.GetDeviceButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GetDeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GetDeviceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDeviceButton.Location = new System.Drawing.Point(79, 110);
            this.GetDeviceButton.Name = "GetDeviceButton";
            this.GetDeviceButton.Size = new System.Drawing.Size(142, 33);
            this.GetDeviceButton.TabIndex = 16;
            this.GetDeviceButton.Text = "Get Input Devices";
            this.GetDeviceButton.UseVisualStyleBackColor = false;
            this.GetDeviceButton.Click += new System.EventHandler(this.GetDeviceButton_Click);
            // 
            // OutputChannelList
            // 
            this.OutputChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputChannelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputChannelList.FormattingEnabled = true;
            this.OutputChannelList.Location = new System.Drawing.Point(678, 207);
            this.OutputChannelList.Name = "OutputChannelList";
            this.OutputChannelList.Size = new System.Drawing.Size(310, 293);
            this.OutputChannelList.TabIndex = 14;
            this.OutputChannelList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckList_ItemCheck);
            // 
            // DataSourcegroupbox
            // 
            this.DataSourcegroupbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DataSourcegroupbox.Controls.Add(this.ExtPDC_DB);
            this.DataSourcegroupbox.Controls.Add(this.openECA_DB);
            this.DataSourcegroupbox.Location = new System.Drawing.Point(6, 28);
            this.DataSourcegroupbox.Name = "DataSourcegroupbox";
            this.DataSourcegroupbox.Size = new System.Drawing.Size(288, 76);
            this.DataSourcegroupbox.TabIndex = 7;
            this.DataSourcegroupbox.TabStop = false;
            this.DataSourcegroupbox.Text = "Select Data Source";
            // 
            // ExtPDC_DB
            // 
            this.ExtPDC_DB.AutoSize = true;
            this.ExtPDC_DB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtPDC_DB.Location = new System.Drawing.Point(7, 50);
            this.ExtPDC_DB.Name = "ExtPDC_DB";
            this.ExtPDC_DB.Size = new System.Drawing.Size(208, 20);
            this.ExtPDC_DB.TabIndex = 17;
            this.ExtPDC_DB.Text = "External PDC Subscription";
            this.ExtPDC_DB.UseVisualStyleBackColor = true;
            // 
            // openECA_DB
            // 
            this.openECA_DB.AutoSize = true;
            this.openECA_DB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openECA_DB.Location = new System.Drawing.Point(7, 26);
            this.openECA_DB.Name = "openECA_DB";
            this.openECA_DB.Size = new System.Drawing.Size(92, 20);
            this.openECA_DB.TabIndex = 16;
            this.openECA_DB.Text = "openECA";
            this.openECA_DB.UseVisualStyleBackColor = true;
            // 
            // MeasTypeNewgroupbox
            // 
            this.MeasTypeNewgroupbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MeasTypeNewgroupbox.Controls.Add(this.Freq_Button);
            this.MeasTypeNewgroupbox.Controls.Add(this.Curr_AngButton);
            this.MeasTypeNewgroupbox.Controls.Add(this.Curr_MagButton);
            this.MeasTypeNewgroupbox.Controls.Add(this.Volt_AngButton);
            this.MeasTypeNewgroupbox.Controls.Add(this.Volt_MagButton);
            this.MeasTypeNewgroupbox.Controls.Add(this.AvailableMeastypebutton);
            this.MeasTypeNewgroupbox.Location = new System.Drawing.Point(329, 28);
            this.MeasTypeNewgroupbox.Name = "MeasTypeNewgroupbox";
            this.MeasTypeNewgroupbox.Size = new System.Drawing.Size(678, 76);
            this.MeasTypeNewgroupbox.TabIndex = 13;
            this.MeasTypeNewgroupbox.TabStop = false;
            this.MeasTypeNewgroupbox.Text = "Measurement Types";
            // 
            // Freq_Button
            // 
            this.Freq_Button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Freq_Button.AutoSize = true;
            this.Freq_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Freq_Button.Location = new System.Drawing.Point(565, 53);
            this.Freq_Button.Name = "Freq_Button";
            this.Freq_Button.Size = new System.Drawing.Size(100, 20);
            this.Freq_Button.TabIndex = 12;
            this.Freq_Button.Text = "Frequency";
            this.Freq_Button.UseVisualStyleBackColor = true;
            // 
            // Curr_AngButton
            // 
            this.Curr_AngButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Curr_AngButton.AutoSize = true;
            this.Curr_AngButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Curr_AngButton.Location = new System.Drawing.Point(439, 53);
            this.Curr_AngButton.Name = "Curr_AngButton";
            this.Curr_AngButton.Size = new System.Drawing.Size(120, 20);
            this.Curr_AngButton.TabIndex = 11;
            this.Curr_AngButton.Text = "Current Angle";
            this.Curr_AngButton.UseVisualStyleBackColor = true;
            // 
            // Curr_MagButton
            // 
            this.Curr_MagButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Curr_MagButton.AutoSize = true;
            this.Curr_MagButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Curr_MagButton.Location = new System.Drawing.Point(281, 53);
            this.Curr_MagButton.Name = "Curr_MagButton";
            this.Curr_MagButton.Size = new System.Drawing.Size(152, 20);
            this.Curr_MagButton.TabIndex = 10;
            this.Curr_MagButton.Text = "Current Magnitude";
            this.Curr_MagButton.UseVisualStyleBackColor = true;
            // 
            // Volt_AngButton
            // 
            this.Volt_AngButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Volt_AngButton.AutoSize = true;
            this.Volt_AngButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volt_AngButton.Location = new System.Drawing.Point(160, 53);
            this.Volt_AngButton.Name = "Volt_AngButton";
            this.Volt_AngButton.Size = new System.Drawing.Size(125, 20);
            this.Volt_AngButton.TabIndex = 9;
            this.Volt_AngButton.Text = "Voltage Angle";
            this.Volt_AngButton.UseVisualStyleBackColor = true;
            // 
            // Volt_MagButton
            // 
            this.Volt_MagButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Volt_MagButton.AutoSize = true;
            this.Volt_MagButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volt_MagButton.Location = new System.Drawing.Point(7, 53);
            this.Volt_MagButton.Name = "Volt_MagButton";
            this.Volt_MagButton.Size = new System.Drawing.Size(157, 20);
            this.Volt_MagButton.TabIndex = 8;
            this.Volt_MagButton.Text = "Voltage Magnitude";
            this.Volt_MagButton.UseVisualStyleBackColor = true;
            // 
            // AvailableMeastypebutton
            // 
            this.AvailableMeastypebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AvailableMeastypebutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AvailableMeastypebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AvailableMeastypebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableMeastypebutton.Location = new System.Drawing.Point(208, 19);
            this.AvailableMeastypebutton.Name = "AvailableMeastypebutton";
            this.AvailableMeastypebutton.Size = new System.Drawing.Size(271, 29);
            this.AvailableMeastypebutton.TabIndex = 7;
            this.AvailableMeastypebutton.Text = "Get Available Measurement Types";
            this.AvailableMeastypebutton.UseVisualStyleBackColor = false;
            this.AvailableMeastypebutton.Click += new System.EventHandler(this.AvailableMeastypebutton_Click);
            // 
            // RefreshInputList
            // 
            this.RefreshInputList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RefreshInputList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RefreshInputList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshInputList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshInputList.Location = new System.Drawing.Point(329, 109);
            this.RefreshInputList.Name = "RefreshInputList";
            this.RefreshInputList.Size = new System.Drawing.Size(286, 34);
            this.RefreshInputList.TabIndex = 8;
            this.RefreshInputList.Text = "Refresh Input Measurement Channels";
            this.RefreshInputList.UseVisualStyleBackColor = false;
            this.RefreshInputList.Click += new System.EventHandler(this.RefreshInputList_Click);
            // 
            // Savegroupbox
            // 
            this.Savegroupbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Savegroupbox.Controls.Add(this.CSVlocationlabel);
            this.Savegroupbox.Controls.Add(this.Locationlabel);
            this.Savegroupbox.Controls.Add(this.SaveFrameworkbutton);
            this.Savegroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savegroupbox.Location = new System.Drawing.Point(20, 694);
            this.Savegroupbox.Name = "Savegroupbox";
            this.Savegroupbox.Size = new System.Drawing.Size(1044, 73);
            this.Savegroupbox.TabIndex = 28;
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
            // RunSSDQButton
            // 
            this.RunSSDQButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RunSSDQButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RunSSDQButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RunSSDQButton.Location = new System.Drawing.Point(35, 120);
            this.RunSSDQButton.Name = "RunSSDQButton";
            this.RunSSDQButton.Size = new System.Drawing.Size(122, 31);
            this.RunSSDQButton.TabIndex = 29;
            this.RunSSDQButton.Text = "Run SSDQ";
            this.RunSSDQButton.UseVisualStyleBackColor = false;
            this.RunSSDQButton.Click += new System.EventHandler(this.RunSSDQButton_Click);
            // 
            // ParameterSettingsButton
            // 
            this.ParameterSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ParameterSettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ParameterSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ParameterSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterSettingsButton.Location = new System.Drawing.Point(6, 47);
            this.ParameterSettingsButton.Name = "ParameterSettingsButton";
            this.ParameterSettingsButton.Size = new System.Drawing.Size(186, 34);
            this.ParameterSettingsButton.TabIndex = 12;
            this.ParameterSettingsButton.Text = "Parameter Settings";
            this.ParameterSettingsButton.UseVisualStyleBackColor = false;
            this.ParameterSettingsButton.Click += new System.EventHandler(this.ParameterSettingsButton_Click);
            // 
            // EPRIpictureBox
            // 
            this.EPRIpictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EPRIpictureBox.BackgroundImage = global::SSDQopenECA.Properties.Resources.EPRI_Logo;
            this.EPRIpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EPRIpictureBox.Location = new System.Drawing.Point(20, 9);
            this.EPRIpictureBox.Name = "EPRIpictureBox";
            this.EPRIpictureBox.Size = new System.Drawing.Size(192, 118);
            this.EPRIpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.EPRIpictureBox.TabIndex = 13;
            this.EPRIpictureBox.TabStop = false;
            // 
            // SSDQactionBox
            // 
            this.SSDQactionBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SSDQactionBox.Controls.Add(this.Datagroupbox);
            this.SSDQactionBox.Controls.Add(this.StopSSDQbutton);
            this.SSDQactionBox.Controls.Add(this.ParameterSettingsButton);
            this.SSDQactionBox.Controls.Add(this.RunSSDQButton);
            this.SSDQactionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSDQactionBox.Location = new System.Drawing.Point(1070, 240);
            this.SSDQactionBox.Name = "SSDQactionBox";
            this.SSDQactionBox.Size = new System.Drawing.Size(207, 368);
            this.SSDQactionBox.TabIndex = 30;
            this.SSDQactionBox.TabStop = false;
            this.SSDQactionBox.Text = "SSDQ Actions";
            // 
            // Datagroupbox
            // 
            this.Datagroupbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Datagroupbox.Controls.Add(this.button2);
            this.Datagroupbox.Controls.Add(this.RecordData_button);
            this.Datagroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datagroupbox.Location = new System.Drawing.Point(15, 232);
            this.Datagroupbox.Name = "Datagroupbox";
            this.Datagroupbox.Size = new System.Drawing.Size(177, 111);
            this.Datagroupbox.TabIndex = 33;
            this.Datagroupbox.TabStop = false;
            this.Datagroupbox.Text = "Data Visualization";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(29, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 34);
            this.button2.TabIndex = 31;
            this.button2.Text = "PLOT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // RecordData_button
            // 
            this.RecordData_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RecordData_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RecordData_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RecordData_button.Location = new System.Drawing.Point(29, 65);
            this.RecordData_button.Name = "RecordData_button";
            this.RecordData_button.Size = new System.Drawing.Size(122, 40);
            this.RecordData_button.TabIndex = 32;
            this.RecordData_button.Text = "Record Data";
            this.RecordData_button.UseVisualStyleBackColor = false;
            this.RecordData_button.Click += new System.EventHandler(this.RecordData_button_Click);
            // 
            // StopSSDQbutton
            // 
            this.StopSSDQbutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StopSSDQbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StopSSDQbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StopSSDQbutton.Location = new System.Drawing.Point(35, 166);
            this.StopSSDQbutton.Name = "StopSSDQbutton";
            this.StopSSDQbutton.Size = new System.Drawing.Size(122, 33);
            this.StopSSDQbutton.TabIndex = 30;
            this.StopSSDQbutton.Text = "Stop SSDQ";
            this.StopSSDQbutton.UseVisualStyleBackColor = false;
            this.StopSSDQbutton.Click += new System.EventHandler(this.StopSSDQbutton_Click);
            // 
            // Config_locationbox
            // 
            this.Config_locationbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Config_locationbox.Controls.Add(this.Framework_LocationBox);
            this.Config_locationbox.Controls.Add(this.SearchFrameworkbutton);
            this.Config_locationbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_locationbox.Location = new System.Drawing.Point(218, 82);
            this.Config_locationbox.Name = "Config_locationbox";
            this.Config_locationbox.Size = new System.Drawing.Size(950, 58);
            this.Config_locationbox.TabIndex = 31;
            this.Config_locationbox.TabStop = false;
            this.Config_locationbox.Text = "Provide Stored openECA Framework CSV File";
            // 
            // Framework_LocationBox
            // 
            this.Framework_LocationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Framework_LocationBox.Location = new System.Drawing.Point(16, 25);
            this.Framework_LocationBox.Name = "Framework_LocationBox";
            this.Framework_LocationBox.Size = new System.Drawing.Size(774, 22);
            this.Framework_LocationBox.TabIndex = 29;
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
            // MeasTypeOldgroupbox
            // 
            this.MeasTypeOldgroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MeasTypeOldgroupbox.Controls.Add(this.DeselectTypes_button);
            this.MeasTypeOldgroupbox.Controls.Add(this.SelectAllTypes_button);
            this.MeasTypeOldgroupbox.Controls.Add(this.Addmeastypes_button);
            this.MeasTypeOldgroupbox.Controls.Add(this.MeasTypecheckList);
            this.MeasTypeOldgroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasTypeOldgroupbox.Location = new System.Drawing.Point(6, 358);
            this.MeasTypeOldgroupbox.Name = "MeasTypeOldgroupbox";
            this.MeasTypeOldgroupbox.Size = new System.Drawing.Size(294, 188);
            this.MeasTypeOldgroupbox.TabIndex = 26;
            this.MeasTypeOldgroupbox.TabStop = false;
            this.MeasTypeOldgroupbox.Text = "Measurement Type";
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
            // Adddevices_button
            // 
            this.Adddevices_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Adddevices_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Adddevices_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Adddevices_button.Location = new System.Drawing.Point(66, 110);
            this.Adddevices_button.Name = "Adddevices_button";
            this.Adddevices_button.Size = new System.Drawing.Size(172, 33);
            this.Adddevices_button.TabIndex = 34;
            this.Adddevices_button.Text = "Update Input Devices";
            this.Adddevices_button.UseVisualStyleBackColor = false;
            this.Adddevices_button.Click += new System.EventHandler(this.Adddevices_button_Click);
            // 
            // Input_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1319, 781);
            this.Controls.Add(this.Config_locationbox);
            this.Controls.Add(this.Savegroupbox);
            this.Controls.Add(this.SSDQactionBox);
            this.Controls.Add(this.EPRIpictureBox);
            this.Controls.Add(this.MeasurementBox);
            this.Controls.Add(this.Heading);
            this.Name = "Input_screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSDQ openECA Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputScreen_FormClosing);
            this.Load += new System.EventHandler(this.Input_screen_Load);
            this.MeasurementBox.ResumeLayout(false);
            this.MeasurementBox.PerformLayout();
            this.DataSourcegroupbox.ResumeLayout(false);
            this.DataSourcegroupbox.PerformLayout();
            this.MeasTypeNewgroupbox.ResumeLayout(false);
            this.MeasTypeNewgroupbox.PerformLayout();
            this.Savegroupbox.ResumeLayout(false);
            this.Savegroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPRIpictureBox)).EndInit();
            this.SSDQactionBox.ResumeLayout(false);
            this.Datagroupbox.ResumeLayout(false);
            this.Config_locationbox.ResumeLayout(false);
            this.Config_locationbox.PerformLayout();
            this.MeasTypeOldgroupbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.CheckedListBox InputChannelList;
        private System.Windows.Forms.Button Create_Framework_button;
        private System.Windows.Forms.GroupBox MeasurementBox;
        private System.Windows.Forms.Button RefreshInputList;
        private System.Windows.Forms.Button ParameterSettingsButton;
        private System.Windows.Forms.GroupBox MeasTypeNewgroupbox;
        private System.Windows.Forms.PictureBox EPRIpictureBox;
        private System.Windows.Forms.CheckedListBox OutputChannelList;
        private System.Windows.Forms.GroupBox DataSourcegroupbox;
        private System.Windows.Forms.CheckedListBox DeviceCheckList;
        private System.Windows.Forms.Button GetDeviceButton;
        private System.Windows.Forms.Button AllMeasbutton;
        private System.Windows.Forms.Button AllDevicesbutton;
        private System.Windows.Forms.Button UpdateChannels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OutputDevice_combobox;
        private System.Windows.Forms.Button AvailableMeastypebutton;
        private System.Windows.Forms.Button Deselect_IPchannels;
        private System.Windows.Forms.Button Deselect_devices;
        private System.Windows.Forms.Button SaveFrameworkbutton;
        private System.Windows.Forms.GroupBox Savegroupbox;
        private System.Windows.Forms.Label Locationlabel;
        private System.Windows.Forms.Label CSVlocationlabel;
        private System.Windows.Forms.CheckBox Freq_Button;
        private System.Windows.Forms.CheckBox Curr_AngButton;
        private System.Windows.Forms.CheckBox Curr_MagButton;
        private System.Windows.Forms.CheckBox Volt_AngButton;
        private System.Windows.Forms.CheckBox Volt_MagButton;
        private System.Windows.Forms.Button RunSSDQButton;
        private System.Windows.Forms.GroupBox SSDQactionBox;
        private System.Windows.Forms.Button RecordData_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button StopSSDQbutton;
        private System.Windows.Forms.GroupBox Datagroupbox;
        private System.Windows.Forms.CheckBox ExtPDC_DB;
        private System.Windows.Forms.CheckBox openECA_DB;
        private System.Windows.Forms.GroupBox Config_locationbox;
        private System.Windows.Forms.TextBox Framework_LocationBox;
        private System.Windows.Forms.Button SearchFrameworkbutton;
        private System.Windows.Forms.GroupBox MeasTypeOldgroupbox;
        private System.Windows.Forms.Button DeselectTypes_button;
        private System.Windows.Forms.Button SelectAllTypes_button;
        private System.Windows.Forms.Button Addmeastypes_button;
        private System.Windows.Forms.CheckedListBox MeasTypecheckList;
        private System.Windows.Forms.Button Adddevices_button;
    }
}

