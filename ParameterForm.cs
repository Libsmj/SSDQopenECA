// ************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:ParameterForm.cs
//Description:This code segment enables the user to modify the otherwise default values of the parameters required
//for SSDQ algorithm
//Inputs:User provided values
//Output:Parameters used in the HankelProcess.cs
//*************************************************************************************************************
using System;
using System.Windows.Forms;
using ECAClientFramework;

namespace SSDQopenECA
{
    public partial class ParameterForm : Form
    {
        //Refer HankelProcess.cs for individual variable description
        public static int       L = 10;
        public static double    ea = 2;
        public static int       k = 6;
        public static double    n = 1.2;
        public static double    a = 6;
        public static double    b = 30;
        public static int       r = 600;

        public static bool paramsavailable = false;

        public ParameterForm()
        {
            InitializeComponent();
        }

        private void ParameterForm_Load(object sender, EventArgs e)
        {
            //Show Default values for user
            ParamtextBox1.Text = Convert.ToString(L);
            ParamtextBox2.Text = Convert.ToString(ea);
            ParamtextBox3.Text = Convert.ToString(k);
            ParamtextBox4.Text = Convert.ToString(n);
            ParamtextBox5.Text = Convert.ToString(r / SystemSettings.FramesPerSecond);
            BadDatatextBox1.Text = Convert.ToString(a);
            BadDatatextBox2.Text = Convert.ToString(b);
        }
        private void Parameters_Button_Click(object sender, EventArgs e)
        {
            try
            {
                L = Convert.ToInt32(ParamtextBox1.Text);
                ea = Convert.ToDouble(ParamtextBox2.Text);
                k = Convert.ToInt32(ParamtextBox3.Text);
                n = Convert.ToDouble(ParamtextBox4.Text);
                r = Convert.ToInt32(Convert.ToDouble(ParamtextBox5.Text) * SystemSettings.FramesPerSecond);
                a = Convert.ToDouble(BadDatatextBox1.Text);
                b = Convert.ToDouble(BadDatatextBox2.Text);
                paramsavailable = true;
                this.Close();
                MessageBox.Show(Convert.ToString(L));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information");
            }

        }
    }
}
