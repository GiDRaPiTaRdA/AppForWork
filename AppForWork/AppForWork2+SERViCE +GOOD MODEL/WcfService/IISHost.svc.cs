using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using Cars.Vehicles;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Operation : IOperation
    {
        readonly VehiclesXmlSerializer serializer;
        public Operation()
        {
            this.serializer = new VehiclesXmlSerializer(@"C:\Users\Admin\Desktop\VehiclesDB.xml");
            this.Read();
        }

        public void Add(Vehicle vehicle)
        {
            Thread.Sleep(3000);//for test
            this.serializer.Add(vehicle);
        }
        public void AddMany(Vehicle[] vehicles)
        {
            foreach (var current in vehicles)
            {
                this.Add(current);
            }
           
        }
        public void Refresh(Vehicle vehicle)
        {
            Thread.Sleep(3000);//for test
            this.serializer.Refresh(vehicle);
        }
        /// <summary>
        /// Name - is a vehicle that will be replaced
        /// Vehicle - vehicle is a vehicle on which vehicle will be replaced
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vehicle"></param>
        public void Replace(string name, Vehicle vehicle)
        {
            Thread.Sleep(3000);//for test
            this.serializer.Replace(name, vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            Thread.Sleep(3000);//for test
            this.serializer.Remove(vehicle);
        }
        public List<Vehicle> Read()
        {
            Thread.Sleep(3000);//for test
            List<Vehicle> temp = this.serializer.Desirialize();
            return temp;
        }
        public void Clear()
        {
            Thread.Sleep(3000);//for test
            this.serializer.Clear();
        }
    }
}
