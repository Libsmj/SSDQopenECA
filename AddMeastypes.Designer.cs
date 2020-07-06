namespace SSDQopenECA
{
    partial class AddMeastypes
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
            this.AddMeastypesgroupbox = new System.Windows.Forms.GroupBox();
            this.Adddevices_button = new System.Windows.Forms.Button();
            this.Deselect_devices = new System.Windows.Forms.Button();
            this.MeastypeCheckList = new System.Windows.Forms.CheckedListBox();
            this.AllDevicesbutton = new System.Windows.Forms.Button();
            this.AddMeastypesgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddMeastypesgroupbox
            // 
            this.AddMeastypesgroupbox.Controls.Add(this.Adddevices_button);
            this.AddMeastypesgroupbox.Controls.Add(this.Deselect_devices);
            this.AddMeastypesgroupbox.Controls.Add(this.MeastypeCheckList);
            this.AddMeastypesgroupbox.Controls.Add(this.AllDevicesbutton);
            this.AddMeastypesgroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMeastypesgroupbox.Location = new System.Drawing.Point(12, 12);
            this.AddMeastypesgroupbox.Name = "AddMeastypesgroupbox";
            this.AddMeastypesgroupbox.Size = new System.Drawing.Size(437, 352);
            this.AddMeastypesgroupbox.TabIndex = 2;
            this.AddMeastypesgroupbox.TabStop = false;
            this.AddMeastypesgroupbox.Text = "Add Available Measurement Types";
            // 
            // Adddevices_button
            // 
            this.Adddevices_button.Location = new System.Drawing.Point(161, 309);
            this.Adddevices_button.Name = "Adddevices_button";
            this.Adddevices_button.Size = new System.Drawing.Size(102, 33);
            this.Adddevices_button.TabIndex = 36;
            this.Adddevices_button.Text = "Update";
            this.Adddevices_button.UseVisualStyleBackColor = true;
            this.Adddevices_button.Click += new System.EventHandler(this.AddMeastypes_button_Click);
            // 
            // Deselect_devices
            // 
            this.Deselect_devices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Deselect_devices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Deselect_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deselect_devices.Location = new System.Drawing.Point(291, 39);
            this.Deselect_devices.Name = "Deselect_devices";
            this.Deselect_devices.Size = new System.Drawing.Size(103, 23);
            this.Deselect_devices.TabIndex = 35;
            this.Deselect_devices.Text = "Deselect All";
            this.Deselect_devices.UseVisualStyleBackColor = false;
            this.Deselect_devices.Click += new System.EventHandler(this.Deselect_Meastypes_Click);
            // 
            // MeastypeCheckList
            // 
            this.MeastypeCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeastypeCheckList.FormattingEnabled = true;
            this.MeastypeCheckList.Location = new System.Drawing.Point(32, 68);
            this.MeastypeCheckList.Name = "MeastypeCheckList";
            this.MeastypeCheckList.Size = new System.Drawing.Size(362, 235);
            this.MeastypeCheckList.TabIndex = 0;
            // 
            // AllDevicesbutton
            // 
            this.AllDevicesbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllDevicesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllDevicesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllDevicesbutton.Location = new System.Drawing.Point(32, 39);
            this.AllDevicesbutton.Name = "AllDevicesbutton";
            this.AllDevicesbutton.Size = new System.Drawing.Size(84, 23);
            this.AllDevicesbutton.TabIndex = 34;
            this.AllDevicesbutton.Text = "Select All";
            this.AllDevicesbutton.UseVisualStyleBackColor = false;
            this.AllDevicesbutton.Click += new System.EventHandler(this.AllMeastypesbutton_Click);
            // 
            // AddMeastypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(462, 371);
            this.Controls.Add(this.AddMeastypesgroupbox);
            this.Name = "AddMeastypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Measurement Types";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddMeastypes_FormClosing);
            this.Load += new System.EventHandler(this.AddMeastypes_Load);
            this.AddMeastypesgroupbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddMeastypesgroupbox;
        private System.Windows.Forms.Button Adddevices_button;
        private System.Windows.Forms.Button Deselect_devices;
        private System.Windows.Forms.CheckedListBox MeastypeCheckList;
        private System.Windows.Forms.Button AllDevicesbutton;
    }
}