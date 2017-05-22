using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plotTool
{
    public partial class PlottingWindow : Form
    {
        // member variables
        //private double[] time;
        private List<double> time;
        private double[,] data;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        List<int> selectedItems;
        string[] fields;
        System.Windows.Forms.Timer timer1;

        int time_window_ms = 10000;
        double y_min = -10;
        double y_max = 10;

        public PlottingWindow()
        {
            InitializeComponent();
            this.FormClosing += plottingWindow_FormClosing;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += updateChart;
            timer1.Interval = 10;
            timer1.Start();

            
        }


        public void SetData(List<double> time, double[,] data, List<int> selectedItems, string[] fields)
        {
            this.time = time;
            this.data = data;
            this.selectedItems = selectedItems;
            this.fields = fields;

            chart1.Series.Clear();
            for (int i = 0; i < selectedItems.Count; i++)
            {
                chart1.Series.Add(fields[selectedItems[i]]);
                chart1.Series[fields[selectedItems[i]]].Points.Clear();
                chart1.Series[fields[selectedItems[i]]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            }

            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            setRange();
            
        }

        private void setRange()
        {
            chart1.ChartAreas[0].AxisY.Maximum = 10.2; // need to find a better way to change that
            chart1.ChartAreas[0].AxisX.Maximum = time_window_ms * 0.001;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = y_min;
            chart1.ChartAreas[0].AxisY.Maximum = y_max;
        }

        private void updateChart(object sender, EventArgs e)
        {
            for (int j = 0; j < selectedItems.Count; j++)
            {
                chart1.Series[fields[selectedItems[j]]].Points.Clear();
                for (int i = 0; i < data.GetLength(1); i++)
                    chart1.Series[fields[selectedItems[j]]].Points.AddXY((time[i] - time[data.GetLength(1) - 1] + time_window_ms) * 0.001, data[selectedItems[j], i]);
            }


        }

        private void plottingWindow_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer1.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double x_range = System.Convert.ToDouble(numericUpDown1.Value);
            time_window_ms = System.Convert.ToInt32(x_range * 1000);
            setRange();
        }

 
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            y_min = System.Convert.ToDouble(numericUpDown2.Value);
            setRange();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            y_max = System.Convert.ToDouble(numericUpDown3.Value);
            setRange();
        }
    }
}
