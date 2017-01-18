using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleServerHost;


namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(DataBase)))
            {
                host.Open();
                Console.WriteLine("Server is running...\n");
                Console.WriteLine("Press any key to stop the server");
                Console.Read();
                host.Close();
            }
        }
    }
}
