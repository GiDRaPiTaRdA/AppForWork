using System;
using System.Runtime.Serialization;

namespace CarParts
{
    [DataContract]
    public class Wheels: Part
    {
        private const string _name = nameof(Wheels);

        public Wheels():base(_name,100){ }
        public Wheels(int state) : base(_name, state){ }
    }
}