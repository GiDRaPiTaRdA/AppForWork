using System.Collections.ObjectModel;
using System.Linq;
using Cars.Vehicles;
using Cars.Vehicles.Parts;
using PropertyChanged;

namespace CarStationService
{
    [ImplementPropertyChanged]
    public class CarStation
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public string NameOfStation { get; private set; }

        public ObservableCollection<ExtendedVehicle> Vehicles { get; set; } = new ObservableCollection<ExtendedVehicle>();

        public CarStation(string name)
        {
            this.NameOfStation = name;
        }

        public void AddVehicle(ExtendedVehicle extendedVehicle)
        {
            this.Vehicles.Add(extendedVehicle);
        }

        public void RepairVehicle(ExtendedVehicle extendedVehicle)
        {
            if (extendedVehicle != null)
            {
                extendedVehicle.VehiclePartsList.ToList().ForEach(part=>part.State = Part.MaxStateValue);
                extendedVehicle.AddOnsCollection.ToList().ForEach(addOn=>addOn.NeedsRepare=false);
            }
        }

        public int RepairPrice(ExtendedVehicle extendedVehicle)
        {
            int sum = 0;
            if (extendedVehicle != null)
            {
                sum = extendedVehicle.VehiclePartsList.Sum(p => Part.MaxStateValue - p.State) *10;
                sum += extendedVehicle.AddOnsCollection.Where(addOn => addOn.NeedsRepare).Sum(a => a.Price);
            }
            return sum;
        }
    }
}