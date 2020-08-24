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
        private bool incomingDataStarted = false;//variable to check whether data from openECA has started streaming in     
        private Thread InputmeasThread;         //Thread for plotting Input measurements
        private Thread ProcmeasThread;          //Thread for plotting Processed measurements
        private int graph_length = 200;          //Number of Frames plotted in GUI
        private Vector<double> A_data;          //Actual data
        private Vector<double> P_data;          //Processed data
        private double[][] Inputarray = new double[1000][];         //Array representing data of Input number of channels(1000 max)
        private double[][] Processedarray = new double[1000][];     //Array representing data of Output number of channels(1000 max)
        private int Plot_channels;
        private List<string>[] Inentrynamelist = new List<string>[5];
        private List<string> PlotInentrynamelist = new List<string>();      //Input entries required for plotting
        private List<string> Plotcheckedactualnamelist = new List<string>();// Name of Input channels selected for plotting
        private List<string> Plotcheckedprocessednamelist = new List<string>();//Name of Output channels for plotting
        private List<int> Plotcheckedindexlist = new List<int>();
        private string Meastype = "";
        private int Meas;
        private List<string> Indatadevicelist = new List<string>();
        private List<string> Indatatypelist = new List<string>();
        private List<string> IPchannelnamelist = new List<string>();
        private List<string>[] IPchannelnamelist_updated = new List<string>[5];       
        private bool SSDQ_started;
        private Matrix<double> submatrix;
        private int wdsize=0;
        private string Channelnameprefix;
        public bool Plot_started = false;

        //Used for dynamic axes updation
        private double max_proc = 0;    // max value of processed measurements in the array
        private double max_input = 0;// max value of input measurements in the array
        private double min_proc = 0;// min value of processed measurements in the array
        private double min_input = 0;// min value of input measurements in the array


            // temp
        //private String temp1 = "1";
        //private String temp2 = "1";

        public Plot()
        {
            InitializeComponent();
        }

        public void Plot_Load(object sender, EventArgs e)
        {
            wdsize = ParameterForm.L;
            //Retrieve necessary data from the earlier window(Either New or Load options)
            Inentrynamelist = Algorithm.SSDQ_config.Inentrynamelist_updated;
            IPchannelnamelist = Algorithm.SSDQ_config.Indatareflist;
            IPchannelnamelist_updated = Algorithm.SSDQ_config.IPchannelnamelist_updated;
            Indatadevicelist = Algorithm.SSDQ_config.Indatadevicelist;
            Indatatypelist = Algorithm.SSDQ_config.Indatatypelist;
            Channelnameprefix = Algorithm.SSDQ_config.Channelnameprefix;
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

                    Plot_started = true;
                    Plot_channels = PlotChannelList.CheckedItems.Count;
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

                    for (int i = 0; i < Plot_channels; i++)
                    {
                        Inputarray[i] = new double[graph_length];
                        Processedarray[i] = new double[graph_length];
                    }                 
                    A_data = Vector<double>.Build.Dense(Plot_channels);
                    P_data = Vector<double>.Build.Dense(Plot_channels);

                    //Retrieve the window size of data of all channels 
                    SSDQ_started = Algorithm.SSDQ_config.SSDQ_started;
                    submatrix = Algorithm.SSDQ_config.submatrixData[Meas];

                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
  
        public void Update_Measurements()
        {
            if (SSDQ_started == true)
            {
                try
                {
                    for (int i = 0; i < Plot_channels; i++)
                    {
                        var propertyvalue2 = Algorithm.InData.GetType().GetProperty(PlotInentrynamelist[i]).GetValue(Algorithm.InData, null);
                        A_data[i] = Convert.ToDouble(propertyvalue2);
                        P_data[i] = Convert.ToDouble(submatrix.At(Plotcheckedindexlist[i], wdsize - 1));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not record data: " + ex.Message);
                    return;
                }

                AxisMaxMinCalc();
                DecidePlotproperties();
                if (!incomingDataStarted)
                {
                    incomingDataStarted = true;
                    StartGraphs();
                }
                //Update input and processed arrays for each frame
                if (incomingDataStarted)
                {
                    for (int i = 0; i < Plot_channels; i++)
                    {
                        if (P_data[i] >= Math.Pow(10, 26))
                        {
                            MessageBox.Show("SSDQ algorithm failed, overflow error");
                            this.Close();
                        }

                        Inputarray[i][graph_length - 1] = A_data[i];
                        Array.Copy(Inputarray[i], 1, Inputarray[i], 0, graph_length - 1);

                        
                        for (int j = 0; j < wdsize; j++)
                        {
                            Processedarray[i][Processedarray[i].Length + j - wdsize] = Convert.ToDouble(submatrix.At(Plotcheckedindexlist[i], j));
                            //For angle measurements convert back to degrees from radians
                            if (Meas == 1 || Meas == 3)
                            {
                                Processedarray[i][Processedarray[i].Length + j - wdsize] = (Processedarray[i][Processedarray[i].Length + j - wdsize] * 360 / (2 * Math.PI)) % 360;
                                if (Processedarray[i][Processedarray[i].Length + j - wdsize] > 180)
                                {
                                    Processedarray[i][Processedarray[i].Length + j - wdsize] = Processedarray[i][Processedarray[i].Length + j - wdsize] - 360;
                                }
                            }
                        }
                        Array.Copy(Processedarray[i], 1, Processedarray[i], 0, Processedarray[i].Length - 1);
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void AxisMaxMinCalc()
        {
            for (int i = 0; i < Plot_channels; i++)
            {
                double max_input_temp = Inputarray[i].Max();
                double max_proc_temp = Processedarray[i].Max();
                double min_input_temp = Inputarray[i].Min();
                double min_proc_temp = Processedarray[i].Min();

                if (i == 0)
                {
                    max_proc = max_proc_temp;
                    max_input = max_input_temp;
                    min_proc = min_proc_temp;
                    min_input = min_input_temp;
                }
                if (min_input_temp < min_input)
                {
                    min_input = min_input_temp;
                }
                if (min_proc_temp < min_proc)
                {
                    min_proc = min_proc_temp;
                }
                if (max_input_temp > max_input)
                {
                    max_input = max_input_temp;
                }
                if (max_proc_temp > max_proc)
                {
                    max_proc = max_proc_temp;
                }
            }
        }

        private void DecidePlotproperties()
        {
            if (Meas == 0 || Meas == 2)
            {
                InputDataChart.ChartAreas[0].AxisY.Title = "Magnitude";
                InputDataChart.ChartAreas[0].AxisY.Minimum = (Math.Floor(min_input * 10) / 10) * 0.95;// for limiting the number of decimal places for plot axes
                InputDataChart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(max_input * 10) / 10) * 1.05;

                ProcessedDataChart.ChartAreas[0].AxisY.Title = "Magnitude";
                ProcessedDataChart.ChartAreas[0].AxisY.Minimum = (Math.Floor(min_proc * 10) / 10) * 0.95;
                ProcessedDataChart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(max_proc * 10) / 10) * 1.05;
            }
            else if (Meas == 1 || Meas == 3)
            {
                InputDataChart.ChartAreas[0].AxisY.Title = "Angle (in degrees)";
                InputDataChart.ChartAreas[0].AxisY.Minimum = -200;
                InputDataChart.ChartAreas[0].AxisY.Maximum = 200;

                ProcessedDataChart.ChartAreas[0].AxisY.Title = "Angle (in degrees)";
                ProcessedDataChart.ChartAreas[0].AxisY.Minimum = -200;
                ProcessedDataChart.ChartAreas[0].AxisY.Maximum = 200;
            }
            else if (Meas == 4)
            {
                InputDataChart.ChartAreas[0].AxisY.Title = "Frequency (in Hz)";
                InputDataChart.ChartAreas[0].AxisY.Minimum = (Math.Floor(min_input * 10) / 10) * 0.95;
                InputDataChart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(max_input * 10) / 10) * 1.1;

                ProcessedDataChart.ChartAreas[0].AxisY.Title = "Frequency (in Hz)";
                ProcessedDataChart.ChartAreas[0].AxisY.Minimum = (Math.Floor(min_proc * 10) / 10) * 0.995;
                ProcessedDataChart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(max_proc * 10) / 10) * 1.005;
            }

            if (InputDataChart.ChartAreas[0].AxisY.Minimum == InputDataChart.ChartAreas[0].AxisY.Maximum)
            {
                InputDataChart.ChartAreas[0].AxisY.Maximum = InputDataChart.ChartAreas[0].AxisY.Minimum + 1;
            }
            if (ProcessedDataChart.ChartAreas[0].AxisY.Minimum == ProcessedDataChart.ChartAreas[0].AxisY.Maximum)
            {
                ProcessedDataChart.ChartAreas[0].AxisY.Maximum = ProcessedDataChart.ChartAreas[0].AxisY.Minimum + 1;
            }
            InputDataChart.ChartAreas[0].AxisX.Title = "Number of Frames";
            ProcessedDataChart.ChartAreas[0].AxisX.Title = "Number of Frames";
            InputDataChart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            InputDataChart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            ProcessedDataChart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            ProcessedDataChart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
        }

        private void StartGraphs()
        {
            //Start the individual threads
            InputmeasThread = new Thread(new ThreadStart(this.StreamInputdata))
            {
                IsBackground = true
            };
            InputmeasThread.Start();
            ProcmeasThread = new Thread(new ThreadStart(this.StreamProcesseddata))
            {
                IsBackground = true
            };
            ProcmeasThread.Start();
        }

        private void StreamInputdata()
        {

            while (incomingDataStarted)
            {
                
                if (InputDataChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateInputgraph(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(500);
            }
        }

        private void UpdateInputgraph()
        {
            InputDataChart.Series.Clear();
            for (int i = 0; i < Plot_channels; i++)
            {
                InputDataChart.Series.Add(Plotcheckedactualnamelist[i]);
                InputDataChart.Series[Plotcheckedactualnamelist[i]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                InputDataChart.Series[Plotcheckedactualnamelist[i]].BorderWidth = 2;
                InputDataChart.Series[Plotcheckedactualnamelist[i]].Points.Clear();
                for (int j = 0; j < graph_length-1; j++)
                {
                    InputDataChart.Series[Plotcheckedactualnamelist[i]].Points.AddY(Inputarray[i][j]);
                }
            }
            // temp
            //if (Algorithm.New_config.numberOfFrame >= 330)
            //{
            //    InputDataChart.SaveImage("C:\\Users\\Jacob\\Desktop\\temp\\i" + temp1 + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            //    temp1 = (Int32.Parse(temp1) + 1).ToString();
            //}
        }

        private void StreamProcesseddata()
        {
            while (incomingDataStarted)
            {
               
                if (ProcessedDataChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateProcessedgraph(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(500);
            }
        }

        private void UpdateProcessedgraph()
        {
            ProcessedDataChart.Series.Clear();
            for (int i = 0; i < Plot_channels; i++)
            {
                ProcessedDataChart.Series.Add(Plotcheckedprocessednamelist[i]);
                ProcessedDataChart.Series[Plotcheckedprocessednamelist[i]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                ProcessedDataChart.Series[Plotcheckedprocessednamelist[i]].BorderWidth = 2;
                ProcessedDataChart.Series[Plotcheckedprocessednamelist[i]].Points.Clear();
                for (int j = 0; j < graph_length-1; j++)
                {
                    ProcessedDataChart.Series[Plotcheckedprocessednamelist[i]].Points.AddY(Processedarray[i][j]);
                }
            }
            // temp
            //if (Algorithm.New_config.numberOfFrame >= 330)
            //{
            //    ProcessedDataChart.SaveImage("C:\\Users\\Jacob\\Desktop\\temp\\o" + temp2 + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            //    temp2 = (Int32.Parse(temp2) + 1).ToString();
            //}
        }

        private void Plot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (incomingDataStarted)
            {
                Plot_started = false;

                //forecefully stop all started threads
                InputmeasThread.Abort();
                ProcmeasThread.Abort();
            }
        }
    }
}