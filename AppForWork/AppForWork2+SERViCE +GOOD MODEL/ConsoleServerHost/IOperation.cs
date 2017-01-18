using System.Collections.Generic;
using System.ServiceModel;
using Cars.Vehicles;

//using Cars.Vehicles;

namespace ConsoleServerHost
{
    [ServiceContract]
    public interface IOperation
    {
        [OperationContract]
        void Add(Vehicle vehicle);

        [OperationContract]
        void Clear();

        [OperationContract]
        void Remove(Vehicle vehicle);

        [OperationContract]
        void Refresh(Vehicle vehicle);

        /// <summary>
        /// Name - is a vehicle that will be replaced
        /// Vehicle - vehicle is a vehicle on which vehicle will be replaced
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vehicle"></param>
        [OperationContract]
        void Replace(string name, Vehicle vehicle);

        [OperationContract]
        void AddMany(Vehicle[] vehicles);

        [OperationContract]
        List<Vehicle> Read();
    }
}