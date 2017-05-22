using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace plotTool
{
    public partial class Form1 : Form
    {

        //private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        int num_data_samples = 3000;
        //private double[] time;
        private List<double> time;
        //private double[,] plottingData;
        private double[,] plottingData;

        
        // network stuff
        private NetworkStream stream;
        private TcpClient client;

        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        // check box list
        string[] fields;

        public Form1()
        {
            //AllocConsole();
            
            InitializeComponent();
            ServerIPText.Text = "127.0.0.1";
            ServerPortText.Text = "27015";

            //time = new double[plottingWindow];
            time = new List<double>(num_data_samples);
            for (int i = 0; i < num_data_samples; i++)
                time.Add(Convert.ToDouble(0));
                //time[i] = Convert.ToDouble(0);

            plottingData = new double[1, num_data_samples];

            stopwatch.Start();
        }

        //[System.Runtime.InteropServices.DllImport("kernel32.dll")]
        //private static extern bool AllocConsole();

        private void PlotButton_Click(object sender, EventArgs e)
        {
            PlottingWindow win1 = new PlottingWindow();
            
            List<int> selectedItems = new List<int>();
            for(int i = 0 ; i < PlottingListBox.Items.Count; i++)
            {
                if (PlottingListBox.GetItemChecked(i))
                    selectedItems.Add(i);
            }
            win1.SetData(time, plottingData, selectedItems, fields);

            win1.Show();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(ServerIPText.Text, Convert.ToInt32(ServerPortText.Text));

                stream = client.GetStream();
            
                Thread t = new Thread(NetworkCommunication);
                t.Start(stream);

                Thread.Sleep(1000);
            
                PlottingListBox.DisplayMember = "Text";
                PlottingListBox.ValueMember = "Value";
                for (int i = 0; i < fields.Length; i++)
                    PlottingListBox.Items.Add(fields[i]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server!");
            }
        }

        public void NetworkCommunication(object stream)
        {
            
            NetworkStream streamLocal = (NetworkStream)stream;

            Byte[] data = new Byte[256];
            Byte[] data2 = new Byte[256];
            String responseData = String.Empty;

            do
            {
                Int32 bytes = streamLocal.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                fields = new string[1];
                double[] values = new double[1];
                int numFields =  parseStream(responseData, ref fields, ref values);
                if(plottingData.GetLength(0) != numFields)
                    plottingData = new double[numFields, num_data_samples];
                
                //checkBoxList = fields;
                updateData(values);

                data2 = System.Text.Encoding.ASCII.GetBytes("none");
                streamLocal.Write(data2, 0, data2.Length);
                Thread.Sleep(10);
            } while (data2.GetLength(0) > 0);

            // Close everything.
            streamLocal.Close();
            client.Close();



            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

        private void updateData(double[] values)
        {
      
            for (int rowIdx = 0; rowIdx < plottingData.GetLength(0); rowIdx++)
            {
                for (int i = 0; i < plottingData.GetLength(1) - 1; i++)
                {
                    plottingData[rowIdx, i] = plottingData[rowIdx, i + 1];
                    //if (rowIdx == 0)
                    //    time[i] = time[i + 1];
                }

                if (rowIdx == 0)
                {
                    long time_ms = stopwatch.ElapsedMilliseconds;
                    
                    time.Add(time_ms);
                    time.RemoveAt(0);

                    //time[plottingData.GetLength(1) - 1] = time_ms;

                    //System.Console.WriteLine(time_ms.ToString());
                }
                plottingData[rowIdx, plottingData.GetLength(1) - 1] = values[rowIdx];
            }

        }


        private int parseStream(string responseData, ref string[] fields, ref double[] values)
        {
            string[] dataString = responseData.Split(',');
            int numFields = dataString.Length / 2;

            fields = new string[numFields];
            Array.Copy(dataString, 0, fields, 0, numFields);

            values = new double[numFields];
            for (int i = 0; i < numFields; i++)
                values[i] = Convert.ToDouble(dataString[i + numFields]);

            return numFields;
        }

        private void PlottingListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
