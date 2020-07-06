// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:Program.cs
//Description: This is the main entry point for the application by starting the thread which runs the "Terms.cs" class.
//*********************************************************************************************************************
using System;
using System.Windows.Forms;

namespace SSDQopenECA
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Terms Terms = new Terms();  
            Application.Run(Terms);     //Execute the Terms class
        }
    }
}
