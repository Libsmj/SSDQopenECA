// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:AddMeastypes.cs
//Description: This code segment implements the process of updating the measurement types for the "Load a stored openECA framework" option
//*********************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SSDQopenECA
{
    public partial class AddMeastypes : Form
    {
        private static List<string> Devicenamelist = new List<string>();
        private static string Database_file;
        private static string constring;
        private readonly static List<string> MeasTypelist = new List<string>();

        public static List<string> SignalTypelist = new List<string>();
        public static List<string> AddedMeastypes = new List<string>();       
        public static bool Addbuttonclicked = false;        
        public static List<string> Meastypelist_updated = new List<string>();
        public AddMeastypes()
        {
            InitializeComponent();
        }

       
        private void AddMeastypes_Load(object sender, EventArgs e)
        {
            MeastypeCheckList.Items.Clear();
            AddedMeastypes.Clear();
            Addbuttonclicked = false;
            Devicenamelist = Algorithm.Stored_config.Devicenamelist_updated;
            SignalTypelist = Algorithm.Stored_config.SignalTypelist;
            Database_file = FrameworkConfiguration.DB_filename;
            constring = "Data Source=" + Database_file;
            SQLiteConnection conDatabase = new SQLiteConnection(constring);
            conDatabase.Open();
            
            if (Devicenamelist.Count == 0)
            {
                MessageBox.Show("Select Input Devices", "Missing Information");
            }
            else
            {
                MeasTypelist.Clear();
                Meastypelist_updated.Clear();
                for (int i = 0; i < Devicenamelist.Count; i++)
                {
                    string query_Meastype = "SELECT SignalType FROM ActiveMeasurement WHERE Device=" + "'" + Convert.ToString(Devicenamelist[i]) + "' ; ";
                    SQLiteCommand cmd_Meastype = new SQLiteCommand(query_Meastype, conDatabase);
                    SQLiteDataReader reader;
                    reader = cmd_Meastype.ExecuteReader();
                    while (reader.Read())
                    {
                        string sSR = reader.GetString(0);
                        if (!MeasTypelist.Contains(sSR))
                        {
                            MeasTypelist.Add(sSR);
                        }
                    }
                    reader.Close();
                }
                conDatabase.Close();
                if (MeasTypelist.Count == 0)
                {
                    MessageBox.Show("The selected devices do not contain channels of the available measurement types", "Error Information");
                }
                if (MeasTypelist.Contains("VPHM"))
                {
                    MeastypeCheckList.Items.Add("Voltage Magnitude");
                    Meastypelist_updated.Add("Voltage Magnitude");
                }
                if (MeasTypelist.Contains("VPHA"))
                {
                    MeastypeCheckList.Items.Add("Voltage Angle");
                    Meastypelist_updated.Add("Voltage Angle");

                }
                if (MeasTypelist.Contains("IPHM"))
                {
                    MeastypeCheckList.Items.Add("Current Magnitude");
                    Meastypelist_updated.Add("Current Magnitude");
                }
                if (MeasTypelist.Contains("IPHA"))
                {
                    MeastypeCheckList.Items.Add("Current Angle");
                    Meastypelist_updated.Add("Current Angle");
                }
                if (MeasTypelist.Contains("FREQ"))
                {
                    MeastypeCheckList.Items.Add("Frequency");
                    Meastypelist_updated.Add("Frequency");
                }
                
            }
        }
        private void AllMeastypesbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MeastypeCheckList.Items.Count; i++)
            {
                MeastypeCheckList.SetItemChecked(i, true);
            }
        }

        private void Deselect_Meastypes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MeastypeCheckList.Items.Count; i++)
            {
                MeastypeCheckList.SetItemChecked(i, false);
            }
        }

        private void AddMeastypes_button_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < MeastypeCheckList.CheckedItems.Count; i++)
            {
                AddedMeastypes.Add(Convert.ToString(MeastypeCheckList.CheckedItems[i]));

            }
            Addbuttonclicked = true;
            this.Close();
        }
        private void AddMeastypes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Addbuttonclicked = true;
        }
    }
}
