using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using Cars.Vehicles;

namespace ConsoleServerHost
{
    public class Operation:IOperation
    {
        readonly VehiclesXmlSerializer serializer;
        public Operation()
        {
            this.serializer = new VehiclesXmlSerializer("VehiclesDB.xml");
            this.Read();
        }
        
        public void Add(Vehicle vehicle)
        {
            Thread.Sleep(5000);//for test
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
            this.serializer.Refresh(vehicle);
        }

        /// <summary>
        /// Name - is a vehicle that will be replaced
        /// Vehicle - vehicle is a vehicle on which vehicle will be replaced
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vehicle"></param>
        public void Replace(string name,Vehicle vehicle)
        {
            this.serializer.Replace(name,vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            this.serializer.Remove(vehicle);
        }
        public List<Vehicle> Read()
        {
            List<Vehicle> temp = this.serializer.Desirialize();
            return temp;
        }
        public void Clear()
        {
            this.serializer.Clear();
        }
    }
}