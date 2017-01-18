using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Cars.Vehicles;
using CarStationService;

namespace AppForWork2.Model
{
    public class ApplicationModel : INotifyPropertyChanged
    {
        public CarStation CarStation { get; }

        private readonly ClientOperationManager clientOperationManager;

        #region Constants and Types
        const string stationName = "WOG"; //NAME OF STATION TO CREATE
        const string defaultVehiclesName = "Default Vehicle"; //NAME OF VEHICLE TO CREATE
        const EVehicleType defaultVehicleType = EVehicleType.Car; //DEFAULT VEHICLE TYPE
        private ExtendedVehicle selectedVehicle;
        #endregion

        #region Properties
        public string VehicleName
        {
            get
            {
                if (this.SelectedVehicle != null)
                {
                    return this.SelectedVehicle.Name;
                }
                else
                {
                    return defaultVehiclesName;
                }
            }
            set
            {
                if (this.SelectedVehicle != null)
                {
                    if (!this.SelectedVehicle.IsItemSaved)
                    {
                        this.SelectedVehicle.Name = value;
                    }
                    else
                    {
                        MessageBox.Show("Unable to change name of the saved vehicle", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        } // VEHICLE NAME

        public EVehicleType DefaultEVehicleType { get; set; } = defaultVehicleType; //DEFAULT VEHICLE TYPE

        public IEnumerable<EVehicleType> EVehicleTypes { get; } = Enum.GetValues(typeof(EVehicleType)).Cast<EVehicleType>(); //ENUM TYPES FOR COMBOBOX

        public ExtendedVehicle SelectedVehicle
        {
            get { return this.selectedVehicle; }
            set
            {
                if (this.selectedVehicle != null)
                {
                    (this.selectedVehicle as INotifyPropertyChanged).PropertyChanged -= this.SelectedVehicleChanged;
                }
                this.selectedVehicle = value;
                if (this.selectedVehicle != null)
                {
                    (this.selectedVehicle as INotifyPropertyChanged).PropertyChanged += this.SelectedVehicleChanged;
                }
            }
        } //Vehicle selected in vehicle list

        private void SelectedVehicleChanged(object sender, PropertyChangedEventArgs e) //Raises when something changed in selected vehicle 
        {
            this.OnPropertyChanged(nameof(this.AmountToPay));
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public int AmountToPay
        {
            get
            {
                int result = 0;
                if (this.SelectedVehicle != null)
                {
                    result = this.CarStation.RepairPrice(this.SelectedVehicle);
                }
                return result;
            }
        } //Ammount to pay
        #endregion

        #region Constructors
        public ApplicationModel()
        {
            this.CarStation = new CarStation(stationName);
            this.clientOperationManager = new ClientOperationManager();

            this.InnitListOfVehiclesFromDataBase();
        }
        #endregion

        #region Methods

        #region Functions
        private async Task<bool> CheckIfContainsSameName(Vehicle vehicle)
        {
            //var temp =  this.clientOperationManager.Read();
            //bool flag = false;

            //foreach (var v in temp)
            //{
            //    if (v.Name == vehicle.Name)
            //    {
            //        flag = true;
            //    }
            //}
            //return flag;

            var temp = await this.clientOperationManager.Read();
            bool flag = false;

            foreach (var v in temp)
            {
                if (v.Name == vehicle.Name)
                {
                    flag = true;
                }
            }
            return flag;
        } //check db for existanse of the same name in it
        #endregion

        #region Procedures
        private async void InnitListOfVehiclesFromDataBase()
        {
            this.CarStation.Vehicles.Clear();
            var vehiclesFromXml = await this.clientOperationManager.Read();
            if (vehiclesFromXml != null)
            {
                foreach (var current in vehiclesFromXml)
                {
                    ExtendedVehicle container = new ExtendedVehicle(current);
                    container.IsItemSaved = true;

                    Application.Current.Dispatcher.Invoke(() => { this.CarStation.AddVehicle(container); });
                }
            }
            MessageBox.Show("LOaded");
        } //innit from xml
        #endregion

        #region Buttons or Avaible Actions
        public void NewVehicle()
        {
            switch (this.DefaultEVehicleType)
            {
                case EVehicleType.Car:
                    this.CarStation.AddVehicle(new ExtendedVehicle(new Car(defaultVehiclesName)));
                    break;
                case EVehicleType.Bus:
                    this.CarStation.AddVehicle(new ExtendedVehicle(new Bus(defaultVehiclesName)));
                    break;
                case EVehicleType.Truck:
                    this.CarStation.AddVehicle(new ExtendedVehicle(new Truck(defaultVehiclesName)));
                    break;
                default:
                    throw new Exception("Not Implemented vehicle type");
            }
            this.SelectedVehicle = null;
        }

        public void Save()
        {
            this.Save(this.SelectedVehicle);
        }

        public void RemoveSelectedVehicle()
        {
            this.RemoveVehicle(this.SelectedVehicle);
        }

        public async void RepairVehicle(ExtendedVehicle extendedVehicle)
        {
            if (extendedVehicle != null)
            {
                this.CarStation.RepairVehicle(extendedVehicle);

                if (extendedVehicle.IsItemSaved)
                {
                    try
                    {
                        await this.clientOperationManager.Repare(VehiclesMapping.ToVehicle(extendedVehicle));
                        MessageBox.Show("Vehicle Repared successfuly", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (EndpointNotFoundException e)
                    {
                        Trace.WriteLine(e);
                        MessageBox.Show("Error: Connection lost", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e);
                        MessageBox.Show("Failed to repare vehicle, for extended info watch log", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        public async void RemoveAllVehicles()
        {
            try
            {
                await this.clientOperationManager.Clear();

                this.CarStation.Vehicles.Clear();

                MessageBox.Show("All cars have been removed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (EndpointNotFoundException e)
            {
                Trace.WriteLine(e);
                MessageBox.Show("Error: Connection lost", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                MessageBox.Show("Failed to clear vehicles, for extended info watch log", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void RemoveVehicle(ExtendedVehicle extendedVehicle)
        {
            try
            {
                if (extendedVehicle.IsItemSaved)
                {
                    await this.clientOperationManager.Remove(VehiclesMapping.ToVehicle(extendedVehicle));
                }
                this.CarStation.Vehicles.Remove(extendedVehicle);
                MessageBox.Show("Vehicle removed successfuly", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (EndpointNotFoundException e)
            {
                Trace.WriteLine(e);
                MessageBox.Show("Error: Connection lost", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                MessageBox.Show("Failed to remove vehicle, for extended info watch log", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Save(ExtendedVehicle extendedVehicle)
        {
            if (extendedVehicle != null)
            {
                if (!await this.CheckIfContainsSameName(extendedVehicle))
                {
                    try
                    {
                        await this.clientOperationManager.Save(VehiclesMapping.ToVehicle(extendedVehicle));
                        extendedVehicle.IsItemSaved = true;
                        MessageBox.Show("Vehicle saved successfuly", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    catch (EndpointNotFoundException e)
                    {
                        Trace.WriteLine(e);
                        MessageBox.Show("Error: Connection lost", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e);
                        MessageBox.Show("Failed to save vehicle, for extended info watch log", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Such vehicle already exists", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
        #endregion

        #endregion

        #region OnPropertyChanged Implemented
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}