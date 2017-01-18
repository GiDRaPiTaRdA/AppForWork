using System;
using System.Collections.Generic;
using Cars;
using Cars.Vehicles;
using Cars.Vehicles.AddOns;
using Cars.Vehicles.Parts;

namespace Cars.Vehicles
{
    [Serializable]
    public class ExtendedVehicle :Vehicle, ISavedItem
    {
        public ExtendedVehicle()
        {
        }
        public ExtendedVehicle(Vehicle vehicle)
        {
            this.Name = vehicle.Name;
            this.Type = vehicle.Type;

            this.AddOnsCollection = vehicle.AddOnsCollection;
            this.VehiclePartsList = vehicle.VehiclePartsList;
        }

        protected override IEnumerable<AddOn> InitAddOns()
        {
            return new List<AddOn>();
        }

        protected override IEnumerable<Part> InitAdditionalVehicleParts()
        {
            return new List<Part>();
        }

        public bool IsItemSaved { get; set; }
    }
}