using System;
using System.Runtime.Serialization;

namespace CarParts
{
    [DataContract]
    public class Rail: Part
    {
        private const string _name = nameof(Rail);

        public Rail():base(_name,100){ }
        public Rail(int state) : base(_name, state){ }
    }
}