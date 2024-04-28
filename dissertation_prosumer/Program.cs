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
            //DataAccess.InitializeDatabase();
            var world = new World(0, Utils.Delay);

            var prosumerAgent1 = new ProsumerAgent();
            var prosumerAgent2 = new ProsumerAgent();
            var prosumerAgent3 = new ProsumerAgent();
            world.AddProsumer(prosumerAgent1, "prosumer1");
            /*world.AddProsumer(prosumerAgent2, "prosumer2");
            world.AddProsumer(prosumerAgent3, "prosumer3");*/

            world.Start();
        }
    }
}
