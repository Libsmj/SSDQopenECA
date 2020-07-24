// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:Input_screen2.cs
//Description: This Code segment refers to the similar functionalities as Input_screen.cs form with some added features
// required for loading a stored openECA framework and updating it.Refer to the Input_scrren.cs for details.
//*********************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using ECACommonUtilities;
using ECACommonUtilities.Model;
using ECAClientFramework;
using ECAClientUtilities.API;
using System.Data.SQLite;
using HankelRobustDataEstimation;
using MathNet.Numerics.LinearAlgebra;
using System.Text;

namespace SSDQopenECA
{
    public partial class Input_screen2 : Form
    {
        //Private Fields
        private int InitialPIDCount;
        private int OriginalPIDCount;

        private HankelProcess[] hankelProcess = new HankelProcess[5];
        private HankelProcessComplex[] hankelProcessComplex = new HankelProcessComplex[2];
        private bool[] complexOperations = new bool[3];

        private List<int> MeasType = new List<int>();   //Int Values - Only to get the signaltypeID for checked Input channels from input channel list for assigning to output channels creation before framework creation
        private List<int> Meas = new List<int>();       //Int Values - Only get the condensed form of types of SignalTypeID present in the framework after framework creation.
        private int[] MeasNum = new int[5];             //Int Values - Gets the index of a SingalTypeID after initialization

        private string Framework_filename = "";
        private string Database_file = "";
        private string constring;
        private List<int> Eachtypechannelnum = new List<int>();
        private bool Insufficientchannels = true;
        public int numberOfFrame;
        private List<string> SignalReflist = new List<string>();
        private List<string> SignalIDlist = new List<string>();
        private List<string> CSVhead = new List<string>();
        private List<string> CSVdata = new List<string>();
        private StreamWriter stream;
        private StringBuilder sb = new StringBuilder();
        private string strSeperator = ",";
        private bool Frameworkcreatedonce = false;
        private List<string> Totaldevicenamelist = new List<string>();
        private List<string> ActiveDevicenamelist = new List<string>();
        private bool Input_Output_mismatch = false;
        private List<string> UncheckedItems = new List<string>();
        private List<string> Unavailablemeastypes = new List<string>();
        private int count = 0;
        private Vector<double>[] data_observed_initial = new Vector<double>[5];
        private Vector<double>[] Proc_data;
        private int wdsize = 0;
        private List<string> IndataIDlist = new List<string>();
        private List<string> OutdataIDlist = new List<string>();
        private List<Int32> OutDeviceIDlist = new List<Int32>();
        private List<string> OPchannelnamelist = new List<string>();

        //Public Fields
        public List<string> Inentrynamelist = new List<string>();
        public List<string> Outentrynamelist = new List<string>();
        public List<string> Indatatypelist = new List<string>();
        public List<string> Indatareflist = new List<string>();
        public List<string> Indatadevicelist = new List<string>();
        public List<string> MeasTypelist = new List<string>();
        public double Num_channels;
        public List<string> Devicenamelist = new List<string>();
        public List<string> Devicenamelist_updated = new List<string>();
        public List<string> Meastypelist_updated = new List<string>();
        public List<string> SignalTypelist = new List<string>();
        public List<string>[] Inentrynamelist_updated = new List<string>[5];
        public List<string>[] IPchannelnamelist_updated = new List<string>[5];
        public List<int> NumChannelList = new List<int>();
        public bool SSDQ_started = false;
        public Thread MainWindow_thread = new Thread(ThreadStart_for_main_window);
        public List<double> Proc_data_updated = new List<double>();

        public Matrix<double>[] submatrixData = new Matrix<double>[5];
        private Matrix<double>[][] submatrixDataComplex = new Matrix<double>[2][];
        private Vector<double>[][] complexMeasurments = new Vector<double>[2][];

        public Matrix<double> submatrixStacked;
        public string Channelnameprefix;

        public Input_screen2()
        {
            InitializeComponent();
        }

        private void Input_screen2_Load(object sender, EventArgs e)
        {
            try
            {
                Totaldevicenamelist.Clear();
                ActiveDevicenamelist.Clear();

                Savegroupbox.Enabled = false;
                Database_file = FrameworkConfiguration.DB_filename;
                StoredMeasurementBox.Enabled = false;
                SSDQactionBox.Enabled = false;
                Frameworkcreatedonce = false;

                constring = "Data Source=" + Database_file;
                SQLiteConnection conDatabase = new SQLiteConnection(constring);
                conDatabase.Open();

                //string query_rowcount = "SELECT COUNT (*) FROM Measurement";
                //SQLiteCommand cmd_rowcount = new SQLiteCommand(query_rowcount, conDatabase);
                //InitialPIDCount = Convert.ToInt32(cmd_rowcount.ExecuteScalar());

                //Get initial MAX PointID in database
                string query_rowcount = "SELECT MAX(PointID) FROM Measurement";
                SQLiteCommand cmd_rowcount = new SQLiteCommand(query_rowcount, conDatabase);
                OriginalPIDCount = Convert.ToInt32(cmd_rowcount.ExecuteScalar());
                InitialPIDCount = OriginalPIDCount;
                string query_Totaldevices = "SELECT Acronym FROM DeviceDetail WHERE Category!='Gateway';";
                SQLiteCommand cmd_Totaldevices = new SQLiteCommand(query_Totaldevices, conDatabase);
                SQLiteDataReader reader;
                reader = cmd_Totaldevices.ExecuteReader();
                while (reader.Read())
                {
                    string sSR = reader.GetString(0);
                    if (!Totaldevicenamelist.Contains(sSR))
                    {
                        Totaldevicenamelist.Add(sSR);
                    }

                }
                reader.Close();
                string query_activedevices = "SELECT Device FROM ActiveMeasurement WHERE SignalType!='STAT' AND Protocol!='GatewayTransport' ;";
                SQLiteCommand cmd_activedevices = new SQLiteCommand(query_activedevices, conDatabase);
                reader = cmd_activedevices.ExecuteReader();
                while (reader.Read())
                {
                    string sSR = reader.GetString(0);
                    if (!ActiveDevicenamelist.Contains(sSR))
                    {
                        ActiveDevicenamelist.Add(sSR);
                    }
                }
                for (int i = 0; i < Totaldevicenamelist.Count; i++)
                {
                    if (!ActiveDevicenamelist.Contains(Totaldevicenamelist[i]))
                    {
                        OutputDevice_combobox.Items.Add(Totaldevicenamelist[i]);
                    }
                }
                reader.Close();
                conDatabase.Close();
                OutputDevice_combobox.Items.Add("Same Device Allocation");
                Channelnameprefix = "SSDQ_";
                CSVhead.Clear();
                CSVhead.Add("Device");
                CSVhead.Add("Input Measurement Channel Signal Reference");
                CSVhead.Add("Input Measurement Channel Signal ID");
                CSVhead.Add("Input Measurement Channel SignalType ID");
            }
            catch
            {
                MessageBox.Show("Wrong Database file selected. Choose the appropriate openECA.db database file in the installed directory. ", "Error Information");
                this.Close();
            }

        }

