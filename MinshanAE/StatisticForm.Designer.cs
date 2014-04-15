namespace MinshanAE
{
    partial class StatisticForm
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 69868.8D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 462285.81D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 402992.37D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 985963.23D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 462219.03D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 524219.13D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 82966.32D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 174614.85D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 7878.06D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 273201.84D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1709.64D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 16761.69D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Title = "图例";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.Label = "#LEGENDTEXT";
            dataPoint1.LegendText = "常绿阔叶林";
            dataPoint1.ToolTip = "#VAL";
            dataPoint2.Label = "#LEGENDTEXT";
            dataPoint2.LegendText = "落叶阔叶林";
            dataPoint2.ToolTip = "#VAL";
            dataPoint3.Label = "#LEGENDTEXT";
            dataPoint3.LegendText = "针阔混交林";
            dataPoint3.ToolTip = "#VAL";
            dataPoint4.Label = "#LEGENDTEXT";
            dataPoint4.LegendText = "针叶林";
            dataPoint4.ToolTip = "#VAL";
            dataPoint5.Label = "#LEGENDTEXT";
            dataPoint5.LegendText = "灌丛";
            dataPoint5.ToolTip = "#VAL";
            dataPoint6.Label = "#LEGENDTEXT";
            dataPoint6.LegendText = "草甸";
            dataPoint6.ToolTip = "#VAL";
            dataPoint7.Label = "#LEGENDTEXT";
            dataPoint7.LegendText = "流石滩植被";
            dataPoint7.ToolTip = "#VAL";
            dataPoint8.AxisLabel = "#LEGENDTEXT";
            dataPoint8.Label = "#LEGENDTEXT";
            dataPoint8.LegendText = "冰雪带";
            dataPoint8.ToolTip = "#VAL";
            dataPoint9.Label = "#LEGENDTEXT";
            dataPoint9.LegendText = "河流与水体";
            dataPoint9.ToolTip = "#VAL";
            dataPoint10.Label = "#LEGENDTEXT";
            dataPoint10.LegendText = "耕地";
            dataPoint10.ToolTip = "#VAL";
            dataPoint11.Label = "#LEGENDTEXT";
            dataPoint11.LegendText = "居民点";
            dataPoint11.ToolTip = "#VAL";
            dataPoint12.Label = "#LEGENDTEXT";
            dataPoint12.LegendText = "裸地";
            dataPoint12.ToolTip = "#VAL";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.Points.Add(dataPoint7);
            series1.Points.Add(dataPoint8);
            series1.Points.Add(dataPoint9);
            series1.Points.Add(dataPoint10);
            series1.Points.Add(dataPoint11);
            series1.Points.Add(dataPoint12);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(658, 414);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "统计图";
            title1.Name = "Title1";
            title1.Text = "岷山地区植被覆盖和土地利用类型";
            this.chart1.Titles.Add(title1);
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 414);
            this.Controls.Add(this.chart1);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}