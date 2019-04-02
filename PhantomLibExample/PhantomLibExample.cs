using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Globalization;
using PhantomLib;

namespace PhantomLibExample
{
    class PhantomLibExample
    {
        static ConcurrentQueue<object[]> messagesQueue = new ConcurrentQueue<object[]>();
        static Dictionary<string, string> phantom_to_ip = new Dictionary<string, string>();

        static void processMessages(Phantom.Messages message, Phantom.MessageData data)
        {
            object[] parameters = new object[3];
            parameters[0] = message;
            parameters[1] = data;
            parameters[2] = DateTime.Now;

            messagesQueue.Enqueue(parameters);

            if (messagesQueue.Count > 100)
            {
                object[] dummy;
                messagesQueue.TryDequeue(out dummy);
            }
        }

        static void Main(string[] args)
        {
            Phantom.Instance.start(new Phantom.ProcessPhantomMessages(processMessages), true);

            while (true)
            {
                object[] parameters;
                if (messagesQueue.TryDequeue(out parameters))
                {
                    Phantom.Messages message = (Phantom.Messages)parameters[0];
                    Phantom.MessageData generic_data = (Phantom.MessageData)parameters[1];
                    DateTime message_time = (DateTime)parameters[2];

                    switch (message)
                    {
                        case Phantom.Messages.RECEIVED_ID_INFO:
                            {
                                Phantom.MessageDataIDInfo data = (Phantom.MessageDataIDInfo)generic_data;

                                phantom_to_ip[data.phantom_code] = data.ip_address;

                                Console.WriteLine("Id from " + data.phantom_code + " " + data.ip_address);

                                break;
                            }
                        case Phantom.Messages.RECEIVED_EIMOINFO:
                            {
                                Phantom.MessageDataEIMO data = (Phantom.MessageDataEIMO)generic_data;

                                phantom_to_ip[data.phantom_code] = data.ip_address;

                                break;
                            }
                        case Phantom.Messages.RECEIVED_PHANTOM_ACCEL_DATA:
                            {
                                Phantom.MessageDataEIMONanoAccel data = (Phantom.MessageDataEIMONanoAccel)generic_data;

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
                                        "C Battery " + data.battery.ToString() + " Module Temperature: " + data.module_temperature.ToString() + " (" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + ")\n");
                                }
                                else
                                {
                                    Console.WriteLine("TEmperature from termocopule " + data.phantom_code + " " + data.temperature.ToString() +
                                        "C Battery " + data.battery.ToString() + " Module Temperature: " + data.module_temperature.ToString() + " (" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + ")\n");
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
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
}