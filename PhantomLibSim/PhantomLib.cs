using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace PhantomLib
{
    public class Phantom
    {
        public const string EIMONanoAccelLR = "EINALR";
        public const string EIMONanoAccelHR = "EINAHR";
        public const string EIMONanoTempNC = "EINTNC";
        public const string EIMONanoTempTP = "EINTTP";
        public const string EIMONanoRPM = "EINRPM";
        public const string EIMONanoVoltage = "EINVoltage";
        public const string EIMONanoCurrent = "EINCurrent";
        public const string EIMONanoBiaxial = "EINABA";
        public const string EIMONanoAccelGP = "EINAGP";
        

        private bool ack_packages = false;
        private bool should_stop_threads = false;
        private ProcessPhantomMessages m_messageProcessor;


        public delegate void ProcessPhantomMessages(Messages message, MessageData data);


        string[] simulator_list =
        {
            "999999981",
            "999999982",
            "999999983",
            "999999984",
            "999999985",
            "999999986",
            "999999987",
            "999999988",
            "999999989",
            "999999990",
            "999999991",
            "999999992",
            "999999993",
            "999999994",
            "999999995",
            "999999996",
            "999999997",
            "999999998",
        };


        public enum Messages
        {
            RECEIVED_EIMOINFO,
            RECEIVED_ID_INFO,
            RECEIVED_PHANTOM_ACCEL_DATA,
            RECEIVED_PHANTOM_TEMP_DATA,
            RECEIVED_PHANTOM_ACCEL_SETTINGS,
            RECEIVED_PHANTOM_ACCEL_STATE,
            RECEIVED_PHANTOM_CURRENT_DATA,
            RECEIVED_PHANTOM_RPM_DATA,
            RECEIVED_PHANTOM_GP_SETTINGS,
            RECEIVED_PHANTOM_GP_STATE,
        }


        public enum Reason
        {
            REQUESTED = 1,
            SCHEDULED = 2,
            ALARM = 3
        }

        public enum TemperatureType
        {
            THERMOCOUPLE = 1,
            INFRARED = 2
        }


        public class MessageData
        {
            public string device;
        }

        public class MessageDataEIMO : MessageData
        {
            public Reason recording_reason;
            public string ip_address;
            public string phantom_code;
        }

        public class MessageDataEIMONanoAccel : MessageData
        {
            public Reason recording_reason;
            public string phantom_code;
            public float temperature;
            public short[] channel1;
            public short[] channel2;
            public short[] channel3;
            public double calibration;
            public int sample_rate;
        }

        public class MessageDataEIMONanoTemp : MessageData
        {
            public Reason recording_reason;
            public string phantom_code;
            public TemperatureType type;
            public float temperature;
            public float battery;
            public float ambient_temperature;
            public float module_temperature;
        }

        public class MessageDataIDInfo : MessageData
        {
            public string ip_address;
            public string phantom_code;
        }
        
        public class MessageEIMONanoAccelSettings : MessageData
        {
            public string phantom_code;
            public int send_interval;
            public int sample_rate;
            public int samples_to_get;
            public int range;
            public float alarm1;
            public float alarm2;
            public float alarm3;
            public int alarmcheck_interval;
        }
        public class MessageEIMONanoAccelState : MessageData
        {
            public string phantom_code;
            public float battery;
            public float temperature;
            public float rms1;
            public float rms2;
            public float rms3;
        }

        public class MessageEIMONanoCurrentData : MessageData
        {
            public string phantom_code;
            public float battery;
            public float module_temperature;
            public float current1;
            public float current2;
            public float current3;
        }
        public class MessageEIMONanoRPMData : MessageData
        {
            public string phantom_code;
            public float battery;
            public float module_temperature;
            public float rpm;
        }

        public class MessageEIMONanoGPSettings : MessageData
        {
            public string phantom_code;
            public int send_interval;
            public int sample_rate;
            public int samples_to_get;
            public int range;
            public float alarm1;
            public float alarm2;
            public int alarmcheck_interval;
        }
        public class MessageEIMONanoGPAccelState : MessageData
        {
            public string phantom_code;
            public float battery;
            public float temperature;
            public float rms1;
            public float rms2;
            public float vpp_min1;
            public float vpp_max1;

            public float vpp_min2;
            public float vpp_max2;

            public float vpp_min01;
            public float vpp_max01;

            public float vpp_min02;
            public float vpp_max02;
        }

        private static Phantom _PhantomInstance = null;


        public static Phantom Instance
        {
            get
            {
                if (_PhantomInstance == null)
                {
                    _PhantomInstance = new Phantom();
                }

                return _PhantomInstance;
            }
        }

        private Phantom()
        {
        }

        public void start(ProcessPhantomMessages messageProcessor, bool receive_vibration_data)
        {
            should_stop_threads = false;
            ack_packages = receive_vibration_data;

            m_messageProcessor = messageProcessor;

            Thread newThread = new Thread(SimThread);
            newThread.Start(messageProcessor);
        }
        
        
        public void stop()
        {
            should_stop_threads = true;
        }
        

        public short[] GetTestSignal(int Length, Random rnd)
        {
            short[] signal = new short[Length - 1 + 1];
            int div = rnd.Next(10, 100);
            double Mult = 100;

            for (var i = 0; i < Length; i++)
            {
                signal[i] = (short) ((rnd.Next(1, 100) / (1000 / Mult)) * 1);
                signal[i] += (short)(Math.Cos(i / (double)div) * Mult); // 1000
            }
            return signal;
        }

        private void SimThread(object data)
        {
            Random rnd = new Random();
            uint seconds = 0;

            while (true)
            {
                if (seconds % 5 == 0)
                {
                    MessageDataEIMONanoAccel message_data = new MessageDataEIMONanoAccel();

                    message_data.phantom_code = simulator_list[rnd.Next(0, simulator_list.Length)];
                    message_data.channel1 = GetTestSignal(25600, rnd);
                    message_data.channel2 = GetTestSignal(25600, rnd);
                    message_data.channel3 = GetTestSignal(25600, rnd);
                    message_data.calibration = 0.5;
                    message_data.temperature = rnd.Next(1000, 3500) / 100;
                    message_data.recording_reason = Reason.SCHEDULED;
                    message_data.sample_rate = 25600;
                    message_data.device = EIMONanoAccelLR;

                    m_messageProcessor(Messages.RECEIVED_PHANTOM_ACCEL_DATA, message_data);
                }

                if ((seconds + 2) % 5 == 0)
                {
                    MessageEIMONanoAccelState message_data = new MessageEIMONanoAccelState();

                    message_data.phantom_code = simulator_list[rnd.Next(0, simulator_list.Length)];

                    message_data.rms1 = rnd.Next(100, 5000) / 100;
                    message_data.rms2 = rnd.Next(100, 5000) / 100;
                    message_data.rms3 = rnd.Next(100, 5000) / 100;

                    message_data.battery = rnd.Next(200, 400) / 100;
                    message_data.temperature = rnd.Next(1000, 3500) / 100;
                    message_data.device = EIMONanoAccelLR;


                    m_messageProcessor(Messages.RECEIVED_PHANTOM_ACCEL_STATE, message_data);

                }

                Thread.Sleep(1000);
                seconds++;

                if (should_stop_threads)
                    break;
            }
        }
    }
}
