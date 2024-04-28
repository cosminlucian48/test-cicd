using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActressMas;
using SQLite;

namespace dissertation_prosumer
{
    internal class ProsumerAgent : Agent
    {
        public int counter = 0;
        public int prosumerId = 0;

        public ProsumerAgent() : base() { }
        public override void Setup()
        {
            prosumerId = Int32.Parse(this.Name.Remove(0, 8));
            Console.WriteLine("[{0} {1}] Hi", this.Name, prosumerId);
            
        }

        public override void Act(Message message)
        {
            Console.WriteLine("\t[{1} -> {0}]: {2}", this.Name, message.Sender, message.Content);

            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters);

            switch (action)
            {
                case "started":
                    counter += 1;
                    break;
                case "load_update":
                    break;
                case "generation_update":
                    break;
                default:
                    break;
            }
        }
    }
}
