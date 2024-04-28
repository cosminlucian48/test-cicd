﻿using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace dissertation_prosumer
{
    internal class ProsumerGeneratorAgent : Agent
    {
        public int counter = 0;
        public string myProsumerName = "";
        public int myProsumerId = 0;
        public double currentLoad = 0.0;
        public DateTime lastTimestamp;
        public int getNewLoadInterval = 2 * Utils.Delay;
        private System.Timers.Timer _timer;

        public ProsumerGeneratorAgent(string prosumerName): base(){
            myProsumerName = prosumerName;
            myProsumerId = Int32.Parse(prosumerName.Remove(0, 8));

            lastTimestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            _timer = new System.Timers.Timer();
            _timer.Elapsed += t_Elapsed;
            _timer.Interval = getNewLoadInterval;
        }

        public override void Setup()
        {
            Console.WriteLine("[{0}] Hi - Prosumer Generator started", this.Name);
            _timer.Start();
        }

        private async void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<ProsumerGeneratorDataModel> results = await DatabaseConnection.Instance.GetProsumerGenerationByIdAsync(myProsumerId, lastTimestamp.ToString("hh:mm:ss tt"));
            ProsumerGeneratorDataModel res = results.FirstOrDefault();
            if (res == null) return;
            Send(myProsumerName, Utils.Str("generation_update", res.GenerationRate));
            lastTimestamp = lastTimestamp.AddMinutes(15);

            return;
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
