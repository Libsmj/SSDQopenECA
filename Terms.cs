// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:Terms.cs
//Description: This code segment depicts the Start page of the Application.
//*********************************************************************************************************************
using System;
using System.Threading;
using System.Windows.Forms;

namespace SSDQopenECA
{
    public partial class Terms : Form
    {
        public Terms()
        {
            InitializeComponent();
        }

        private void Terms_Load(object sender, EventArgs e)
        {
            //Load the form with the text as shown below
            label1.Text = " Streaming Synchrophasor Data Quality (SSDQ) openECA Version 1.0 \n Electric Power Research Institute (EPRI) \n 3420 Hillview Ave. \n Palo Alto,CA 94304";
            label2.Text = " Copyright © 2019 Electric Power Research Institute, Inc. All rights reserved.";
            label3.Text = " As a user of this EPRI preproduction software, you accept and acknowledge that: \n" +
                "\u2022 This software is a preproduction version which may have problems that could potentially harm your system. \n" +
                "\u2022 To satisfy the terms and conditions of the Master License Agreement or Preproduction License Agreement between EPRI and your company, you \n" +
                "   understand what to do with this preproduction product after the preproduction review period has expired. \n" +
                "\u2022 Reproduction or distribution of this preproduction software is in violation of the terms and conditions of the Master License Agreement or the \n" +
                "   Preproduction License Agreement currently in place between EPRI and your company. \n" +
                "\u2022 Your company's funding will determine if you have the rights to the final production release of this product. \n" +
                "\u2022 EPRI will evaluate all tester suggestions and recommendations, but does not guarantee they will be incorporated into the final production product. \n" +
                "\u2022 As a preproduction tester, you agree to provide feedback as a condition of obtaining the preproduction software.";
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            //Upon clicking Accept button the following thread is initiated
            Thread DB_entry_thread = new Thread(ThreadStart_for_DB_entrywindow);
            DB_entry_thread.TrySetApartmentState(ApartmentState.STA);
            DB_entry_thread.Start();
            this.Close();
            
        }
        private void ThreadStart_for_DB_entrywindow()
        {
            // An object of the FrameworkConfiguration class is instantiated and executed.
            FrameworkConfiguration frameworkConfiguration = new FrameworkConfiguration();
            Application.Run(frameworkConfiguration);
            
        }

        private void Decline_Click(object sender, EventArgs e)
        {
            //The form closes if Decline button is clicked
            this.Close();
        }
    }
}
