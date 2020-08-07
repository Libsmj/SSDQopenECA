// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:RecordDataWindow.cs
//Description: This code segment implements the selection of measurement channels to store the measurements in form of a csv file
//at the user defined location.
//*********************************************************************************************************************

using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SSDQopenECA
{
    public partial class RecordDataWindow : Form
    {
        //Variables mostly similar to Plot.cs variables
        private List<string> Indatadevicelist = new List<string>();
        private List<string> Indatatypelist = new List<string>();
        private List<string> IPchannelnamelist = new List<string>();
        //private List<string>[] IPchannelnamelist_updated = new List<string>[5];
        private List<string> Recordcheckedactualnamelist = new List<string>();
        private List<string> Recordcheckedprocessednamelist = new List<string>();
        private List<Int32> Recordcheckedindexlist = new List<Int32>();
        private List<string> Inentrynamelist = new List<string>();
        private List<string> RecordInentrynamelist = new List<string>();
        private List<string> MeasTypelist = new List<string>();
        private StreamWriter stream;
        private StringBuilder sb = new StringBuilder();
        private string strSeperator = ",";
        private List<string> CSVhead = new List<string>();
        private List<string> CSVdata = new List<string>();
        private bool Startbuttonclicked = false;
        private bool SSDQ_started;
        private bool progress = false;      
        private int Record_channels;
        private Vector<double> A_data;
        private int wdsize = 0;
        private List<DateTime> Timestamp = new List<DateTime>();
        private List<double>[] Actual_matrix;
        private List<double>[] Processed_matrix;     
        private int numFrames=0;
        private Matrix<double> submatrix;
        private string Channelnameprefix;
        public bool Record_option = false;

        public RecordDataWindow()
        {
            InitializeComponent();
        }

        private void RecordDataWindow_Load(object sender, EventArgs e)
        {
            wdsize = ParameterForm.L;
            if (FrameworkConfiguration.newframework)
            {
                IPchannelnamelist = Algorithm.New_config.Indatareflist;
                Inentrynamelist = Algorithm.New_config.Inentrynamelist;
                Indatadevicelist = Algorithm.New_config.Indatadevicelist;
                Indatatypelist = Algorithm.New_config.Indatatypelist;
                //IPchannelnamelist_updated = Algorithm.New_config.IPchannelnamelist_updated;
                Channelnameprefix = Algorithm.New_config.Channelnameprefix;
            }
            else
            {
                IPchannelnamelist = Algorithm.Stored_config.Indatareflist;
                Inentrynamelist = Algorithm.Stored_config.Inentrynamelist;              
                Indatadevicelist = Algorithm.Stored_config.Indatadevicelist;
                Indatatypelist = Algorithm.Stored_config.Indatatypelist;
                //IPchannelnamelist_updated = Algorithm.Stored_config.IPchannelnamelist_updated;
                Channelnameprefix = Algorithm.Stored_config.Channelnameprefix;
            }

            FillDevices();
            Startbutton.Enabled = false;
            Stopbutton.Enabled = false;
            CSVgroupBox.Enabled = false;
        }
      
        private void FillDevices()
        {
            DevicecheckedListBox.Items.Clear();
            for (int i = 0; i < Indatadevicelist.Count; i++)
            {
                if (!DevicecheckedListBox.Items.Contains(Indatadevicelist[i]))
                {
                    DevicecheckedListBox.Items.Add(Indatadevicelist[i]);
                }
            }
        }
        private void AllDevicesbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DevicecheckedListBox.Items.Count; i++)
            {
                DevicecheckedListBox.SetItemChecked(i, true);
            }
        }

        private void Deselect_devices_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DevicecheckedListBox.Items.Count; i++)
            {
                DevicecheckedListBox.SetItemChecked(i, false);
            }
        }

        private void AvailableMeastypebutton_Click(object sender, EventArgs e)
        {
            MeasTypechecklist.Items.Clear();
            PlotChannelList.Items.Clear();
            if (DevicecheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Provide Input Devices", "Missing Information");
            }
            else
            {
                for (int i = 0; i < Indatadevicelist.Count; i++)
                {
                    if (DevicecheckedListBox.CheckedItems.Contains(Indatadevicelist[i]))
                    {
                        if (Indatatypelist[i] == "VPHM" && !MeasTypechecklist.Items.Contains("Voltage Magnitude"))
                        {
                            MeasTypechecklist.Items.Add("Voltage Magnitude");
                        }
                        if (Indatatypelist[i] == "VPHA" && !MeasTypechecklist.Items.Contains("Voltage Angle"))
                        {
                            MeasTypechecklist.Items.Add("Voltage Angle");
                        }
                        if (Indatatypelist[i] == "IPHM" && !MeasTypechecklist.Items.Contains("Current Magnitude"))
                        {
                            MeasTypechecklist.Items.Add("Current Magnitude");
                        }
                        if (Indatatypelist[i] == "IPHA" && !MeasTypechecklist.Items.Contains("Current Angle"))
                        {
                            MeasTypechecklist.Items.Add("Current Angle");
                        }
                        if (Indatatypelist[i] == "FREQ" && !MeasTypechecklist.Items.Contains("Frequency"))
                        {
                            MeasTypechecklist.Items.Add("Frequency");
                        }
                    }
                }
            }
        }
        private void AllMeasTypebutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MeasTypechecklist.Items.Count; i++)
            {
                MeasTypechecklist.SetItemChecked(i, true);
            }
        }
        private void DeselectAllMeasType_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MeasTypechecklist.Items.Count; i++)
            {
                MeasTypechecklist.SetItemChecked(i, false);
            }
        }

        private void RefreshPlotList_Click(object sender, EventArgs e)
        {
            PlotChannelList.Items.Clear();
            MeasTypelist.Clear();
            if (DevicecheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select Devices", "Missing Information");
            }
            else
            {
                for (int i = 0; i < MeasTypechecklist.CheckedItems.Count; i++)
                {
                    if(Convert.ToString(MeasTypechecklist.CheckedItems[i])=="Voltage Magnitude")
                    {            
                        MeasTypelist.Add("VPHM");
                    }
                    if (Convert.ToString(MeasTypechecklist.CheckedItems[i]) == "Voltage Angle")
                    {
                        MeasTypelist.Add("VPHA");
                    }
                    if (Convert.ToString(MeasTypechecklist.CheckedItems[i]) == "Current Magnitude")
                    {
                        MeasTypelist.Add("IPHM");
                    }
                    if (Convert.ToString(MeasTypechecklist.CheckedItems[i]) == "Current Angle")
                    {
                        MeasTypelist.Add("IPHA");
                    }
                    if (Convert.ToString(MeasTypechecklist.CheckedItems[i]) == "Frequency")
                    {
                        MeasTypelist.Add("FREQ");
                    }
                }           
                
                if(MeasTypelist.Count!=0)
                {
                    for(int j = 0; j < MeasTypelist.Count; j++)
                    {
                        for (int i = 0; i < IPchannelnamelist.Count; i++)
                        {
                            if (Indatatypelist[i] == MeasTypelist[j] && DevicecheckedListBox.CheckedItems.Contains(Indatadevicelist[i]))
                            {
                                PlotChannelList.Items.Add(IPchannelnamelist[i]);
                            }
                        }
                    }
                    CSVgroupBox.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Select Measurement Type", "Missing Information");
                }                
            }                  
        }

        private void SelectAllPlotChannels_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PlotChannelList.Items.Count; i++)
            {
                PlotChannelList.SetItemChecked(i, true);
            }
        }

        private void Deselect_Plotchannels_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PlotChannelList.Items.Count; i++)
            {
                PlotChannelList.SetItemChecked(i, false);
            }
        }

        private void Saveasbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlotChannelList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Select Measurement Channels for Recording", "Missing Information");
                }
                else
                {
                    var FD = new System.Windows.Forms.SaveFileDialog();
                    if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CSVLocation.Text = FD.FileName;
                        Startbutton.Enabled = true;
                        Stopbutton.Enabled = true;
                        Startbutton.BackColor = Color.LightGray;
                        Stopbutton.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         
        }

        public void Startbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (progress == false)
                {
                    CSVLocation.BackColor = default;
                    if (string.IsNullOrWhiteSpace(CSVLocation.Text))
                    {
                        //CSVLocation.Focus();
                        //CSVLocation.BackColor = Color.Red;
                        MessageBox.Show("Enter Destination File Location", "Missing Information");
                    }
                    else
                    {
                        Startbutton.BackColor = Color.Green;
                        Stopbutton.BackColor = Color.LightGray;
                        numFrames = 0;
                        Timestamp.Clear();
                        Startbuttonclicked = true;
                        Record_option = true;
                        Record_channels = PlotChannelList.CheckedItems.Count;
                        A_data = Vector<double>.Build.Dense(Record_channels);

                        Actual_matrix = new List<double>[wdsize];
                        Processed_matrix = new List<double>[wdsize];
                        for (int i = 0; i < wdsize; i++)
                        {
                            Actual_matrix[i] = new List<double>();
                            Processed_matrix[i] = new List<double>();
                        }

                        Recordcheckedactualnamelist.Clear();
                        Recordcheckedprocessednamelist.Clear();
                        Recordcheckedindexlist.Clear();
                        RecordInentrynamelist.Clear();
                        for (int i = 0; i < PlotChannelList.Items.Count; i++)
                        {
                            if (PlotChannelList.CheckedItems.Contains(PlotChannelList.Items[i]))
                            {
                                Recordcheckedactualnamelist.Add(PlotChannelList.Items[i].ToString());
                                Recordcheckedprocessednamelist.Add(Channelnameprefix + PlotChannelList.Items[i].ToString());

                            }
                        }
                        for (int i = 0; i < IPchannelnamelist.Count; i++)
                        {
                            if (PlotChannelList.CheckedItems.Contains(IPchannelnamelist[i]))
                            {
                                RecordInentrynamelist.Add(Inentrynamelist[i]);
                                Recordcheckedindexlist.Add(i);
                            }
                        }

                        //Adding CSV header for each column
                        CSVhead.Clear();
                        CSVhead.Add("Time");
                        for (int i = 0; i < Record_channels; i++)
                        {
                            CSVhead.Add(Recordcheckedactualnamelist[i]);
                        }
                        for (int i = 0; i < Record_channels; i++)
                        {
                            CSVhead.Add(Recordcheckedprocessednamelist[i]);
                        }

                        string file = CSVLocation.Text + ".csv";
                        stream = File.CreateText(file);
                        MessageBox.Show("CSV File created.Data storing in progress", "Information");
                        progress = true;
                        sb.Clear();
                        sb.AppendLine(string.Join(strSeperator, CSVhead));

                    }
                }
                else
                {
                    MessageBox.Show("Data storing already in progress", "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Update_Measurements()
        {
            numFrames++;
            
            if (FrameworkConfiguration.newframework)
            {
                SSDQ_started = Algorithm.New_config.SSDQ_started;
                submatrix = Algorithm.New_config.submatrixStacked;
            }
            else
            {
                SSDQ_started = Algorithm.Stored_config.SSDQ_started;
                submatrix = Algorithm.Stored_config.submatrixStacked;
            }
            if (SSDQ_started == true)
            {
                for (int i = 0; i < Record_channels; i++)
                {
                    var propertyvalue2 = Algorithm.InData.GetType().GetProperty(RecordInentrynamelist[i]).GetValue(Algorithm.InData, null);
                    A_data[i] = Convert.ToDouble(propertyvalue2);                    
                }

                CSVdata.Clear();
                if (Timestamp.Count < wdsize)
                {
                    Timestamp.Add(Algorithm.InMeta.In_Entry1.Timestamp);
                }
                else
                {
                    Timestamp.RemoveAt(0);
                    Timestamp.Add(Algorithm.InMeta.In_Entry1.Timestamp);
                }

                //Add and update Timestamps, actual data and Processed data
                if (numFrames <= wdsize)
                {
                    Timestamp.Add(Algorithm.InMeta.In_Entry1.Timestamp);
                    for (int j = 0; j < Record_channels; j++)
                    {
                        Actual_matrix[numFrames - 1].Add(A_data[j]);
                    }
                }
                else
                {
                    Timestamp.RemoveAt(0);
                    Timestamp.Add(Algorithm.InMeta.In_Entry1.Timestamp);
                    for (int i = 0; i < wdsize; i++)
                    {
                        if (i < wdsize - 1)
                        {
                            for (int j = 0; j < Record_channels; j++)
                            {
                                Actual_matrix[i][j] = Actual_matrix[i + 1][j];
                                
                            }
                        }
                        else
                        {
                            for (int j = 0; j < Record_channels; j++)
                            {
                                Actual_matrix[wdsize - 1][j]=A_data[j];
                            }
                        }    
                    }

                    for (int i = 0; i < wdsize; i++)
                    {
                        Processed_matrix[i].Clear();
                        
                        for (int j = 0; j < Record_channels; j++)
                        {
                            //For angles convert back to degrees
                            if (Indatatypelist[Recordcheckedindexlist[j]] == "IPHA" || Indatatypelist[Recordcheckedindexlist[j]] == "VPHA")
                            {
                                Processed_matrix[i].Add((Convert.ToDouble(submatrix.At(Recordcheckedindexlist[j], i))* 360 / (2 * Math.PI)) % 360);
                                if (Processed_matrix[i][j] > 180)
                                {
                                    Processed_matrix[i][j] = Processed_matrix[i][j] - 360;
                                }                               
                            }
                            else
                            {
                                Processed_matrix[i].Add(Convert.ToDouble(submatrix.At(Recordcheckedindexlist[j], i)));
                            }
                        }
                    }
                    
                    CSVdata.Add(Convert.ToString(Timestamp[0].TimeOfDay));
                    for (int i = 0; i < Record_channels; i++)
                    {
                        CSVdata.Add(Convert.ToString(Actual_matrix[0][i]));
                    }
                    for (int i = 0; i < Record_channels; i++)
                    {
                        CSVdata.Add(Convert.ToString(Processed_matrix[0][i]));
                    }
                    sb.AppendLine(string.Join(strSeperator, CSVdata));
                }

            }
            else
            {
                if (Startbuttonclicked == true)
                {
                    Startbuttonclicked = false;
                    stream.WriteLine(sb.ToString());
                    stream.Close();
                    MessageBox.Show("Data Storing process interrupted as SSDQ execution was terminated. ", "Error Information");
                    progress = false;
                }
                this.Close();
            }


        }       

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            //Only if the Record start option has been clicked
            if (Startbuttonclicked == true)
            {
                Startbuttonclicked = false;
                Record_option = false;
                stream.WriteLine(sb.ToString());
                stream.Close();
                Startbutton.BackColor = Color.LightGray;
                Stopbutton.BackColor = Color.Red;
                MessageBox.Show("Data Stored to CSV File successfully", "Information");
                progress = false;
                
            }
        }
        private void RecordDataWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Record_option = false;
        }
    }
}
