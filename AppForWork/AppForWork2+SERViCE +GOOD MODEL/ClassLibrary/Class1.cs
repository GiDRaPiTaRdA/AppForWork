using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    [DataContract]
    public class Class1
    {
        [DataMember]
        int a { get; set; }
    }
}
