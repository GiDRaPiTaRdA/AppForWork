using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml.Schema;
using Cars.Vehicles;
using CarStationService;
using Prism.Commands;

using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using CarParts;

namespace AppForWork2.ViewModel
{
    [Export]
    public class MainWindowViewModel :Window ,INotifyPropertyChanged
    {
         CarStation CarStation { get; set; }

        #region Constants and Types
        const string stationName = "WOG";   //NAME OF STATION TO CREATE
        #endregion

        #region Properties
        public string VehicleName { get; set; } = "Default Vehicle";//DEFAULT VEHICLE NAME
        public EVehicleType VehicleType { get; set; } = EVehicleType.Car; //DEFAULT VEHICLE TYPE
        public EVehicleType[] EVehicleTypes { get; } = { EVehicleType.Car, EVehicleType.Bus, EVehicleType.Truck };//ENUM TYPES FOR COMBOBOX
        public Vehicle SelectedVehicle {
            get;
            set; } //Vehicle selected in vehicle list
        public int AmountToPay
        {
            get
            {
                int additionalOptionsSum = 0;
                if (BalancingButtonIsChecked&&SelectedVehicle?.Type==EVehicleType.Car)
                    additionalOptionsSum += 100;
                if (UpSalonButtonIsChecked && SelectedVehicle?.Type == EVehicleType.Bus)
                    additionalOptionsSum += 300;

                return CarStation.RepairPrice(SelectedVehicle)+additionalOptionsSum;
            }
        }//Ammount to pay

        #region Menu Addon Options
        public Visibility OptionsMenuVisibility
        {
            get
            {
                if (BalancingButtonVisibility == Visibility.Visible || UpSalonButtonVisibility == Visibility.Visible)
                    return Visibility.Visible;


                return Visibility.Collapsed;
            }
        }
        public Visibility BalancingButtonVisibility
        {
            get
            {
                if (SelectedVehicle?.Type == EVehicleType.Car)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
        public Visibility UpSalonButtonVisibility
        {
            get
            {
                if (SelectedVehicle?.Type == EVehicleType.Bus)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
        public bool BalancingButtonIsChecked { get; set; }
        public bool UpSalonButtonIsChecked { get; set; }
        #endregion

        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            CarStation = new CarStation(stationName);
            NewVehicleCommand = new DelegateCommand(NewVehicle);
            PartStateChangedCommand = new  DelegateCommand(AmountToPayReview);
            ConfirmChangesCommand =  new DelegateCommand(AmountToPayReview);
            RepareVehicleCommand = new DelegateCommand<Vehicle>(RepairVehicle);
        }
        #endregion

        #region IComand
        public DelegateCommand NewVehicleCommand { get; set; }
        public DelegateCommand PartStateChangedCommand { get; set; }
        public DelegateCommand ConfirmChangesCommand { get; set; }
        public DelegateCommand<Vehicle> RepareVehicleCommand { get; set; }
        #endregion

        #region Methods
        public void NewVehicle()
        {
            switch (VehicleType)
            {
                    case EVehicleType.Car:
                    CarStation.AddVehicle(new Car(VehicleName));
                    break;
                    case EVehicleType.Bus:
                    CarStation.AddVehicle(new Bus(VehicleName));
                    break;
                    case EVehicleType.Truck:
                    CarStation.AddVehicle(new Truck(VehicleName));
                    break;
                default:
                    throw new Exception("Not Implemented vehicle type");
            }
            SelectedVehicle = null;
        }
        private void RefreshSelectedVehicle()
        {
            Vehicle v = SelectedVehicle;
            SelectedVehicle = null;
            SelectedVehicle = v;
        } //GOVNOKOD

        private void UncheckMenuButtons()
        {
            if(SelectedVehicle!=null)
            switch (SelectedVehicle.Type)
            {
                case EVehicleType.Car:
                    BalancingButtonIsChecked = false;
                    break;
                case EVehicleType.Bus:
                    UpSalonButtonIsChecked = false;
                    break;
                case EVehicleType.Truck:
                    break;
                default:
                    BalancingButtonIsChecked = false;
                    UpSalonButtonIsChecked = false;
                    break;

            }
        }

        public void AmountToPayReview()
        {
            OnPropertyChanged(nameof(AmountToPay));
        }
        public void Save()
        {
            
        }//not implemented
        public void RepairVehicle(Vehicle vehicle)
        {
            CarStation.RepairVehicle(SelectedVehicle);

            UncheckMenuButtons();

            RefreshSelectedVehicle();
        }

        #endregion

        #region INotifyPropertyChanged Implemented
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}