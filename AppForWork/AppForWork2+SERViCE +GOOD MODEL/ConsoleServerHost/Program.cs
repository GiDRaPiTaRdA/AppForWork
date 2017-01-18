using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Cars.Vehicles;
using ConsoleServerHost;

namespace ConsoleServerHost
{
    [ServiceBehavior]
    class Program
    { 
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof (ConsoleServerHost.Operation)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Server is running...\n");
                    Console.WriteLine("Press any key to stop the server");
                    Console.Read();
                    host.Close();
                }
                catch (AddressAccessDeniedException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }

        }
    }
}
