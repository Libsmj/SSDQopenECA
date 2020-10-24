namespace SSDQopenECA
{
    partial class FrameworkConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameworkConfiguration));
            this.EPRIpictureBox = new System.Windows.Forms.PictureBox();
            this.Heading = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optionsgroupbox = new System.Windows.Forms.GroupBox();
            this.Newbutton = new System.Windows.Forms.Button();
            this.Presavedbutton = new System.Windows.Forms.Button();
            this.DBSearchbutton = new System.Windows.Forms.Button();
            this.DB_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Helpbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EPRIpictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.optionsgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EPRIpictureBox
            // 
            this.EPRIpictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EPRIpictureBox.BackgroundImage = global::SSDQopenECA.Properties.Resources.EPRI_Logo;
            this.EPRIpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EPRIpictureBox.Location = new System.Drawing.Point(37, 12);
            this.EPRIpictureBox.Name = "EPRIpictureBox";
            this.EPRIpictureBox.Size = new System.Drawing.Size(159, 79);
            this.EPRIpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.EPRIpictureBox.TabIndex = 14;
            this.EPRIpictureBox.TabStop = false;
            // 
            // Heading
            // 
            this.Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Heading.AutoSize = true;
            this.Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.ForeColor = System.Drawing.Color.Navy;
            this.Heading.Location = new System.Drawing.Point(202, 21);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(641, 61);
            this.Heading.TabIndex = 15;
            this.Heading.Text = "SSDQopenECA Interface";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.optionsgroupbox);
            this.groupBox1.Controls.Add(this.DBSearchbutton);
            this.groupBox1.Controls.Add(this.DB_textbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 226);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "openECA Framework Configuration";
            // 
            // optionsgroupbox
            // 
            this.optionsgroupbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.optionsgroupbox.Controls.Add(this.Newbutton);
            this.optionsgroupbox.Controls.Add(this.Presavedbutton);
            this.optionsgroupbox.Location = new System.Drawing.Point(6, 130);
            this.optionsgroupbox.Name = "optionsgroupbox";
            this.optionsgroupbox.Size = new System.Drawing.Size(777, 84);
            this.optionsgroupbox.TabIndex = 5;
            this.optionsgroupbox.TabStop = false;
            this.optionsgroupbox.Text = "Options";
            // 
            // Newbutton
            // 
            this.Newbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Newbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Newbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Newbutton.Location = new System.Drawing.Point(17, 25);
            this.Newbutton.Name = "Newbutton";
            this.Newbutton.Size = new System.Drawing.Size(291, 42);
            this.Newbutton.TabIndex = 2;
            this.Newbutton.Text = "Create New openECA Framework";
            this.Newbutton.UseVisualStyleBackColor = false;
            this.Newbutton.Click += new System.EventHandler(this.Newbutton_Click);
            // 
            // Presavedbutton
            // 
            this.Presavedbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Presavedbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Presavedbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Presavedbutton.Location = new System.Drawing.Point(416, 25);
            this.Presavedbutton.Name = "Presavedbutton";
            this.Presavedbutton.Size = new System.Drawing.Size(330, 42);
            this.Presavedbutton.TabIndex = 3;
            this.Presavedbutton.Text = "Load Pre-saved openECA Framework";
            this.Presavedbutton.UseVisualStyleBackColor = false;
            this.Presavedbutton.Click += new System.EventHandler(this.Presavedbutton_Click);
            // 
            // DBSearchbutton
            // 
            this.DBSearchbutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DBSearchbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DBSearchbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DBSearchbutton.Location = new System.Drawing.Point(711, 70);
            this.DBSearchbutton.Name = "DBSearchbutton";
            this.DBSearchbutton.Size = new System.Drawing.Size(106, 32);
            this.DBSearchbutton.TabIndex = 4;
            this.DBSearchbutton.Text = "Search";
            this.DBSearchbutton.UseVisualStyleBackColor = false;
            this.DBSearchbutton.Click += new System.EventHandler(this.DBSearchbutton_Click);
            // 
            // DB_textbox
            // 
            this.DB_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DB_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB_textbox.Location = new System.Drawing.Point(23, 65);
            this.DB_textbox.Name = "DB_textbox";
            this.DB_textbox.Size = new System.Drawing.Size(660, 26);
            this.DB_textbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select openECA.db Database file";
            // 
            // Helpbutton
            // 
            this.Helpbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Helpbutton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Helpbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Helpbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpbutton.Location = new System.Drawing.Point(801, 95);
            this.Helpbutton.Name = "Helpbutton";
            this.Helpbutton.Size = new System.Drawing.Size(81, 33);
            this.Helpbutton.TabIndex = 17;
            this.Helpbutton.Text = "Help";
            this.Helpbutton.UseVisualStyleBackColor = false;
            this.Helpbutton.Click += new System.EventHandler(this.Helpbutton_Click);
            // 
            // FrameworkConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(922, 362);
            this.Controls.Add(this.Helpbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Heading);
            this.Controls.Add(this.EPRIpictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrameworkConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrameworkConfiguration";
            this.Load += new System.EventHandler(this.FrameworkConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EPRIpictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.optionsgroupbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox EPRIpictureBox;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Presavedbutton;
        private System.Windows.Forms.Button Newbutton;
        private System.Windows.Forms.TextBox DB_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox optionsgroupbox;
        private System.Windows.Forms.Button DBSearchbutton;
        private System.Windows.Forms.Button Helpbutton;
    }
}