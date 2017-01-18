using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppForWork2.ServiceReference2;
using Cars.Vehicles;

namespace AppForWork2.Model
{
    public class ClientOperationManager
    {
        public async Task<Vehicle[]> Read()
        {
            using (var client = new OperationClient())
            {
                Vehicle[] a = await client.ReadAsync();
                return a;
            }
        }

        public async Task Save(Vehicle vehicle)
        {
            using (var client = new OperationClient())
            {
                await client.AddAsync(vehicle);
            }
        }

        public async Task Remove(Vehicle vehicle)
        {
            using (var client = new OperationClient())
            {
                await client.RemoveAsync(vehicle);
            }
        }

        public async Task Clear()
        {
            using (var client = new OperationClient())
            {
                await client.ClearAsync();
            }
        }

        public async Task Repare(Vehicle vehicle)
        {
            using (var client = new OperationClient())
            {
                await client.RefreshAsync(vehicle);
            }
        }

        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            using (var client = new OperationClient())
            {
                client.AddManyAsync(vehicles.ToArray());
            }
        }
    }
}