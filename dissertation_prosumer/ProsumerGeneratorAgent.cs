using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dissertation_prosumer
{
    internal class ProsumerGeneratorAgent : Agent
    {
        public int counter = 0;
        public string myProsumerName = "";

        public ProsumerGeneratorAgent(string prosumerName): base(){
            myProsumerName = prosumerName;
        }

        public override void Setup()
        {
            Console.WriteLine("[{0}] Hi", this.Name);
            Send(myProsumerName, "started");
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
