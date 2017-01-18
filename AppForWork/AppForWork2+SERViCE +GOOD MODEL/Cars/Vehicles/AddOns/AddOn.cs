using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;


namespace Cars.Vehicles.AddOns
{
    [DataContract]
    [ImplementPropertyChanged]
    public class AddOn
    {
        public AddOn()
        {
        }
        public AddOn(string name,int price)
        {
            this.Name = name;
            this.Price = price;
            this.NeedsRepare = false;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public  int Price { get; set; }
        [DataMember]
        public bool NeedsRepare { get; set; }
    }
}
