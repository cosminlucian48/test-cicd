using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActressMas;

namespace dissertation_prosumer
{
    internal class ProsumerAgent : Agent
    {
        public int counter = 0;
        public override void Setup()
        {
            Console.WriteLine("[{0}] Hi", this.Name);
            Broadcast("started");
        }

        public override void Act(Message message)
        {
            Console.WriteLine("\t[{1} -> {0}]: {2} - counter = {3}", this.Name, message.Sender, message.Content, counter);

            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters);

            switch (action)
            {
                case "started":
                    counter += 1;
                    Send(message.Sender, "started");
                    break;

                default:
                    break;
            }
        }
    }
}
