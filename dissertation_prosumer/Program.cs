using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dissertation_prosumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var env = new ActressMas.EnvironmentMas(0, 1500);

            var prosumerAgent1 = new ProsumerAgent();
            var prosumerAgent2 = new ProsumerAgent();
            var prosumerAgent3 = new ProsumerAgent();
            env.Add(prosumerAgent1, "prosumer1");
            env.Add(prosumerAgent2, "prosumer2");
            env.Add(prosumerAgent3, "prosumer3");

            env.Start();
        }
    }
}
