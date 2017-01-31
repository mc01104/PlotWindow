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
        private double[] time;
        private double[,] data;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        List<int> selectedItems;
        string[] fields;
        System.Windows.Forms.Timer timer1;


        public PlottingWindow()
        {
            InitializeComponent();
            this.FormClosing += plottingWindow_FormClosing;

            //chart1.ChartAreas[0].AxisY.Minimum = -1.5;
            //chart1.ChartAreas[0].AxisY.Maximum = 1.5;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += updateChart;
            timer1.Interval = 10;
            timer1.Start();
        }


        public void SetData(double[] time, double[,] data, List<int> selectedItems, string[] fields)
        {
            this.time = time;
            this.data = data;
            this.selectedItems = selectedItems;
            this.fields = fields;


            chart1.Series["Series1"].Name = fields[selectedItems[0]];
            chart1.Series[fields[selectedItems[0]]].Points.Clear();
            chart1.Series[fields[selectedItems[0]]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

        }

        private void updateChart(object sender, EventArgs e)
        {

            // TODO: make it general to plot multiple series
            chart1.Series[fields[selectedItems[0]]].Points.Clear();
            for (int i = 0; i < data.GetLength(1); i++)
            {
                chart1.Series[fields[selectedItems[0]]].Points.AddXY(time[i], data[selectedItems[0], i]);
            }
            //UpdateData();
        }

        private void plottingWindow_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer1.Stop();
        }
    }
}
