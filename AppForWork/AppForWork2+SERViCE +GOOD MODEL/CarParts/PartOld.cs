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
    public class PartOld
    {
        [DataMember]
        int _state;
        

        public PartOld()
        {
            this.Name = "";
            this.State = 100;
        }
        protected PartOld(string name, int state)
        {
            this.Name = name;
            this.State = state;
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public EPartTypes Type { get; set; }
        [DataMember]
        public int State
        {
            get { return this._state; }
            set
            {
                if (value > 100)
                    this._state = 100;
                else if(value<0)
                {
                    this._state = 0;
                }
                else
                {
                   this._state = value; 
                }
            }
        }
    }
}