// ************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:Algorithm.cs
//Inputs:Files inside Model folder
//Output:Output measurements to openECA platform
//*************************************************************************************************************

using System;
using ECAClientFramework;
using ECAClientUtilities.API;
using SSDQopenECA.Model.GPA;
using System.Windows.Forms;

namespace SSDQopenECA
{
    public class Algorithm
    {
        public static Hub API { get; set; }
        public static In_Data InData;
        public static _In_DataMeta InMeta;
        public static Output output;

        public static RecordDataWindow RecordDataWindow = new RecordDataWindow();
        public static Input_screen New_config = new Input_screen();
        public static Input_screen2 Stored_config = new Input_screen2();
        public static Plot Plotwindow = new Plot();

        public class Output
        {
            public Out_Data OutputData = new Out_Data();
            public _Out_DataMeta OutputMeta = new _Out_DataMeta();
            public static Func<Output> CreateNew { get; set; } = () => new Output();
        }

        public static void UpdateSystemSettings()
        {
            SystemSettings.InputMapping = "In_Map";
            SystemSettings.OutputMapping = "Out_Map";
            SystemSettings.ConnectionString = @"server=localhost:6190; interface=0.0.0.0";
            SystemSettings.FramesPerSecond = 30;
            SystemSettings.LagTime = 3;
            SystemSettings.LeadTime = 1;
        }
    
        public static void Check1()
        {
            if (New_config.InvokeRequired)
                New_config.Invoke((MethodInvoker)delegate ()
                {
                    Check1();
                });
            else
            {
                New_config.Update_Measurements();
            }
        }
        public static void Check2()
        {
            if (Stored_config.InvokeRequired)
                Stored_config.Invoke((MethodInvoker)delegate ()
                {
                    Check2();
                });
            else
            {
                Stored_config.Update_Measurements();
            }
        }
        public static void Check3()
        {
            if (Plotwindow.InvokeRequired)
                Plotwindow.Invoke((MethodInvoker)delegate ()
                {
                    Check3();
                });
            else
            {
                Plotwindow.Update_Measurements();
            }
        }
        public static void Check4()
        {
            if (RecordDataWindow.InvokeRequired)
                RecordDataWindow.Invoke((MethodInvoker)delegate ()
                {
                    Check4();
                });
            else
            {
                RecordDataWindow.Update_Measurements();
            }
        }

        public static Output Execute(In_Data inputData, _In_DataMeta inputMeta)
        {
            output = Output.CreateNew();
            InData = inputData;
            InMeta = inputMeta;

            try
            {
                MainWindow.WriteMessage("opeECA Framework created....SSDQ Analytic receiving data");
               
                //Check if New openECA framework creation is selected
                if (New_config.SSDQ_started == true)
                {
                    Algorithm.Check1();
                    for (int i = 0; i < New_config.Num_channels; i++)
                    {
                        output.OutputData.GetType().GetProperty(New_config.Outentrynamelist[i]).SetValue(output.OutputData, New_config.Proc_data_updated[i]);
                    }
                }
                //Check if Load stored openECA framework creation is selected
                if (Stored_config.SSDQ_started == true)
                {
                    Algorithm.Check2();
                    for (int i = 0; i < Stored_config.Num_channels; i++)
                    {
                        output.OutputData.GetType().GetProperty(Stored_config.Outentrynamelist[i]).SetValue(output.OutputData, Stored_config.Proc_data_updated[i]);
                    }
                }
                //Check if Plot button in Plot window is clicked
                if (Plotwindow.Plot_started == true)
                {
                    Algorithm.Check3();
                }
                //Check if Record start button is clicked in Record Data Window
                if (RecordDataWindow.Record_option == true)
                {
                    Algorithm.Check4();
                }             
            }
            catch (Exception ex)
            {
                // Display exceptions to the main window
                MainWindow.WriteError(new InvalidOperationException($"Algorithm exception: {ex.Message}", ex));
            }
            return output;
        }
    }
}
