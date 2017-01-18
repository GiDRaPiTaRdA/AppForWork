using System;
using System.Runtime.Serialization;

namespace CarParts
{
    [DataContract]
    public class Chassis: Part
    {
        private const string _name = nameof(Chassis);

        public Chassis():base(_name,100){ }
        public Chassis(int state) : base(_name, state){ }
    }
}