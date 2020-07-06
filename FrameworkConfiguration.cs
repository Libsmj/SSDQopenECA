// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:FrameworkConfiguration.cs
//Description: This code segment depicts the Database search window along with providing the user various options of openECA Framework creation.
//**********************************************************************************************************************************************
using System;
using System.Windows.Forms;
using System.Threading;

namespace SSDQopenECA
{
    public partial class FrameworkConfiguration : Form
    {
        public static string DB_filename = "";      //Database filename
        public static Thread Frameworkwindow_thread = new Thread(ThreadStart_for_NewFrameworkwindow);
        public static bool newframework = false;    //variable differentiating between New and Load Framework options
        public FrameworkConfiguration()
        {
            InitializeComponent();
        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            //Multiple instances of openECA are prohibited
            if (Frameworkwindow_thread.IsAlive || Algorithm.New_config.MainWindow_thread.IsAlive || Algorithm.Stored_config.MainWindow_thread.IsAlive)
            {
                MessageBox.Show("An instance of openECA framework creation window has been created and is running.Close the creation window and try again", "Error Information");
            }
            else
            {
                newframework = true;
                Frameworkwindow_thread = new Thread(ThreadStart_for_NewFrameworkwindow);
                Frameworkwindow_thread.TrySetApartmentState(ApartmentState.STA);
                Frameworkwindow_thread.Start();
            }

        }
        private static void ThreadStart_for_NewFrameworkwindow()
        {
            //Execute an object of Input_screen which refers to New openECA framwework creation option
            Algorithm.New_config = new Input_screen();
            Application.Run(Algorithm.New_config);
        }

        private void Presavedbutton_Click(object sender, EventArgs e)
        {
            if (Frameworkwindow_thread.IsAlive || Algorithm.New_config.MainWindow_thread.IsAlive || Algorithm.Stored_config.MainWindow_thread.IsAlive)
            {
                MessageBox.Show("An instance of openECA framework creation window has been created and is running.Close the creation window and try again", "Error Information");
            }
            else
            {
                newframework = false;
                Frameworkwindow_thread = new Thread(ThreadStart_for_SavedFrameworkwindow);
                Frameworkwindow_thread.TrySetApartmentState(ApartmentState.STA);
                Frameworkwindow_thread.Start();
            }

        }
        private static void ThreadStart_for_SavedFrameworkwindow()
        {
            //Execute an object of Input_screen which refers to loading of Stored openECA framwework creation option
            Algorithm.Stored_config = new Input_screen2();
            Application.Run(Algorithm.Stored_config);
        }

        private void FrameworkConfiguration_Load(object sender, EventArgs e)
        {
            optionsgroupbox.Enabled = false;           
        }

        private void DBSearchbutton_Click(object sender, EventArgs e)
        {
            optionsgroupbox.Enabled = false;
            try
            {
                var FD = new OpenFileDialog();      //File destination
                if (FD.ShowDialog() == DialogResult.OK)
                {
                    DB_textbox.Text = FD.FileName;  
                    DB_filename = DB_textbox.Text;  //Allocating the database filename as the text inside the DB_textbox
                    MessageBox.Show("Retrieving Data from the Database file in the specified location.", "Information");
                    optionsgroupbox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                DB_textbox.Text = FD.FileName;
            }
        }

        private void Helpbutton_Click(object sender, EventArgs e)
        {
            var Help_thread = new Thread(ThreadStart_for_Helpwindow);
            Help_thread.TrySetApartmentState(ApartmentState.STA);
            Help_thread.Start();
        }
        private static void ThreadStart_for_Helpwindow()
        {
            //Execute an object of Help class which contains additional details of the product.
            Helpwindow Help = new Helpwindow();
            Application.Run(Help);
        }
    }
}
