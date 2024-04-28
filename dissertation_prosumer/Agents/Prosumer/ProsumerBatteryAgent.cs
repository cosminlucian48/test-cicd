using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace dissertation_prosumer
{
    internal class ProsumerBatteryAgent : Agent
    {
        private System.Timers.Timer _timer;
        public int counter = 0;
        public string myProsumerName = "";
        public int currentCapacity = 0; // storage value as WH.   1kwh of generated energy = 1 000 wh
        public int maximumCapacity = 1000;
        public int chargingEfficiency = 1;
        public int dischargingEfficiency = 1;
        public int batterySOCNotificationInterval = 2 * Utils.Delay;
        public int myProsumerId = 0;

        public ProsumerBatteryAgent(string prosumerName): base()
        {
            myProsumerName = prosumerName;
            myProsumerId = Int32.Parse(prosumerName.Remove(0, 8));

            _timer = new System.Timers.Timer();
            _timer.Elapsed += t_Elapsed;
            _timer.Interval = batterySOCNotificationInterval;
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Send(this.myProsumerName, Utils.Str("battery_soc",this.currentCapacity));
            this.currentCapacity += 10;
            return;
        }

        public override void Setup()
        {
            Console.WriteLine("[{0}] Hi", this.Name);
            Send(myProsumerName, "started");
            _timer.Start();
        }

        public override void Act(Message message)
        {
            Console.WriteLine("\t[{1} -> {0}]: {2} - counter = {3}", this.Name, message.Sender, message.Content, counter);

            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters);

            switch (action)
            {
                case "started":
                    if (message.Sender == myProsumerName)
                    {
                        counter += 1;
                        Send(message.Sender, "started");
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