        private void SearchFrameworkbutton_Click(object sender, EventArgs e)
        {

            try
            {
                var FD = new System.Windows.Forms.OpenFileDialog();
                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Open and read the contents of the saved framework (.csv) file
                    Framework_LocationBox.Text = FD.FileName;
                    Framework_filename = Framework_LocationBox.Text;
                    Devicenamelist.Clear();
                    SignalReflist.Clear();
                    SignalIDlist.Clear();
                    SignalTypelist.Clear();
                    using (var rd = new StreamReader(Framework_filename))
                    {
                        while (!rd.EndOfStream)
                        {
                            var splits = rd.ReadLine().Split(',');
                            if ((splits[0] != "") && (splits[1] != "") && (splits[2] != "") && (splits[3] != ""))
                            {
                                Devicenamelist.Add(splits[0]);
                                SignalReflist.Add(splits[1]);
                                SignalIDlist.Add(splits[2]);
                                SignalTypelist.Add(splits[3]);
                            }

                        }
                    }
                    if (Devicenamelist[0] == "Device" && SignalReflist[0] == "Input Measurement Channel Signal Reference" && SignalIDlist[0] == "Input Measurement Channel Signal ID" && SignalTypelist[0] == "Input Measurement Channel SignalType ID")
                    {
                        MessageBox.Show("Retrieving Data from the stored openECA configuration.", "Information");
                        Populatedata();
                        StoredMeasurementBox.Enabled = true;
                    }
                    else
                    {
                        //StoredMeasurementBox.Enabled = false;
                        MessageBox.Show("Wrong framework file selected. Choose the appropriate framework (.csv) file for proper execution. ", "Error Information");
                    }

                }

            }
            catch
            {
                MessageBox.Show("Wrong framework file selected. Choose the appropriate framework (.csv) file for proper execution. ", "Error Information");
            }
        }

        private void Populatedata()
        {
            DeviceCheckList.Items.Clear();
            InputChannelList.Items.Clear();
            MeasTypecheckList.Items.Clear();
            OutputDevice_combobox.Text = "";

            for (int i = 1; i < Devicenamelist.Count; i++)
            {
                if (!DeviceCheckList.Items.Contains(Devicenamelist[i]))
                {
                    DeviceCheckList.Items.Add(Devicenamelist[i]);
                }
                InputChannelList.Items.Add(SignalReflist[i]);
                InputChannelList.SetItemChecked(i - 1, true);

                if (SignalTypelist[i] == "VPHM" && !MeasTypecheckList.Items.Contains("Voltage Magnitude"))
                {
                    MeasTypecheckList.Items.Add("Voltage Magnitude");
                }
                if (SignalTypelist[i] == "VPHA" && !MeasTypecheckList.Items.Contains("Voltage Angle"))
                {
                    MeasTypecheckList.Items.Add("Voltage Angle");
                }
                if (SignalTypelist[i] == "IPHM" && !MeasTypecheckList.Items.Contains("Current Magnitude"))
                {
                    MeasTypecheckList.Items.Add("Current Magnitude");
                }
                if (SignalTypelist[i] == "IPHA" && !MeasTypecheckList.Items.Contains("Current Angle"))
                {
                    MeasTypecheckList.Items.Add("Current Angle");
                }
                if (SignalTypelist[i] == "FREQ" && !MeasTypecheckList.Items.Contains("Frequency"))
                {
                    MeasTypecheckList.Items.Add("Frequency");
                }
            }

            for (int i = 0; i < DeviceCheckList.Items.Count; i++)
            {
                DeviceCheckList.SetItemChecked(i, true);
            }

            for (int i = 0; i < MeasTypecheckList.Items.Count; i++)
            {
                MeasTypecheckList.SetItemChecked(i, true);
            }
            FillOutputCheckListBox();
        }

        private void Adddevices_button_Click(object sender, EventArgs e)
        {

            Devicenamelist_updated.Clear();
            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
            {
                Devicenamelist_updated.Add(Convert.ToString(DeviceCheckList.CheckedItems[i]));
            }

            UncheckedItems.Clear();
            for (int i = 0; i < DeviceCheckList.Items.Count; i++)
            {
                if (!DeviceCheckList.GetItemChecked(i))
                {
                    UncheckedItems.Add(Convert.ToString(DeviceCheckList.Items[i]));

                }
            }
            for (int i = 0; i < UncheckedItems.Count; i++)
            {
                DeviceCheckList.Items.Remove(UncheckedItems[i]);
            }



            AddDevices.Addbuttonclicked = false;
            var AddDevicesWindow_thread = new Thread(ThreadStart_for_AddDevicesWindow);
            AddDevicesWindow_thread.TrySetApartmentState(ApartmentState.STA);
            AddDevicesWindow_thread.Start();
            while (AddDevices.Addbuttonclicked == false)
            {

            }
            if (AddDevices.AddedDevices.Count != 0)
            {
                for (int i = 0; i < AddDevices.AddedDevices.Count; i++)
                {
                    if (!DeviceCheckList.Items.Contains(AddDevices.AddedDevices[i]))
                    {
                        DeviceCheckList.Items.Add(AddDevices.AddedDevices[i]);
                    }

                }
                for (int i = 0; i < DeviceCheckList.Items.Count; i++)
                {
                    DeviceCheckList.SetItemChecked(i, true);

                }
            }

        }

