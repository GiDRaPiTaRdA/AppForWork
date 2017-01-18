using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using PropertyChanged;

namespace Cars.Vehicles.Parts
{
    [DataContract]
    [ImplementPropertyChanged]
    public class Part
    {
        public static int MaxStateValue { get; } = 100;

        [DataMember]
         private int _state;

        public Part(){}//for serializer
        public Part(EPartTypes type)
        {
            this.Type = type;
            this.State = MaxStateValue;
        }
        protected Part(int state,EPartTypes type)
        {
            this.Type = type;
            this.State = state;
        }

        [DataMember]
        public EPartTypes Type { get; set; }
        [DataMember]
        public int State
        {
            get { return this._state; }
            set
            {
                this._state = value <= MaxStateValue
                    ? value >= 0 ? value : 0
                    : MaxStateValue;
            }
        }
    }
}