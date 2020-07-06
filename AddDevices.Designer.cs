namespace SSDQopenECA
{
    partial class AddDevices
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
            this.DeviceCheckList = new System.Windows.Forms.CheckedListBox();
            this.Adddevicesgroupbox = new System.Windows.Forms.GroupBox();
            this.Adddevices_button = new System.Windows.Forms.Button();
            this.Deselect_devices = new System.Windows.Forms.Button();
            this.AllDevicesbutton = new System.Windows.Forms.Button();
            this.Adddevicesgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceCheckList
            // 
            this.DeviceCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceCheckList.FormattingEnabled = true;
            this.DeviceCheckList.Location = new System.Drawing.Point(38, 68);
            this.DeviceCheckList.Name = "DeviceCheckList";
            this.DeviceCheckList.Size = new System.Drawing.Size(352, 256);
            this.DeviceCheckList.TabIndex = 0;
            // 
            // Adddevicesgroupbox
            // 
            this.Adddevicesgroupbox.Controls.Add(this.Adddevices_button);
            this.Adddevicesgroupbox.Controls.Add(this.Deselect_devices);
            this.Adddevicesgroupbox.Controls.Add(this.DeviceCheckList);
            this.Adddevicesgroupbox.Controls.Add(this.AllDevicesbutton);
            this.Adddevicesgroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Adddevicesgroupbox.Location = new System.Drawing.Point(12, 12);
            this.Adddevicesgroupbox.Name = "Adddevicesgroupbox";
            this.Adddevicesgroupbox.Size = new System.Drawing.Size(437, 372);
            this.Adddevicesgroupbox.TabIndex = 1;
            this.Adddevicesgroupbox.TabStop = false;
            this.Adddevicesgroupbox.Text = "Add Available Devices";
            // 
            // Adddevices_button
            // 
            this.Adddevices_button.Location = new System.Drawing.Point(172, 330);
            this.Adddevices_button.Name = "Adddevices_button";
            this.Adddevices_button.Size = new System.Drawing.Size(87, 33);
            this.Adddevices_button.TabIndex = 36;
            this.Adddevices_button.Text = "Update";
            this.Adddevices_button.UseVisualStyleBackColor = true;
            this.Adddevices_button.Click += new System.EventHandler(this.Adddevices_button_Click);
            // 
            // Deselect_devices
            // 
            this.Deselect_devices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_devices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_devices.Location = new System.Drawing.Point(287, 39);
            this.Deselect_devices.Name = "Deselect_devices";
            this.Deselect_devices.Size = new System.Drawing.Size(103, 23);
            this.Deselect_devices.TabIndex = 35;
            this.Deselect_devices.Text = "Deselect All";
            this.Deselect_devices.UseVisualStyleBackColor = false;
            this.Deselect_devices.Click += new System.EventHandler(this.Deselect_devices_Click);
            // 
            // AllDevicesbutton
            // 
            this.AllDevicesbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllDevicesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllDevicesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDevicesbutton.Location = new System.Drawing.Point(38, 39);
            this.AllDevicesbutton.Name = "AllDevicesbutton";
            this.AllDevicesbutton.Size = new System.Drawing.Size(84, 23);
            this.AllDevicesbutton.TabIndex = 34;
            this.AllDevicesbutton.Text = "Select All";
            this.AllDevicesbutton.UseVisualStyleBackColor = false;
            this.AllDevicesbutton.Click += new System.EventHandler(this.AllDevicesbutton_Click);
            // 
            // AddDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(462, 390);
            this.Controls.Add(this.Adddevicesgroupbox);
            this.Name = "AddDevices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Devices";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddDevices_FormClosing);
            this.Load += new System.EventHandler(this.AddDevices_Load);
            this.Adddevicesgroupbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox DeviceCheckList;
        private System.Windows.Forms.GroupBox Adddevicesgroupbox;
        private System.Windows.Forms.Button Deselect_devices;
        private System.Windows.Forms.Button AllDevicesbutton;
        private System.Windows.Forms.Button Adddevices_button;
    }
}