        private static void ThreadStart_for_AddDevicesWindow()
        {
            AddDevices AddDevices = new AddDevices();
            Application.Run(AddDevices);
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

        private void Addmeastypes_button_Click(object sender, EventArgs e)
        {
            Devicenamelist_updated.Clear();
            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
            {
                Devicenamelist_updated.Add(Convert.ToString(DeviceCheckList.CheckedItems[i]));
            }

            UncheckedItems.Clear();
            for (int i = 0; i < MeasTypecheckList.Items.Count; i++)
            {
                if (!MeasTypecheckList.GetItemChecked(i))
                {
                    UncheckedItems.Add(Convert.ToString(MeasTypecheckList.Items[i]));

                }
            }
            for (int i = 0; i < UncheckedItems.Count; i++)
            {
                MeasTypecheckList.Items.Remove(UncheckedItems[i]);
            }

            AddMeastypes.Addbuttonclicked = false;


            var AddMeastypeWindow_thread = new Thread(ThreadStart_for_AddMeastypeWindow);
            AddMeastypeWindow_thread.TrySetApartmentState(ApartmentState.STA);
            AddMeastypeWindow_thread.Start();
            while (AddMeastypes.Addbuttonclicked == false)
            {

            }
            Unavailablemeastypes.Clear();
            for (int i = 0; i < MeasTypecheckList.Items.Count; i++)
            {
                if (!AddMeastypes.Meastypelist_updated.Contains(MeasTypecheckList.Items[i]))
                {
                    Unavailablemeastypes.Add(Convert.ToString(MeasTypecheckList.Items[i]));

                }
            }
            for (int i = 0; i < Unavailablemeastypes.Count; i++)
            {
                MeasTypecheckList.Items.Remove(Unavailablemeastypes[i]);
            }


            if (AddMeastypes.AddedMeastypes.Count != 0)
            {
                for (int i = 0; i < AddMeastypes.AddedMeastypes.Count; i++)
                {
                    if (!MeasTypecheckList.Items.Contains(AddMeastypes.AddedMeastypes[i]))
                    {
                        MeasTypecheckList.Items.Add(AddMeastypes.AddedMeastypes[i]);
                    }
                }
                for (int i = 0; i < MeasTypecheckList.Items.Count; i++)
                {
                    MeasTypecheckList.SetItemChecked(i, true);
                }
            }

        }

        private static void ThreadStart_for_AddMeastypeWindow()
        {
            AddMeastypes AddMeastypes = new AddMeastypes();
            Application.Run(AddMeastypes);
        }

        private void SelectAllTypes_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MeasTypecheckList.Items.Count; i++)
            {
                MeasTypecheckList.SetItemChecked(i, false);
            }
        }

        private void DeselectTypes_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MeasTypecheckList.Items.Count; i++)
            {
                MeasTypecheckList.SetItemChecked(i, false);
            }
        }

        private void RefreshChannelsbutton_Click(object sender, EventArgs e)
        {

            InputChannelList.Items.Clear();
            FillInputCheckListBox();
        }

        private void FillInputCheckListBox()
        {
            try
            {
                //SQLConnection, SQLDataReader and SQLCommand instead of following if SQL database is used instead of SQLite
                SQLiteConnection conDatabase = new SQLiteConnection(constring);
                SQLiteDataReader reader;
                conDatabase.Open();
                if (DeviceCheckList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Select Input Device", "Missing Information");
                }
                else
                {
                    if (MeasTypecheckList.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Select Measurement Type", "Missing Information");
                    }
                    else
                    {

                        if (MeasTypecheckList.CheckedItems.Contains("Current Magnitude"))
                        {
                            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
                            {
                                string query_Imag = "SELECT SignalReference FROM ActiveMeasurement WHERE SignalType='IPHM' AND Device=" + "'" + Convert.ToString(DeviceCheckList.CheckedItems[i]) + "' ; ";
                                SQLiteCommand cmd_Imag = new SQLiteCommand(query_Imag, conDatabase);
                                reader = cmd_Imag.ExecuteReader();
                                while (reader.Read())
                                {
                                    string sSR = reader.GetString(0);
                                    if (!OutputChannelList.Items.Contains(sSR))
                                    {
                                        InputChannelList.Items.Add(sSR);

                                    }

                                }
                            }


                        }
                        if (MeasTypecheckList.CheckedItems.Contains("Current Angle"))
                        {
                            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
                            {
                                string query_Iang = "SELECT SignalReference FROM ActiveMeasurement WHERE SignalType='IPHA' AND Device=" + "'" + Convert.ToString(DeviceCheckList.CheckedItems[i]) + "' ; ";
                                SQLiteCommand cmd_Iang = new SQLiteCommand(query_Iang, conDatabase);
                                reader = cmd_Iang.ExecuteReader();
                                while (reader.Read())
                                {
                                    string sSR = reader.GetString(0);
                                    if (!OutputChannelList.Items.Contains(sSR))
                                    {
                                        InputChannelList.Items.Add(sSR);

                                    }

                                }
                            }

                        }
                        if (MeasTypecheckList.CheckedItems.Contains("Voltage Magnitude"))
                        {
                            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
                            {
                                string query_Vmag = "SELECT SignalReference FROM ActiveMeasurement WHERE SignalType='VPHM' AND Device=" + "'" + Convert.ToString(DeviceCheckList.CheckedItems[i]) + "' ; ";
                                SQLiteCommand cmd_Vmag = new SQLiteCommand(query_Vmag, conDatabase);
                                reader = cmd_Vmag.ExecuteReader();
                                while (reader.Read())
                                {
                                    string sSR = reader.GetString(0);
                                    if (!OutputChannelList.Items.Contains(sSR))
                                    {
                                        InputChannelList.Items.Add(sSR);

                                    }

                                }
                            }


                        }
                        if (MeasTypecheckList.CheckedItems.Contains("Voltage Angle"))
                        {
                            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
                            {
                                string query_Vang = "SELECT SignalReference FROM ActiveMeasurement WHERE SignalType='VPHA' AND Device=" + "'" + Convert.ToString(DeviceCheckList.CheckedItems[i]) + "' ; ";
                                SQLiteCommand cmd_Vang = new SQLiteCommand(query_Vang, conDatabase);
                                reader = cmd_Vang.ExecuteReader();
                                while (reader.Read())
                                {
                                    string sSR = reader.GetString(0);
                                    if (!OutputChannelList.Items.Contains(sSR))
                                    {
                                        InputChannelList.Items.Add(sSR);

                                    }
                                }
                            }

                        }

                        if (MeasTypecheckList.CheckedItems.Contains("Frequency"))
                        {
                            for (int i = 0; i < DeviceCheckList.CheckedItems.Count; i++)
                            {
                                string query_freq = "SELECT SignalReference FROM ActiveMeasurement WHERE SignalType='FREQ' AND Device=" + "'" + Convert.ToString(DeviceCheckList.CheckedItems[i]) + "' ; ";
                                SQLiteCommand cmd_freq = new SQLiteCommand(query_freq, conDatabase);
                                reader = cmd_freq.ExecuteReader();
                                while (reader.Read())
                                {
                                    string sSR = reader.GetString(0);
                                    if (!OutputChannelList.Items.Contains(sSR))
                                    {
                                        InputChannelList.Items.Add(sSR);

                                    }

                                }
                            }

                        }

                    }
                }
                conDatabase.Close();
                for (int i = 0; i < InputChannelList.Items.Count; i++)
                {
                    if (SignalReflist.Contains(InputChannelList.Items[i]))
                    {
                        InputChannelList.SetItemChecked(i, true);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void AllMeasbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < InputChannelList.Items.Count; i++)
            {
                InputChannelList.SetItemChecked(i, true);
            }
        }

        private void Deselect_IPchannels_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < InputChannelList.Items.Count; i++)
            {
                InputChannelList.SetItemChecked(i, false);
            }
        }

        private void UpdateChannels_Click(object sender, EventArgs e)
        {

            FillOutputCheckListBox();
        }

        private void FillOutputCheckListBox()
        {
            Meas.Clear();
            OutDeviceIDlist.Clear();
            MeasType.Clear();
            OutputChannelList.Items.Clear();
            //IPchannelnamelist.Clear();
            OPchannelnamelist.Clear();
            OutputDevice_combobox.BackColor = default;


            SQLiteConnection conDatabase = new SQLiteConnection(constring);
            conDatabase.Open();

            ////Get initial number of Rows in database
            //string query_rowcount = "SELECT COUNT (*) FROM Measurement";
            //SQLiteCommand cmd_rowcount = new SQLiteCommand(query_rowcount, conDatabase);
            //int CurrRowCount = Convert.ToInt32(cmd_rowcount.ExecuteScalar());




            //string query_Totalmeas = "SELECT SignalReference FROM Measurement";
            //SQLiteCommand cmd_Totalmeas = new SQLiteCommand(query_Totalmeas, conDatabase);
            //SQLiteDataReader reader1;
            //reader1 = cmd_Totalmeas.ExecuteReader();
            //while (reader1.Read())
            //{
            //    string query_delete = String.Format("DELETE FROM Measurement WHERE SignalReference LIKE '%SSDQ_%' ESCAPE'_'");
            //    SQLiteCommand cmd_delete = new SQLiteCommand(query_delete, conDatabase);
            //    cmd_delete.ExecuteNonQuery();

            //}
            //reader1.Close();




            //Get current MAX PointID in database
            string query_pidcount = "SELECT MAX(PointID) FROM Measurement";
            SQLiteCommand cmd_pidcount = new SQLiteCommand(query_pidcount, conDatabase);
            int PIDcount = Convert.ToInt32(cmd_pidcount.ExecuteScalar());

            if (PIDcount > OriginalPIDCount)
            {
                string query_delete = String.Format("DELETE FROM Measurement WHERE PointID > '{0}'", Convert.ToString(InitialPIDCount));
                SQLiteCommand cmd_delete = new SQLiteCommand(query_delete, conDatabase);
                cmd_delete.ExecuteNonQuery();
            }

            try
            {
                if (string.IsNullOrWhiteSpace(OutputDevice_combobox.Text))
                {
                    MessageBox.Show("Provide Output Device", "Missing Information");
                }
                else if (!OutputDevice_combobox.Items.Contains(OutputDevice_combobox.Text))
                {
                    MessageBox.Show("Provide an appropriate Output Device from the dropdown menu", "Error Information");
                }
                else if (InputChannelList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Select Input measurement channels", "Missing Information");
                }
                else
                {
                    for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                    {
                        string query_delete = String.Format("DELETE FROM Measurement WHERE SignalReference = '{0}'", Channelnameprefix + Convert.ToString(InputChannelList.CheckedItems[i]));
                        SQLiteCommand cmd_delete = new SQLiteCommand(query_delete, conDatabase);
                        cmd_delete.ExecuteNonQuery();
                    }

                    //Get current MAX PointID in database
                    string query_pidcount1 = "SELECT MAX(PointID) FROM Measurement";
                    SQLiteCommand cmd_pidcount1 = new SQLiteCommand(query_pidcount1, conDatabase);
                    InitialPIDCount = Convert.ToInt32(cmd_pidcount1.ExecuteScalar());



                    if (OutputDevice_combobox.Text != "Same Device Allocation")
                    {
                        string query_outdeviceID = String.Format("SELECT ID FROM DeviceDetail WHERE Acronym='{0}'", OutputDevice_combobox.Text);
                        SQLiteCommand cmd_outdeviceID = new SQLiteCommand(query_outdeviceID, conDatabase);
                        for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                        {
                            OutDeviceIDlist.Add(Convert.ToInt32(cmd_outdeviceID.ExecuteScalar()));
                        }

                    }
                    else
                    {
                        string query_outdeviceID = String.Format("SELECT DeviceID,SignalReference FROM Measurement ;");
                        SQLiteCommand cmd_outdeviceID = new SQLiteCommand(query_outdeviceID, conDatabase);

                        for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                        {
                            SQLiteDataReader reader;
                            reader = cmd_outdeviceID.ExecuteReader();
                            while (reader.Read())
                            {
                                if (Convert.ToString(InputChannelList.CheckedItems[i]) == reader.GetString(1))
                                {
                                    OutDeviceIDlist.Add(reader.GetInt32(0));
                                }
                            }
                            reader.Close();
                        }

                    }
                    string query_MeasType = String.Format("SELECT SignalTypeID,SignalReference FROM Measurement ;");
                    SQLiteCommand cmd_MeasType = new SQLiteCommand(query_MeasType, conDatabase);

                    for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                    {
                        SQLiteDataReader reader;
                        reader = cmd_MeasType.ExecuteReader();
                        while (reader.Read())
                        {
                            if (Convert.ToString(InputChannelList.CheckedItems[i]) == reader.GetString(1))
                            {
                                MeasType.Add(reader.GetInt32(0) - 1);
                            }
                        }
                        reader.Close();
                    }
                    for (int i = 0; i < MeasType.Count; i++)
                    {
                        if (!Meas.Contains(MeasType[i]))
                        {
                            Meas.Add(MeasType[i]);
                        }

                    }
                    if (InputChannelList.CheckedItems.Count != 0)
                    {
                        //Warning for selection of less than 4 channels
                        for (int i = 0; i < 5; i++)
                        {
                            Eachtypechannelnum.Add(0);
                        }
                        for (int i = 0; i < Meas.Count; i++)
                        {
                            int num = 0;
                            for (int j = 0; j < MeasType.Count; j++)
                            {
                                if (MeasType[j] == Meas[i])
                                {
                                    num++;
                                }
                            }
                            Eachtypechannelnum[Meas[i]] = num;
                            if (Eachtypechannelnum[Meas[i]] > 0 && Eachtypechannelnum[Meas[i]] < 4)
                            {
                                Insufficientchannels = true;
                                break;
                            }
                            else
                            {
                                Insufficientchannels = false;
                            }
                        }
                        if (Insufficientchannels == true)
                        {
                            MessageBox.Show("Provide atleast 4 channels of each selected type for proper execution of SSDQ algorithm", "Warning");
                        }
                        else
                        {

                            for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                            {
                                string query_insert = "INSERT INTO Measurement (PointID,DeviceID,PointTag,SignalTypeID,SignalReference,Description,Subscribed,Enabled) VALUES (@P_id,@Dev_id,@P_tag,@Sigtype_id,@Sig_ref,@Des,@Sub,@En)";
                                SQLiteCommand cmd_insert = new SQLiteCommand();
                                cmd_insert.CommandText = query_insert;
                                cmd_insert.Connection = conDatabase;

                                cmd_insert.Parameters.Add(new SQLiteParameter("@P_id", Convert.ToString(InitialPIDCount + i + 1)));
                                cmd_insert.Parameters.Add(new SQLiteParameter("@Dev_id", Convert.ToString(OutDeviceIDlist[i])));     //1 refers to Test Device ,7 refers to Proc_PMU added by me
                                cmd_insert.Parameters.Add(new SQLiteParameter("@P_tag", Channelnameprefix + InputChannelList.CheckedItems[i]));
                                cmd_insert.Parameters.Add(new SQLiteParameter("@Sigtype_id", Convert.ToString(MeasType[i] + 1)));
                                cmd_insert.Parameters.Add(new SQLiteParameter("@Sig_ref", Channelnameprefix + InputChannelList.CheckedItems[i]));
                                cmd_insert.Parameters.Add(new SQLiteParameter("@Des", "Processed Measurement Channel for " + InputChannelList.CheckedItems[i]));
                                cmd_insert.Parameters.Add(new SQLiteParameter("@Sub", "1"));
                                cmd_insert.Parameters.Add(new SQLiteParameter("@En", "1"));
                                cmd_insert.ExecuteNonQuery();
                            }
                            MessageBox.Show("Successfully added output measurement channels into the database", "Information");
                            string query_opchannels = String.Format("SELECT SignalReference FROM Measurement WHERE PointID > '{0}'", Convert.ToString(InitialPIDCount));
                            SQLiteCommand cmd_opchannels = new SQLiteCommand(query_opchannels, conDatabase);
                            SQLiteDataReader reader;
                            reader = cmd_opchannels.ExecuteReader();
                            while (reader.Read())
                            {
                                string sSR = reader.GetString(0);
                                OutputChannelList.Items.Add(sSR);
                                OPchannelnamelist.Add(sSR);
                            }
                            reader.Close();
                            for (int i = 0; i < OutputChannelList.Items.Count; i++)
                            {
                                OutputChannelList.SetItemChecked(i, true);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Select Input measurement channels", "Missing Information");
                    }
                }
                conDatabase.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private void Create_Framework_button_Click(object sender, EventArgs e)
        {
            CreateFramework();
        }

        private void CreateFramework()
        {
            if (MainWindow_thread.IsAlive)
            {
                MessageBox.Show("An instance of openECA framework has been created and is running.Stop the framework and try again", "Error Information");
            }
            else
            {
                SSDQ_started = false;
                numberOfFrame = 0;
                Input_Output_mismatch = false;
                RunSSDQButton.BackColor = Color.LightGray;
                StopSSDQbutton.BackColor = Color.LightGray;
                try
                {

                    if (InputChannelList.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Select Input Measurement Channels", "Missing Information");
                    }
                    else if (OutputChannelList.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Select Output Measurement Channels", "Missing Information");
                    }
                    else if (InputChannelList.CheckedItems.Count != OutputChannelList.CheckedItems.Count)
                    {
                        MessageBox.Show("Input & Output Measurement Channels Number Mismatch. To Troubleshoot Create/Update Output Measurement Channels.", "Error Information");
                    }
                    else
                    {
                        for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                        {
                            if (Convert.ToString(OutputChannelList.CheckedItems[i]) != Channelnameprefix + Convert.ToString(InputChannelList.CheckedItems[i]))
                            {
                                Input_Output_mismatch = true;
                                break;
                            }
                        }
                        if (Input_Output_mismatch == true)
                        {
                            MessageBox.Show("Input & Output Measurement Channels Allocation Mismatch. To Troubleshoot Create/Update Output Measurement Channels. ", "Error Information");
                        }
                        else
                        {
                            int entry_count = 0;
                            Inentrynamelist.Clear();
                            IndataIDlist.Clear();
                            Indatareflist.Clear();
                            Indatatypelist.Clear();
                            Indatadevicelist.Clear();
                            Outentrynamelist.Clear();
                            OutdataIDlist.Clear();
                            SQLiteConnection conDatabase = new SQLiteConnection(constring);
                            SQLiteDataReader reader;
                            conDatabase.Open();

                            //Checks for the Checked items in the Measurement list and retrieves the total number of items and their ID values for creation of .ecaidl and .ecamap files
                            string query_entry = "SELECT ID,SignalReference,Device,SignalType FROM ActiveMeasurement ;";
                            SQLiteCommand cmd_entry = new SQLiteCommand(query_entry, conDatabase);

                            for (int i = 0; i < InputChannelList.CheckedItems.Count; i++)
                            {
                                reader = cmd_entry.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (InputChannelList.CheckedItems[i].ToString() == reader.GetString(1))
                                    {
                                        Indatadevicelist.Add(reader.GetString(2));
                                        Indatareflist.Add(reader.GetString(1));
                                        Indatatypelist.Add(reader.GetString(3));
                                        Inentrynamelist.Add("In_Entry" + Convert.ToString(entry_count + 1));
                                        entry_count++;
                                        IndataIDlist.Add(reader.GetString(0));
                                    }
                                }
                                reader.Close();

                            }
                            for (int i = 0; i < OutputChannelList.CheckedItems.Count; i++)
                            {
                                reader = cmd_entry.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (OutputChannelList.CheckedItems[i].ToString() == reader.GetString(1))
                                    {
                                        Outentrynamelist.Add("Out_Entry" + Convert.ToString(i + 1));
                                        OutdataIDlist.Add(reader.GetString(0));
                                    }
                                }
                                reader.Close();

                            }
                            conDatabase.Close();
                            Num_channels = InputChannelList.CheckedItems.Count;
                            Makedatastructs();
                            MakeMappings();

                            Frameworkcreatedonce = true;        //To allow saving of framework later.

                            MainWindow_thread = new Thread(ThreadStart_for_main_window);
                            MainWindow_thread.TrySetApartmentState(ApartmentState.STA);
                            MainWindow_thread.Start();
                            SSDQactionBox.Enabled = true;
                            Savegroupbox.Enabled = true;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Makedatastructs()
        {
            // Create datastructs
            UserDefinedType input_data = new UserDefinedType();
            input_data.Category = "GPA";
            input_data.Identifier = "In_Data";
            for (int i = 0; i < Inentrynamelist.Count; i++)
            {
                input_data.Fields.Add(new UDTField()
                {
                    Type = new DataType() { Category = "FloatingPoint", Identifier = "Double" },
                    Identifier = Inentrynamelist[i]
                });
            }
            UserDefinedType output_data = new UserDefinedType();
            output_data.Category = "GPA";
            output_data.Identifier = "Out_Data";
            for (int i = 0; i < Outentrynamelist.Count; i++)
            {
                output_data.Fields.Add(new UDTField()
                {

                    Type = new DataType() { Category = "FloatingPoint", Identifier = "Double" },
                    Identifier = Outentrynamelist[i]
                });
            }

            // Add new datastructs to the UDTWriter
            // and write the results to a file
            UDTWriter Structwriter = new UDTWriter();
            Structwriter.Types.Add(input_data);
            Structwriter.Types.Add(output_data);
            Structwriter.Write(Path.GetFullPath("Model\\UserDefinedTypes.ecaidl"));
        }

        private void MakeMappings()
        {
            UDTCompiler udtCompiler = new UDTCompiler();
            udtCompiler.Compile("Model\\UserDefinedTypes.ecaidl");
            UserDefinedType In_Data = (UserDefinedType)udtCompiler.GetType("In_Data");
            Dictionary<string, UDTField> In_DataFields = In_Data.Fields.ToDictionary(field => field.Identifier);

            UserDefinedType Out_Data = (UserDefinedType)udtCompiler.GetType("Out_Data");
            Dictionary<string, UDTField> Out_DataFields = Out_Data.Fields.ToDictionary(field => field.Identifier);

            // Create mapping
            TypeMapping input_map = new TypeMapping();
            input_map.Type = In_Data;
            input_map.Identifier = "In_Map";
            for (int i = 0; i < Inentrynamelist.Count; i++)
            {

                input_map.FieldMappings.Add(new FieldMapping()
                {
                    Field = In_DataFields[Inentrynamelist[i]],
                    Expression = IndataIDlist[i]
                });
            }

            TypeMapping output_map = new TypeMapping();
            output_map.Type = Out_Data;
            output_map.Identifier = "Out_Map";

            for (int i = 0; i < Outentrynamelist.Count; i++)
            {
                output_map.FieldMappings.Add(new FieldMapping()
                {
                    Field = Out_DataFields[Outentrynamelist[i]],
                    Expression = OutdataIDlist[i]
                });
            }
            // Add new mappings to the MappingWriter and write the results to a file
            MappingWriter Mapwriter = new MappingWriter();
            Mapwriter.Mappings.Add(input_map);
            Mapwriter.Mappings.Add(output_map);
            Mapwriter.Write(Path.GetFullPath("Model\\UserDefinedMappings.ecamap"));
        }

        private static void ThreadStart_for_main_window()
        {
            try
            {
                Algorithm.UpdateSystemSettings();
                Framework framework = FrameworkFactory.Create();
                Algorithm.API = new Hub(framework);
                MainWindow mainWindow = new MainWindow(framework);
                mainWindow.Text = "SSDQ openECA Analytic";
                Application.Run(mainWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ParameterSettingsButton_Click_1(object sender, EventArgs e)
        {
            var Parameterwindow_thread = new Thread(ThreadStart_for_Parameterwindow);
            Parameterwindow_thread.TrySetApartmentState(ApartmentState.STA);
            Parameterwindow_thread.Start();
        }

        private static void ThreadStart_for_Parameterwindow()
        {
            ParameterForm Parameterwindow = new ParameterForm();
            Application.Run(Parameterwindow);
        }

        private void RunSSDQButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainWindow_thread.IsAlive)
                {
                    if (SSDQ_started == true)
                    {
                        MessageBox.Show("SSDQ Algorithm already running.", "Error Information");
                    }
                    else
                    {
                        InitializeLists();
                        SSDQ_started = true;
                        wdsize = ParameterForm.L;
                        // Create and Initialize objects of the appropriate types for individual Hankel process execution
                        for (int i = 0; i < Meas.Count; i++)
                        {
                            hankelProcess[Meas[i]] = new HankelProcess(Meas[i]);
                            submatrixData[Meas[i]] = hankelProcess[Meas[i]].Initialize();
                            MeasNum[Meas[i]] = i;
                        }

                        if (MeasNum[0] > -1 && MeasNum[1] > -1)
                        {
                            if (NumChannelList[Meas[MeasNum[0]]] == NumChannelList[Meas[MeasNum[1]]])
                            {
                                complexOperations[0] = true;
                                hankelProcessComplex[0] = new HankelProcessComplex(0);
                                complexMeasurments[0] = new Vector<double>[2];
                                complexMeasurments[0][0] = Vector<double>.Build.Dense(NumChannelList[Meas[MeasNum[0]]]);
                                complexMeasurments[0][1] = Vector<double>.Build.Dense(NumChannelList[Meas[MeasNum[1]]]);
                            }
                        }

                        if (MeasNum[2] > -1 && MeasNum[3] > -1)
                        {
                            if (NumChannelList[Meas[MeasNum[2]]] == NumChannelList[Meas[MeasNum[3]]])
                            {
                                complexOperations[1] = true;
                                hankelProcessComplex[1] = new HankelProcessComplex(2);
                                complexMeasurments[1] = new Vector<double>[2];
                                complexMeasurments[1][0] = Vector<double>.Build.Dense(NumChannelList[Meas[MeasNum[2]]]);
                                complexMeasurments[1][1] = Vector<double>.Build.Dense(NumChannelList[Meas[MeasNum[3]]]);
                            }
                        }

                        RunSSDQButton.BackColor = Color.Green;
                        StopSSDQbutton.BackColor = Color.LightGray;
                        MessageBox.Show("SSDQ Algorithm Running......", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Create an openECA instance to Run SSDQ", "Error Information");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InitializeLists()
        {
            for (int i = 0; i < 5; i++)
            {
                //Index wise 0-Curr Mag, 1-Curr_Ang, 2-Volt Mag, 3-Volt Ang, 4-Freq.
                //following lists are each list containing 5 sublists....initialized here 
                Inentrynamelist_updated[i] = new List<string>();
                IPchannelnamelist_updated[i] = new List<string>();

                //Total number of channel of each type mentioned in list NumChannelList
                NumChannelList.Add(0);

                complexOperations[i / 2] = false;
                MeasNum[i] = -1;
            }

            for (int i = 0; i < Indatatypelist.Count; i++)
            {
                if (Indatatypelist[i] == "IPHM")
                {
                    Inentrynamelist_updated[0].Add(Inentrynamelist[i]);
                    IPchannelnamelist_updated[0].Add(Indatareflist[i]);
                }
                else if (Indatatypelist[i] == "IPHA")
                {
                    Inentrynamelist_updated[1].Add(Inentrynamelist[i]);
                    IPchannelnamelist_updated[1].Add(Indatareflist[i]);
                }
                else if (Indatatypelist[i] == "VPHM")
                {
                    Inentrynamelist_updated[2].Add(Inentrynamelist[i]);
                    IPchannelnamelist_updated[2].Add(Indatareflist[i]);
                }
                else if (Indatatypelist[i] == "VPHA")
                {
                    Inentrynamelist_updated[3].Add(Inentrynamelist[i]);
                    IPchannelnamelist_updated[3].Add(Indatareflist[i]);
                }

                else if (Indatatypelist[i] == "FREQ")
                {
                    Inentrynamelist_updated[4].Add(Inentrynamelist[i]);
                    IPchannelnamelist_updated[4].Add(Indatareflist[i]);
                }

            }
            for (int i = 0; i < 5; i++)
            {
                NumChannelList[i] = Inentrynamelist_updated[i].Count;
                if (NumChannelList[i] > 0)
                {
                    data_observed_initial[i] = Vector<double>.Build.Dense(NumChannelList[i]);
                }
            }
        }

        public void Update_Measurements()
        {
            try
            {
                numberOfFrame++;

                Proc_data_updated.Clear();
                Proc_data = new Vector<double>[5];
                submatrixStacked = Matrix<double>.Build.Dense(Inentrynamelist.Count, wdsize);
                count = 0;

                // Gets input
                for (int i = 0; i < Num_channels; i++)
                {
                    var propertyvalue1 = Algorithm.InData.GetType().GetProperty(Inentrynamelist[i]).GetValue(Algorithm.InData, null);
                    for (int j = 0; j < 5; j++)
                    {
                        if (NumChannelList[j] > 0)
                        {
                            for (int k = 0; k < NumChannelList[j]; k++)
                            {
                                if (Inentrynamelist[i] == Inentrynamelist_updated[j][k])
                                {
                                    data_observed_initial[j][k] = Convert.ToDouble(propertyvalue1);

                                    //In case the measurements are voltage angles or current angles, they are modified into radians from degrees for proper conditioning by Hankel robust estimation
                                    if (j == 1 || j == 3)
                                    {
                                        if (data_observed_initial[j][k] < 0)
                                        {
                                            data_observed_initial[j][k] = 360 + data_observed_initial[j][k];
                                        }
                                        data_observed_initial[j][k] *= Math.PI / 180;
                                    }
                                }
                            }
                        }
                    }
                }

                // Performs real-valued calculations
                for (int i = 0; i < Meas.Count; i++)
                {
                    Proc_data[i] = Vector<double>.Build.Dense(NumChannelList[Meas[i]]);

                    if (!complexOperations[Meas[i] / 2])
                    {
                        submatrixData[Meas[i]] = hankelProcess[Meas[i]].ProcessFrame(data_observed_initial[Meas[i]], numberOfFrame);
                        for (int j = 0; j < submatrixData[Meas[i]].RowCount; j++)
                        {
                            submatrixStacked.SetRow(count, submatrixData[Meas[i]].Row(j));
                            count++;
                        }
                        Proc_data[i] = submatrixData[Meas[i]].Column(wdsize - 1);

                    }
                    else
                    {
                        complexMeasurments[Meas[i] / 2][Meas[i] % 2] = data_observed_initial[Meas[i]].Clone();
                    }
                }

                // Perform complex-valued calculations
                for (int c = 0; c < 2; c++)
                {
                    if (complexOperations[c])
                    {
                        submatrixDataComplex[c] = hankelProcessComplex[c].ProcessFrame(complexMeasurments[c], numberOfFrame);

                        for (int i = 0; i < 2; i++)
                        {
                            submatrixData[2 * c + i] = submatrixDataComplex[c][i];
                            for (int j = 0; j < submatrixData[2 * c + i].RowCount; j++)
                            {
                                submatrixStacked.SetRow(count, submatrixData[2 * c + i].Row(j));
                                count++;
                            }
                            Proc_data[MeasNum[2 * c + i]] = submatrixData[2 * c + i].Column(wdsize - 1);
                        }
                    }
                }

                for (int i = 0; i < Meas.Count; i++)
                {
                    //Convert back the measurements from radians to degrees
                    if (Meas[i] == 1 || Meas[i] == 3)
                    {
                        for (int j = 0; j < Proc_data[i].Count; j++)
                        {
                            Proc_data[i][j] = (Proc_data[i][j] * 180 / Math.PI) % 360;
                            if (Proc_data[i][j] > 180)
                            {
                                Proc_data[i][j] = Proc_data[i][j] - 360;
                            }
                        }
                    }
                    for (int j = 0; j < Proc_data[i].Count; j++)
                    {
                        Proc_data_updated.Add(Proc_data[i][j]);                    //This is used as output data to openECA Manager
                    }
                }
            }
            catch (Exception ex)
            {
                SSDQ_started = false;
                numberOfFrame = 0;
                RunSSDQButton.BackColor = Color.LightGray;
                StopSSDQbutton.BackColor = Color.Red;
                MessageBox.Show("SSDQ method failed to converge. Try running SSDQ again.", "Error Information: " + ex.Message);
            }
        }

        private void StopSSDQbutton_Click(object sender, EventArgs e)
        {
            if (SSDQ_started == true)
            {
                SSDQ_started = false;
                numberOfFrame = 0;
                RunSSDQButton.BackColor = Color.LightGray;
                StopSSDQbutton.BackColor = Color.Red;
                MessageBox.Show("SSDQ Algorithm execution terminated.", "Information");
            }

        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSDQ_started == true)
                {
                    var PlotWindow_thread = new Thread(ThreadStart_for_PlotWindow);
                    PlotWindow_thread.TrySetApartmentState(ApartmentState.STA);
                    PlotWindow_thread.Start();
                }
                else
                {
                    MessageBox.Show("Run SSDQ to use the Plot option", "Error Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void ThreadStart_for_PlotWindow()
        {
            Algorithm.Plotwindow = new Plot();
            Application.Run(Algorithm.Plotwindow);

        }

        private void RecordData_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSDQ_started == true)
                {
                    var RecordDataWindow_thread = new Thread(ThreadStart_for_RecordDataWindow);
                    RecordDataWindow_thread.TrySetApartmentState(ApartmentState.STA);
                    RecordDataWindow_thread.Start();
                }
                else
                {
                    MessageBox.Show("Run SSDQ to start recording data", "Error Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void ThreadStart_for_RecordDataWindow()
        {
            Algorithm.RecordDataWindow = new RecordDataWindow();
            Application.Run(Algorithm.RecordDataWindow);

        }

        private void SaveFrameworkbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Frameworkcreatedonce)
                {
                    var FD = new System.Windows.Forms.SaveFileDialog();
                    if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string file = FD.FileName + ".csv";
                        CSVlocationlabel.Text = file;
                        stream = File.CreateText(file);
                        sb.Clear();
                        sb.AppendLine(string.Join(strSeperator, CSVhead));
                        for (int i = 0; i < Num_channels; i++)
                        {
                            CSVdata.Clear();
                            CSVdata.Add(Indatadevicelist[i]);
                            CSVdata.Add(Indatareflist[i]);
                            CSVdata.Add(IndataIDlist[i]);
                            CSVdata.Add(Indatatypelist[i]);
                            sb.AppendLine(string.Join(strSeperator, CSVdata));
                        }
                        stream.WriteLine(sb.ToString());
                        stream.Close();
                        MessageBox.Show("An openECA Framework (.csv file) was saved successfully at the destination folder", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Load atleast one instance of openECAFramework", "Error Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InputScreen2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SQLiteConnection conDatabase = new SQLiteConnection(constring);
                conDatabase.Open();

                //Get current MAX PointID in database
                string query_rowcount = "SELECT MAX(PointID) FROM Measurement";
                SQLiteCommand cmd_rowcount = new SQLiteCommand(query_rowcount, conDatabase);
                int PIDcount = Convert.ToInt32(cmd_rowcount.ExecuteScalar());

                if (PIDcount > Math.Min(InitialPIDCount, OriginalPIDCount))
                {
                    string query_delete = String.Format("DELETE FROM Measurement WHERE PointID > '{0}'", Convert.ToString(InitialPIDCount));
                    SQLiteCommand cmd_delete = new SQLiteCommand(query_delete, conDatabase);
                    cmd_delete.ExecuteNonQuery();
                }
                conDatabase.Close();
                SSDQ_started = false;
            }
            catch
            {

            }
        }
    }
}