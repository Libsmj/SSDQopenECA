// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:AddDevices.cs
//Description: This code segment implements the process of updating the devices for the "Load a stored openECA framework" option
//*********************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SSDQopenECA
{
    public partial class AddDevices : Form
    {
        private static List<string> Devicenamelist = new List<string>();
        private static string Database_file;
        private static string constring;

        public static List<string> AddedDevices = new List<string>();      
        public static bool Addbuttonclicked = false;
        public AddDevices()
        {
            InitializeComponent();
        }

        private void AddDevices_Load(object sender, EventArgs e)
        {
            DeviceCheckList.Items.Clear();
            AddedDevices.Clear();
            Addbuttonclicked = false;
            Devicenamelist = Algorithm.SSDQ_config.Devicenamelist_updated;
            Database_file = FrameworkConfiguration.DB_filename;
            constring = "Data Source=" + Database_file;
            SQLiteConnection conDatabase = new SQLiteConnection(constring);
            conDatabase.Open();
            string query_Indevices = "SELECT Acronym FROM DeviceDetail ;";
            SQLiteCommand cmd_Indevices = new SQLiteCommand(query_Indevices, conDatabase);
            SQLiteDataReader reader;
            reader = cmd_Indevices.ExecuteReader();
            while (reader.Read())
            {
                string sSR = reader.GetString(0);
                if (!Devicenamelist.Contains(sSR))
                {
                    DeviceCheckList.Items.Add(sSR);
                }
            }
            reader.Close();
            conDatabase.Close();
        }

        private void AllDevicesbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DeviceCheckList.Items.Count; i++)
            {
                DeviceCheckList.SetItemChecked(i, true);
            }
        }

        private void Deselect_devices_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DeviceCheckList.Items.Count; i++)
            {
                DeviceCheckList.SetItemChecked(i, false);
            }
        }

        private void Adddevices_button_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
            {
                AddedDevices.Add(Convert.ToString(DeviceCheckList.CheckedItems[i]));
                
            }
            Addbuttonclicked = true;
            this.Close();
        }
        private void AddDevices_FormClosing(object sender, FormClosingEventArgs e)
        {
            Addbuttonclicked = true;
        }
    }
}
