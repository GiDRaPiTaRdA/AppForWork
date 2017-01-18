using System;
using System.Runtime.Serialization;

namespace CarParts
{
    [DataContract]
    public class Hidraulics: Part
    {
        private const string _name = nameof(Hidraulics);

        public Hidraulics():base(_name,100){ }
        public Hidraulics(int state) : base(_name, state){ }
    }
}