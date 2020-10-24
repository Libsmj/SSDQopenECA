namespace SSDQopenECA
{
    partial class PlotFigure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotFigure));
            this.InputPlotLabel = new System.Windows.Forms.Label();
            this.ProcessedPlotlabel = new System.Windows.Forms.Label();
            this.InputDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ProcessedDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.InputDataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessedDataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // InputPlotLabel
            // 
            this.InputPlotLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InputPlotLabel.AutoSize = true;
            this.InputPlotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPlotLabel.Location = new System.Drawing.Point(413, 10);
            this.InputPlotLabel.Name = "InputPlotLabel";
            this.InputPlotLabel.Size = new System.Drawing.Size(174, 20);
            this.InputPlotLabel.TabIndex = 47;
            this.InputPlotLabel.Text = "Input Measurements";
            // 
            // ProcessedPlotlabel
            // 
            this.ProcessedPlotlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProcessedPlotlabel.AutoSize = true;
            this.ProcessedPlotlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessedPlotlabel.Location = new System.Drawing.Point(392, 357);
            this.ProcessedPlotlabel.Name = "ProcessedPlotlabel";
            this.ProcessedPlotlabel.Size = new System.Drawing.Size(216, 20);
            this.ProcessedPlotlabel.TabIndex = 48;
            this.ProcessedPlotlabel.Text = "Processed Measurements";
            // 
            // InputDataChart
            // 
            this.InputDataChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 87F;
            this.InputDataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.InputDataChart.Legends.Add(legend1);
            this.InputDataChart.Location = new System.Drawing.Point(12, 33);
            this.InputDataChart.Name = "InputDataChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Inputseries";
            this.InputDataChart.Series.Add(series1);
            this.InputDataChart.Size = new System.Drawing.Size(960, 298);
            this.InputDataChart.TabIndex = 46;
            this.InputDataChart.Text = "Input Data Chart";
            // 
            // ProcessedDataChart
            // 
            this.ProcessedDataChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 87F;
            this.ProcessedDataChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ProcessedDataChart.Legends.Add(legend2);
            this.ProcessedDataChart.Location = new System.Drawing.Point(12, 380);
            this.ProcessedDataChart.Name = "ProcessedDataChart";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Processedseries";
            this.ProcessedDataChart.Series.Add(series2);
            this.ProcessedDataChart.Size = new System.Drawing.Size(960, 298);
            this.ProcessedDataChart.TabIndex = 45;
            this.ProcessedDataChart.Text = "Processed Data Chart";
            // 
            // PlotFigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.InputPlotLabel);
            this.Controls.Add(this.ProcessedPlotlabel);
            this.Controls.Add(this.InputDataChart);
            this.Controls.Add(this.ProcessedDataChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlotFigure";
            this.Text = "Figure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Plot_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.InputDataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessedDataChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputPlotLabel;
        private System.Windows.Forms.Label ProcessedPlotlabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart InputDataChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ProcessedDataChart;
    }
}