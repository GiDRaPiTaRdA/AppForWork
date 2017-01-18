using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Cars.Vehicles.AddOns;
using Cars.Vehicles.Parts;

namespace Cars.Vehicles
{
    [DataContract]
    public class Car : Vehicle
    {
        public Car()
            : base(EVehicleType.Car){}

        public Car(string name)
            : base(name, EVehicleType.Car){}

        protected override IEnumerable<AddOn> InitAddOns()
        {
            var toReturn = new ObservableCollection<AddOn>
            {
                new AddOn("Wheels", 100)
            };
            return toReturn;
        }

        protected override IEnumerable<Part> InitAdditionalVehicleParts()
        {
            return new ObservableCollection<Part>();
        }
    }
}