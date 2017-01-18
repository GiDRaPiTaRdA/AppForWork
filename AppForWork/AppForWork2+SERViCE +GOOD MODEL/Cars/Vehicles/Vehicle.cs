using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Cars.Vehicles.AddOns;
using Cars.Vehicles.Parts;

namespace Cars.Vehicles
{
    [DataContract]
    [XmlInclude(typeof(Part))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Truck))]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Bus))]
    [KnownType(typeof(Truck))]
    public  class Vehicle : INotifyPropertyChanged
    {
        private ObservableCollection<Part> vehiclePartsList;
        private ObservableCollection<AddOn> addOnsCollection;

        public Vehicle(){}//for Serializer

        public Vehicle(EVehicleType type) //ALL CHILD VEHICLES USE THIS CONSTRUCTOR AS DEFAULT
        {
            this.Type = type;

            //this.InternalInitParts();//!!!
        }

        public Vehicle(string name, EVehicleType type)
        {
            this.Name = name;
            this.Type = type;
            this.InternalInitParts();
            this.InternalInitAddOns();
        }


        #region properties
        [DataMember]
        public string Name { get; set; } = "Default";

        [DataMember]
        public EVehicleType Type { get; set; }

        #region AddOns
        [DataMember]
        public ObservableCollection<AddOn> AddOnsCollection
        {
            get
            {
                return this.addOnsCollection;
            }
            set
            {
                this.addOnsCollection = value;
                if (this.addOnsCollection != null)
                {
                    foreach (var addOn in this.addOnsCollection)
                    {
                        if ((addOn as INotifyPropertyChanged) != null)
                        {
                            (addOn as INotifyPropertyChanged).PropertyChanged += this.Vehicle_PropertyChanged;
                        }
                    }
                }
            }
        }

        protected virtual IEnumerable<AddOn> InitAddOns()
        {
            return new List<AddOn>();
        }

        private void InternalInitAddOns()
        {
            this.AddOnsCollection = new ObservableCollection<AddOn>(this.InitAddOns());
        }

        #endregion

        #region Parts
        [DataMember] //make it depend on state
        public ObservableCollection<Part> VehiclePartsList
        {
            get { return this.vehiclePartsList; }
            set
            {
                this.vehiclePartsList = value;
                if (this.vehiclePartsList != null)
                {
                    foreach (var part in this.vehiclePartsList)
                    {
                        if ((part as INotifyPropertyChanged) != null)
                        {
                            (part as INotifyPropertyChanged).PropertyChanged += this.Vehicle_PropertyChanged;
                        }
                    }
                }
            }
        } //VehiclePartsList

        protected virtual IEnumerable<Part> InitAdditionalVehicleParts()
        {
            return new List<Part>();
        }

        private void InternalInitParts()
        {
            this.VehiclePartsList = new ObservableCollection<Part>
                (
                new[]
                {
                    new Part(EPartTypes.Body),
                    new Part(EPartTypes.Breaks),
                    new Part(EPartTypes.Chassis),
                    new Part(EPartTypes.Engine),
                    new Part(EPartTypes.Wheels)
                }.Union(this.InitAdditionalVehicleParts()));
        }
        #endregion

        #endregion

        private void Vehicle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(nameof(this.VehiclePartsList));
            this.OnPropertyChanged(nameof(this.AddOnsCollection));
        }

        #region ProperyChangedImplemented
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        
    }
        
}