using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Cars.Vehicles.AddOns;
using Cars.Vehicles.Parts;

namespace Cars.Vehicles
{
    [DataContract]
    public class Truck : Vehicle
    {
        public Truck()
            : base(EVehicleType.Truck){}

        public Truck(string name)
            : base(name, EVehicleType.Truck){}

        protected override IEnumerable<AddOn> InitAddOns()
        {
            return new ObservableCollection<AddOn>();
        }

        protected override IEnumerable<Part> InitAdditionalVehicleParts()
        {
            return new ObservableCollection<Part>()
            {
                new Part(EPartTypes.Hidraulics)
            };
        }
    }
}