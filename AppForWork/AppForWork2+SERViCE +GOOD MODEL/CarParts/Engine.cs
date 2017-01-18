using System;
using System.Runtime.Serialization;

namespace CarParts 
{
    [DataContract]
    public class Engine: Part
    {
        private const string _name = nameof(Engine);

        public Engine():base(_name,100){ }
        public Engine(int state) : base(_name, state){ }
    }
}