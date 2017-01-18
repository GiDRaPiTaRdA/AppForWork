using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CarParts
{
    [DataContract]
    public class Body:Part
    {
        private const string _name = nameof(Body);

        public Body(): base(_name, 100){}
        public Body(int state): base(_name, state){}
    }
}