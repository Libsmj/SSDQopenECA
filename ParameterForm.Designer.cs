namespace SSDQopenECA
{
    partial class ParameterForm
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
            this.ParameterBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Paramlabel2 = new System.Windows.Forms.Label();
            this.Paramlabel1 = new System.Windows.Forms.Label();
            this.Parameters_Button = new System.Windows.Forms.Button();
            this.BadDatabox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BadDatalabel1 = new System.Windows.Forms.Label();
            this.BadDataEqn_label = new System.Windows.Forms.Label();
            this.BadDatatextBox2 = new System.Windows.Forms.TextBox();
            this.BadDatatextBox1 = new System.Windows.Forms.TextBox();
            this.ParamtextBox4 = new System.Windows.Forms.TextBox();
            this.ParamtextBox3 = new System.Windows.Forms.TextBox();
            this.ParamtextBox2 = new System.Windows.Forms.TextBox();
            this.ParamtextBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ParamtextBox5 = new System.Windows.Forms.TextBox();
            this.ParameterBox.SuspendLayout();
            this.BadDatabox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParameterBox
            // 
            this.ParameterBox.Controls.Add(this.ParamtextBox5);
            this.ParameterBox.Controls.Add(this.label4);
            this.ParameterBox.Controls.Add(this.label2);
            this.ParameterBox.Controls.Add(this.label1);
            this.ParameterBox.Controls.Add(this.Paramlabel2);
            this.ParameterBox.Controls.Add(this.Paramlabel1);
            this.ParameterBox.Controls.Add(this.Parameters_Button);
            this.ParameterBox.Controls.Add(this.BadDatabox);
            this.ParameterBox.Controls.Add(this.ParamtextBox4);
            this.ParameterBox.Controls.Add(this.ParamtextBox3);
            this.ParameterBox.Controls.Add(this.ParamtextBox2);
            this.ParameterBox.Controls.Add(this.ParamtextBox1);
            this.ParameterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterBox.Location = new System.Drawing.Point(12, 12);
            this.ParameterBox.Name = "ParameterBox";
            this.ParameterBox.Size = new System.Drawing.Size(655, 383);
            this.ParameterBox.TabIndex = 9;
            this.ParameterBox.TabStop = false;
            this.ParameterBox.Text = "Parameter Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ratio of approximation errors to distinguish measurements\r\nfrom simultaneous and " +
    "consecutive bad data (suggested range: 2-2.5)\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of observation vectors in each column of the Hankel matrix (k)";
            // 
            // Paramlabel2
            // 
            this.Paramlabel2.AutoSize = true;
            this.Paramlabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paramlabel2.Location = new System.Drawing.Point(18, 66);
            this.Paramlabel2.Name = "Paramlabel2";
            this.Paramlabel2.Size = new System.Drawing.Size(374, 32);
            this.Paramlabel2.TabIndex = 6;
            this.Paramlabel2.Text = "Approximation error threshold to determine the matrix rank (%) \r\n(suggested range" +
    ": 1-5)\r\n";
            // 
            // Paramlabel1
            // 
            this.Paramlabel1.AutoSize = true;
            this.Paramlabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paramlabel1.Location = new System.Drawing.Point(18, 25);
            this.Paramlabel1.Name = "Paramlabel1";
            this.Paramlabel1.Size = new System.Drawing.Size(207, 16);
            this.Paramlabel1.TabIndex = 5;
            this.Paramlabel1.Text = "Length of the moving data window";
            // 
            // Parameters_Button
            // 
            this.Parameters_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Parameters_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Parameters_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parameters_Button.Location = new System.Drawing.Point(287, 328);
            this.Parameters_Button.Name = "Parameters_Button";
            this.Parameters_Button.Size = new System.Drawing.Size(82, 35);
            this.Parameters_Button.TabIndex = 3;
            this.Parameters_Button.Text = "OK";
            this.Parameters_Button.UseVisualStyleBackColor = false;
            this.Parameters_Button.Click += new System.EventHandler(this.Parameters_Button_Click);
            // 
            // BadDatabox
            // 
            this.BadDatabox.Controls.Add(this.label3);
            this.BadDatabox.Controls.Add(this.BadDatalabel1);
            this.BadDatabox.Controls.Add(this.BadDataEqn_label);
            this.BadDatabox.Controls.Add(this.BadDatatextBox2);
            this.BadDatabox.Controls.Add(this.BadDatatextBox1);
            this.BadDatabox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BadDatabox.Location = new System.Drawing.Point(21, 218);
            this.BadDatabox.Name = "BadDatabox";
            this.BadDatabox.Size = new System.Drawing.Size(567, 95);
            this.BadDatabox.TabIndex = 4;
            this.BadDatabox.TabStop = false;
            this.BadDatabox.Text = "Bad Data Detection Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value of \'b\' (10-40)";
            // 
            // BadDatalabel1
            // 
            this.BadDatalabel1.AutoSize = true;
            this.BadDatalabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BadDatalabel1.Location = new System.Drawing.Point(5, 69);
            this.BadDatalabel1.Name = "BadDatalabel1";
            this.BadDatalabel1.Size = new System.Drawing.Size(110, 16);
            this.BadDatalabel1.TabIndex = 4;
            this.BadDatalabel1.Text = "Value of \'a\' (2-10)";
            // 
            // BadDataEqn_label
            // 
            this.BadDataEqn_label.AutoSize = true;
            this.BadDataEqn_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BadDataEqn_label.Location = new System.Drawing.Point(98, 29);
            this.BadDataEqn_label.Name = "BadDataEqn_label";
            this.BadDataEqn_label.Size = new System.Drawing.Size(366, 16);
            this.BadDataEqn_label.TabIndex = 3;
            this.BadDataEqn_label.Text = "Time-varying Threshold: f(t)=min{a, b*exp(-tdiff*0.6)}\r\n";
            // 
            // BadDatatextBox2
            // 
            this.BadDatatextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BadDatatextBox2.Location = new System.Drawing.Point(444, 66);
            this.BadDatatextBox2.Multiline = true;
            this.BadDatatextBox2.Name = "BadDatatextBox2";
            this.BadDatatextBox2.Size = new System.Drawing.Size(96, 23);
            this.BadDatatextBox2.TabIndex = 2;
            // 
            // BadDatatextBox1
            // 
            this.BadDatatextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BadDatatextBox1.Location = new System.Drawing.Point(134, 66);
            this.BadDatatextBox1.Multiline = true;
            this.BadDatatextBox1.Name = "BadDatatextBox1";
            this.BadDatatextBox1.Size = new System.Drawing.Size(84, 23);
            this.BadDatatextBox1.TabIndex = 1;
            // 
            // ParamtextBox4
            // 
            this.ParamtextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamtextBox4.Location = new System.Drawing.Point(499, 142);
            this.ParamtextBox4.Multiline = true;
            this.ParamtextBox4.Name = "ParamtextBox4";
            this.ParamtextBox4.Size = new System.Drawing.Size(84, 32);
            this.ParamtextBox4.TabIndex = 3;
            // 
            // ParamtextBox3
            // 
            this.ParamtextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamtextBox3.Location = new System.Drawing.Point(499, 106);
            this.ParamtextBox3.Multiline = true;
            this.ParamtextBox3.Name = "ParamtextBox3";
            this.ParamtextBox3.Size = new System.Drawing.Size(84, 30);
            this.ParamtextBox3.TabIndex = 2;
            this.ParamtextBox3.Text = "\r\n";
            // 
            // ParamtextBox2
            // 
            this.ParamtextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamtextBox2.Location = new System.Drawing.Point(499, 66);
            this.ParamtextBox2.Multiline = true;
            this.ParamtextBox2.Name = "ParamtextBox2";
            this.ParamtextBox2.Size = new System.Drawing.Size(84, 30);
            this.ParamtextBox2.TabIndex = 1;
            // 
            // ParamtextBox1
            // 
            this.ParamtextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamtextBox1.Location = new System.Drawing.Point(499, 25);
            this.ParamtextBox1.Multiline = true;
            this.ParamtextBox1.Name = "ParamtextBox1";
            this.ParamtextBox1.Size = new System.Drawing.Size(84, 31);
            this.ParamtextBox1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Period of periodic subspace estimation";
            // 
            // ParamtextBox5
            // 
            this.ParamtextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamtextBox5.Location = new System.Drawing.Point(499, 180);
            this.ParamtextBox5.Multiline = true;
            this.ParamtextBox5.Name = "ParamtextBox5";
            this.ParamtextBox5.Size = new System.Drawing.Size(84, 32);
            this.ParamtextBox5.TabIndex = 10;
            // 
            // ParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(674, 413);
            this.Controls.Add(this.ParameterBox);
            this.Name = "ParameterForm";
            this.Text = "Parameter Settings";
            this.Load += new System.EventHandler(this.ParameterForm_Load);
            this.ParameterBox.ResumeLayout(false);
            this.ParameterBox.PerformLayout();
            this.BadDatabox.ResumeLayout(false);
            this.BadDatabox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ParameterBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Paramlabel2;
        private System.Windows.Forms.Label Paramlabel1;
        private System.Windows.Forms.Button Parameters_Button;
        private System.Windows.Forms.GroupBox BadDatabox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BadDatalabel1;
        private System.Windows.Forms.Label BadDataEqn_label;
        private System.Windows.Forms.TextBox BadDatatextBox2;
        private System.Windows.Forms.TextBox BadDatatextBox1;
        private System.Windows.Forms.TextBox ParamtextBox4;
        private System.Windows.Forms.TextBox ParamtextBox3;
        private System.Windows.Forms.TextBox ParamtextBox2;
        private System.Windows.Forms.TextBox ParamtextBox1;
        private System.Windows.Forms.TextBox ParamtextBox5;
        private System.Windows.Forms.Label label4;
    }
}