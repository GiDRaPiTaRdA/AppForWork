using System;
using System.Runtime.Serialization;

namespace CarParts
{
    [DataContract]
    public class Salon: Part
    {
        private const string _name = nameof(Salon);

        public Salon():base(_name,100){ }
        public Salon(int state) : base(_name, state){ }
    }
}