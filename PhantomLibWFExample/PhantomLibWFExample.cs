using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PhantomLib;

namespace PhantomLibWFExample
{
    public partial class PhantomLibWFExample : Form
    {
        class ModuleData
        {
            public string module_type;
        }

        class AccelModuleData :  ModuleData
        {
            public float rms_channel1;
            public float rms_channel2;
            public float rms_channel3;

            public float module_temperature;
            public float module_battery;

            public Int16[] channel1;
            public Int16[] channel2;
            public Int16[] channel3;

            public DateTime? last_update_rms = null;
            public DateTime? last_update_data = null;
        }

        Dictionary<string, object> phantom_to_data = new Dictionary<string, object>();


        public PhantomLibWFExample()
        {
            InitializeComponent();
        }

        public void processMessages(Phantom.Messages message, Phantom.MessageData data)
        {
            object[] parameters = new object[2];
            parameters[0] = message;
            parameters[1] = data;

            this.Invoke(new Phantom.ProcessPhantomMessages(processMessagesMainThread), parameters);
        }

        public void processMessagesMainThread(Phantom.Messages message, Phantom.MessageData generic_data)
        {
            switch (message)
            {
                case Phantom.Messages.RECEIVED_ID_INFO:
                    {
                        Phantom.MessageDataIDInfo data = (Phantom.MessageDataIDInfo)generic_data;

                        //phantom_to_ip[data.phantom_code] = data.ip_address;

                        Console.WriteLine("Id from " + data.phantom_code + " " + data.ip_address);

                        break;
                    }
                case Phantom.Messages.RECEIVED_EIMOINFO:
                    {
                        Phantom.MessageDataEIMO data = (Phantom.MessageDataEIMO)generic_data;

                        //phantom_to_ip[data.phantom_code] = data.ip_address;

                        break;
                    }
                case Phantom.Messages.RECEIVED_PHANTOM_ACCEL_DATA:
                    {
                        Phantom.MessageDataEIMONanoAccel data = (Phantom.MessageDataEIMONanoAccel)generic_data;
                        AccelModuleData mem_data = null;

                        try
                        {
                            mem_data = (AccelModuleData) phantom_to_data[data.phantom_code];
                        }
                        catch (Exception)
                        {
                            mem_data = new AccelModuleData();
                            phantom_to_data[data.phantom_code] = mem_data;

                            phantomListBox.Items.Add(data.phantom_code);
                        }

                        mem_data.module_type = data.device;
                        mem_data.channel1 = data.channel1;
                        mem_data.channel2 = data.channel2;
                        mem_data.channel3 = data.channel3;
                        mem_data.last_update_data = DateTime.Now;
                        updateui_if_selected(data.phantom_code);

                        Console.WriteLine("Data from " + data.phantom_code);

                        
                        break;
                    }
                case Phantom.Messages.RECEIVED_PHANTOM_TEMP_DATA:
                    {
                        Phantom.MessageDataEIMONanoTemp data = (Phantom.MessageDataEIMONanoTemp)generic_data;

                        if (data.type == Phantom.TemperatureType.INFRARED)
                        {
                            Console.WriteLine("TEmperature from infrarred " + data.phantom_code + " Object Temp " + data.temperature.ToString() +
                                " Ambient Temp " + data.ambient_temperature.ToString() +
                                "C Battery " + data.battery.ToString() + " Module Temperature: " + data.module_temperature.ToString() + " (" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")\n");
                        }
                        else
                        {
                            Console.WriteLine("TEmperature from termocopule " + data.phantom_code + " " + data.temperature.ToString() +
                                "C Battery " + data.battery.ToString() + " Module Temperature: " + data.module_temperature.ToString() + " (" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")\n");
                        }

                        break;
                    }
                case Phantom.Messages.RECEIVED_PHANTOM_ACCEL_SETTINGS:
                    {
                        Phantom.MessageEIMONanoAccelSettings data = (Phantom.MessageEIMONanoAccelSettings)generic_data;

                        Console.WriteLine("Settings from " + data.phantom_code + " send interval: " + data.send_interval.ToString()
                            + " Sample Rate: " + data.sample_rate.ToString()
                            + " Samples to Get: " + data.samples_to_get.ToString()
                            + " Range: " + data.range.ToString() + "g"
                            + " AlarmX: " + data.alarm1.ToString() + "mm/s"
                            + " AlarmY: " + data.alarm2.ToString() + "mm/s"
                            + " AlarmZ: " + data.alarm3.ToString() + "mm/s"
                            + "Alarm Check Interval " + data.alarmcheck_interval.ToString() + "s"
                            + " (" + System.DateTime.Now.ToString() + ")"
                            + "\r\n");


                        break;
                    }
                case Phantom.Messages.RECEIVED_PHANTOM_ACCEL_STATE:
                    {
                        Phantom.MessageEIMONanoAccelState data = (Phantom.MessageEIMONanoAccelState)generic_data;

                        AccelModuleData mem_data = null;

                        try
                        {
                            mem_data = (AccelModuleData)phantom_to_data[data.phantom_code];
                        }
                        catch (Exception)
                        {
                            mem_data = new AccelModuleData();
                            phantom_to_data[data.phantom_code] = mem_data;

                            phantomListBox.Items.Add(data.phantom_code);
                        }

                        mem_data.module_type = data.device;
                        mem_data.module_battery = data.battery;
                        mem_data.module_temperature = data.temperature;
                        mem_data.rms_channel1 = data.rms1;
                        mem_data.rms_channel2 = data.rms2;
                        mem_data.rms_channel3 = data.rms3;

                        mem_data.last_update_rms = DateTime.Now;
                        updateui_if_selected(data.phantom_code);

                        Console.WriteLine("State from " + data.phantom_code + " RMS Channel1: " + data.rms1.ToString()
                            + " RMS Channel2: " + data.rms2.ToString()
                            + " RMS Channel13: " + data.rms3.ToString()
                            + " Battery voltage: " + data.battery.ToString() + "v"
                            + " Temperature: " + data.temperature.ToString() + "C"
                            + "\n");

                        break;
                    }
            }
        }

