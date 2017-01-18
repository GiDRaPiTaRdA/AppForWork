using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Cars.Vehicles.AddOns;
using Cars.Vehicles.Parts;

namespace Cars.Vehicles
{
    [DataContract]
    public class Bus : Vehicle
    {
        public Bus()
            : base(EVehicleType.Bus){}

        public Bus(string name)
            : base(name, EVehicleType.Bus){}

        protected override IEnumerable<Part> InitAdditionalVehicleParts()
        {
            return new ObservableCollection<Part>()
            {
                new Part(EPartTypes.Salon),
                new Part(EPartTypes.Rail)
            };
        }
        protected override IEnumerable<AddOn> InitAddOns()
        {
            var toReturn = new ObservableCollection<AddOn>
            {
                new AddOn("Update salon", 300),
                new AddOn("Total check",200)
            };
            return toReturn;
        }
    }
}