// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:Plot.cs
//Description: This Code segment uses the openECA.db database file in order to populate necessaery input devices
//and consequently the input measurement channels and creates and adds required output channels to the database.
//the Hankel Data Robust estimation process is carried out and options for plotting and recording data are provided to user 
//Inputs:openECA.db database file
//*********************************************************************************************************************

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace SSDQopenECA
{
    public partial class Plot : Form
    {
        private List<string>[] Inentrynamelist = new List<string>[5];
        private List<string> PlotInentrynamelist = new List<string>();          //Input entries required for plotting
        private List<string> Plotcheckedactualnamelist = new List<string>();    //Name of Input channels selected for plotting
        private List<string> Plotcheckedprocessednamelist = new List<string>(); //Name of Output channels for plotting
        private List<int> Plotcheckedindexlist = new List<int>();
        private string Meastype = "";
        private int Meas;
        private List<string> Indatadevicelist = new List<string>();
        private List<string> Indatatypelist = new List<string>();
        private List<string> IPchannelnamelist = new List<string>();
        private List<string>[] IPchannelnamelist_updated = new List<string>[5];
        private string Channelnameprefix;
        private bool SSDQ_started;
        public bool Plot_started = false;

        private List<PlotFigure> figures;

        public Plot()
        {
            InitializeComponent();
        }

        public void Plot_Load(object sender, EventArgs e)
        {
            //Retrieve necessary data from the earlier window(Either New or Load options)
            Inentrynamelist = Algorithm.SSDQ_config.Inentrynamelist_updated;
            IPchannelnamelist = Algorithm.SSDQ_config.Indatareflist;
            IPchannelnamelist_updated = Algorithm.SSDQ_config.IPchannelnamelist_updated;
            Indatadevicelist = Algorithm.SSDQ_config.Indatadevicelist;
            Indatatypelist = Algorithm.SSDQ_config.Indatatypelist;
            Channelnameprefix = Algorithm.SSDQ_config.Channelnameprefix;
            figures = new List<PlotFigure>();
            FillDevices();
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
            //Populate measurement types in the combo box based on the devices selected.
            MeasComboBox.Items.Clear();
            MeasComboBox.Text = "";
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
                        if (Indatatypelist[i] == "VPHM" && !MeasComboBox.Items.Contains("Voltage Magnitude"))
                        {
                            MeasComboBox.Items.Add("Voltage Magnitude");
                        }
                        if (Indatatypelist[i] == "VPHA" && !MeasComboBox.Items.Contains("Voltage Angle"))
                        {
                            MeasComboBox.Items.Add("Voltage Angle");
                        }
                        if (Indatatypelist[i] == "IPHM" && !MeasComboBox.Items.Contains("Current Magnitude"))
                        {
                            MeasComboBox.Items.Add("Current Magnitude");
                        }
                        if (Indatatypelist[i] == "IPHA" && !MeasComboBox.Items.Contains("Current Angle"))
                        {
                            MeasComboBox.Items.Add("Current Angle");
                        }
                        if (Indatatypelist[i] == "FREQ" && !MeasComboBox.Items.Contains("Frequency"))
                        {
                            MeasComboBox.Items.Add("Frequency");
                        }
                    }
                }
            }
        }
      
        private void RefreshPlotList_Click(object sender, EventArgs e)
        {
            PlotChannelList.Items.Clear();
            if (DevicecheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select Devices", "Missing Information");
            }
            else
            {
                if (MeasComboBox.Text== "Voltage Magnitude")
                {
                    Meastype = "VPHM";
                }
                else if (MeasComboBox.Text == "Voltage Angle")
                {
                    Meastype = "VPHA";
                }
                else if (MeasComboBox.Text == "Current Magnitude")
                {
                    Meastype = "IPHM";
                }
                else if (MeasComboBox.Text == "Current Angle")
                {
                    Meastype = "IPHA";
                }
                else if (MeasComboBox.Text == "Frequency")
                {
                    Meastype = "FREQ";
                }
                else
                {
                    Meastype = "";
                }
                if (Meastype != "")
                {
                    for (int i = 0; i < IPchannelnamelist.Count; i++)
                    {
                        if (Indatatypelist[i] == Meastype && DevicecheckedListBox.CheckedItems.Contains(Indatadevicelist[i]))
                        {
                            PlotChannelList.Items.Add(IPchannelnamelist[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Valid Measurement Type", "Missing Information");
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

        private void PlotButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlotChannelList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Select Measurement Channels for Plotting", "Error Information");
                }
                else
                {
                    if (Meastype == "VPHM")
                    {
                        Meas = 2;
                    }
                    else if (Meastype == "VPHA")
                    {
                        Meas = 3;
                    }
                    else if (Meastype == "IPHM")
                    {
                        Meas = 0;
                    }
                    else if (Meastype == "IPHA")
                    {
                        Meas = 1;
                    }
                    else if (Meastype == "FREQ")
                    {
                        Meas = 4;
                    }

                    SSDQ_started = Algorithm.SSDQ_config.SSDQ_started;
                    Plot_started = true;
                    Plotcheckedindexlist.Clear();
                    Plotcheckedactualnamelist.Clear();
                    Plotcheckedprocessednamelist.Clear();
                    PlotInentrynamelist.Clear();

                    for (int i = 0; i < PlotChannelList.Items.Count; i++)
                    {
                        if (PlotChannelList.CheckedItems.Contains(PlotChannelList.Items[i]))
                        {
                            Plotcheckedactualnamelist.Add(PlotChannelList.Items[i].ToString());
                            Plotcheckedprocessednamelist.Add(Channelnameprefix + PlotChannelList.Items[i].ToString());

                            Plotcheckedindexlist.Add(IPchannelnamelist_updated[Meas].IndexOf(Convert.ToString(PlotChannelList.Items[i])));
                            PlotInentrynamelist.Add(Inentrynamelist[Meas][IPchannelnamelist_updated[Meas].IndexOf(Convert.ToString(PlotChannelList.Items[i]))]);
                        }
                    }
                }
                PlotFigure newFigure = new PlotFigure(PlotChannelList, Meas);
                figures.Add(newFigure);
                newFigure.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
  
        public void Update_Measurements()
        {
            if (SSDQ_started && Plot_started)
            {
                foreach (PlotFigure figure in figures)
                {
                    try
                    {
                        figure.Update_Measurements();
                    }
                    catch
                    {
                        figures.Remove(figure);
                    }
                }
            }
        }

        private void Plot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Plot_started = false;
        }
    }
}