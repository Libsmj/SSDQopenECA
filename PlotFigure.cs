using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using MathNet.Numerics.LinearAlgebra;

namespace SSDQopenECA
{
    public partial class PlotFigure : Form
    {
        private bool incomingDataStarted = false;   //Variable to check whether data from openECA has started streaming in     
        private Thread InputmeasThread;             //Thread for plotting Input measurements
        private Thread ProcmeasThread;              //Thread for plotting Processed measurements
        private int graph_length = 200;             //Number of Frames plotted in GUI
        private Vector<double> A_data;              //Actual data
        private Vector<double> P_data;              //Processed data
        private double[][] Inputarray = new double[1000][];         //Array representing data of Input number of channels(1000 max)
        private double[][] Processedarray = new double[1000][];     //Array representing data of Output number of channels(1000 max)
        private int Plot_channels;
        private List<string>[] Inentrynamelist = new List<string>[5];
        private List<string> PlotInentrynamelist = new List<string>();          //Input entries required for plotting
        private List<string> Plotcheckedactualnamelist = new List<string>();    //Name of Input channels selected for plotting
        private List<string> Plotcheckedprocessednamelist = new List<string>(); //Name of Output channels for plotting
        private List<int> Plotcheckedindexlist = new List<int>();
        private int Meas;
        private List<string>[] IPchannelnamelist_updated = new List<string>[5];
        private bool SSDQ_started;
        private Matrix<double> submatrix;
        private int wdsize = 0;
        private string Channelnameprefix;
        public bool Plot_started = false;

        //Used for dynamic axes updation
        private double max_proc = 0;    // max value of processed measurements in the array
        private double max_input = 0;   // max value of input measurements in the array
        private double min_proc = 0;    // min value of processed measurements in the array
        private double min_input = 0;   // min value of input measurements in the array

        public PlotFigure(CheckedListBox PlotChannelList, int meas)
        {
            InitializeComponent();

            Meas = meas;
            wdsize = ParameterForm.L;
            IPchannelnamelist_updated = Algorithm.SSDQ_config.IPchannelnamelist_updated;
            Inentrynamelist = Algorithm.SSDQ_config.Inentrynamelist_updated;
            Channelnameprefix = Algorithm.SSDQ_config.Channelnameprefix;

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

        public void Update_Measurements()
        {
            if (SSDQ_started && Plot_started)
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
                for (int j = 0; j < graph_length - 1; j++)
                {
                    InputDataChart.Series[Plotcheckedactualnamelist[i]].Points.AddY(Inputarray[i][j]);
                }
            }
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
                for (int j = 0; j < graph_length - 1; j++)
                {
                    ProcessedDataChart.Series[Plotcheckedprocessednamelist[i]].Points.AddY(Processedarray[i][j]);
                }
            }
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