        private void PhantomLibWFExample_Load(object sender, EventArgs e)
        {
            Phantom.Instance.start(new Phantom.ProcessPhantomMessages(processMessages), true);

            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            /*
            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = 12;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 50;
            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 5;
            */



        }

        private void PhantomLibWFExample_FormClosing(object sender, FormClosingEventArgs e)
        {
            Phantom.Instance.stop();
        }

        private void recreate_series()
        {
            try
            {
                chart1.Series.Remove(chart1.Series["Channel X"]);
                chart1.Series.Remove(chart1.Series["Channel Y"]);
                chart1.Series.Remove(chart1.Series["Channel Z"]);
            }
            catch (Exception) { };


            chart1.Series.Add("Channel X");
            chart1.Series["Channel X"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Channel X"].Color = Color.Red;
            chart1.Series["Channel X"].IsVisibleInLegend = false;

            chart1.Series.Add("Channel Y");
            chart1.Series["Channel Y"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Channel Y"].Color = Color.Green;
            chart1.Series["Channel Y"].IsVisibleInLegend = false;

            chart1.Series.Add("Channel Z");
            chart1.Series["Channel Z"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Channel Z"].Color = Color.Blue;
            chart1.Series["Channel Z"].IsVisibleInLegend = false;


        }

        private void updateui_for_phantom(string code)
        {
            try
            {
                AccelModuleData mem_data;
                mem_data = (AccelModuleData)phantom_to_data[code];

                if (mem_data.last_update_rms != null)
                {
                    sensortype.Text = mem_data.module_type;

                    speed1.Text = mem_data.rms_channel1.ToString() + "mm/s";
                    speed2.Text = mem_data.rms_channel2.ToString() + "mm/s";
                    speed3.Text = mem_data.rms_channel3.ToString() + "mm/s";

                    battery.Text = mem_data.module_battery.ToString() + "V";
                    temperature.Text = mem_data.module_temperature.ToString() + "C";

                    last_updated_rms.Text = mem_data.last_update_rms.ToString();
                }
                else
                {
                    speed1.Text = "";
                    speed2.Text = "";
                    speed3.Text = "";

                    battery.Text = "";
                    temperature.Text = "";

                    last_updated_rms.Text = "";
                }


                recreate_series();

                if (mem_data.last_update_data != null)
                {
                    sensortype.Text = mem_data.module_type;

                    chart1.Series["Channel X"].Points.DataBindY(mem_data.channel1);
                    chart1.Series["Channel Y"].Points.DataBindY(mem_data.channel2);
                    chart1.Series["Channel Z"].Points.DataBindY(mem_data.channel3);

                    last_updated_data.Text = mem_data.last_update_data.ToString();
                }
                else
                {
                    last_updated_data.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void updateui_if_selected(string code)
        {
            if (phantomListBox.SelectedItem == null)
            {
                phantomListBox.SelectedIndex = 0;
            }
            else
            {
                string selected = phantomListBox.GetItemText(phantomListBox.SelectedItem);

                if (code == selected)
                {
                    updateui_for_phantom(code);
                }
            }
        }

        private void phantomListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string selected = phantomListBox.GetItemText(phantomListBox.SelectedItem);

            updateui_for_phantom(selected);
        }
    }
}
