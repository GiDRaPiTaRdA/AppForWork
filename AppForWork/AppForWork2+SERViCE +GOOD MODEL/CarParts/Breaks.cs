using System;
using System.Runtime.Serialization;

namespace CarParts
{
    [DataContract]
    public class Breaks:Part
    {
        private const string _name = nameof(Breaks);

        public Breaks(): base(_name, 100){ }
        public Breaks(int state): base(_name, state){ }
    }
}